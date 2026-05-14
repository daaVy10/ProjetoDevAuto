using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;

using PdfDocument = iTextSharp.text.Document;
using PdfFont = iTextSharp.text.Font;
using PdfFontFactory = iTextSharp.text.FontFactory;
using PdfParagraph = iTextSharp.text.Paragraph;
using PdfPageSize = iTextSharp.text.PageSize;
using PdfElement = iTextSharp.text.Element;
using PdfWriter = iTextSharp.text.pdf.PdfWriter;
using PdfImage = iTextSharp.text.Image;
using PdfTable = iTextSharp.text.pdf.PdfPTable;
using PdfCell = iTextSharp.text.pdf.PdfPCell;
using PdfPhrase = iTextSharp.text.Phrase;
using PdfColor = iTextSharp.text.BaseColor;

namespace Tela1_Acesso
{
    public partial class Orçamentos : Form
    {
        private int _idServico = 0;
        private bool carregandoClientes = false;

        private string conexao =
            "Server=localhost;Database=FullSound;Uid=root;Pwd=;";

        private readonly PdfColor corPreta = new PdfColor(20, 20, 20);
        private readonly PdfColor corCinzaEscuro = new PdfColor(45, 45, 45);
        private readonly PdfColor corLaranja = new PdfColor(255, 140, 0);
        private readonly PdfColor corCinzaClaro = new PdfColor(245, 245, 245);

        public Orçamentos(int idServico)
        {
            InitializeComponent();

            _idServico = idServico;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            btnAdicionar.Click -= btnAdicionar_Click;
            btnAdicionar.Click += btnAdicionar_Click;

            btnEmitirComprovante.Click -= btnEmitirComprovante_Click;
            btnEmitirComprovante.Click += btnEmitirComprovante_Click;

            dgvListadeServicos.CellClick -= dgvListadeServicos_CellClick;
            dgvListadeServicos.CellClick += dgvListadeServicos_CellClick;

            cbClientes.SelectedIndexChanged -= cbClientes_SelectedIndexChanged;
            cbClientes.SelectedIndexChanged += cbClientes_SelectedIndexChanged;

            pbAgenda.Click -= pbAgenda_Click;
            pbAgenda.Click += pbAgenda_Click;

            pbClientes.Click -= pbClientes_Click;
            pbClientes.Click += pbClientes_Click;

            pbHome.Click -= pbHome_Click;
            pbHome.Click += pbHome_Click;

            pictureBox1.Click -= pictureBox1_Click;
            pictureBox1.Click += pictureBox1_Click;
        }

        private void Orçamentos_Load(object sender, EventArgs e)
        {
            ConfigurarDgvServicos();
            CarregarComboClientes();

            if (_idServico > 0)
                CarregarDadosAgendaComDestaque(_idServico);
            else
                CarregarDadosAgenda();
        }

        private void ConfigurarDgvServicos()
        {
            dgvListadeServicos.AutoGenerateColumns = true;
            dgvListadeServicos.Enabled = true;
            dgvListadeServicos.ReadOnly = true;
            dgvListadeServicos.AllowUserToAddRows = false;
            dgvListadeServicos.AllowUserToDeleteRows = false;
            dgvListadeServicos.AllowUserToResizeRows = false;
            dgvListadeServicos.AllowUserToResizeColumns = false;
            dgvListadeServicos.MultiSelect = false;
            dgvListadeServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListadeServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListadeServicos.RowHeadersVisible = false;
            dgvListadeServicos.EnableHeadersVisualStyles = false;
            dgvListadeServicos.BorderStyle = BorderStyle.None;
            dgvListadeServicos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvListadeServicos.BackgroundColor = System.Drawing.Color.FromArgb(32, 32, 32);
            dgvListadeServicos.GridColor = System.Drawing.Color.FromArgb(45, 45, 45);

            dgvListadeServicos.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(45, 45, 45);

            dgvListadeServicos.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.Orange;

            dgvListadeServicos.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.FromArgb(45, 45, 45);

            dgvListadeServicos.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.Orange;

            dgvListadeServicos.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font("Segoe UI", 9, System.Drawing.FontStyle.Bold);

            dgvListadeServicos.DefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(38, 38, 38);

            dgvListadeServicos.DefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            dgvListadeServicos.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.DarkOrange;

            dgvListadeServicos.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.Black;

            dgvListadeServicos.RowTemplate.Height = 35;
        }

