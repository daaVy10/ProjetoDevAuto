using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Data;
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

            btnRemoverCliente.Click -= btnRemoverCliente_Click;
            btnRemoverCliente.Click += btnRemoverCliente_Click;

            btnAlterarCliente.Click -= btnAlterarCliente_Click;
            btnAlterarCliente.Click += btnAlterarCliente_Click;

            btnSalvarAlteracao.Click -= btnSalvarAlteracao_Click;
            btnSalvarAlteracao.Click += btnSalvarAlteracao_Click;

            btnCancelarAlteracao.Click -= btnCancelarAlteracao_Click;
            btnCancelarAlteracao.Click += btnCancelarAlteracao_Click;

            dgvClientes.CellClick -= dgvClientes_CellClick;
            dgvClientes.CellClick += dgvClientes_CellClick;
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {

        }

        private void TelaCliente_Load_1(object sender, EventArgs e)
        {
            PrepararDgvClientes();
            CarregarClientes();

            pnlAlterarCliente.Visible = false;
        }

        private void PrepararDgvClientes()
        {
            dgvClientes.AutoGenerateColumns = false;

            if (!dgvClientes.Columns.Contains("colIdCliente"))
            {
                DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
                colId.Name = "colIdCliente";
                colId.HeaderText = "ID";
                colId.Visible = false;

                dgvClientes.Columns.Insert(0, colId);
            }

            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
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
                        SELECT 
                            id_cliente,
                            nome,
                            celular,
                            tipo_veiculo
                        FROM Clientes
                        ORDER BY id_cliente ASC";

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

                    dgvClientes.ClearSelection();
                    idClienteSelecionado = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar clientes: " + ex.Message);
                }
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
                MessageBox.Show("Digite o nome do cliente.");
                return;
            }

            if (txtCelular.Text.Trim() == "")
            {
                MessageBox.Show("Digite o celular do cliente.");
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
                MessageBox.Show("Selecione o tipo de veículo.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        INSERT INTO Clientes
                        (
                            nome,
                            celular,
                            tipo_veiculo
                        )
                        VALUES
                        (
                            @nome,
                            @celular,
                            @tipo
                        )";

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

        private void dgvClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            try
            {
                object valorId = dgvClientes.Rows[e.RowIndex].Cells["colIdCliente"].Value;

                if (valorId == null || valorId == DBNull.Value)
                    return;

                idClienteSelecionado = Convert.ToInt32(valorId);

                txtNome.Text = dgvClientes.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCelular.Text = dgvClientes.Rows[e.RowIndex].Cells[2].Value.ToString();

                string tipo = dgvClientes.Rows[e.RowIndex].Cells[3].Value.ToString();

                rbHatch.Checked = tipo == "HATCH";
                rbSedan.Checked = tipo == "SEDAN";
                rbSUV.Checked = tipo == "SUV";
            }
            catch
            {
                idClienteSelecionado = 0;
            }
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private int ContarAgendamentosDoCliente()
        {
            int total = 0;

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = @"
                    SELECT COUNT(*)
                    FROM agenda
                    WHERE id_cliente = @id_cliente";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@id_cliente", idClienteSelecionado);

                total = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return total;
        }

        private void ExcluirClienteEAgendamentos()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                MySqlTransaction transacao = conn.BeginTransaction();

                try
                {
                    string sqlAgenda = @"
                        DELETE FROM agenda
                        WHERE id_cliente = @id_cliente";

                    MySqlCommand cmdAgenda = new MySqlCommand(sqlAgenda, conn, transacao);
                    cmdAgenda.Parameters.AddWithValue("@id_cliente", idClienteSelecionado);
                    cmdAgenda.ExecuteNonQuery();

                    string sqlCliente = @"
                        DELETE FROM Clientes
                        WHERE id_cliente = @id_cliente";

                    MySqlCommand cmdCliente = new MySqlCommand(sqlCliente, conn, transacao);
                    cmdCliente.Parameters.AddWithValue("@id_cliente", idClienteSelecionado);
                    cmdCliente.ExecuteNonQuery();

                    transacao.Commit();
                }
                catch
                {
                    transacao.Rollback();
                    throw;
                }
            }
        }

        private void btnRemoverCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado <= 0)
            {
                MessageBox.Show("Selecione um cliente na tabela.");
                return;
            }

            string nomeCliente = "selecionado";

            if (dgvClientes.CurrentRow != null)
            {
                nomeCliente = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            }

            int totalAgendamentos;

            try
            {
                totalAgendamentos = ContarAgendamentosDoCliente();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar agendamentos do cliente: " + ex.Message);
                return;
            }

            DialogResult resposta;

            if (totalAgendamentos > 0)
            {
                resposta = MessageBox.Show(
                    "O cliente \"" + nomeCliente + "\" possui " + totalAgendamentos +
                    " agendamento(s) e serviço(s) cadastrados.\n\n" +
                    "Se você excluir este cliente, todos os agendamentos e serviços ligados a ele também serão excluídos.\n\n" +
                    "Deseja realmente excluir?",
                    "Cliente possui agendamentos",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                resposta = MessageBox.Show(
                    "Deseja realmente remover o cliente \"" + nomeCliente + "\"?",
                    "Confirmar remoção",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );
            }

            if (resposta != DialogResult.Yes)
                return;

            try
            {
                ExcluirClienteEAgendamentos();

                MessageBox.Show("Cliente removido com sucesso!");

                LimparCampos();
                CarregarClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao remover cliente: " + ex.Message);
            }
        }

        private void btnAlterarCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado <= 0)
            {
                MessageBox.Show("Selecione um cliente na tabela.");
                return;
            }

            if (dgvClientes.CurrentRow == null)
            {
                MessageBox.Show("Selecione um cliente na tabela.");
                return;
            }

            txtAlterarNome.Text = dgvClientes.CurrentRow.Cells[1].Value.ToString();
            txtAlterarCelular.Text = dgvClientes.CurrentRow.Cells[2].Value.ToString();

            string tipo = dgvClientes.CurrentRow.Cells[3].Value.ToString();

            rbAlterarHatch.Checked = tipo == "HATCH";
            rbAlterarSedan.Checked = tipo == "SEDAN";
            rbAlterarSuv.Checked = tipo == "SUV";

            pnlAlterarCliente.Visible = true;
            pnlAlterarCliente.BringToFront();
        }

        private void btnSalvarAlteracao_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado <= 0)
            {
                MessageBox.Show("Selecione um cliente.");
                return;
            }

            if (txtAlterarNome.Text.Trim() == "")
            {
                MessageBox.Show("Digite o nome do cliente.");
                return;
            }

            if (txtAlterarCelular.Text.Trim() == "")
            {
                MessageBox.Show("Digite o celular do cliente.");
                return;
            }

            string tipoVeiculo = "";

            if (rbAlterarHatch.Checked)
                tipoVeiculo = "HATCH";
            else if (rbAlterarSedan.Checked)
                tipoVeiculo = "SEDAN";
            else if (rbAlterarSuv.Checked)
                tipoVeiculo = "SUV";
            else
            {
                MessageBox.Show("Selecione o tipo de veículo.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = @"
                        UPDATE Clientes
                        SET
                            nome = @nome,
                            celular = @celular,
                            tipo_veiculo = @tipo
                        WHERE id_cliente = @id_cliente";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@nome", txtAlterarNome.Text.Trim());
                    cmd.Parameters.AddWithValue("@celular", txtAlterarCelular.Text.Trim());
                    cmd.Parameters.AddWithValue("@tipo", tipoVeiculo);
                    cmd.Parameters.AddWithValue("@id_cliente", idClienteSelecionado);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente alterado com sucesso!");

                    pnlAlterarCliente.Visible = false;

                    LimparCampos();
                    CarregarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao alterar cliente: " + ex.Message);
                }
            }
        }

        private void btnCancelarAlteracao_Click(object sender, EventArgs e)
        {
            pnlAlterarCliente.Visible = false;

            txtAlterarNome.Clear();
            txtAlterarCelular.Clear();

            rbAlterarHatch.Checked = false;
            rbAlterarSedan.Checked = false;
            rbAlterarSuv.Checked = false;
        }

        private void LimparCampos()
        {
            txtNome.Clear();
            txtCelular.Clear();

            rbHatch.Checked = false;
            rbSedan.Checked = false;
            rbSUV.Checked = false;

            idClienteSelecionado = 0;

            dgvClientes.ClearSelection();

            txtNome.Focus();
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
    }
}