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
    public partial class frmAcai : Form
    {
        public frmAcai()
        {
            InitializeComponent();
        }

        string nome;
        string tamanhoCopo;
        string frutaEscolhida;
        string coberturaEscolhida;

        double precoTamanhoCopo = 0;
        double precoFruta = 2.00;  // Exemplo: cada fruta custa 2.00
        double precoComplemento = 1.50;  // Exemplo: cada complemento custa 1.50
        double precoCobertura = 3.00;
        private void btnPedido_Click(object sender, EventArgs e)
        {
            nome = txtNome.Text; // Coletar o nome

            // Coletar o tamanho do copo
            if (btnPequeno.Checked) { tamanhoCopo = "Pequeno"; precoTamanhoCopo = 15.00; }
            else if (btnMedio.Checked) { tamanhoCopo = "Médio"; precoTamanhoCopo = 20.00; }
            else if (btnGrande.Checked) { tamanhoCopo = "Grande"; precoTamanhoCopo = 25.00; }
            else if (btnFamilia.Checked) { tamanhoCopo = "Família"; precoTamanhoCopo = 35.00; }

            // Coletar as frutas escolhidas
            frutaEscolhida = "";
            if (numBanana.Value > 0) { frutaEscolhida += $"Banana ({numBanana.Value}), "; }
            if (numMorango.Value > 0) { frutaEscolhida += $"Morango ({numMorango.Value}), "; }

            // Coletar as coberturas escolhidas
            coberturaEscolhida = "";
            if (numGranola.Value > 0) { coberturaEscolhida += $"Granola ({numGranola.Value}), "; }
            if (numLeite.Value > 0) { coberturaEscolhida += $"Leite Condensado ({numLeite.Value}), "; }
            if (numNutella.Value > 0) { coberturaEscolhida += $"Nutella ({numNutella.Value}), "; }

            // Remover a última vírgula e espaço
            if (frutaEscolhida.Length > 0) { frutaEscolhida = frutaEscolhida.Substring(0, frutaEscolhida.Length - 2); }
            if (coberturaEscolhida.Length > 0) { coberturaEscolhida = coberturaEscolhida.Substring(0, coberturaEscolhida.Length - 2); }

            // Gerar uma senha única para o pedido
            string senha = DateTime.Now.ToString("yyyyMMddHHmmss");

            // Exibir as informações do pedido
            listBox1.Items.Clear();
            listBox1.Items.Add($"Nome: {nome}");
            listBox1.Items.Add($"Tamanho: {tamanhoCopo}");
            listBox1.Items.Add($"Frutas: {frutaEscolhida}");
            listBox1.Items.Add($"Coberturas: {coberturaEscolhida}");
            listBox1.Items.Add($"Senha: {senha}");
            listBox1.Items.Add($"Total: R$ {CalcularTotal():F2}");
        }
        // Exibir informações
       
        private void btnTamanhoCopo_Click(object sender, EventArgs e)
        {
            // Define o tamanho do copo com base no botão clicado
            Button clickedButton = sender as Button;

            // Define o tamanho do copo
            tamanhoCopo = clickedButton.Text;

            double total = precoTamanhoCopo;

            // Adicionar preço das frutas
            if (numBanana.Value > 0) { total += precoFruta * (double)numBanana.Value; }
            if (numMorango.Value > 0) { total += precoFruta * (double)numMorango.Value; }

            // Adicionar preço das coberturas
            if (numGranola.Value > 0) { total += precoCobertura * (double)numGranola.Value; }
            if (numLeite.Value > 0) { total += precoCobertura * (double)numLeite.Value; }
            if (numNutella.Value > 0) { total += precoCobertura * (double)numNutella.Value; }

            return total;
        }

    }
}
