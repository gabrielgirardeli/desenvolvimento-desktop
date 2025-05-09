﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultApps.Windows
{
    public partial class frmAposentadoria : Form
    {
        public frmAposentadoria()
        {
            InitializeComponent();
        }

        private void btnVerificar_Click(object sender, EventArgs e)
        {
            DateTime dataNascimento;

            // Verificar se o texto do MaskedTextBox pode ser convertido para DateTime
            if (!DateTime.TryParse(mtbDataNascimento.Text, out dataNascimento))
            {
                MessageBox.Show("Por favor, insira uma data de nascimento válida no formato dd/MM/yyyy.");
                return;
            }
            int tempoContribuicao;
            if (!int.TryParse(txtTempoContribuicao.Text, out tempoContribuicao) || tempoContribuicao < 0)
            {
                MessageBox.Show("Por favor, insira um número válido de anos de contribuição.");
                return;
            }

            int idade = DateTime.Now.Year - dataNascimento.Year;
            if (DateTime.Now < dataNascimento.AddYears(idade))
                idade--;  // Ajusta a idade se a pessoa ainda não fez aniversário neste ano

            // Verifica o sexo selecionado
            string sexo = cbmSexo.SelectedItem.ToString();

            // Lógica de aposentadoria
            bool podeAposentar = false;

            // Regras de aposentadoria
            if (sexo == "Masculino" && idade >= 65 && tempoContribuicao >= 15)
            {
                podeAposentar = true;
            }
            else if (sexo == "Feminino" && idade >= 60 && tempoContribuicao >= 15)
            {
                podeAposentar = true;
            }

            // Exibe a mensagem de resultado
            if (podeAposentar)
            {
                lblResultado.Text = "Você pode dar entrada no processo de aposentadoria.";
                lblResultado.ForeColor = System.Drawing.Color.Green;
            }
            else
            {
                lblResultado.Text = "Você não cumpre os requisitos para se aposentar.";
                lblResultado.ForeColor = System.Drawing.Color.Red;
            }

            // Exibe o painel de resultado
            pnlResultado.Show();

        }
    }
}
