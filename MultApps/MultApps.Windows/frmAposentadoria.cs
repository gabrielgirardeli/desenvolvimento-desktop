using System;
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

        }
    }
}
