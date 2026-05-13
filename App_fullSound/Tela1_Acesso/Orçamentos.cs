using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Tela1_Acesso
{
    public partial class Orçamentos : Form
    {
        private int _idServico;
        private string conexao = "Server=localhost;Database=FullSound;Uid=root;Pwd=;";

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

            dgvListadeServicos.CellClick -= dgvListadeServicos_CellClick;
            dgvListadeServicos.CellClick += dgvListadeServicos_CellClick;

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
            CarregarDadosAgenda();
        }

        private void ConfigurarDgv()
        {
            dgvListadeServicos.Enabled = true;
            dgvListadeServicos.ReadOnly = true;
            dgvListadeServicos.AllowUserToAddRows = false;
            dgvListadeServicos.AllowUserToDeleteRows = false;
            dgvListadeServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvListadeServicos.MultiSelect = false;
            dgvListadeServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvListadeServicos.AutoGenerateColumns = true;
        }

        private void EstilizarDgv(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgv.BorderStyle = BorderStyle.None;
            dgv.GridColor = Color.FromArgb(45, 45, 45);
            dgv.RowHeadersVisible = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
            dgv.DefaultCellStyle.ForeColor = Color.White;
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 55, 55);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;

            dgv.RowTemplate.Height = 35;
        }

        private void CarregarDadosAgenda()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql;

                    if (_idServico > 0)
                    {
                        sql = @"
                            SELECT
                                a.id_servico AS ID,
                                c.nome AS Cliente,
                                DATE_FORMAT(a.data_agendamento, '%d/%m/%Y') AS Data,
                                a.tipo_servico AS Servico,
                                a.valor AS Valor
                            FROM agenda a
                            INNER JOIN Clientes c 
                                ON c.id_cliente = a.id_cliente
                            WHERE a.id_servico = @idServico";
                    }
                    else
                    {
                        sql = @"
                            SELECT
                                a.id_servico AS ID,
                                c.nome AS Cliente,
                                DATE_FORMAT(a.data_agendamento, '%d/%m/%Y') AS Data,
                                a.tipo_servico AS Servico,
                                a.valor AS Valor
                            FROM agenda a
                            INNER JOIN Clientes c 
                                ON c.id_cliente = a.id_cliente
                            ORDER BY a.id_servico DESC";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    if (_idServico > 0)
                    {
                        cmd.Parameters.AddWithValue("@idServico", _idServico);
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvListadeServicos.Columns.Clear();
                    dgvListadeServicos.DataSource = null;
                    dgvListadeServicos.DataSource = dt;

                    if (dgvListadeServicos.Columns.Contains("ID"))
                    {
                        dgvListadeServicos.Columns["ID"].Visible = false;
                    }

                    CarregarComboClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar dados do orçamento: " + ex.Message);
                }
            }
        }

        private void CarregarComboClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql;

                    if (_idServico > 0)
                    {
                        sql = @"
                            SELECT 
                                c.id_cliente,
                                c.nome
                            FROM agenda a
                            INNER JOIN Clientes c 
                                ON c.id_cliente = a.id_cliente
                            WHERE a.id_servico = @idServico";
                    }
                    else
                    {
                        sql = @"
                            SELECT 
                                id_cliente,
                                nome
                            FROM Clientes
                            ORDER BY nome";
                    }

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    if (_idServico > 0)
                    {
                        cmd.Parameters.AddWithValue("@idServico", _idServico);
                    }

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cbClientes.DataSource = null;
                    cbClientes.DataSource = dt;
                    cbClientes.DisplayMember = "nome";
                    cbClientes.ValueMember = "id_cliente";

                    if (dt.Rows.Count > 0)
                        cbClientes.SelectedIndex = 0;
                    else
                        cbClientes.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar cliente: " + ex.Message);
                }
            }
        }

        private void dgvListadeServicos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                if (dgvListadeServicos.Columns.Contains("ID"))
                {
                    object valor = dgvListadeServicos.Rows[e.RowIndex].Cells["ID"].Value;

                    if (valor != null && valor != DBNull.Value)
                    {
                        _idServico = Convert.ToInt32(valor);
                    }
                }
            }
            catch
            {
                _idServico = 0;
            }
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (_idServico <= 0)
            {
                MessageBox.Show("Selecione um serviço na lista ou abra o orçamento pela tela Agenda.");
                return;
            }

            if (txtValor.Text.Trim() == "")
            {
                MessageBox.Show("Digite o valor do orçamento.");
                return;
            }

            string valorDigitado = txtValor.Text.Replace("R$", "").Trim();

            decimal valor;

            if (!decimal.TryParse(valorDigitado, NumberStyles.Any, new CultureInfo("pt-BR"), out valor))
            {
                MessageBox.Show("Digite um valor válido. Exemplo: 250,00");
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

                    MessageBox.Show("Valor adicionado com sucesso!");

                    txtValor.Clear();

                    CarregarDadosAgenda();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar valor: " + ex.Message);
                }
            }
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