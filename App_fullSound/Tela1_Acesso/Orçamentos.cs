using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace Tela1_Acesso
{
    public partial class Orçamentos : Form
    {
        private int _idServico = 0;

        private string conexao =
            "Server=localhost;Database=FullSound;Uid=root;Pwd=;";

        public Orçamentos(int idServico)
        {
            InitializeComponent();

            _idServico = idServico;

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds =
                Screen.FromHandle(this.Handle).WorkingArea;

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
            ConfigurarDgv();
            EstilizarDgv(dgvListadeServicos);
            CarregarComboClientes();
            CarregarDadosAgenda();
        }

        private void ConfigurarDgv()
        {
            dgvListadeServicos.Enabled = true;
            dgvListadeServicos.ReadOnly = true;
            dgvListadeServicos.AllowUserToAddRows = false;
            dgvListadeServicos.AllowUserToDeleteRows = false;

            dgvListadeServicos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvListadeServicos.MultiSelect = false;

            dgvListadeServicos.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvListadeServicos.AutoGenerateColumns = true;
        }

        private void EstilizarDgv(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;

            dgv.BackgroundColor =
                System.Drawing.Color.FromArgb(32, 32, 32);

            dgv.BorderStyle = BorderStyle.None;

            dgv.GridColor =
                System.Drawing.Color.FromArgb(45, 45, 45);

            dgv.RowHeadersVisible = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(45, 45, 45);

            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                System.Drawing.Color.Orange;

            dgv.ColumnHeadersDefaultCellStyle.Font =
                new System.Drawing.Font(
                    "Segoe UI",
                    9,
                    System.Drawing.FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor =
                System.Drawing.Color.FromArgb(38, 38, 38);

            dgv.DefaultCellStyle.ForeColor =
                System.Drawing.Color.White;

            // COR LARANJA AO SELECIONAR
            dgv.DefaultCellStyle.SelectionBackColor =
                System.Drawing.Color.DarkOrange;

            dgv.DefaultCellStyle.SelectionForeColor =
                System.Drawing.Color.Black;

            dgv.RowTemplate.Height = 35;
        }

        private void CarregarComboClientes()
        {
            using (MySqlConnection conn =
                new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            id_cliente,
                            nome
                        FROM clientes
                        ORDER BY nome";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    cbClientes.DataSource = null;

                    cbClientes.DataSource = dt;

                    cbClientes.DisplayMember = "nome";

                    cbClientes.ValueMember = "id_cliente";

                    cbClientes.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao carregar clientes: "
                        + ex.Message);
                }
            }
        }

        private void CarregarDadosAgenda()
        {
            using (MySqlConnection conn =
                new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            a.id_servico AS ID,
                            c.nome AS Cliente,
                            DATE_FORMAT(
                                a.data_agendamento,
                                '%d/%m/%Y %H:%i'
                            ) AS Data,
                            a.tipo_servico AS Servico,
                            a.valor AS Valor
                        FROM agenda a
                        INNER JOIN clientes c
                            ON c.id_cliente = a.id_cliente
                        ORDER BY a.id_servico DESC";

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(sql, conn);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvListadeServicos.Columns.Clear();

                    dgvListadeServicos.DataSource = null;

                    dgvListadeServicos.DataSource = dt;

                    if (dgvListadeServicos.Columns.Contains("ID"))
                    {
                        dgvListadeServicos.Columns["ID"].Visible = false;
                    }

                    _idServico = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao carregar dados: "
                        + ex.Message);
                }
            }
        }

        private void CarregarDadosPorCliente(int idCliente)
        {
            using (MySqlConnection conn =
                new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT
                            a.id_servico AS ID,
                            c.nome AS Cliente,
                            DATE_FORMAT(
                                a.data_agendamento,
                                '%d/%m/%Y %H:%i'
                            ) AS Data,
                            a.tipo_servico AS Servico,
                            a.valor AS Valor
                        FROM agenda a
                        INNER JOIN clientes c
                            ON c.id_cliente = a.id_cliente
                        WHERE a.id_cliente = @idCliente
                        ORDER BY a.id_servico DESC";

                    MySqlCommand cmd =
                        new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue(
                        "@idCliente",
                        idCliente);

                    MySqlDataAdapter da =
                        new MySqlDataAdapter(cmd);

                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvListadeServicos.Columns.Clear();

                    dgvListadeServicos.DataSource = null;

                    dgvListadeServicos.DataSource = dt;

                    if (dgvListadeServicos.Columns.Contains("ID"))
                    {
                        dgvListadeServicos.Columns["ID"].Visible = false;
                    }

                    _idServico = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao filtrar cliente: "
                        + ex.Message);
                }
            }
        }

        private void cbClientes_SelectedIndexChanged(
            object sender,
            EventArgs e)
        {
            if (cbClientes.SelectedValue == null ||
                cbClientes.SelectedValue is DataRowView)
                return;

            int idCliente =
                Convert.ToInt32(cbClientes.SelectedValue);

            CarregarDadosPorCliente(idCliente);
        }

        private void dgvListadeServicos_CellClick(
            object sender,
            DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                dgvListadeServicos.Rows[e.RowIndex].Selected = true;

                object valor =
                    dgvListadeServicos.Rows[e.RowIndex]
                    .Cells["ID"].Value;

                if (valor != null &&
                    valor != DBNull.Value)
                {
                    _idServico = Convert.ToInt32(valor);
                }
            }
            catch
            {
                _idServico = 0;
            }
        }

        private void btnAdicionar_Click(
            object sender,
            EventArgs e)
        {
            if (cbClientes.SelectedValue == null ||
                cbClientes.SelectedValue is DataRowView)
            {
                MessageBox.Show(
                    "Selecione um cliente.");
                return;
            }

            // PRECISA CLICAR NO SERVIÇO
            if (_idServico <= 0)
            {
                MessageBox.Show(
                    "Clique no serviço desejado na lista antes de adicionar o valor.");
                return;
            }

            if (txtValor.Text.Trim() == "")
            {
                MessageBox.Show(
                    "Digite um valor.");
                return;
            }

            string valorDigitado =
                txtValor.Text
                .Replace("R$", "")
                .Trim();

            decimal valor;

            if (!decimal.TryParse(
                valorDigitado,
                NumberStyles.Any,
                new CultureInfo("pt-BR"),
                out valor))
            {
                MessageBox.Show(
                    "Digite um valor válido.");
                return;
            }

            int idCliente =
                Convert.ToInt32(cbClientes.SelectedValue);

            using (MySqlConnection conn =
                new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        UPDATE agenda
                        SET valor = @valor
                        WHERE id_servico = @idServico
                        AND id_cliente = @idCliente";

                    MySqlCommand cmd =
                        new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue(
                        "@valor",
                        valor);

                    cmd.Parameters.AddWithValue(
                        "@idServico",
                        _idServico);

                    cmd.Parameters.AddWithValue(
                        "@idCliente",
                        idCliente);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show(
                        "Valor atualizado com sucesso!");

                    txtValor.Clear();

                    CarregarDadosPorCliente(idCliente);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao adicionar valor: "
                        + ex.Message);
                }
            }
        }

        private void btnEmitirComprovante_Click(
            object sender,
            EventArgs e)
        {
            if (dgvListadeServicos.CurrentRow == null)
            {
                MessageBox.Show(
                    "Selecione um serviço.");
                return;
            }

            try
            {
                string cliente =
                    dgvListadeServicos.CurrentRow
                    .Cells["Cliente"].Value.ToString();

                string data =
                    dgvListadeServicos.CurrentRow
                    .Cells["Data"].Value.ToString();

                string servico =
                    dgvListadeServicos.CurrentRow
                    .Cells["Servico"].Value.ToString();

                string valor =
                    dgvListadeServicos.CurrentRow
                    .Cells["Valor"].Value.ToString();

                string desktop =
                    Environment.GetFolderPath(
                        Environment.SpecialFolder.Desktop);

                string caminhoPdf =
                    Path.Combine(desktop, "comprovante.pdf");

                Document doc =
                    new Document(PageSize.A4, 40, 40, 40, 40);

                PdfWriter writer =
                    PdfWriter.GetInstance(
                        doc,
                        new FileStream(
                            caminhoPdf,
                            FileMode.Create));

                doc.Open();

                BaseColor preto =
                    new BaseColor(15, 15, 15);

                BaseColor laranja =
                    new BaseColor(255, 140, 0);

                BaseColor cinza =
                    new BaseColor(35, 35, 35);

                BaseColor branco =
                    BaseColor.WHITE;

                PdfContentByte canvas =
                    writer.DirectContentUnder;

                canvas.SetColorFill(preto);

                canvas.Rectangle(
                    0,
                    0,
                    doc.PageSize.Width,
                    doc.PageSize.Height);

                canvas.Fill();

                string caminhoLogo =
                    Path.Combine(
                        Application.StartupPath,
                        "logo.png");

                if (File.Exists(caminhoLogo))
                {
                    iTextSharp.text.Image logo =
                        iTextSharp.text.Image.GetInstance(
                            caminhoLogo);

                    logo.ScaleToFit(130f, 130f);

                    logo.SetAbsolutePosition(40, 715);

                    doc.Add(logo);
                }

                Paragraph titulo =
                    new Paragraph(
                        "COMPROVANTE DE ORÇAMENTO",
                        FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            22,
                            branco));

                titulo.Alignment =
                    Element.ALIGN_CENTER;

                titulo.SpacingBefore = 95;
                titulo.SpacingAfter = 35;

                doc.Add(titulo);

                PdfPTable tabela =
                    new PdfPTable(2);

                tabela.WidthPercentage = 100;

                tabela.SetWidths(
                    new float[] { 30, 70 });

                AdicionarLinhaEstilizada(
                    tabela,
                    "CLIENTE",
                    cliente,
                    laranja,
                    cinza,
                    branco);

                AdicionarLinhaEstilizada(
                    tabela,
                    "DATA E HORA",
                    data,
                    laranja,
                    cinza,
                    branco);

                AdicionarLinhaEstilizada(
                    tabela,
                    "SERVIÇO",
                    servico,
                    laranja,
                    cinza,
                    branco);

                AdicionarLinhaEstilizada(
                    tabela,
                    "VALOR",
                    "R$ " + valor,
                    laranja,
                    cinza,
                    branco);

                doc.Add(tabela);

                doc.Close();

                MessageBox.Show(
                    "Comprovante gerado com sucesso!");

                Process.Start(
                    new ProcessStartInfo()
                    {
                        FileName = caminhoPdf,
                        UseShellExecute = true
                    });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao gerar PDF: "
                    + ex.Message);
            }
        }

        private void AdicionarLinhaEstilizada(
            PdfPTable tabela,
            string campo,
            string valor,
            BaseColor corCampo,
            BaseColor corValor,
            BaseColor corTexto)
        {
            PdfPCell celulaCampo =
                new PdfPCell(
                    new Phrase(
                        campo,
                        FontFactory.GetFont(
                            FontFactory.HELVETICA_BOLD,
                            12,
                            corTexto)));

            celulaCampo.BackgroundColor = corCampo;
            celulaCampo.Padding = 10;

            PdfPCell celulaValor =
                new PdfPCell(
                    new Phrase(
                        valor,
                        FontFactory.GetFont(
                            FontFactory.HELVETICA,
                            12,
                            corTexto)));

            celulaValor.BackgroundColor = corValor;
            celulaValor.Padding = 10;

            tabela.AddCell(celulaCampo);
            tabela.AddCell(celulaValor);
        }

        private void pbAgenda_Click(
            object sender,
            EventArgs e)
        {
            Agenda agenda = new Agenda();

            agenda.Show();

            this.Hide();
        }

        private void pbClientes_Click(
            object sender,
            EventArgs e)
        {
            TelaCliente cliente =
                new TelaCliente();

            cliente.Show();

            this.Hide();
        }

        private void pbHome_Click(
            object sender,
            EventArgs e)
        {
            Home home = new Home();

            home.Show();

            this.Hide();
        }

        private void pictureBox1_Click(
            object sender,
            EventArgs e)
        {
            Application.Exit();
        }
    }
}