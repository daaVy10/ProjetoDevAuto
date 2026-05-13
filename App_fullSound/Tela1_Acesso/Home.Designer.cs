namespace Tela1_Acesso
{
    partial class Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            pictureBox10 = new PictureBox();
            pbAgenda = new PictureBox();
            pbClientes = new PictureBox();
            pbOrcamento = new PictureBox();
            lbAgenda = new Label();
            lbClientes = new Label();
            lbHome = new Label();
            LbOrçamentos = new Label();
            panel1 = new Panel();
            label4 = new Label();
            label1 = new Label();
            pbHome = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnSair = new Button();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox10).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAgenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbOrcamento).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbHome).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox10
            // 
            pictureBox10.BackgroundImage = (Image)resources.GetObject("pictureBox10.BackgroundImage");
            pictureBox10.Image = (Image)resources.GetObject("pictureBox10.Image");
            pictureBox10.Location = new Point(470, 213);
            pictureBox10.Name = "pictureBox10";
            pictureBox10.Size = new Size(0, 0);
            pictureBox10.TabIndex = 84;
            pictureBox10.TabStop = false;
            // 
            // pbAgenda
            // 
            pbAgenda.ErrorImage = null;
            pbAgenda.Image = (Image)resources.GetObject("pbAgenda.Image");
            pbAgenda.Location = new Point(22, 329);
            pbAgenda.Name = "pbAgenda";
            pbAgenda.Size = new Size(72, 66);
            pbAgenda.SizeMode = PictureBoxSizeMode.Zoom;
            pbAgenda.TabIndex = 91;
            pbAgenda.TabStop = false;
            pbAgenda.Click += pbAgenda_Click;
            // 
            // pbClientes
            // 
            pbClientes.ErrorImage = null;
            pbClientes.Image = (Image)resources.GetObject("pbClientes.Image");
            pbClientes.Location = new Point(27, 262);
            pbClientes.Name = "pbClientes";
            pbClientes.Size = new Size(63, 46);
            pbClientes.SizeMode = PictureBoxSizeMode.Zoom;
            pbClientes.TabIndex = 90;
            pbClientes.TabStop = false;
            pbClientes.Click += pbClientes_Click;
            // 
            // pbOrcamento
            // 
            pbOrcamento.ErrorImage = null;
            pbOrcamento.Image = (Image)resources.GetObject("pbOrcamento.Image");
            pbOrcamento.Location = new Point(22, 422);
            pbOrcamento.Name = "pbOrcamento";
            pbOrcamento.Size = new Size(63, 57);
            pbOrcamento.SizeMode = PictureBoxSizeMode.Zoom;
            pbOrcamento.TabIndex = 89;
            pbOrcamento.TabStop = false;
            pbOrcamento.Click += pbOrcamento_Click;
            // 
            // lbAgenda
            // 
            lbAgenda.AutoSize = true;
            lbAgenda.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbAgenda.ForeColor = SystemColors.ButtonFace;
            lbAgenda.Location = new Point(87, 356);
            lbAgenda.Name = "lbAgenda";
            lbAgenda.Size = new Size(67, 21);
            lbAgenda.TabIndex = 88;
            lbAgenda.Text = "Agenda";
            // 
            // lbClientes
            // 
            lbClientes.AutoSize = true;
            lbClientes.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClientes.ForeColor = Color.AliceBlue;
            lbClientes.Location = new Point(87, 280);
            lbClientes.Name = "lbClientes";
            lbClientes.Size = new Size(61, 21);
            lbClientes.TabIndex = 87;
            lbClientes.Text = "Cliente";
            // 
            // lbHome
            // 
            lbHome.AutoSize = true;
            lbHome.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbHome.ForeColor = Color.DarkOrange;
            lbHome.Location = new Point(87, 205);
            lbHome.Name = "lbHome";
            lbHome.Size = new Size(55, 21);
            lbHome.TabIndex = 86;
            lbHome.Text = "Home";
            // 
            // LbOrçamentos
            // 
            LbOrçamentos.AutoSize = true;
            LbOrçamentos.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LbOrçamentos.ForeColor = SystemColors.ButtonFace;
            LbOrçamentos.Location = new Point(87, 446);
            LbOrçamentos.Name = "LbOrçamentos";
            LbOrçamentos.Size = new Size(92, 21);
            LbOrçamentos.TabIndex = 85;
            LbOrçamentos.Text = "Orçamento";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pbHome);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(btnSair);
            panel1.Controls.Add(LbOrçamentos);
            panel1.Controls.Add(lbAgenda);
            panel1.Controls.Add(lbClientes);
            panel1.Controls.Add(pbOrcamento);
            panel1.Controls.Add(lbHome);
            panel1.Controls.Add(pbClientes);
            panel1.Controls.Add(pbAgenda);
            panel1.Location = new Point(-2, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(263, 622);
            panel1.TabIndex = 93;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Arial", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.DarkOrange;
            label4.Location = new Point(108, 64);
            label4.Name = "label4";
            label4.Size = new Size(137, 38);
            label4.TabIndex = 101;
            label4.Text = "SOUND";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Arial", 24.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(22, 64);
            label1.Name = "label1";
            label1.Size = new Size(97, 38);
            label1.TabIndex = 100;
            label1.Text = "FULL";
            // 
            // pbHome
            // 
            pbHome.Image = (Image)resources.GetObject("pbHome.Image");
            pbHome.Location = new Point(27, 178);
            pbHome.Name = "pbHome";
            pbHome.Size = new Size(63, 56);
            pbHome.SizeMode = PictureBoxSizeMode.Zoom;
            pbHome.TabIndex = 99;
            pbHome.TabStop = false;
            pbHome.Click += pbHome_Click;
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
            // pictureBox2
            // 
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(16, 527);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(115, 65);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 97;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
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
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Symbol", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(1297, 35);
            label2.Name = "label2";
            label2.Size = new Size(103, 21);
            label2.TabIndex = 0;
            label2.Text = "Bem-Vindo!";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(267, 2);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1672, 941);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
            pictureBox1.TabIndex = 94;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1419, 662);
            Controls.Add(label2);
            Controls.Add(pictureBox1);
            Controls.Add(pictureBox10);
            Controls.Add(panel1);
            Name = "Home";
            Text = "Home";
            ((System.ComponentModel.ISupportInitialize)pictureBox10).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAgenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbClientes).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbOrcamento).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbHome).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox10;
        private PictureBox pbAgenda;
        private PictureBox pbClientes;
        private PictureBox pbOrcamento;
        private Label lbAgenda;
        private Label lbClientes;
        private Label lbHome;
        private Label LbOrçamentos;
        private Panel panel1;
        private Button btnSair;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private PictureBox pbHome;
        private Label label1;
        private PictureBox pictureBox1;
        private Label label4;
    }
}