using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Tela1_Acesso;

namespace FullSoundApp
{
    public partial class Agenda : Form
    {
        string conexao = "Server=localhost;Database=FullSound;Uid=root;Pwd=;";

        private int idServico = 0;

        public Agenda()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            dgvAgendamentos.CellClick -= dgvAgendamentos_CellClick;
            dgvAgendamentos.CellClick += dgvAgendamentos_CellClick;

            ConfigurarComboServico();

            dtpData.Format = DateTimePickerFormat.Short;
            mtxHora.Mask = "00:00";

            dgvAgendamentos.AutoGenerateColumns = true;
            dgvAgendamentos.ReadOnly = true;
            dgvAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAgendamentos.MultiSelect = false;

            ConfigurarDgv();
            CarregarClientes();
        }

        private void Agenda_Load(object sender, EventArgs e)
        {
            Carregar();
        }

        private void ConfigurarComboServico()
        {
            comboTipoServico.Items.Clear();

            comboTipoServico.Items.Add("Instalação");
            comboTipoServico.Items.Add("Manutenção");
            comboTipoServico.Items.Add("Sonorização de evento");
            comboTipoServico.Items.Add("Locação de equipamentos");
            comboTipoServico.Items.Add("Orçamento rápido");

            comboTipoServico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoServico.SelectedIndex = -1;
        }

        private void ConfigurarDgv()
        {
            dgvAgendamentos.EnableHeadersVisualStyles = false;
            dgvAgendamentos.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvAgendamentos.BorderStyle = BorderStyle.None;
            dgvAgendamentos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAgendamentos.GridColor = Color.FromArgb(45, 45, 45);

            dgvAgendamentos.RowHeadersVisible = false;
            dgvAgendamentos.AllowUserToAddRows = false;
            dgvAgendamentos.AllowUserToResizeRows = false;

            dgvAgendamentos.DefaultCellStyle.BackColor = Color.FromArgb(38, 38, 38);
            dgvAgendamentos.DefaultCellStyle.ForeColor = Color.White;
            dgvAgendamentos.DefaultCellStyle.SelectionBackColor = Color.FromArgb(55, 55, 55);
            dgvAgendamentos.DefaultCellStyle.SelectionForeColor = Color.White;

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 45, 45);
            dgvAgendamentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dgvAgendamentos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvAgendamentos.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAgendamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAgendamentos.RowTemplate.Height = 40;
        }

        private void CarregarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = "SELECT id_cliente, nome FROM Clientes ORDER BY nome";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
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
                    MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
                }
            }
        }

        private void Carregar()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT 
                            a.id_servico,
                            c.nome AS Cliente,
                            DATE_FORMAT(a.data_agendamento, '%d/%m/%Y') AS Data,
                            a.hora_agendamento AS Hora,
                            COALESCE(a.tipo_servico, '') AS Servico
                        FROM agenda a
                        INNER JOIN Clientes c 
                            ON c.id_cliente = a.id_cliente
                        ORDER BY a.id_servico DESC";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvAgendamentos.DataSource = null;
                    dgvAgendamentos.DataSource = dt;

                    if (dgvAgendamentos.Columns.Contains("id_servico"))
                    {
                        dgvAgendamentos.Columns["id_servico"].HeaderText = "ID";
                    }

                    idServico = 0;
                    dgvAgendamentos.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar agendamentos: " + ex.Message);
                }
            }
        }

        private void btnServiço_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedIndex == -1 || cbClientes.SelectedValue == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            if (comboTipoServico.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione o tipo de serviço.");
                return;
            }

            if (!mtxHora.MaskCompleted)
            {
                MessageBox.Show("Informe a hora.");
                return;
            }

            string tipoServico = comboTipoServico.SelectedItem.ToString();

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        INSERT INTO agenda
                        (
                            id_cliente,
                            data_agendamento,
                            hora_agendamento,
                            tipo_servico
                        )
                        VALUES
                        (
                            @id_cliente,
                            @data,
                            @hora,
                            @tipo_servico
                        )";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@id_cliente", cbClientes.SelectedValue);
                    cmd.Parameters.AddWithValue("@data", dtpData.Value.Date);
                    cmd.Parameters.AddWithValue("@hora", mtxHora.Text);
                    cmd.Parameters.AddWithValue("@tipo_servico", tipoServico);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Agendamento salvo com sucesso!");

                    Carregar();

                    cbClientes.SelectedIndex = -1;
                    comboTipoServico.SelectedIndex = -1;
                    mtxHora.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar agendamento: " + ex.Message);
                }
            }
        }

        private void dgvAgendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            PegarIdServicoDaLinha(e.RowIndex);
        }

        private void PegarIdServicoDaLinha(int rowIndex)
        {
            try
            {
                if (rowIndex < 0)
                    return;

                if (!dgvAgendamentos.Columns.Contains("id_servico"))
                    return;

                object valor = dgvAgendamentos.Rows[rowIndex].Cells["id_servico"].Value;

                if (valor == null || valor == DBNull.Value)
                    return;

                idServico = Convert.ToInt32(valor);
            }
            catch
            {
                idServico = 0;
            }
        }

        private bool SelecionarAgendamentoAtual()
        {
            try
            {
                if (dgvAgendamentos.CurrentRow == null)
                    return false;

                if (!dgvAgendamentos.Columns.Contains("id_servico"))
                    return false;

                object valor = dgvAgendamentos.CurrentRow.Cells["id_servico"].Value;

                if (valor == null || valor == DBNull.Value)
                    return false;

                idServico = Convert.ToInt32(valor);

                return idServico > 0;
            }
            catch
            {
                idServico = 0;
                return false;
            }
        }

        private void AbrirTelaOrcamento()
        {
            if (!SelecionarAgendamentoAtual())
            {
                MessageBox.Show("Clique em um agendamento da tabela antes de abrir o orçamento.");
                return;
            }

            Orçamentos orcamentos = new Orçamentos(idServico);
            this.Hide();
            orcamentos.Show();
        }

        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            AbrirTelaOrcamento();
        }

        private void pbOrcamento_Click(object sender, EventArgs e)
        {
            AbrirTelaOrcamento();
        }

        private void pbHome_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            TelaCliente cliente = new TelaCliente();
            this.Hide();
            cliente.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdicionarServico_Click(object sender, EventArgs e)
        {

        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {

        }

        private void btnEmitirComprovante_Click(object sender, EventArgs e)
        {

        }

        private void btnEmitirComprovante_Click_1(object sender, EventArgs e)
        {

        }
    }
}