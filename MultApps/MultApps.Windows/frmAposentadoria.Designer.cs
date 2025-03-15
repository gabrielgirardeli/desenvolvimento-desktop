namespace MultApps.Windows
{
    partial class frmAposentadoria
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
            this.cbmSexo = new System.Windows.Forms.ComboBox();
            this.lblVerificadorDeAposentadoria = new System.Windows.Forms.Label();
            this.btnVerificar = new System.Windows.Forms.Button();
            this.lblDataNascimento = new System.Windows.Forms.Label();
            this.mtbDataNascimento = new System.Windows.Forms.MaskedTextBox();
            this.lblTempoDeContribuicao = new System.Windows.Forms.Label();
            this.pnlResultado = new System.Windows.Forms.Panel();
            this.pageSetupDialog1 = new System.Windows.Forms.PageSetupDialog();
            this.lblResultado = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.txtTempoContribuicao = new System.Windows.Forms.TextBox();
            this.pnlResultado.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbmSexo
            // 
            this.cbmSexo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbmSexo.FormattingEnabled = true;
            this.cbmSexo.Items.AddRange(new object[] {
            "Masculino",
            "Feminino",
            "Não Prefiro dizer"});
            this.cbmSexo.Location = new System.Drawing.Point(18, 188);
            this.cbmSexo.Name = "cbmSexo";
            this.cbmSexo.Size = new System.Drawing.Size(121, 32);
            this.cbmSexo.TabIndex = 1;
            this.cbmSexo.Text = "Sexo";
            // 
            // lblVerificadorDeAposentadoria
            // 
            this.lblVerificadorDeAposentadoria.AutoSize = true;
            this.lblVerificadorDeAposentadoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVerificadorDeAposentadoria.Location = new System.Drawing.Point(134, 20);
            this.lblVerificadorDeAposentadoria.Name = "lblVerificadorDeAposentadoria";
            this.lblVerificadorDeAposentadoria.Size = new System.Drawing.Size(500, 42);
            this.lblVerificadorDeAposentadoria.TabIndex = 3;
            this.lblVerificadorDeAposentadoria.Text = "Verificador de Aposentadoria";
            // 
            // btnVerificar
            // 
            this.btnVerificar.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerificar.Location = new System.Drawing.Point(631, 376);
            this.btnVerificar.Name = "btnVerificar";
            this.btnVerificar.Size = new System.Drawing.Size(108, 28);
            this.btnVerificar.TabIndex = 4;
            this.btnVerificar.Text = "Verificar";
            this.btnVerificar.UseVisualStyleBackColor = true;
            this.btnVerificar.Click += new System.EventHandler(this.btnVerificar_Click);
            // 
            // lblDataNascimento
            // 
            this.lblDataNascimento.AutoSize = true;
            this.lblDataNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDataNascimento.Location = new System.Drawing.Point(14, 86);
            this.lblDataNascimento.Name = "lblDataNascimento";
            this.lblDataNascimento.Size = new System.Drawing.Size(197, 24);
            this.lblDataNascimento.TabIndex = 5;
            this.lblDataNascimento.Text = "Data de Nascimento";
            // 
            // mtbDataNascimento
            // 
            this.mtbDataNascimento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDataNascimento.Location = new System.Drawing.Point(18, 127);
            this.mtbDataNascimento.Mask = "00/00/0000";
            this.mtbDataNascimento.Name = "mtbDataNascimento";
            this.mtbDataNascimento.Size = new System.Drawing.Size(193, 29);
            this.mtbDataNascimento.TabIndex = 6;
            this.mtbDataNascimento.ValidatingType = typeof(System.DateTime);
            // 
            // lblTempoDeContribuicao
            // 
            this.lblTempoDeContribuicao.AutoSize = true;
            this.lblTempoDeContribuicao.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempoDeContribuicao.Location = new System.Drawing.Point(14, 265);
            this.lblTempoDeContribuicao.Name = "lblTempoDeContribuicao";
            this.lblTempoDeContribuicao.Size = new System.Drawing.Size(272, 24);
            this.lblTempoDeContribuicao.TabIndex = 7;
            this.lblTempoDeContribuicao.Text = "Tempo de  Contribuição (anos)";
            // 
            // pnlResultado
            // 
            this.pnlResultado.Controls.Add(this.lblResultado);
            this.pnlResultado.Location = new System.Drawing.Point(343, 301);
            this.pnlResultado.Name = "pnlResultado";
            this.pnlResultado.Size = new System.Drawing.Size(420, 57);
            this.pnlResultado.TabIndex = 9;
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(91, 23);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 13);
            this.lblResultado.TabIndex = 0;
            // 
            // txtTempoContribuicao
            // 
            this.txtTempoContribuicao.Location = new System.Drawing.Point(50, 321);
            this.txtTempoContribuicao.Name = "txtTempoContribuicao";
            this.txtTempoContribuicao.Size = new System.Drawing.Size(144, 20);
            this.txtTempoContribuicao.TabIndex = 10;
            // 
            // frmAposentadoria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtTempoContribuicao);
            this.Controls.Add(this.pnlResultado);
            this.Controls.Add(this.lblTempoDeContribuicao);
            this.Controls.Add(this.mtbDataNascimento);
            this.Controls.Add(this.lblDataNascimento);
            this.Controls.Add(this.btnVerificar);
            this.Controls.Add(this.lblVerificadorDeAposentadoria);
            this.Controls.Add(this.cbmSexo);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.Name = "frmAposentadoria";
            this.Text = "frmAposentadoria";
            this.pnlResultado.ResumeLayout(false);
            this.pnlResultado.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cbmSexo;
        private System.Windows.Forms.Label lblVerificadorDeAposentadoria;
        private System.Windows.Forms.Button btnVerificar;
        private System.Windows.Forms.Label lblDataNascimento;
        private System.Windows.Forms.MaskedTextBox mtbDataNascimento;
        private System.Windows.Forms.Label lblTempoDeContribuicao;
        private System.Windows.Forms.Panel pnlResultado;
        private System.Windows.Forms.PageSetupDialog pageSetupDialog1;
        private System.Windows.Forms.Label lblResultado;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.TextBox txtTempoContribuicao;
    }
}