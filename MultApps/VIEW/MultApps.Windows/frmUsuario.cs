using System;
using System.Windows.Forms;
using MultApps.Models;        
using MultApps.Controller;

namespace MultApps.Windows
{
    public partial class FrmUsuario : Form
    {
        private object chkAtivo;
        private object usuarioSelecionado;
        private object controller;

        public FrmUsuario()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0; // Todos
            AtualizarGrid();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            bool ativo = comboBox1.SelectedItem.ToString() == "Ativo";

            var usuario = new Usuario
            {
                NomeCompleto = txtNome.Text,
                CPF = txtCPF.Text,
                Email = txtEmail.Text,
                SenhaCriptografada = "MinhaSenhaSimples123!",
                DataCadastro = DateTime.Now,
                Ativo = ativo
            };

            if (usuarioSelecionado == null)
                controller.Adicionar(usuario);
            else
                controller.Atualizar(usuarioSelecionado, usuario);

            LimparCampos();
            AtualizarGrid();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (usuarioSelecionado != null)
            {
                controller.Remover(usuarioSelecionado);
                LimparCampos();
                AtualizarGrid();
            }
        }

        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            string status = comboBox1.SelectedItem.ToString();
            .DataSource = controller.FiltrarPorStatus(status);
        }

        private void AtualizarGrid()
        {
            dgvUsuarios.DataSource = null;
            dgvUsuarios.DataSource = controller.ObterTodos();
        }

        private void LimparCampos()
        {
            txtNome.Text = "";
            txtCPF.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            comboBox1.SelectedIndex = 0;
            usuarioSelecionado = null;
        }

        private void dgvUsuarios_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                usuarioSelecionado = dataGridView1.SelectedRows[0].DataBoundItem as Usuario;

                if (usuarioSelecionado != null)
                {
                    txtNome.Text = usuarioSelecionado.NomeCompleto;
                    txtCPF.Text = usuarioSelecionado.CPF;
                    txtEmail.Text = usuarioSelecionado.Email;
                    comboBox1.SelectedItem = usuarioSelecionado.Ativo ? "Ativo" : "Inativo";
                }
            }
        }
    }   
    }
}



