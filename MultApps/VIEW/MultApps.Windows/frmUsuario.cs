using System;
using System.Windows.Forms;
using MultApps.Models;        
using MultApps.Controller;
using MultApps.Models.Enums;
using MultApps.Models.repositories;
using System.Collections.Generic;
using MultApps.Models.Entities;
using System.Diagnostics.Eventing.Reader;


namespace MultApps.Windows
{
    public partial class FrmUsuario : Form
    {
        private readonly UsuarioRepositories _usuarioRepo;

        public FrmUsuario()
        {
            InitializeComponent();
            var status = new[] { "inativo", "ativo" };
            var filtros = new[] { "todos", "ativos", "inativos" };
            cmbStatus.Items.AddRange(status);
            cbmFiltra.Items.AddRange(filtros);
            cmbStatus.SelectedIndex = 1;
          
          
         
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                var usuario = new Usuario(); 
                usuario.NomeCompleto = txtNome.Text;
                usuario.CPF = txtCPF.Text;
                usuario.Email = txtEmail.Text;
                usuario.Senha = txtSenha.Text;
                usuario.Status = (StatusEnum)cmbStatus.SelectedIndex;

                var usuarioRepositories = new UsuarioRepositories();
                

                var resultado = usuarioRepositories.CadastrarUsuario(usuario);


                if (TemCamposEmBranco())
                {
                    MessageBox.Show($"Usuario {usuario.NomeCompleto} cadastra com sucesso!");
                }
                else
                {

                    MessageBox.Show($"Erro ao cadastrar o usuário {usuario.NomeCompleto}");
                    CarregarTodosUsuario();
                    limparCampos();
                }
            }
            catch (Exception)
            {

                throw;
            }

         

          




           

        }

        private bool TemCamposEmBranco()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))  return true;
            {
                MessageBox.Show("compo nome é obrigatorio");
                txtNome.Focus();
                return true;
                
             }


            if (string.IsNullOrWhiteSpace(txtCPF.Text)) return true;
            {
                MessageBox.Show("compo CPF é obrigatorio");
                txtCPF.Focus();
                return true;

            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text)) return true;
            {
                MessageBox.Show("compo nome é obrigatorio");
                txtEmail.Focus();
                return true;

            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text)) return true;
            {
                MessageBox.Show("compo nome é obrigatorio");
                txtSenha.Focus();
                return true;

            }

            if (cmbStatus.SelectedIndex == -1)
            {
                MessageBox.Show("compo Status é obrigatorio");
                cmbStatus.Focus();
                return true;
            }
            return false;


        }

        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            CarregarTodosUsuario();
        }

        private void  CarregarTodosUsuario()
        {
            var usuarioRepositorio = new UsuarioRepositories();
            var listarUsuario = usuarioRepositorio.listarUsuario();
            dataGridView1.DataSource = listarUsuario;
        }

        private void limparCampos()
        {
            txtCPF.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            cbmFiltra.SelectedIndex = 1;
            txtDataCriacao.Clear();
            txtDataAlteracao.Clear();

        }

    }
}



