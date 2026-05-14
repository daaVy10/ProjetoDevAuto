namespace Tela1_Acesso
{
    partial class TelaCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TelaCliente));
            LbNome = new Label();
            LbCelular2 = new Label();
            LbTipoDePagamento = new Label();
            txtNome = new TextBox();
            txtCelular = new TextBox();
            dgvClientes = new DataGridView();
            ColNome = new DataGridViewTextBoxColumn();
            ColCelular = new DataGridViewTextBoxColumn();
            ColTipodoVeiculo = new DataGridViewTextBoxColumn();
            gbTipodePagamento = new GroupBox();
            rbSUV = new RadioButton();
            rbSedan = new RadioButton();
            rbHatch = new RadioButton();
            lbClientes2 = new Label();
            panel1 = new Panel();
            pictureBox3 = new PictureBox();
            label3 = new Label();
            pictureBox2 = new PictureBox();
            btnSair = new Button();
            label2 = new Label();
            label4 = new Label();
            label5 = new Label();
            label7 = new Label();
            pbOrcamento = new PictureBox();
            pictureBox1 = new PictureBox();
            pbAgenda = new PictureBox();
            pictureBox4 = new PictureBox();
            pictureBox6 = new PictureBox();
            btnAdicionarClient = new Button();
            btnRemoverCliente = new Button();
            btnAlterarCliente = new Button();
            pnlAlterarCliente = new Panel();
            lbltel = new Label();
            lblnome = new Label();
            btnCancelarAlteracao = new Button();
            btnSalvarAlteracao = new Button();
            rbAlterarSuv = new RadioButton();
            rbAlterarSedan = new RadioButton();
            rbAlterarHatch = new RadioButton();
            txtAlterarCelular = new TextBox();
            txtAlterarNome = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
            gbTipodePagamento.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbOrcamento).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbAgenda).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).BeginInit();
            pnlAlterarCliente.SuspendLayout();
            SuspendLayout();
            // 
            // LbNome
            // 
            LbNome.AutoSize = true;
            LbNome.ForeColor = Color.White;
            LbNome.Location = new Point(435, 107);
            LbNome.Name = "LbNome";
            LbNome.Size = new Size(43, 15);
            LbNome.TabIndex = 9;
            LbNome.Text = "Nome:";
            // 
            // LbCelular2
            // 
            LbCelular2.AutoSize = true;
            LbCelular2.ForeColor = Color.White;
            LbCelular2.Location = new Point(435, 183);
            LbCelular2.Name = "LbCelular2";
            LbCelular2.Size = new Size(47, 15);
            LbCelular2.TabIndex = 10;
            LbCelular2.Text = "Celular:";
            // 
            // LbTipoDePagamento
            // 
            LbTipoDePagamento.AutoSize = true;
            LbTipoDePagamento.ForeColor = Color.White;
            LbTipoDePagamento.Location = new Point(945, 51);
            LbTipoDePagamento.Name = "LbTipoDePagamento";
            LbTipoDePagamento.Size = new Size(91, 15);
            LbTipoDePagamento.TabIndex = 13;
            LbTipoDePagamento.Text = "Tipo do veículo:";
            // 
            // txtNome
            // 
            txtNome.Location = new Point(435, 125);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(310, 23);
            txtNome.TabIndex = 14;
            // 
            // txtCelular
            // 
            txtCelular.Location = new Point(435, 201);
            txtCelular.Name = "txtCelular";
            txtCelular.Size = new Size(126, 23);
            txtCelular.TabIndex = 15;
            // 
            // dgvClientes
            // 
            dgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvClientes.Columns.AddRange(new DataGridViewColumn[] { ColNome, ColCelular, ColTipodoVeiculo });
            dgvClientes.Location = new Point(431, 333);
            dgvClientes.MultiSelect = false;
            dgvClientes.Name = "dgvClientes";
            dgvClientes.ReadOnly = true;
            dgvClientes.Size = new Size(719, 261);
            dgvClientes.TabIndex = 39;
            dgvClientes.CellContentClick += dgvClientes_CellContentClick;
            // 
            // ColNome
            // 
            ColNome.HeaderText = "Nome";
            ColNome.Name = "ColNome";
            ColNome.ReadOnly = true;
            // 
            // ColCelular
            // 
            ColCelular.HeaderText = "Celular";
            ColCelular.Name = "ColCelular";
            ColCelular.ReadOnly = true;
            // 
            // ColTipodoVeiculo
            // 
            ColTipodoVeiculo.HeaderText = "Tipo do Veiculo";
            ColTipodoVeiculo.Name = "ColTipodoVeiculo";
            ColTipodoVeiculo.ReadOnly = true;
            // 
            // gbTipodePagamento
            // 
            gbTipodePagamento.Controls.Add(rbSUV);
            gbTipodePagamento.Controls.Add(rbSedan);
            gbTipodePagamento.Controls.Add(rbHatch);
            gbTipodePagamento.Location = new Point(945, 80);
            gbTipodePagamento.Name = "gbTipodePagamento";
            gbTipodePagamento.Size = new Size(200, 147);
            gbTipodePagamento.TabIndex = 41;
            gbTipodePagamento.TabStop = false;
            gbTipodePagamento.Text = "groupBox1";
            // 
            // rbSUV
            // 
            rbSUV.AutoSize = true;
            rbSUV.Location = new Point(6, 82);
            rbSUV.Name = "rbSUV";
            rbSUV.Size = new Size(46, 19);
            rbSUV.TabIndex = 2;
            rbSUV.TabStop = true;
            rbSUV.Text = "SUV";
            rbSUV.UseVisualStyleBackColor = true;
            // 
            // rbSedan
            // 
            rbSedan.AutoSize = true;
            rbSedan.Location = new Point(6, 55);
            rbSedan.Name = "rbSedan";
            rbSedan.Size = new Size(57, 19);
            rbSedan.TabIndex = 1;
            rbSedan.TabStop = true;
            rbSedan.Text = "Sedan";
            rbSedan.UseVisualStyleBackColor = true;
            // 
            // rbHatch
            // 
            rbHatch.AutoSize = true;
            rbHatch.Location = new Point(6, 30);
            rbHatch.Name = "rbHatch";
            rbHatch.Size = new Size(57, 19);
            rbHatch.TabIndex = 0;
            rbHatch.TabStop = true;
            rbHatch.Text = "Hatch";
            rbHatch.UseVisualStyleBackColor = true;
            // 
            // lbClientes2
            // 
            lbClientes2.AutoSize = true;
            lbClientes2.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbClientes2.ForeColor = Color.White;
            lbClientes2.Location = new Point(492, 51);
            lbClientes2.Name = "lbClientes2";
            lbClientes2.Size = new Size(200, 30);
            lbClientes2.TabIndex = 43;
            lbClientes2.Text = "Cadastro de Cliente";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ActiveCaptionText;
            panel1.Controls.Add(pictureBox3);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(pictureBox2);
            panel1.Controls.Add(btnSair);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(pbOrcamento);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(pbAgenda);
            panel1.Controls.Add(pictureBox4);
            panel1.Location = new Point(1, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(270, 621);
            panel1.TabIndex = 94;
            // 
            // pictureBox3
            // 
            pictureBox3.Cursor = Cursors.Hand;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(21, 180);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(63, 56);
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.TabIndex = 99;
            pictureBox3.TabStop = false;
            pictureBox3.Click += pictureBox3_Click;
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
            pictureBox2.Cursor = Cursors.Hand;
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
            label2.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ButtonFace;
            label2.Location = new Point(81, 448);
            label2.Name = "label2";
            label2.Size = new Size(92, 21);
            label2.TabIndex = 85;
            label2.Text = "Orçamento";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(81, 358);
            label4.Name = "label4";
            label4.Size = new Size(67, 21);
            label4.TabIndex = 88;
            label4.Text = "Agenda";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.DarkOrange;
            label5.Location = new Point(81, 282);
            label5.Name = "label5";
            label5.Size = new Size(61, 21);
            label5.TabIndex = 87;
            label5.Text = "Cliente";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.SeaShell;
            label7.Location = new Point(81, 207);
            label7.Name = "label7";
            label7.Size = new Size(55, 21);
            label7.TabIndex = 86;
            label7.Text = "Home";
            // 
            // pbOrcamento
            // 
            pbOrcamento.Cursor = Cursors.Hand;
            pbOrcamento.ErrorImage = null;
            pbOrcamento.Image = (Image)resources.GetObject("pbOrcamento.Image");
            pbOrcamento.Location = new Point(16, 424);
            pbOrcamento.Name = "pbOrcamento";
            pbOrcamento.Size = new Size(63, 57);
            pbOrcamento.SizeMode = PictureBoxSizeMode.Zoom;
            pbOrcamento.TabIndex = 89;
            pbOrcamento.TabStop = false;
            pbOrcamento.Click += pbOrcamento_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.ErrorImage = null;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(21, 262);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(67, 48);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 90;
            pictureBox1.TabStop = false;
            // 
            // pbAgenda
            // 
            pbAgenda.Cursor = Cursors.Hand;
            pbAgenda.ErrorImage = null;
            pbAgenda.Image = (Image)resources.GetObject("pbAgenda.Image");
            pbAgenda.Location = new Point(16, 331);
            pbAgenda.Name = "pbAgenda";
            pbAgenda.Size = new Size(72, 66);
            pbAgenda.SizeMode = PictureBoxSizeMode.Zoom;
            pbAgenda.TabIndex = 91;
            pbAgenda.TabStop = false;
            pbAgenda.Click += pbAgenda_Click;
            // 
            // pictureBox4
            // 
            pictureBox4.Image = (Image)resources.GetObject("pictureBox4.Image");
            pictureBox4.Location = new Point(3, 0);
            pictureBox4.Name = "pictureBox4";
            pictureBox4.Size = new Size(264, 228);
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.TabIndex = 97;
            pictureBox4.TabStop = false;
            // 
            // pictureBox6
            // 
            pictureBox6.ErrorImage = null;
            pictureBox6.Image = (Image)resources.GetObject("pictureBox6.Image");
            pictureBox6.Location = new Point(431, 32);
            pictureBox6.Name = "pictureBox6";
            pictureBox6.Size = new Size(55, 55);
            pictureBox6.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox6.TabIndex = 95;
            pictureBox6.TabStop = false;
            // 
            // btnAdicionarClient
            // 
            btnAdicionarClient.BackColor = Color.DarkOrange;
            btnAdicionarClient.Cursor = Cursors.Hand;
            btnAdicionarClient.FlatStyle = FlatStyle.Flat;
            btnAdicionarClient.ForeColor = Color.Black;
            btnAdicionarClient.Location = new Point(781, 162);
            btnAdicionarClient.Name = "btnAdicionarClient";
            btnAdicionarClient.Size = new Size(124, 23);
            btnAdicionarClient.TabIndex = 96;
            btnAdicionarClient.Text = "Adicionar Cliente";
            btnAdicionarClient.UseVisualStyleBackColor = false;
            btnAdicionarClient.Click += btnAdicionarCliente_Click_1;
            // 
            // btnRemoverCliente
            // 
            btnRemoverCliente.BackColor = Color.DarkOrange;
            btnRemoverCliente.Cursor = Cursors.Hand;
            btnRemoverCliente.FlatStyle = FlatStyle.Flat;
            btnRemoverCliente.ForeColor = Color.Black;
            btnRemoverCliente.Location = new Point(781, 242);
            btnRemoverCliente.Name = "btnRemoverCliente";
            btnRemoverCliente.Size = new Size(124, 23);
            btnRemoverCliente.TabIndex = 97;
            btnRemoverCliente.Text = "Remover Cliente";
            btnRemoverCliente.UseVisualStyleBackColor = false;
            // 
            // btnAlterarCliente
            // 
            btnAlterarCliente.BackColor = Color.DarkOrange;
            btnAlterarCliente.Cursor = Cursors.Hand;
            btnAlterarCliente.FlatStyle = FlatStyle.Flat;
            btnAlterarCliente.ForeColor = Color.Black;
            btnAlterarCliente.Location = new Point(781, 201);
            btnAlterarCliente.Name = "btnAlterarCliente";
            btnAlterarCliente.Size = new Size(124, 23);
            btnAlterarCliente.TabIndex = 98;
            btnAlterarCliente.Text = "Alterar Dados";
            btnAlterarCliente.UseVisualStyleBackColor = false;
            btnAlterarCliente.Click += btnAlterarCliente_Click;
            // 
            // pnlAlterarCliente
            // 
            pnlAlterarCliente.Controls.Add(lbltel);
            pnlAlterarCliente.Controls.Add(lblnome);
            pnlAlterarCliente.Controls.Add(btnCancelarAlteracao);
            pnlAlterarCliente.Controls.Add(btnSalvarAlteracao);
            pnlAlterarCliente.Controls.Add(rbAlterarSuv);
            pnlAlterarCliente.Controls.Add(rbAlterarSedan);
            pnlAlterarCliente.Controls.Add(rbAlterarHatch);
            pnlAlterarCliente.Controls.Add(txtAlterarCelular);
            pnlAlterarCliente.Controls.Add(txtAlterarNome);
            pnlAlterarCliente.Location = new Point(1024, 284);
            pnlAlterarCliente.Name = "pnlAlterarCliente";
            pnlAlterarCliente.Size = new Size(366, 278);
            pnlAlterarCliente.TabIndex = 99;
            pnlAlterarCliente.Visible = false;
            // 
            // lbltel
            // 
            lbltel.AutoSize = true;
            lbltel.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltel.Location = new Point(215, 25);
            lbltel.Name = "lbltel";
            lbltel.Size = new Size(59, 15);
            lbltel.TabIndex = 8;
            lbltel.Text = "Telefone:";
            // 
            // lblnome
            // 
            lblnome.AutoSize = true;
            lblnome.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblnome.Location = new Point(35, 25);
            lblnome.Name = "lblnome";
            lblnome.Size = new Size(44, 15);
            lblnome.TabIndex = 7;
            lblnome.Text = "Nome:";
            // 
            // btnCancelarAlteracao
            // 
            btnCancelarAlteracao.ForeColor = Color.Black;
            btnCancelarAlteracao.Location = new Point(244, 236);
            btnCancelarAlteracao.Name = "btnCancelarAlteracao";
            btnCancelarAlteracao.Size = new Size(94, 23);
            btnCancelarAlteracao.TabIndex = 6;
            btnCancelarAlteracao.Text = "Cancelar";
            btnCancelarAlteracao.UseVisualStyleBackColor = true;
            btnCancelarAlteracao.Click += btnCancelarAlteracao_Click;
            // 
            // btnSalvarAlteracao
            // 
            btnSalvarAlteracao.ForeColor = Color.Black;
            btnSalvarAlteracao.Location = new Point(41, 236);
            btnSalvarAlteracao.Name = "btnSalvarAlteracao";
            btnSalvarAlteracao.Size = new Size(94, 23);
            btnSalvarAlteracao.TabIndex = 5;
            btnSalvarAlteracao.Text = "Salvar";
            btnSalvarAlteracao.UseVisualStyleBackColor = true;
            btnSalvarAlteracao.Click += btnSalvarAlteracao_Click;
            // 
            // rbAlterarSuv
            // 
            rbAlterarSuv.AutoSize = true;
            rbAlterarSuv.Location = new Point(35, 186);
            rbAlterarSuv.Name = "rbAlterarSuv";
            rbAlterarSuv.Size = new Size(46, 19);
            rbAlterarSuv.TabIndex = 4;
            rbAlterarSuv.TabStop = true;
            rbAlterarSuv.Text = "SUV";
            rbAlterarSuv.UseVisualStyleBackColor = true;
            // 
            // rbAlterarSedan
            // 
            rbAlterarSedan.AutoSize = true;
            rbAlterarSedan.Location = new Point(35, 150);
            rbAlterarSedan.Name = "rbAlterarSedan";
            rbAlterarSedan.Size = new Size(57, 19);
            rbAlterarSedan.TabIndex = 3;
            rbAlterarSedan.TabStop = true;
            rbAlterarSedan.Text = "Sedan";
            rbAlterarSedan.UseVisualStyleBackColor = true;
            // 
            // rbAlterarHatch
            // 
            rbAlterarHatch.AutoSize = true;
            rbAlterarHatch.Location = new Point(35, 116);
            rbAlterarHatch.Name = "rbAlterarHatch";
            rbAlterarHatch.Size = new Size(57, 19);
            rbAlterarHatch.TabIndex = 2;
            rbAlterarHatch.TabStop = true;
            rbAlterarHatch.Text = "Hatch";
            rbAlterarHatch.UseVisualStyleBackColor = true;
            // 
            // txtAlterarCelular
            // 
            txtAlterarCelular.Location = new Point(215, 59);
            txtAlterarCelular.Name = "txtAlterarCelular";
            txtAlterarCelular.Size = new Size(123, 23);
            txtAlterarCelular.TabIndex = 1;
            // 
            // txtAlterarNome
            // 
            txtAlterarNome.Location = new Point(35, 59);
            txtAlterarNome.Name = "txtAlterarNome";
            txtAlterarNome.Size = new Size(146, 23);
            txtAlterarNome.TabIndex = 0;
            // 
            // TelaCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1419, 624);
            Controls.Add(pnlAlterarCliente);
            Controls.Add(btnAlterarCliente);
            Controls.Add(btnRemoverCliente);
            Controls.Add(btnAdicionarClient);
            Controls.Add(pictureBox6);
            Controls.Add(panel1);
            Controls.Add(lbClientes2);
            Controls.Add(gbTipodePagamento);
            Controls.Add(dgvClientes);
            Controls.Add(txtCelular);
            Controls.Add(txtNome);
            Controls.Add(LbTipoDePagamento);
            Controls.Add(LbCelular2);
            Controls.Add(LbNome);
            ForeColor = Color.White;
            Name = "TelaCliente";
            Text = "TelaCliente";
            Load += TelaCliente_Load_1;
            ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
            gbTipodePagamento.ResumeLayout(false);
            gbTipodePagamento.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbOrcamento).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbAgenda).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox4).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox6).EndInit();
            pnlAlterarCliente.ResumeLayout(false);
            pnlAlterarCliente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label LbNome;
        private Label LbCelular2;
        private Label LbTipoDePagamento;
        private TextBox txtNome;
        private TextBox txtCelular;
        private Button button3;
        private Button button4;
        private Label lbClientes2;
        private DataGridView dgvClientes;
        private GroupBox gbTipodePagamento;
        private RadioButton rbHatch;
        private RadioButton rbSUV;
        private RadioButton rbSedan;
        private Panel panel1;
        private Label label3;
        private PictureBox pictureBox2;
        private Button btnSair;
        private Label label2;
        private Label label4;
        private Label label5;
        private PictureBox pbOrcamento;
        private PictureBox pbAgenda;
        private PictureBox pictureBox6;
        private Button btnAdicionarClient;
        private PictureBox pictureBox3;
        private Label label7;
        private PictureBox pictureBox1;
        private PictureBox pictureBox4;
        private DataGridViewTextBoxColumn ColNome;
        private DataGridViewTextBoxColumn ColCelular;
        private DataGridViewTextBoxColumn ColTipodoVeiculo;
        private Button btnRemoverCliente;
        private Button btnAlterarCliente;
        private Panel pnlAlterarCliente;
        private Button btnCancelarAlteracao;
        private Button btnSalvarAlteracao;
        private RadioButton rbAlterarSuv;
        private RadioButton rbAlterarSedan;
        private RadioButton rbAlterarHatch;
        private TextBox txtAlterarCelular;
        private TextBox txtAlterarNome;
        private Label lbltel;
        private Label lblnome;
    }
}