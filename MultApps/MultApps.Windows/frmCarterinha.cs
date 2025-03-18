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
                picIcone.ImageLocation = icone; // Caminho do ícone
            }
            else
            {
                MessageBox.Show("Por favor, insira dados válidos.");
            }
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
                return cpf.Substring(0, 3) + ".XXX.XXX." + cpf.Substring(7, 3) + "-XX";
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
            if (idade <= 12)
                return @"C:\Imagens\criança.png"; // Caminho do ícone para criança
            else if (idade >= 60)
                return @"C:\Imagens\idoso.png"; // Caminho do ícone para idoso
            else if (idade >= 13 && idade <= 35)
                return @"C:\Imagens\jovem.png"; // Caminho do ícone para jovem
            else
                return @"C:\Imagens\adulto.png"; // Caminho do ícone para adulto
        }

        // Função para atualizar a cor de fundo da carteirinha com base na zona
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
     