namespace MultApps.Windows
{
    partial class frmCarterinha
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblvisitante = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblCpf1 = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.TextBox();
            this.lblDataDeNascimento = new System.Windows.Forms.Label();
            this.txtDataDeNascimento = new System.Windows.Forms.TextBox();
            this.btnGerarCarterinha = new System.Windows.Forms.Button();
            this.picIcone = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCpf2 = new System.Windows.Forms.Label();
            this.lblZona = new System.Windows.Forms.Label();
            this.lblIdade = new System.Windows.Forms.Label();
            this.lblCpf = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picIcone)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(89, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(635, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Gerador de Carterinha  de acesso ao parque";
            // 
            // lblvisitante
            // 
            this.lblvisitante.AutoSize = true;
            this.lblvisitante.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblvisitante.Location = new System.Drawing.Point(36, 105);
            this.lblvisitante.Name = "lblvisitante";
            this.lblvisitante.Size = new System.Drawing.Size(62, 24);
            this.lblvisitante.TabIndex = 1;
            this.lblvisitante.Text = "Nome";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(40, 150);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(300, 20);
            this.txtNome.TabIndex = 2;
            // 
            // lblCpf1
            // 
            this.lblCpf1.AutoSize = true;
            this.lblCpf1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpf1.Location = new System.Drawing.Point(36, 188);
            this.lblCpf1.Name = "lblCpf1";
            this.lblCpf1.Size = new System.Drawing.Size(50, 24);
            this.lblCpf1.TabIndex = 3;
            this.lblCpf1.Text = "CPF";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(40, 233);
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(300, 20);
            this.txtCPF.TabIndex = 4;
            // 
            // lblDataDeNascimento
            // 
            this.lblDataDeNascimento.AutoSize = true;
            this.lblDataDeNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataDeNascimento.Location = new System.Drawing.Point(36, 281);
            this.lblDataDeNascimento.Name = "lblDataDeNascimento";
            this.lblDataDeNascimento.Size = new System.Drawing.Size(197, 24);
            this.lblDataDeNascimento.TabIndex = 5;
            this.lblDataDeNascimento.Text = "Data de Nascimento";
            // 
            // txtDataDeNascimento
            // 
            this.txtDataDeNascimento.Location = new System.Drawing.Point(40, 324);
            this.txtDataDeNascimento.Name = "txtDataDeNascimento";
            this.txtDataDeNascimento.Size = new System.Drawing.Size(300, 20);
            this.txtDataDeNascimento.TabIndex = 6;
            // 
            // btnGerarCarterinha
            // 
            this.btnGerarCarterinha.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerarCarterinha.Location = new System.Drawing.Point(40, 379);
            this.btnGerarCarterinha.Name = "btnGerarCarterinha";
            this.btnGerarCarterinha.Size = new System.Drawing.Size(317, 43);
            this.btnGerarCarterinha.TabIndex = 7;
            this.btnGerarCarterinha.Text = "Gerar Carterinha";
            this.btnGerarCarterinha.UseVisualStyleBackColor = true;
            this.btnGerarCarterinha.Click += new System.EventHandler(this.btnGerarCarterinha_Click);
            // 
            // picIcone
            // 
            this.picIcone.Location = new System.Drawing.Point(45, 33);
            this.picIcone.Name = "picIcone";
            this.picIcone.Size = new System.Drawing.Size(186, 115);
            this.picIcone.TabIndex = 8;
            this.picIcone.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblCpf2);
            this.panel1.Controls.Add(this.lblZona);
            this.panel1.Controls.Add(this.lblIdade);
            this.panel1.Controls.Add(this.lblCpf);
            this.panel1.Controls.Add(this.lblNome);
            this.panel1.Controls.Add(this.picIcone);
            this.panel1.Location = new System.Drawing.Point(451, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(289, 333);
            this.panel1.TabIndex = 9;
            // 
            // lblCpf2
            // 
            this.lblCpf2.AutoSize = true;
            this.lblCpf2.Location = new System.Drawing.Point(82, 205);
            this.lblCpf2.Name = "lblCpf2";
            this.lblCpf2.Size = new System.Drawing.Size(27, 13);
            this.lblCpf2.TabIndex = 13;
            this.lblCpf2.Text = "CPF";
            this.lblCpf2.Visible = false;
            // 
            // lblZona
            // 
            this.lblZona.AutoSize = true;
            this.lblZona.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblZona.Location = new System.Drawing.Point(39, 291);
            this.lblZona.Name = "lblZona";
            this.lblZona.Size = new System.Drawing.Size(36, 13);
            this.lblZona.TabIndex = 12;
            this.lblZona.Text = "Zona";
            this.lblZona.Visible = false;
            // 
            // lblIdade
            // 
            this.lblIdade.AutoSize = true;
            this.lblIdade.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdade.Location = new System.Drawing.Point(82, 238);
            this.lblIdade.Name = "lblIdade";
            this.lblIdade.Size = new System.Drawing.Size(39, 13);
            this.lblIdade.TabIndex = 11;
            this.lblIdade.Text = "Idade";
            this.lblIdade.Visible = false;
            // 
            // lblCpf
            // 
            this.lblCpf.AutoSize = true;
            this.lblCpf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCpf.Location = new System.Drawing.Point(75, 206);
            this.lblCpf.Name = "lblCpf";
            this.lblCpf.Size = new System.Drawing.Size(0, 13);
            this.lblCpf.TabIndex = 10;
            this.lblCpf.Visible = false;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(75, 176);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(114, 13);
            this.lblNome.TabIndex = 9;
            this.lblNome.Text = "Nome do  Visitante";
            this.lblNome.Visible = false;
            // 
            // frmCarterinha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnGerarCarterinha);
            this.Controls.Add(this.txtDataDeNascimento);
            this.Controls.Add(this.lblDataDeNascimento);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.lblCpf1);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblvisitante);
            this.Controls.Add(this.label1);
            this.Name = "frmCarterinha";
            this.Text = "frmCarterinha";
            ((System.ComponentModel.ISupportInitialize)(this.picIcone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblvisitante;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCpf1;
        private System.Windows.Forms.TextBox txtCPF;
        private System.Windows.Forms.Label lblDataDeNascimento;
        private System.Windows.Forms.TextBox txtDataDeNascimento;
        private System.Windows.Forms.Button btnGerarCarterinha;
        private System.Windows.Forms.PictureBox picIcone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblCpf;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label lblIdade;
        private System.Windows.Forms.Label lblZona;
        private System.Windows.Forms.Label lblCpf2;
    }
}