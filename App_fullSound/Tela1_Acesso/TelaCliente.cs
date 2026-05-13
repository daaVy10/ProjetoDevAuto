using FullSoundApp;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tela1_Acesso
{
    public partial class TelaCliente : Form
    {
        string conexao = "Server=localhost;Database=FullSound;Uid=root;Pwd=";
        public TelaCliente()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }

        private void TelaCliente_Load(object sender, EventArgs e)
        {

        }
        private void btnAdicionarCliente_Click(object sender, EventArgs e)
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
                tipoVeiculo = "Hatch";
            else if (rbSedan.Checked)
                tipoVeiculo = "Sedan";
            else if (rbSUV.Checked)
                tipoVeiculo = "SUV";
            else
            {
                MessageBox.Show("Selecione o tipo de veículo");
                return;
            }
            dgvClientes.Rows.Add(
                txtNome.Text,
                txtCelular.Text,
                tipoVeiculo
            );
            txtNome.Clear();
            txtCelular.Clear();
            rbHatch.Checked = false;
            rbSedan.Checked = false;
            rbSUV.Checked = false;

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
            Orçamentos orcamentos = new Orçamentos();
            this.Hide();
            orcamentos.Show();
        }
        private void TelaCliente_Load_1(object sender, EventArgs e)
        {
            dgvClientes.AutoGenerateColumns = false;
            dgvClientes.DefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.DefaultCellStyle.ForeColor = Color.Black;
            dgvClientes.Columns.Clear();
            dgvClientes.Columns.Add("colNome", "Nome");
            dgvClientes.Columns.Add("colCelular", "Celular");
            dgvClientes.Columns.Add("colTipo", "Tipo de Veículo");
            dgvClientes.AllowUserToAddRows = false;
            dgvClientes.ReadOnly = true;
            dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            CarregarClientes();
        }
        private void CarregarClientes()
        {
            dgvClientes.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = "SELECT nome, celular, tipo_veiculo FROM Clientes";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    dgvClientes.Rows.Add(
                        dr["nome"].ToString(),
                        dr["celular"].ToString(),
                        dr["tipo_veiculo"].ToString()
                    );
                }
            }
        }

        private void btnAdicionarCliente_Click_1(object sender, EventArgs e)
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
                conn.Open();

                string sql = @"INSERT INTO Clientes 
                       (nome, celular, tipo_veiculo)
                       VALUES (@nome, @celular, @tipo)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@nome", txtNome.Text);
                cmd.Parameters.AddWithValue("@celular", txtCelular.Text);
                cmd.Parameters.AddWithValue("@tipo", tipoVeiculo);
                cmd.ExecuteNonQuery();
            }
            MessageBox.Show("Cliente cadastrado com sucesso!");
            txtNome.Clear();
            txtCelular.Clear();
            rbHatch.Checked = false;
            rbSedan.Checked = false;
            rbSUV.Checked = false;
            CarregarClientes();

        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
    }
}
