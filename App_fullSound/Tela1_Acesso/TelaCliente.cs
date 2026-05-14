using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Data;
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
            ConfigurarDgvClientes();
            CarregarClientes();

            pnlAlterarCliente.Visible = false;
        }

        private void ConfigurarDgvClientes()
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.Columns.Clear();

            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.Name = "colIdCliente";
            colId.HeaderText = "ID";
            colId.Visible = false;
            dgvClientes.Columns.Add(colId);

            dgvClientes.Columns.Add("colNome", "Nome");
            dgvClientes.Columns.Add("colCelular", "Celular");
            dgvClientes.Columns.Add("colTipo", "Tipo de Veículo");

            dgvClientes.RowHeadersVisible = false;
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.AllowUserToDeleteRows = false;
            dgvClientes.AllowUserToResizeRows = false;
            dgvClientes.AllowUserToResizeColumns = false;

            dgvClientes.ReadOnly = true;
            dgvClientes.MultiSelect = false;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvClientes.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvClientes.BorderStyle = BorderStyle.None;

            dgvClientes.EnableHeadersVisualStyles = false;

            dgvClientes.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;

            // REMOVE O AZUL DO CABEÇALHO
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvClientes.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

            dgvClientes.DefaultCellStyle.BackColor = Color.White;
            dgvClientes.DefaultCellStyle.ForeColor = Color.Black;

            // COR DA LINHA SELECIONADA
            dgvClientes.DefaultCellStyle.SelectionBackColor = Color.DarkOrange;
            dgvClientes.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvClientes.GridColor = Color.Gray;
            dgvClientes.ClearSelection();
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

                txtNome.Text = dgvClientes.Rows[e.RowIndex].Cells["colNome"].Value.ToString();
                txtCelular.Text = dgvClientes.Rows[e.RowIndex].Cells["colCelular"].Value.ToString();

                string tipo = dgvClientes.Rows[e.RowIndex].Cells["colTipo"].Value.ToString();

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

        private void btnRemoverCliente_Click(object sender, EventArgs e)
        {
            if (idClienteSelecionado <= 0)
            {
                MessageBox.Show("Selecione um cliente na tabela.");
                return;
            }

            DialogResult resposta = MessageBox.Show(
                "Deseja remover este cliente?",
                "Confirmar remoção",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resposta != DialogResult.Yes)
                return;

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = "DELETE FROM Clientes WHERE id_cliente = @id_cliente";

                    MySqlCommand cmd = new MySqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@id_cliente", idClienteSelecionado);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Cliente removido com sucesso!");

                    LimparCampos();
                    CarregarClientes();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        "Erro ao remover cliente. Verifique se ele não possui agendamentos cadastrados.\n\n" +
                        ex.Message
                    );
                }
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

            txtAlterarNome.Text = dgvClientes.CurrentRow.Cells["colNome"].Value.ToString();
            txtAlterarCelular.Text = dgvClientes.CurrentRow.Cells["colCelular"].Value.ToString();

            string tipo = dgvClientes.CurrentRow.Cells["colTipo"].Value.ToString();

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