        private void AjustarColunasDgv()
        {
            if (dgvListadeServicos.Columns.Contains("ID"))
                dgvListadeServicos.Columns["ID"].Visible = false;

            if (dgvListadeServicos.Columns.Contains("Cliente"))
                dgvListadeServicos.Columns["Cliente"].FillWeight = 28;

            if (dgvListadeServicos.Columns.Contains("Data"))
                dgvListadeServicos.Columns["Data"].FillWeight = 20;

            if (dgvListadeServicos.Columns.Contains("Servico"))
            {
                dgvListadeServicos.Columns["Servico"].HeaderText = "Serviço";
                dgvListadeServicos.Columns["Servico"].FillWeight = 32;
            }

            if (dgvListadeServicos.Columns.Contains("Valor"))
                dgvListadeServicos.Columns["Valor"].FillWeight = 15;
        }

        private void CarregarComboClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    carregandoClientes = true;
                    conn.Open();

                    string sql = @"
                        SELECT id_cliente, nome
                        FROM Clientes
                        ORDER BY nome";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    DataRow linhaTodos = dt.NewRow();
                    linhaTodos["id_cliente"] = 0;
                    linhaTodos["nome"] = "Todos os clientes";
                    dt.Rows.InsertAt(linhaTodos, 0);

                    cbClientes.DataSource = null;
                    cbClientes.DataSource = dt;
                    cbClientes.DisplayMember = "nome";
                    cbClientes.ValueMember = "id_cliente";
                    cbClientes.SelectedValue = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
                }
                finally
                {
                    carregandoClientes = false;
                }
            }
        }

        private void CarregarDadosAgenda()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            a.id_servico AS ID,
                            c.nome AS Cliente,
                            DATE_FORMAT(a.data_agendamento, '%d/%m/%Y') AS Data,
                            a.tipo_servico AS Servico,
                            FORMAT(COALESCE(a.valor, 0), 2, 'de_DE') AS Valor
                        FROM agenda a
                        INNER JOIN Clientes c ON c.id_cliente = a.id_cliente
                        ORDER BY a.id_servico DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvListadeServicos.Columns.Clear();
                    dgvListadeServicos.DataSource = null;
                    dgvListadeServicos.DataSource = dt;

                    ConfigurarDgvServicos();
                    AjustarColunasDgv();

                    _idServico = 0;
                    dgvListadeServicos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void CarregarDadosAgendaComDestaque(int idServicoDestaque)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            a.id_servico AS ID,
                            c.nome AS Cliente,
                            DATE_FORMAT(a.data_agendamento, '%d/%m/%Y') AS Data,
                            a.tipo_servico AS Servico,
                            FORMAT(COALESCE(a.valor, 0), 2, 'de_DE') AS Valor
                        FROM agenda a
                        INNER JOIN Clientes c ON c.id_cliente = a.id_cliente
                        ORDER BY
                            CASE 
                                WHEN a.id_servico = @idServicoDestaque THEN 0
                                ELSE 1
                            END,
                            a.id_servico DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idServicoDestaque", idServicoDestaque);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvListadeServicos.Columns.Clear();
                    dgvListadeServicos.DataSource = null;
                    dgvListadeServicos.DataSource = dt;

                    ConfigurarDgvServicos();
                    AjustarColunasDgv();

                    carregandoClientes = true;
                    cbClientes.SelectedValue = 0;
                    carregandoClientes = false;

                    _idServico = idServicoDestaque;

                    if (dgvListadeServicos.Rows.Count > 0)
                    {
                        dgvListadeServicos.ClearSelection();
                        dgvListadeServicos.Rows[0].Selected = true;
                        dgvListadeServicos.CurrentCell =
                            dgvListadeServicos.Rows[0].Cells["Cliente"];
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados: " + ex.Message);
                }
            }
        }

        private void CarregarDadosPorCliente(int idCliente)
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            a.id_servico AS ID,
                            c.nome AS Cliente,
                            DATE_FORMAT(a.data_agendamento, '%d/%m/%Y') AS Data,
                            a.tipo_servico AS Servico,
                            FORMAT(COALESCE(a.valor, 0), 2, 'de_DE') AS Valor
                        FROM agenda a
                        INNER JOIN Clientes c ON c.id_cliente = a.id_cliente
                        WHERE a.id_cliente = @idCliente
                        ORDER BY a.id_servico DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvListadeServicos.Columns.Clear();
                    dgvListadeServicos.DataSource = null;
                    dgvListadeServicos.DataSource = dt;

                    ConfigurarDgvServicos();
                    AjustarColunasDgv();

                    _idServico = 0;
                    dgvListadeServicos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao filtrar cliente: " + ex.Message);
                }
            }
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carregandoClientes)
                return;

            if (cbClientes.SelectedValue == null || cbClientes.SelectedValue is DataRowView)
                return;

            int idCliente = Convert.ToInt32(cbClientes.SelectedValue);

            if (idCliente == 0)
                CarregarDadosAgenda();
            else
                CarregarDadosPorCliente(idCliente);
        }

        private void dgvListadeServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                dgvListadeServicos.Rows[e.RowIndex].Selected = true;

                if (!dgvListadeServicos.Columns.Contains("ID"))
                    return;

                object valor = dgvListadeServicos.Rows[e.RowIndex].Cells["ID"].Value;

                if (valor != null && valor != DBNull.Value)
                    _idServico = Convert.ToInt32(valor);
            }
            catch
            {
                _idServico = 0;
            }
        }

        private void PegarIdServicoDaLinhaAtual()
        {
            try
            {
                if (dgvListadeServicos.CurrentRow == null)
                    return;

                if (!dgvListadeServicos.Columns.Contains("ID"))
                    return;

                object valor = dgvListadeServicos.CurrentRow.Cells["ID"].Value;

                if (valor == null || valor == DBNull.Value)
                    return;

                _idServico = Convert.ToInt32(valor);
            }
            catch
            {
                _idServico = 0;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (_idServico <= 0)
                PegarIdServicoDaLinhaAtual();

            if (_idServico <= 0)
            {
                MessageBox.Show("Selecione um serviço na lista para adicionar o valor.");
                return;
            }

            if (txtValor.Text.Trim() == "")
            {
                MessageBox.Show("O valor ainda não foi adicionado. Digite um valor.");
                return;
            }

            string valorDigitado = txtValor.Text.Replace("R$", "").Trim();

            if (!decimal.TryParse(
                valorDigitado,
                NumberStyles.Any,
                new CultureInfo("pt-BR"),
                out decimal valor))
            {
                MessageBox.Show("Digite um valor válido.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        UPDATE agenda
                        SET valor = @valor
                        WHERE id_servico = @idServico";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@valor", valor);
                    cmd.Parameters.AddWithValue("@idServico", _idServico);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Valor atualizado com sucesso!");

                    txtValor.Clear();

                    int idServicoAtual = _idServico;
                    CarregarDadosAgendaComDestaque(idServicoAtual);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar valor: " + ex.Message);
                }
            }
        }

        private void btnEmitirComprovante_Click(object sender, EventArgs e)
        {
            if (dgvListadeServicos.CurrentRow == null)
            {
                MessageBox.Show("Selecione um serviço.");
                return;
            }

            try
            {
                string cliente = dgvListadeServicos.CurrentRow.Cells["Cliente"].Value.ToString();
                string data = dgvListadeServicos.CurrentRow.Cells["Data"].Value.ToString();
                string servico = dgvListadeServicos.CurrentRow.Cells["Servico"].Value.ToString();
                string valor = dgvListadeServicos.CurrentRow.Cells["Valor"].Value.ToString();

                string downloads = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                    "Downloads"
                );

                if (!Directory.Exists(downloads))
                    Directory.CreateDirectory(downloads);

                string nomeArquivo = GerarNomeArquivoPdf(cliente);
                string caminhoPdf = Path.Combine(downloads, nomeArquivo);

                PdfDocument documento = new PdfDocument(PdfPageSize.A4, 60, 60, 40, 40);

                PdfWriter.GetInstance(
                    documento,
                    new FileStream(caminhoPdf, FileMode.Create)
                );

                documento.Open();

                PdfFont fonteTitulo = PdfFontFactory.GetFont(
                    PdfFontFactory.HELVETICA_BOLD,
                    20,
                    corPreta
                );

                PdfFont fonteLabel = PdfFontFactory.GetFont(
                    PdfFontFactory.HELVETICA_BOLD,
                    12,
                    corLaranja
                );

                PdfFont fonteTexto = PdfFontFactory.GetFont(
                    PdfFontFactory.HELVETICA,
                    12,
                    PdfColor.BLACK
                );

                PdfFont fonteRodape = PdfFontFactory.GetFont(
                    PdfFontFactory.HELVETICA,
                    10,
                    PdfColor.GRAY
                );

                AdicionarLogoPdf(documento);

                PdfParagraph titulo = new PdfParagraph("COMPROVANTE DE ORÇAMENTO", fonteTitulo);
                titulo.Alignment = PdfElement.ALIGN_CENTER;
                titulo.SpacingBefore = 8f;
                titulo.SpacingAfter = 12f;
                documento.Add(titulo);

                PdfTable linhaLaranja = new PdfTable(1);
                linhaLaranja.WidthPercentage = 100;
                PdfCell celulaLinha = new PdfCell(new PdfPhrase(" "));
                celulaLinha.BackgroundColor = corLaranja;
                celulaLinha.FixedHeight = 4f;
                celulaLinha.Border = 0;
                linhaLaranja.AddCell(celulaLinha);
                linhaLaranja.SpacingAfter = 24f;
                documento.Add(linhaLaranja);

                PdfTable tabela = new PdfTable(2);
                tabela.WidthPercentage = 100;
                tabela.SetWidths(new float[] { 30, 70 });
                tabela.SpacingAfter = 28f;

                AdicionarLinhaTabela(tabela, "CLIENTE", cliente, fonteLabel, fonteTexto);
                AdicionarLinhaTabela(tabela, "DATA", data, fonteLabel, fonteTexto);
                AdicionarLinhaTabela(tabela, "SERVIÇO", servico, fonteLabel, fonteTexto);
                AdicionarLinhaTabela(tabela, "VALOR", "R$ " + valor, fonteLabel, fonteTexto);

                documento.Add(tabela);

                PdfParagraph rodape = new PdfParagraph(
                    "Comprovante gerado em: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    fonteRodape
                );

                rodape.Alignment = PdfElement.ALIGN_LEFT;
                documento.Add(rodape);

                documento.Close();

                MessageBox.Show(
                    "Comprovante salvo em Downloads com sucesso!\n\n" + caminhoPdf
                );

                Process.Start(new ProcessStartInfo()
                {
                    FileName = caminhoPdf,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao emitir comprovante: " + ex.Message);
            }
        }

        private string GerarNomeArquivoPdf(string cliente)
        {
            string primeiroNome = "cliente";

            if (!string.IsNullOrWhiteSpace(cliente))
                primeiroNome = cliente.Trim().Split(' ')[0];

            foreach (char c in Path.GetInvalidFileNameChars())
                primeiroNome = primeiroNome.Replace(c.ToString(), "");

            string downloads = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
                "Downloads"
            );

            string nomeBase = "comprovante_" + primeiroNome;
            string nomeArquivo = nomeBase + ".pdf";
            string caminho = Path.Combine(downloads, nomeArquivo);

            int contador = 1;

            while (File.Exists(caminho))
            {
                nomeArquivo = nomeBase + "_" + contador + ".pdf";
                caminho = Path.Combine(downloads, nomeArquivo);
                contador++;
            }

            return nomeArquivo;
        }

        private void AdicionarLogoPdf(PdfDocument documento)
        {
            if (pictureBox4.Image == null)
                return;

            using (MemoryStream ms = new MemoryStream())
            {
                pictureBox4.Image.Save(ms, ImageFormat.Png);

                PdfImage logo = PdfImage.GetInstance(ms.ToArray());
                logo.ScaleToFit(140f, 85f);
                logo.Alignment = PdfElement.ALIGN_CENTER;
                logo.SpacingAfter = 6f;

                documento.Add(logo);
            }
        }

        private void AdicionarLinhaTabela(
            PdfTable tabela,
            string label,
            string texto,
            PdfFont fonteLabel,
            PdfFont fonteTexto)
        {
            PdfCell celulaLabel = new PdfCell(new PdfPhrase(label, fonteLabel));
            celulaLabel.BackgroundColor = corCinzaEscuro;
            celulaLabel.BorderColor = corPreta;
            celulaLabel.PaddingTop = 8;
            celulaLabel.PaddingBottom = 8;
            celulaLabel.PaddingLeft = 10;

            PdfCell celulaTexto = new PdfCell(new PdfPhrase(texto, fonteTexto));
            celulaTexto.BackgroundColor = corCinzaClaro;
            celulaTexto.BorderColor = corPreta;
            celulaTexto.PaddingTop = 8;
            celulaTexto.PaddingBottom = 8;
            celulaTexto.PaddingLeft = 10;

            tabela.AddCell(celulaLabel);
            tabela.AddCell(celulaTexto);
        }

        private void pbAgenda_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();
            agenda.Show();
            this.Hide();
        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            TelaCliente cliente = new TelaCliente();
            cliente.Show();
            this.Hide();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}