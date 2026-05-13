using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Tela1_Acesso
{
    public partial class Orçamentos : Form
    {
        private int _idServico;
        private string conexao =
            "Server=localhost;Database=FullSound;Uid=root;Pwd=;";
        public Orçamentos(int idServico)
        {
            InitializeComponent();
            _idServico = idServico;
        }

        private void Orçamentos_Load(object sender, EventArgs e)
        {
            EstilizarDgv(dgvListadeServicos);
            CarregarDadosAgenda();
        }
        private void CarregarDadosAgenda()
        {
            using (MySqlConnection conn = new MySqlConnection(conexao))
            {
                conn.Open();

                string sql = @"
                    SELECT
                        c.id_cliente,
                        c.nome AS Cliente,
                        a.data_agendamento AS Data,
                        a.tipo_servico AS Servico,
                        a.valor AS Valor,
                        'Pendente' AS Status
                    FROM agenda a
                    INNER JOIN clientes c 
                        ON c.id_cliente = a.id_cliente
                    WHERE a.id_servico = @idServico";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@idServico", _idServico);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvListadeServicos.DataSource = dt;
                cbClientes.DataSource = dt;
                cbClientes.DisplayMember = "Cliente";
                cbClientes.ValueMember = "id_cliente";
            }
        }
        private void EstilizarDgv(DataGridView dgv)
        {
            dgv.EnableHeadersVisualStyles = false;
            dgv.BackgroundColor = Color.FromArgb(32, 32, 32);
            dgv.BorderStyle = BorderStyle.None;

            dgv.ColumnHeadersDefaultCellStyle.BackColor =
                Color.FromArgb(45, 45, 45);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.Orange;

            dgv.DefaultCellStyle.BackColor =
                Color.FromArgb(38, 38, 38);
            dgv.DefaultCellStyle.ForeColor =
                Color.White;

            dgv.ReadOnly = true;
            dgv.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }
    }
}