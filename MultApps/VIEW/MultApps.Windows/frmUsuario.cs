using System;
using System.Windows.Forms;
using MultApps.Models;        
using MultApps.Controller;
using MultApps.Models.Enums;
using MultApps.Models.repositories;
using System.Collections.Generic;
using MultApps.Models.Entities;
using System.Diagnostics.Eventing.Reader;
using MultApps.Models.Services;


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
            cbmFiltra.SelectedIndex = 0;
          
          
         
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                
                
                var usuario = new Usuario(); 
                usuario.NomeCompleto = txtNome.Text;
                usuario.CPF = mskCPF.Text;
                usuario.Email = txtEmail.Text;
                usuario.Senha = CriptografiaService.Criptografar(txtSenha.Text);
                usuario.Status = (StatusEnum)cmbStatus.SelectedIndex;

                var usuarioRepositories = new UsuarioRepositories();



                // Verifica se o email já existe.
                var emailJaExiste = usuarioRepositories.emailExiste(usuario.Email);
                if (emailJaExiste)
                {
                    MessageBox.Show($"O email {usuario.Email} já está cadastrado.");
                    txtEmail.Focus();
                    return;
                }

                var sucesso = usuarioRepositories.CadastrarUsuario(usuario);


                if (sucesso)
                {
                    MessageBox.Show($"Usuario {usuario.NomeCompleto} cadastra com sucesso!");
                    CarregarTodosUsuario();
                    limparCampos();
                }
                else
                {

                    MessageBox.Show($"Erro ao cadastrar o usuário {usuario.NomeCompleto}");
                  
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }

         

          




           

        }

        private bool TemCamposEmBranco()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))  
            {
                MessageBox.Show("compo nome é obrigatorio");
                txtNome.Focus();
                return true;
                
             }


            if (string.IsNullOrWhiteSpace(mskCPF.Text)) 
            {
                MessageBox.Show("compo CPF é obrigatorio");
                mskCPF.Focus();
                return true;

            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text)) 
            {
                MessageBox.Show("compo nome é obrigatorio");
                txtEmail.Focus();
                return true;

            }

            if (string.IsNullOrWhiteSpace(txtSenha.Text)) 
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
            mskCPF.Clear();
            txtEmail.Clear();
            txtNome.Clear();
            txtSenha.Clear();
            cbmFiltra.SelectedIndex = 1;
            txtDataCriacao.Clear();
            txtDataAlteracao.Clear();

        }

        private void cbmFiltra_SelectedIndexChanged(object sender, EventArgs e)
        {
            var usuarioRepositorio = new UsuarioRepositories();
            switch (cbmFiltra.SelectedIndex)
            {

                case 0:
                    CarregarTodosUsuario();
                    break;


                    case 1:
                    var usuariosAtivos = usuarioRepositorio.listarUsuarioPorSatus(1);
                    dataGridView1.DataSource = usuariosAtivos;
                    break;

                    case 2:
                    var usuariosInativos = usuarioRepositorio.listarUsuarioPorSatus(0);
                    dataGridView1.DataSource = usuariosInativos;
                    break;

                   
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
            {
                MessageBox.Show($"Houve um erro ao clicar duas vezes sobre o Grid");
                return;
            }

            // Obtenha a linha selecionada
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

            // Obtenha o ID da categoria da linha selecionada
            var usuarioId = (int)row.Cells[0].Value;

            // Use o método ObterCategoriaPorId para buscar os dados da categoria no banco de dados
            var usuarioRepositories = new UsuarioRepositories();
            var usuario = usuarioRepositories.ObterUsuarioPorId(usuarioId);

            if (usuario == null)
            {
                MessageBox.Show($"Categoria: #{usuarioId} não encontrada");
                return;
            }
            // Preencha os campos de edição com os dados obtidos
            txtID.Text = usuario.Id.ToString();
            txtNome.Text = usuario.NomeCompleto;
            mskCPF.Text = usuario.CPF;
            cmbStatus.SelectedIndex = (int)usuario.Status;
            txtDataCriacao.Text = usuario.DataCriacao.ToString("dd/MM/yyyy HH:mm");
            txtDataAlteracao.Text = usuario.DataAlteracao.ToString("dd/MM/yyyy HH:mm");

            btnExcluir.Enabled = true;
            btnSalvar.Text = "salvar alteracao";

        }


    }
}



