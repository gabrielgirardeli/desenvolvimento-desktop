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
    public partial class frmCarterinha : Form
    {
        public frmCarterinha()
        {
            InitializeComponent();
        }

        private void btnGerarCarterinha_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string cpf = txtCPF.Text;
            DateTime dataNascimento;

            // Verifica se a data de nascimento e CPF são válidos
            if (DateTime.TryParse(txtDataDeNascimento.Text, out dataNascimento) && IsValidCpf(cpf))
            {
                // Calcula a idade com base na data de nascimento
                int idade = CalculateAge(dataNascimento);

                // Chama a função para determinar a zona com base na idade
                string zona = DeterminarZona(idade);

                // Ofusca o CPF
                string cpfOfuscado = OfuscarCpf(cpf);

                // Obtém o ícone baseado na faixa etária
                string icone = ObterIcone(idade);

                // Exibe os dados na interface
                lblNome.Text = "Nome: " + nome;
                lblIdade.Text = "Idade: " + idade.ToString();
                lblCpf.Text = "CPF: " + cpfOfuscado;
                lblZona.Text = "Zona: " + zona;

                // Atualiza a cor de fundo da carteirinha e o ícone
                UpdateCardColor(zona);

                // Carrega a imagem no PictureBox
                try
                {
                    picIcone.Load(icone); // Carrega a imagem do ícone no PictureBox
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Por favor, insira dados válidos.");
            }

            panel1.Visible = true;
            lblNome.Visible = true;
            lblIdade.Visible = true;
            lblCpf.Visible = true;
            lblZona.Visible = true;
       }
      
        // Função para calcular a idade com base na data de nascimento
        private int CalculateAge(DateTime dataNascimento)
        {
            int idade = DateTime.Now.Year - dataNascimento.Year;

            // Ajusta a idade se a data de nascimento ainda não passou este ano
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
                idade--;

            return idade;
        }

        // Função para determinar a zona com base na idade
        private string DeterminarZona(int idade)
        {
            if (idade <= 12)
                return "Zona Azul: Preferência para Crianças";
            else if (idade >= 60)
                return "Zona Verde: Preferência para Idosos";
            else if (idade >= 13 && idade <= 35)
                return "Zona Amarela: Preferência para Jovens";
            else
                return "Zona Roxa: Preferência para Adultos";
        }

        // Função para ofuscar o CPF (mostrando apenas os 6 dígitos do meio)
        private string OfuscarCpf(string cpf)
        {
            if (cpf.Length == 14) // Valida o formato do CPF
            {
                return "XXX" + cpf.Substring(3, 3) + "." + cpf.Substring(9, 5) + "XX"; ;
            }
            else
            {
                return "CPF Inválido";
            }
        }

        // Função para verificar se o CPF é válido
        private bool IsValidCpf(string cpf)
        {
            return cpf.Length == 14; // Valida o formato do CPF (xxx-xxx-xxx-xx)
        }

        // Função para obter o ícone de acordo com a idade
        private string ObterIcone(int idade)
        {
            // Caminhos relativos para as imagens
            if (idade <= 12)
                return @"https://cdn-icons-png.flaticon.com/128/9136/9136536.png"; // Caminho para a imagem da criança
            else if (idade >= 60)
                return @"https://cdn-icons-png.flaticon.com/128/18612/18612539.png"; // Caminho para a imagem do idoso
            else if (idade >= 13 && idade <= 35)
                return @"https://cdn-icons-png.flaticon.com/128/4439/4439795.png"; // Caminho para a imagem do jovem
            else
                return @"https://cdn-icons-png.flaticon.com/128/6748/6748122.png"; // Caminho para a imagem do adulto
        }

        private void UpdateCardColor(string zona)
        {
            if (zona.Contains("Azul"))
                BackColor = System.Drawing.Color.LightBlue; // Cor para Zona Azul (Crianças)
            else if (zona.Contains("Verde"))
                BackColor = System.Drawing.Color.LightGreen; // Cor para Zona Verde (Idosos)
            else if (zona.Contains("Amarela"))
                BackColor = System.Drawing.Color.Yellow; // Cor para Zona Amarela (Jovens)
            else
                BackColor = System.Drawing.Color.Purple; // Cor para Zona Roxa (Adultos)
        }
    }
    
}
     