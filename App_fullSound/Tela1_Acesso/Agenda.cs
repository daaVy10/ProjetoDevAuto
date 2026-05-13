using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Tela1_Acesso;
using static Tela1_Acesso.Orçamentos;

namespace FullSoundApp
{



    public partial class Agenda : Form
    {
        string conexao = "Server=localhost;Database=FullSound;Uid=root;Pwd=;";

        public Agenda()
        {
            InitializeComponent();
            CarregarClientes();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            comboTipoServico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoServico.Items.AddRange(new object[]
            {
                "Instalação",
                "Manutenção",
                "Sonorização de evento",
                "Locação de equipamentos",
                "Orçamento rápido"
            });
            dtpData.Format = DateTimePickerFormat.Short;
            mtxHora.Mask = "00:00";
            dgvAgendamentos.AutoGenerateColumns = true;

            /*
            
            dgvAgendamentos.ReadOnly = true;
            dgvAgendamentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAgendamentos.MultiSelect = false;
             */
            dgvAgendamentos.DefaultCellStyle.ForeColor = Color.Black;
        }


        private void CarregarAgendamentos()
        {

            /*
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = @"SELECT c.nome, a.data, a.hora, a.tipo_servico
                       FROM agenda a
                       JOIN Clientes c ON c.id_cliente = a.id_cliente";

                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    agendamentos.Add(new Agendamento
                    {
                        Cliente = dr["nome"].ToString(),
                        Data = Convert.ToDateTime(dr["data"]),
                        Hora = dr["hora"].ToString(),
                        TipoServico = dr["tipo_servico"].ToString()
                    });
                }
            }

            dgvAgendamentos.DataSource = null;
            dgvAgendamentos.DataSource = agendamentos;*/
        }

        private void ConfigurarDgv()
        {
            dgvAgendamentos.EnableHeadersVisualStyles = false;
            dgvAgendamentos.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgvAgendamentos.BorderStyle = BorderStyle.None;
            dgvAgendamentos.CellBorderStyle = DataGridViewCellBorderStyle.None;
            dgvAgendamentos.GridColor = Color.FromArgb(45, 45, 45);

            dgvAgendamentos.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(45, 45, 45);
            dgvAgendamentos.ColumnHeadersDefaultCellStyle.ForeColor = Color.Orange;
            dgvAgendamentos.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 9, FontStyle.Bold);

            dgvAgendamentos.DefaultCellStyle.BackColor =
                Color.FromArgb(38, 38, 38);
            dgvAgendamentos.DefaultCellStyle.ForeColor = Color.White;
            dgvAgendamentos.DefaultCellStyle.SelectionBackColor =
                dgvAgendamentos.DefaultCellStyle.BackColor;
            dgvAgendamentos.DefaultCellStyle.SelectionForeColor =
                dgvAgendamentos.DefaultCellStyle.ForeColor;

            dgvAgendamentos.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;

            dgvAgendamentos.RowTemplate.Height = 44;
            dgvAgendamentos.ClearSelection();
        }
        private void CarregarClientes()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();
                string sql = "SELECT id_cliente, nome FROM Clientes ORDER BY nome";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cbClientes.DataSource = dt;

                cbClientes.DisplayMember = "nome";

            }
        }
        private void btnAdicionarServico_Click(object sender, EventArgs e)
        {

        }
        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            /*
            bool filtrarTipo = comboTipoServico.SelectedItem != null;
            bool filtrarHora = mtxHora.MaskCompleted;
            string? tipo = filtrarTipo ? comboTipoServico.Text : null;
            DateTime data = dtpData.Value.Date;
            string hora = mtxHora.Text;
            var resultado = agendamentos.Where(a =>
                a.Data.Date == data &&
                (!filtrarTipo || a.TipoServico == tipo) &&
                (!filtrarHora || a.Hora == hora)
            ).ToList();
            dgvAgendamentos.DataSource =
                resultado.Count == 0 ? agendamentos : resultado;*/
        }
        private void btnEmitirComprovante_Click(object sender, EventArgs e)
        {
        }
        private void btnServiço_Click(object sender, EventArgs e)
        {

            if (cbClientes.SelectedItem == null ||
                    comboTipoServico.SelectedItem == null ||
                    !mtxHora.MaskCompleted)
            {
                MessageBox.Show("Preencha todos os campos.");
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();


                string sql = @"INSERT INTO agenda 
    (id_cliente, data_agendamento, hora_agendamento, tipo_servico)
    VALUES (@id_cliente, @data, @hora, @tipo)";


                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@id_cliente",
                    ((DataRowView)cbClientes.SelectedItem)["id_cliente"]);

                cmd.Parameters.AddWithValue("@data", dtpData.Value.Date);
                cmd.Parameters.AddWithValue("@hora", mtxHora.Text);
                cmd.Parameters.AddWithValue("@tipo", comboTipoServico.Text);

                cmd.ExecuteNonQuery();
            }

            MessageBox.Show("Agendamento salvo com sucesso!");

            Carregar();

        }
        private void btnEmitirComprovante_Click_1(object sender, EventArgs e)
        {
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
        private void pbOrcamento_Click(object sender, EventArgs e)
        {
            Orçamentos orcamentos = new Orçamentos();
            this.Hide();
            orcamentos.Show();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void cbClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Carregar()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                try
                {
                    conn.Open();

                    string sql = "select * from agenda";

                    MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    dgvAgendamentos.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Agenda_Load(object sender, EventArgs e)
        {
            Carregar();
        }
        private int idServico;
        private void dgvAgendamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                idServico = Convert.ToInt32(
                    dgvAgendamentos.Rows[e.RowIndex].Cells["id_servico"].Value
                );
            }
        }
        private void btnOrcamento_Click(object sender, EventArgs e)
        {
            Orçamentos frm = new Orçamentos(idServico);
            frm.Show();
        }
    }
}