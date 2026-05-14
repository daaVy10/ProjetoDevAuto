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
        private bool carregandoClientes = false;

        public Agenda()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            dgvAgendamentos.CellClick -= dgvAgendamentos_CellClick;
            dgvAgendamentos.CellClick += dgvAgendamentos_CellClick;

            cbClientes.SelectedIndexChanged -= cbClientes_SelectedIndexChanged;
            cbClientes.SelectedIndexChanged += cbClientes_SelectedIndexChanged;

            ConfigurarComboServico();

            dtpData.Format = DateTimePickerFormat.Short;
            mtxHora.Mask = "00:00";

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

            comboTipoServico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoServico.SelectedIndex = -1;
        }

        private void ConfigurarDgv()
        {
            dgvAgendamentos.AutoGenerateColumns = true;
            dgvAgendamentos.Enabled = true;
            dgvAgendamentos.ReadOnly = true;

            dgvAgendamentos.AllowUserToAddRows = false;
            dgvAgendamentos.AllowUserToDeleteRows = false;
            dgvAgendamentos.AllowUserToResizeRows = false;
            dgvAgendamentos.AllowUserToResizeColumns = false;

            dgvAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAgendamentos.MultiSelect = false;

            dgvAgendamentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvAgendamentos.EnableHeadersVisualStyles = false;
            dgvAgendamentos.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvAgendamentos.BorderStyle = BorderStyle.None;
            dgvAgendamentos.GridColor = Color.FromArgb(45, 45, 45);
            dgvAgendamentos.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;

            dgvAgendamentos.RowHeadersVisible = false;

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(45, 45, 45);

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Orange;

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.SelectionBackColor =
                Color.FromArgb(45, 45, 45);

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.SelectionForeColor =
                Color.Orange;

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvAgendamentos.DefaultCellStyle.BackColor =
                Color.FromArgb(38, 38, 38);

            dgvAgendamentos.DefaultCellStyle.ForeColor =
                Color.White;

            dgvAgendamentos.DefaultCellStyle.SelectionBackColor =
                Color.DarkOrange;

            dgvAgendamentos.DefaultCellStyle.SelectionForeColor =
                Color.Black;

            dgvAgendamentos.RowTemplate.Height = 35;
        }

        private void CarregarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    carregandoClientes = true;

                    conn.Open();

                    string sql = @"
                        SELECT 
                            id_cliente,
                            nome
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

        private void Carregar()
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
                            TIME_FORMAT(a.hora_agendamento, '%H:%i') AS Hora,
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

                    if (dgvAgendamentos.Columns.Contains("ID"))
                    {
                        dgvAgendamentos.Columns["ID"].Visible = false;
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

        private void CarregarPorCliente(int idCliente)
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
                            TIME_FORMAT(a.hora_agendamento, '%H:%i') AS Hora,
                            COALESCE(a.tipo_servico, '') AS Servico
                        FROM agenda a
                        INNER JOIN Clientes c 
                            ON c.id_cliente = a.id_cliente
                        WHERE a.id_cliente = @idCliente
                        ORDER BY a.id_servico DESC";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@idCliente", idCliente);

                    MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    da.Fill(dt);

                    dgvAgendamentos.DataSource = null;
                    dgvAgendamentos.DataSource = dt;

                    if (dgvAgendamentos.Columns.Contains("ID"))
                    {
                        dgvAgendamentos.Columns["ID"].Visible = false;
                    }

                    idServico = 0;
                    dgvAgendamentos.ClearSelection();
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
            {
                Carregar();
            }
            else
            {
                CarregarPorCliente(idCliente);
            }
        }

        private void btnServiço_Click(object sender, EventArgs e)
        {
            if (cbClientes.SelectedValue == null || cbClientes.SelectedValue is DataRowView)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            int idCliente = Convert.ToInt32(cbClientes.SelectedValue);

            if (idCliente == 0)
            {
                MessageBox.Show("Selecione um cliente válido. Não use 'Todos os clientes' para cadastrar serviço.");
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

                    cmd.Parameters.AddWithValue("@id_cliente", idCliente);
                    cmd.Parameters.AddWithValue("@data", dtpData.Value.Date);
                    cmd.Parameters.AddWithValue("@hora", mtxHora.Text);
                    cmd.Parameters.AddWithValue("@tipo_servico", tipoServico);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Agendamento salvo com sucesso!");

                    comboTipoServico.SelectedIndex = -1;
                    mtxHora.Clear();

                    CarregarPorCliente(idCliente);
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

                if (!dgvAgendamentos.Columns.Contains("ID"))
                    return;

                object valor = dgvAgendamentos.Rows[rowIndex].Cells["ID"].Value;

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

                if (!dgvAgendamentos.Columns.Contains("ID"))
                    return false;

                object valor = dgvAgendamentos.CurrentRow.Cells["ID"].Value;

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
            // Se tiver uma linha selecionada, abre orçamento daquele agendamento.
            if (SelecionarAgendamentoAtual())
            {
                Orçamentos orcamentosSelecionado = new Orçamentos(idServico);
                this.Hide();
                orcamentosSelecionado.Show();
                return;
            }

            // Se não tiver linha selecionada, abre a tela de orçamento normalmente.
            Orçamentos orcamentos = new Orçamentos(0);
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