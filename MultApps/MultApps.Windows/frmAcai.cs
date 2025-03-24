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

        // Variáveis para armazenar os valores
        string nome;
        string tamanhoCopo;
        List<PedidoItem> itensPedido = new List<PedidoItem>();

        decimal precoTamanhoCopo = 0;
        decimal precoFruta = 2.00m;  // Exemplo: cada fruta custa 2.00
        decimal precoCobertura = 3.00m; // Exemplo: cada cobertura custa 3.00
        decimal precoComplemento = 1.50m; // Exemplo: cada complemento custa 1


        private void btnPedido_Click(object sender, EventArgs e)
        {
            nome = txtNome.Text;  // txtNome é o TextBox para o nome do cliente
            if (string.IsNullOrEmpty(nome))
            {
                MessageBox.Show("Por favor, insira seu nome.");
                return;
            }

            // 2. Seleção do tamanho do copo
            if (tamanhoCopo == null)
            {
                MessageBox.Show("Por favor, selecione o tamanho do copo.");
                return;
            }

            listBoxPedidos.Items.Add(new PedidoItem("Açaí 300ml", 1, 15.00m));
            listBoxPedidos.Items.Add(new PedidoItem("Banana", 1, 2.50m));
            listBoxPedidos.Items.Add(new PedidoItem("Morango", 1, 3.00m));
            listBoxPedidos.Items.Add(new PedidoItem("Leite Condensado", 1, 2.00m));
            listBoxPedidos.Items.Add(new PedidoItem("Paçoca", 1, 1.50m));
            listBoxPedidos.Items.Add(new PedidoItem("Granola", 1, 3.50m));
            listBoxPedidos.Items.Add(new PedidoItem("Nutella", 1, 8.00m));
            listBoxPedidos.Items.Add($"Nome: {nome}");
            string senha = GerarSenhaCurta();
            listBoxPedidos.Items.Add($"Senha: {senha}");
            listBoxPedidos.Items.Add($"Total: R$ {CalcularTotal():F2}");
            decimal total = CalcularTotal();
            listBoxPedidos.Items.Add($"Total: R$ {total:F2}");
        }
        // Exibir informações




        private void AdicionarItemSelecionado(string nomeItem, decimal quantidade, decimal preco)
        {
            if (quantidade > 0)  // Verifica se a quantidade é maior que 0
            {
                // Adiciona item na lista de pedido
                itensPedido.Add(new PedidoItem(nomeItem, (int)quantidade, preco * quantidade));

                // Adiciona item ao ListBox
                listBoxPedidos.Items.Add($"{nomeItem} (x{quantidade}) - R$ {preco * quantidade:F2}");
            }

        }
            // Método para calcular o total
            private decimal CalcularTotal()
        {
            decimal total = 0;
            foreach (var item in itensPedido)
            {
                total += item.Preco;
            }
            return total;
        }

     



        // Método para gerar uma senha baseada no horário
        private string GerarSenhaCurta()
        {
            DateTime agora = DateTime.Now;
            return $"{agora:MMddHHmmss}"; // Exemplo: 032112451234
        }

        // Evento de selecionar o tamanho do copo
        private void btnTamanhoCopo_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (btn.Name)
            {
                case "btnPequeno":
                    tamanhoCopo = "Pequeno";
                    precoTamanhoCopo = 15.00m;
                    break;
                case "btnMedio":
                    tamanhoCopo = "Médio";
                    precoTamanhoCopo = 20.00m;
                    break;
                case "btnGrande":
                    tamanhoCopo = "Grande";
                    precoTamanhoCopo = 25.00m;
                    break;
                case "btnFamilia":
                    tamanhoCopo = "Família";
                    precoTamanhoCopo = 35.00m;
                    break;
                default:
                    break;
            }
        }
 
        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (listBoxPedidos.SelectedItem != null)
            {
                listBoxPedidos.Items.Remove(listBoxPedidos.SelectedItem);
            }
            else
            {
                MessageBox.Show("Selecione um item para remover.");
            }
        }

        private void btnBanana_Click(object sender, EventArgs e)
        {
            // Torna o NumericUpDown da Banana visível quando o botão de Banana for clicado
            numBanana.Visible = !numBanana.Visible;
        }

        private void btnMorango_Click(object sender, EventArgs e)
        {
            // Torna o NumericUpDown do Morango visível
            numMorango.Visible = !numMorango.Visible;
        }

        private void btnGranola_Click(object sender, EventArgs e)
        {
            // Torna o NumericUpDown da Granola visível
            numGranola.Visible = !numGranola.Visible;
        }

        private void btnLeiteCondensado_Click(object sender, EventArgs e)
        {
            // Torna o NumericUpDown do Leite Condensado visível
            numLeite.Visible = !numLeite.Visible;
        }

        private void btnNutella_Click(object sender, EventArgs e)
        {
            // Torna o NumericUpDown da Nutella visível
            numNutella.Visible = !numNutella.Visible;
        }


        private void AdicionarComplementos()
        {
            decimal totalComplementos = 0;

            // Adiciona Banana, se a quantidade for maior que 0
            if (numBanana.Visible && numBanana.Value > 0)
            {
                decimal precoBanana = precoFruta * numBanana.Value;
                AdicionarItemSelecionado("Banana", numBanana.Value, precoFruta);
                totalComplementos += precoBanana;
            }

            // Adiciona Morango, se a quantidade for maior que 0
            if (numMorango.Visible && numMorango.Value > 0)
            {
                decimal precoMorango = precoFruta * numMorango.Value;
                AdicionarItemSelecionado("Morango", numMorango.Value, precoFruta);
                totalComplementos += precoMorango;
            }

            // Adiciona Granola, se a quantidade for maior que 0
            if (numGranola.Visible && numGranola.Value > 0)
            {
                decimal precoGranola = precoCobertura * numGranola.Value;
                AdicionarItemSelecionado("Granola", numGranola.Value, precoCobertura);
                totalComplementos += precoGranola;
            }

            // Adiciona Nutella, se a quantidade for maior que 0
            if (numNutella.Visible && numNutella.Value > 0)
            {
                decimal precoNutella = precoCobertura * numNutella.Value;
                AdicionarItemSelecionado("Nutella", numNutella.Value, precoCobertura);
                totalComplementos += precoNutella;
            }

            // Adiciona Paçoca, se a quantidade for maior que 0
            if (numPacoca.Visible && numPacoca.Value > 0)
            {
                decimal precoPacoca = precoComplemento * numPacoca.Value;
                AdicionarItemSelecionado("Paçoca", numPacoca.Value, precoComplemento);
                totalComplementos += precoPacoca;
            }

            // Agora, somamos o valor do copo e dos complementos
            decimal totalPedido = precoTamanhoCopo + totalComplementos;


    }   }    
}
