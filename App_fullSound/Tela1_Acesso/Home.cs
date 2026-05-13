using FullSoundApp;
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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.WindowState = FormWindowState.Maximized;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pbHome_Click(object sender, EventArgs e)
        {

        }

        private void pbClientes_Click(object sender, EventArgs e)
        {
            TelaCliente telaCliente = new TelaCliente();
            this.Hide();
            telaCliente.Show();
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
            orcamentos.Show();
            this.Hide();

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
