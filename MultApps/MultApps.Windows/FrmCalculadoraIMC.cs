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
    public partial class FrmCalculadoraIMC : Form
    {
        public FrmCalculadoraIMC()
        {
            InitializeComponent();
        }

        private void chkCrianca_CheckedChanged(object sender, EventArgs e)
        {
            chkCrianca.ForeColor = Color.DarkOrange;
            chkAdulto.ForeColor = Color.Gray;
            chkAdulto.Checked = false;
            lblIdade.Text = "Abaixo de 19 anos";
            cmbIdade.Visible = true;
            label5.Visible = true;
        }

        private void chkAdulto_CheckedChanged(object sender, EventArgs e)
        {
            chkAdulto.ForeColor = Color.DarkOrange;
            chkCrianca.ForeColor = Color.Gray;
            chkCrianca.Checked = false;
            lblIdade.Text = "Acima de 19 anos";
            cmbIdade.Visible = false;
            label5.Visible= false;
        }

        private void lblIdade_Click(object sender, EventArgs e)
        {

        }

        private void chkAdulto_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            var peso = double.Parse(txtPeso.Text);
            var Altura = double.Parse(txtAltura.Text);

            var imc = peso / (Altura * Altura);
            var textoBase = $@"Meu IMC: {imc:N2} é";

            lblResultadoImc.Text = imc.ToString(format: "N2");
            
            if(imc <= 18.5)
            {
                lblResultadoImc.Text = $@"{textoBase} é abaixo do normal";
            }
            else if(imc < 24.9)
            {
                lblResultadoImc.Text = $@"{textoBase} é normal";
            }
            else if (imc < 29.9)
            {
                lblResultadoImc.Text = $@"{textoBase} é sobrepeso";
            }
            else if (imc < 34.9)
            {
                lblResultadoImc.Text = $@"{textoBase} é obesidade grau 1";
            }
            else if (imc < 39.9)
            {
                lblResultadoImc.Text = $@"{textoBase} é obesidade grau 2";
            }
            else 
            {
                lblResultadoImc.Text = $@"{textoBase} é obesidade grau 3";
            }




        }
    }
}
