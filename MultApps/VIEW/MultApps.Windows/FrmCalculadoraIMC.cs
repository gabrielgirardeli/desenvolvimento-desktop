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
            label5.Visible = false;
        }

        private void lblIdade_Click(object sender, EventArgs e)
        {

        }

        private void chkAdulto_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            #region Adulto Masculino
            var peso = double.Parse(txtPeso.Text);
            var Altura = double.Parse(txtAltura.Text);

            var imc = peso / (Altura * Altura);
            var textoBase = $@"Meu IMC: {imc:N2} é";

            lblResultadoImc.Text = imc.ToString(format: "N2");
            if (chkAdulto.Checked && chkMasculino.Checked)
            {

                




                

               

                if (chkMasculino.Checked)

                {
                    if (imc <= 18.5)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é abaixo do normal";
                        picBoxImc.Load(ImcImagem.MasculinoAbaixoDoNormal);
                    }
                    else if (imc < 24.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é normal";
                        picBoxImc.Load(ImcImagem.MasculinoNormal);
                    }
                    else if (imc < 29.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é sobrepeso";
                        picBoxImc.Load(ImcImagem.MasculinoSobrepeso);
                    }
                    else if (imc < 34.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade grau 1";
                        picBoxImc.Load(ImcImagem.MasculinoObesidadeGrau1);
                    }
                    else if (imc < 39.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade grau 2";
                        picBoxImc.Load(ImcImagem.MasculinoObesidadeGrau2);
                    }
                    else
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade grau 3";
                        picBoxImc.Load(ImcImagem.MasculinoObesidadeGrau3);

                    }


                }

                else if (chkFeminino.Checked)
                {
                    if (imc <= 18.5)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é abaixo do normal";
                        picBoxImc.Load(ImcImagem.FemininoAbaixoDoNormal);
                    }
                    else if (imc < 24.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é normal";
                        picBoxImc.Load(ImcImagem.FemininoNormal);
                    }
                    else if (imc < 29.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é sobrepeso";
                        picBoxImc.Load(ImcImagem.FemininoSobrePeso);

                    }
                    else if (imc < 34.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade grau 1";
                        picBoxImc.Load(ImcImagem.FemininoObesidadeGrau1);
                    }
                    else if (imc < 39.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade grau 2";
                        picBoxImc.Load(ImcImagem.FemininoObesidadeGrau2);
                    }
                    else
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade grau 3";
                        picBoxImc.Load(ImcImagem.FemininoObsedidadeGrau3);

                    }


                }

                else if (chkCrianca.Checked == true)
                {
                    if (imc <= 18.5)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é abaixo do normal";
                        picBoxImc.Load(ImcImagem.CriancaAbaixoDoNormal);
                    }

                    else if (imc < 24.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é normal";
                        picBoxImc.Load(ImcImagem.CriancaPesoNormal);
                    }

                    else if (imc < 29.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é sobrepeso";
                        picBoxImc.Load(ImcImagem.CriancaSobrePeso);

                    }

                    else if (imc < 34.9)
                    {
                        lblResultadoImc.Text = $@"{textoBase} é obesidade";
                        picBoxImc.Load(ImcImagem.CriancaObesidade);
                    }

                }




                    #endregion
            }








        }
        private void chkMasculino_CheckedChanged(object sender, EventArgs e)
        {
            chkMasculino.ForeColor = Color.DarkOrange;
            chkFeminino.ForeColor = Color.Gray;
            chkFeminino.Checked = false;


        }

        private void chkFeminino_CheckedChanged(object sender, EventArgs e)
        {
            chkFeminino.ForeColor = Color.DarkOrange;
            chkMasculino.ForeColor = Color.Gray;
            chkMasculino.Checked = false;


        }










    }
}
