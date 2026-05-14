using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Tela1_Acesso
{
    public partial class TelaCliente : Form
    {
        string conexao = "Server=localhost;Database=FullSound;Uid=root;Pwd=;";
        private int idClienteSelecionado = 0;

        public TelaCliente()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;

            btnAdicionarClient.Click -= btnAdicionarCliente_Click;
            btnAdicionarClient.Click += btnAdicionarCliente_Click;

            btnAlterarCliente.Click -= btnAlterarCliente_Click;
            btnAlterarCliente.Click += btnAlterarCliente_Click;

            btnRemoverCliente.Click -= btnRemoverCliente_Click;
            btnRemoverCliente.Click += btnRemoverCliente_Click;

            btnSalvarAlteracao.Click -= btnSalvarAlteracao_Click;
            btnSalvarAlteracao.Click += btnSalvarAlteracao_Click;

            btnCancelarAlteracao.Click -= btnCancelarAlteracao_Click;
            btnCancelarAlteracao.Click += btnCancelarAlteracao_Click;

            dgvClientes.CellClick -= dgvClientes_CellClick;
            dgvClientes.CellClick += dgvClientes_CellClick;
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {
            InicializarTela();
        }

        private void TelaCliente_Load_1(object sender, EventArgs e)
        {
            InicializarTela();
        }

        private void InicializarTela()
        {
            ConfigurarDgvClientes();
            CarregarClientes();
            pnlAlterarCliente.Visible = false;
        }

        private void ConfigurarDgvClientes()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            dgvClientes.Columns.Add("colId", "ID");
            dgvClientes.Columns["colId"].Visible = false;

            dgvClientes.Columns.Add("colNome", "Nome");
            dgvClientes.Columns.Add("colCelular", "Celular");
            dgvClientes.Columns.Add("colTipo", "Tipo de Veículo");

            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.MultiSelect = false;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.DefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private void CarregarClientes()
        {
            dgvClientes.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        SELECT id_cliente, nome, celular, tipo_veiculo
                        FROM Clientes
                        ORDER BY nome";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    MySqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        dgvClientes.Rows.Add(
                            dr["id_cliente"].ToString(),
                            dr["nome"].ToString(),
                            dr["celular"].ToString(),
                            dr["tipo_veiculo"].ToString()
                        );
                    }

                    idClienteSelecionado = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
                }
            }
        }

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                dgvClientes.Rows[e.RowIndex].Selected = true;

                idClienteSelecionado = Convert.ToInt32(
                    dgvClientes.Rows[e.RowIndex].Cells["colId"].Value);
            }
            catch
            {
                idClienteSelecionado = 0;
            }
        }

        private void btnAdicionarCliente_Click(object sender, EventArgs e)
        {
            AdicionarCliente();
        }

        private void btnAdicionarCliente_Click_1(object sender, EventArgs e)
        {
            AdicionarCliente();
        }

        private void AdicionarCliente()
        {
            if (txtNome.Text.Trim() == "")
            {
                MessageBox.Show("Digite o nome do cliente");
                return;
            }

            if (txtCelular.Text.Trim() == "")
            {
                MessageBox.Show("Digite o celular do cliente");
                return;
            }

            string tipoVeiculo = "";

            if (rbHatch.Checked)
                tipoVeiculo = "HATCH";
            else if (rbSedan.Checked)
                tipoVeiculo = "SEDAN";
            else if (rbSUV.Checked)
                tipoVeiculo = "SUV";
            else
            {
                MessageBox.Show("Selecione o tipo de veículo");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        INSERT INTO Clientes 
                        (nome, celular, tipo_veiculo)
                        VALUES 
                        (@nome, @celular, @tipo)";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", txtNome.Text.Trim());
                    cmd.Parameters.AddWithValue("@celular", txtCelular.Text.Trim());
                    cmd.Parameters.AddWithValue("@tipo", tipoVeiculo);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente cadastrado com sucesso!");

                    LimparCampos();
                    CarregarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao adicionar cliente: " + ex.Message);
                }
            }
        }

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na tabela.");
                return;
            }

            try
            {
                idClienteSelecionado = Convert.ToInt32(
                    dgvClientes.CurrentRow.Cells["colId"].Value);

                txtAlterarNome.Text =
                    dgvClientes.CurrentRow.Cells["colNome"].Value.ToString();

                txtAlterarCelular.Text =
                    dgvClientes.CurrentRow.Cells["colCelular"].Value.ToString();

                string tipo =
                    dgvClientes.CurrentRow.Cells["colTipo"].Value.ToString().ToUpper();

                rbAlterarHatch.Checked = tipo == "HATCH";
                rbAlterarSedan.Checked = tipo == "SEDAN";
                rbAlterarSuv.Checked = tipo == "SUV";

                pnlAlterarCliente.Visible = true;
                pnlAlterarCliente.BringToFront();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao abrir alteração: " + ex.Message);
            }
        }

        private void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado <= 0)
            {
                MessageBox.Show("Selecione um cliente na tabela e clique em Alterar Dados.");
                return;
            }

            string novoNome = txtAlterarNome.Text.Trim();
            string novoCelular = txtAlterarCelular.Text.Trim();
            string novoTipo = "";

            if (rbAlterarHatch.Checked)
                novoTipo = "HATCH";
            else if (rbAlterarSedan.Checked)
                novoTipo = "SEDAN";
            else if (rbAlterarSuv.Checked)
                novoTipo = "SUV";

            if (novoNome == "" || novoCelular == "" || novoTipo == "")
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        UPDATE Clientes
                        SET nome = @nome,
                            celular = @celular,
                            tipo_veiculo = @tipo
                        WHERE id_cliente = @id";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@nome", novoNome);
                    cmd.Parameters.AddWithValue("@celular", novoCelular);
                    cmd.Parameters.AddWithValue("@tipo", novoTipo);
                    cmd.Parameters.AddWithValue("@id", idClienteSelecionado);

                    int linhas = cmd.ExecuteNonQuery();

                    if (linhas > 0)
                    {
                        MessageBox.Show("Cliente alterado com sucesso!");

                        pnlAlterarCliente.Visible = false;
                        LimparCamposAlteracao();
                        CarregarClientes();
                    }
                    else
                    {
                        MessageBox.Show("Nenhum cliente foi alterado.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar alteração: " + ex.Message);
                }
            }
        }

        private void btnCancelarAlteracao_Click(object sender, EventArgs e)
        {
            pnlAlterarCliente.Visible = false;
            LimparCamposAlteracao();
        }

        private void btnRemoverCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            try
            {
                int idCliente = Convert.ToInt32(
                    dgvClientes.CurrentRow.Cells["colId"].Value);

                DialogResult resposta = MessageBox.Show(
                    "Deseja remover o cliente e todos os agendamentos dele?",
                    "Confirmação",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (resposta != DialogResult.Yes)
                    return;

                using (MySqlConnection conn = new MySqlConnection(conexao))
                {
                    conn.Open();

                    string sqlAgenda =
                        "DELETE FROM agenda WHERE id_cliente = @id";

                    MySqlCommand cmdAgenda =
                        new MySqlCommand(sqlAgenda, conn);

                    cmdAgenda.Parameters.AddWithValue("@id", idCliente);
                    cmdAgenda.ExecuteNonQuery();

                    string sqlCliente =
                        "DELETE FROM Clientes WHERE id_cliente = @id";

                    MySqlCommand cmdCliente =
                        new MySqlCommand(sqlCliente, conn);

                    cmdCliente.Parameters.AddWithValue("@id", idCliente);
                    cmdCliente.ExecuteNonQuery();

                    MessageBox.Show("Cliente removido com sucesso!");

                    pnlAlterarCliente.Visible = false;
                    LimparCamposAlteracao();
                    CarregarClientes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover cliente: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCelular.Clear();

            rbHatch.Checked = false;
            rbSedan.Checked = false;
            rbSUV.Checked = false;

            txtNome.Focus();
        }

        private void LimparCamposAlteracao()
        {
            txtAlterarNome.Clear();
            txtAlterarCelular.Clear();

            rbAlterarHatch.Checked = false;
            rbAlterarSedan.Checked = false;
            rbAlterarSuv.Checked = false;

            idClienteSelecionado = 0;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            this.Hide();
            home.Show();
        }

        private void pbAgenda_Click(object sender, EventArgs e)
        {
            Agenda agenda = new Agenda();
            this.Hide();
            agenda.Show();
        }

        private void pbOrcamento_Click(object sender, EventArgs e)
        {
            Orçamentos orcamentos = new Orçamentos(0);
            this.Hide();
            orcamentos.Show();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}