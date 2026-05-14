namespace FullSoundApp
{
    partial class Agenda
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Agenda));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            lblData = new Label();
            lblHora = new Label();
            dtpData = new DateTimePicker();
            mtxHora = new MaskedTextBox();
            panelFiltro = new Panel();
            lblTipoServico = new Label();
            comboTipoServico = new ComboBox();
            toolTip1 = new ToolTip(components);
            lbAgenda = new Label();
            pbAgenda = new PictureBox();
            pbHome = new PictureBox();
            label9 = new Label();
            panel1 = new Panel();
            label3 = new Label();
            pictureBox1 = new PictureBox();
            btnSair = new Button();
            LbOrçamentos = new Label();
            lbClientes = new Label();
            pbOrcamento = new PictureBox();
            pbClientes = new PictureBox();
            pictureBox4 = new PictureBox();
            lbClientes2 = new Label();
            pictureBox2 = new PictureBox();
            btnServiço = new Button();
            cbClientes = new ComboBox();
            label1 = new Label();
            dgvAgendamentos = new DataGridView();
            panelFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbAgenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbOrcamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvAgendamentos).BeginInit();
            SuspendLayout();
            // 
            // lblData
            // 
            lblData.AutoSize = true;
            lblData.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblData.ForeColor = Color.White;
            lblData.Location = new Point(418, 138);
            lblData.Name = "lblData";
            lblData.Size = new Size(33, 15);
            lblData.TabIndex = 5;
            lblData.Text = "Data";
            // 
            // lblHora
            // 
            lblHora.AutoSize = true;
            lblHora.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHora.ForeColor = Color.White;
            lblHora.Location = new Point(417, 240);
            lblHora.Name = "lblHora";
            lblHora.Size = new Size(34, 15);
            lblHora.TabIndex = 7;
            lblHora.Text = "Hora";
            // 
            // dtpData
            // 
            dtpData.CalendarForeColor = Color.Black;
            dtpData.CalendarMonthBackground = Color.White;
            dtpData.Font = new Font("Segoe UI", 9F);
            dtpData.Location = new Point(420, 156);
            dtpData.Name = "dtpData";
            dtpData.Size = new Size(326, 23);
            dtpData.TabIndex = 6;
            // 
            // mtxHora
            // 
            mtxHora.AsciiOnly = true;
            mtxHora.BackColor = Color.White;
            mtxHora.BorderStyle = BorderStyle.FixedSingle;
            mtxHora.Font = new Font("Segoe UI", 9F);
            mtxHora.ForeColor = Color.Black;
            mtxHora.Location = new Point(420, 258);
            mtxHora.Mask = "00:00";
            mtxHora.Name = "mtxHora";
            mtxHora.Size = new Size(67, 23);
            mtxHora.TabIndex = 8;
            mtxHora.TextAlign = HorizontalAlignment.Center;
            // 
            // panelFiltro
            // 
            panelFiltro.BackColor = Color.FromArgb(240, 240, 240);
            panelFiltro.BorderStyle = BorderStyle.FixedSingle;
            panelFiltro.Controls.Add(lblTipoServico);
            panelFiltro.Controls.Add(comboTipoServico);
            panelFiltro.Location = new Point(773, 148);
            panelFiltro.Name = "panelFiltro";
            panelFiltro.Padding = new Padding(16);
            panelFiltro.Size = new Size(424, 106);
            panelFiltro.TabIndex = 11;
            // 
            // lblTipoServico
            // 
            lblTipoServico.AutoSize = true;
            lblTipoServico.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTipoServico.ForeColor = Color.Black;
            lblTipoServico.Location = new Point(22, 18);
            lblTipoServico.Name = "lblTipoServico";
            lblTipoServico.Size = new Size(94, 15);
            lblTipoServico.TabIndex = 0;
            lblTipoServico.Text = "Tipo de serviço:";
            // 
            // comboTipoServico
            // 
            comboTipoServico.BackColor = Color.White;
            comboTipoServico.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoServico.Font = new Font("Segoe UI", 9F);
            comboTipoServico.ForeColor = Color.Black;
            comboTipoServico.IntegralHeight = false;
            comboTipoServico.ItemHeight = 15;
            comboTipoServico.Location = new Point(25, 42);
            comboTipoServico.MaxDropDownItems = 6;
            comboTipoServico.Name = "comboTipoServico";
            comboTipoServico.Size = new Size(220, 23);
            comboTipoServico.TabIndex = 1;
            // 
            // lbAgenda
            // 
            lbAgenda.AutoSize = true;
            lbAgenda.BackColor = Color.Black;
            lbAgenda.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAgenda.ForeColor = Color.DarkOrange;
            lbAgenda.Location = new Point(84, 346);
            lbAgenda.Name = "lbAgenda";
            lbAgenda.Size = new Size(67, 21);
            lbAgenda.TabIndex = 103;
            lbAgenda.Text = "Agenda";
            // 
            // pbAgenda
            // 
            pbAgenda.ErrorImage = null;
            pbAgenda.Image = (Image)resources.GetObject("pbAgenda.Image");
            pbAgenda.Location = new Point(24, 322);
            pbAgenda.Name = "pbAgenda";
            pbAgenda.Size = new Size(63, 65);
            pbAgenda.SizeMode = PictureBoxSizeMode.Zoom;
            pbAgenda.TabIndex = 106;
            pbAgenda.TabStop = false;
            // 
            // pbHome
            // 
            pbHome.Cursor = Cursors.Hand;
            pbHome.Image = (Image)resources.GetObject("pbHome.Image");
            pbHome.Location = new Point(24, 174);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(63, 56);
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.TabIndex = 99;
            pbHome.TabStop = false;
            pbHome.Click += pbHome_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.SeaShell;
            label9.Location = new Point(84, 201);
            label9.Name = "label9";
            label9.Size = new Size(55, 21);
            label9.TabIndex = 86;
            label9.Text = "Home";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(lbAgenda);
            panel1.Controls.Add(pbHome);
            panel1.Controls.Add(btnSair);
            panel1.Controls.Add(pbAgenda);
            panel1.Controls.Add(LbOrçamentos);
            panel1.Controls.Add(lbClientes);
            panel1.Controls.Add(pbOrcamento);
            panel1.Controls.Add(pbClientes);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(pictureBox4);
            panel1.Location = new Point(1, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 622);
            panel1.TabIndex = 107;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 11F);
            label3.ForeColor = SystemColors.ButtonFace;
            label3.Location = new Point(97, 550);
            label3.Name = "label3";
            label3.Size = new Size(34, 20);
            label3.TabIndex = 98;
            label3.Text = "Sair";
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(16, 527);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(115, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 97;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnSair
            // 
            btnSair.BackColor = Color.OrangeRed;
            btnSair.ForeColor = SystemColors.Control;
            btnSair.Location = new Point(2347, 603);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(75, 23);
            btnSair.TabIndex = 94;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = false;
            // 
            // LbOrçamentos
            // 
            LbOrçamentos.AutoSize = true;
            LbOrçamentos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbOrçamentos.ForeColor = SystemColors.ButtonFace;
            LbOrçamentos.Location = new Point(84, 438);
            LbOrçamentos.Name = "LbOrçamentos";
            LbOrçamentos.Size = new Size(92, 21);
            LbOrçamentos.TabIndex = 85;
            LbOrçamentos.Text = "Orçamento";
            // 
            // lbClientes
            // 
            lbClientes.AutoSize = true;
            lbClientes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClientes.ForeColor = Color.AliceBlue;
            lbClientes.Location = new Point(84, 271);
            lbClientes.Name = "lbClientes";
            lbClientes.Size = new Size(61, 21);
            lbClientes.TabIndex = 87;
            lbClientes.Text = "Cliente";
            // 
            // pbOrcamento
            // 
            pbOrcamento.Cursor = Cursors.Hand;
            pbOrcamento.ErrorImage = null;
            pbOrcamento.Image = (Image)resources.GetObject("pbOrcamento.Image");
            pbOrcamento.Location = new Point(24, 414);
            pbOrcamento.Name = "pbOrcamento";
            pbOrcamento.Size = new Size(63, 57);
            pbOrcamento.SizeMode = PictureBoxSizeMode.Zoom;
            pbOrcamento.TabIndex = 89;
            pbOrcamento.TabStop = false;
            pbOrcamento.Click += pbOrcamento_Click;
            // 
            // pbClientes
            // 
            pbClientes.Cursor = Cursors.Hand;
            pbClientes.ErrorImage = null;
            pbClientes.Image = (Image)resources.GetObject("pbClientes.Image");
            pbClientes.Location = new Point(24, 253);
            pbClientes.Name = "pbClientes";
            pbClientes.Size = new Size(63, 46);
            pbClientes.SizeMode = PictureBoxSizeMode.Zoom;
            pbClientes.TabIndex = 90;
            pbClientes.TabStop = false;
            pbClientes.Click += pbClientes_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(-4, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(264, 228);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 107;
            pictureBox4.TabStop = false;
            // 
            // lbClientes2
            // 
            lbClientes2.AutoSize = true;
            lbClientes2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClientes2.ForeColor = Color.White;
            lbClientes2.Location = new Point(492, 46);
            lbClientes2.Name = "lbClientes2";
            lbClientes2.Size = new Size(254, 30);
            lbClientes2.TabIndex = 108;
            lbClientes2.Text = "Agendamento de serviço";
            // 
            // pictureBox2
            // 
            pictureBox2.ErrorImage = null;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(431, 32);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(55, 55);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 109;
            pictureBox2.TabStop = false;
            // 
            // btnServiço
            // 
            btnServiço.BackColor = Color.DarkOrange;
            btnServiço.FlatStyle = FlatStyle.Flat;
            btnServiço.ForeColor = Color.Black;
            btnServiço.Location = new Point(624, 207);
            btnServiço.Name = "btnServiço";
            btnServiço.Size = new Size(122, 23);
            btnServiço.TabIndex = 110;
            btnServiço.Text = "Adicionar Serviço";
            btnServiço.UseVisualStyleBackColor = false;
            btnServiço.Click += btnServiço_Click;
            // 
            // cbClientes
            // 
            cbClientes.FormattingEnabled = true;
            cbClientes.Location = new Point(420, 207);
            cbClientes.Name = "cbClientes";
            cbClientes.Size = new Size(121, 23);
            cbClientes.TabIndex = 14;
            cbClientes.SelectedIndexChanged += cbClientes_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.White;
            label1.Location = new Point(418, 191);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 111;
            label1.Text = "Cliente";
            // 
            // dgvAgendamentos
            // 
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Control;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvAgendamentos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvAgendamentos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvAgendamentos.DefaultCellStyle = dataGridViewCellStyle2;
            dgvAgendamentos.Location = new Point(420, 303);
            dgvAgendamentos.Name = "dgvAgendamentos";
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvAgendamentos.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvAgendamentos.Size = new Size(777, 289);
            dgvAgendamentos.TabIndex = 13;
            // 
            // Agenda
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.Black;
            ClientSize = new Size(1419, 624);
            Controls.Add(dgvAgendamentos);
            Controls.Add(label1);
            Controls.Add(btnServiço);
            Controls.Add(cbClientes);
            Controls.Add(pictureBox2);
            Controls.Add(lbClientes2);
            Controls.Add(panel1);
            Controls.Add(lblData);
            Controls.Add(dtpData);
            Controls.Add(lblHora);
            Controls.Add(mtxHora);
            Controls.Add(panelFiltro);
            Font = new Font("Segoe UI", 9F);
            ForeColor = Color.White;
            MinimumSize = new Size(880, 480);
            Name = "Agenda";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Full Sound - Agenda";
            Load += Agenda_Load;
            panelFiltro.ResumeLayout(false);
            panelFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbAgenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbOrcamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvAgendamentos).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblData;
        private System.Windows.Forms.Label lblHora;
        private System.Windows.Forms.DateTimePicker dtpData;
        private System.Windows.Forms.MaskedTextBox mtxHora;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.Label lblTipoServico;
        private System.Windows.Forms.ComboBox comboTipoServico;
        private System.Windows.Forms.ToolTip toolTip1;
        private Label lbAgenda;
        private PictureBox pbAgenda;
        private PictureBox pbHome;
        private Label label9;
        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox1;
        private Button btnSair;
        private Label LbOrçamentos;
        private Label lbClientes;
        private PictureBox pbOrcamento;
        private PictureBox pbClientes;
        private Label lbClientes2;
        private PictureBox pictureBox2;
        private Button btnServiço;
        private PictureBox pictureBox4;
        private ComboBox cbClientes;
        private Label label1;
        private DataGridView dgvAgendamentos;
    }
}
