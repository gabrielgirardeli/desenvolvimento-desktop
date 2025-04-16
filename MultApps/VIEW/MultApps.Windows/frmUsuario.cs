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
            _usuarioRepo = new UsuarioRepositories();
            CarregarFiltroStatus();
            CarregarTodosUsuarios();
         
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            var usuario = new Usuario();
            usuario.NomeCompleto = txtNome.Text;
            usuario.CPF = txtCPF.Text;
            usuario.Email = txtEmail.Text;
            usuario.Senha = txtSenha.Text;
            usuario.Status = (StatusEnum)comboBox1.SelectedIndex;

            var UsuarioRepositories = new UsuarioRepositories();
            
            if (string.IsNullOrEmpty(txtID.Text))
            {

                var resposta = UsuarioRepositories.CadastrarUsuario(usuario);

                if (resposta)
                {
                    MessageBox.Show("Usuário cadastrado com sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar usuário");
                }
            }
            else
            {
                usuario.Id = int.Parse(txtID.Text);
                var resposta = UsuarioRepositories.AtualizarUsuario(usuario);

                if (resposta)
                {
                    MessageBox.Show("Categoria atualizada com sucesso");
                }
                else
                {
                    MessageBox.Show("erro ao atualzar categoria");
                }

            }
           



            bool resultado = _usuarioRepo.CadastrarUsuario(usuario);

            if (resultado)
            {
                MessageBox.Show("Usuário cadastrado com sucesso!");
                LimparCampos();
                CarregarTodosUsuarios();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar usuário.");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimparCampos();
        }

        private void LimparCampos()
        {
            txtID.Clear();
            txtNome.Clear();
            txtCPF.Clear();
            txtEmail.Clear();
            txtSenha.Clear();
            txtDataCriacao.Clear();
            txtDataAlteracao.Clear();
            cbmFiltra.SelectedIndex = -1;
            btnSalvar.Text = "Salvar";
        }

        private void CarregarFiltroStatus()
        {
            cbmFiltra.Items.Clear();
            cbmFiltra.Items.Add("Todos");
            cbmFiltra.Items.Add("Ativo");
            cbmFiltra.Items.Add("Inativo");
            cbmFiltra.Items.Add("Excluido");
            cbmFiltra.SelectedIndex = 0;

            comboBox1.Items.Clear();
            comboBox1.Items.Add("Inativo");
            comboBox1.Items.Add("Ativo");
            comboBox1.Items.Add("Excluido");
        }



        private void cmbFiltroStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            CarregarTodosUsuarios();

            if (cbmFiltra.SelectedItem == null)
            {
                MessageBox.Show("Selecione um status para filtrar os usuários.");
                return;
            }
        }

        private void CarregarTodosUsuarios()
        {
            List<Usuario> usuarios;
            var filtro = cbmFiltra.SelectedItem.ToString();

            switch (filtro)
            {
                case "Ativo":
                    usuarios = _usuarioRepo.FiltrarUsuariosPorStatus(StatusEnum.Ativo);
                    break;
                case "Inativo":
                    usuarios = _usuarioRepo.FiltrarUsuariosPorStatus(StatusEnum.Inativo);
                    break;
                case "Excluido":
                    usuarios = _usuarioRepo.FiltrarUsuariosPorStatus(StatusEnum.Excluido);
                    break;
                default:
                    usuarios = _usuarioRepo.ListarTodosUsuarios(); 
                    break;
            }



            if (usuarios == null || usuarios.Count == 0)
            {
                MessageBox.Show("Nenhum usuário encontrado com o filtro selecionado.");
            }
            else
            {
                dataGridView1.DataSource = usuarios;
            }

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "Id"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "NomeCompleto",
                HeaderText = "Nome"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "CPF",
                HeaderText = "CPF"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Email",
                HeaderText = "Email"
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataCriacao",
                HeaderText = "Data de Criação",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataAlteracao",
                HeaderText = "Última Alteração",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:mm" }
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status"
            });

            dataGridView1.DataSource = usuarios;
        }

        private void dataGridViewUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridView1.Rows[e.RowIndex];
            int id = (int)row.Cells[0].Value;

            var usuario = _usuarioRepo.ObterUsuarioPorId(id);

            if (usuario == null)
            {
                MessageBox.Show($"Usuário com ID {id} não encontrado.");
                return;
            }

            txtID.Text = usuario.Id.ToString();
            txtNome.Text = usuario.NomeCompleto;
            txtCPF.Text = usuario.CPF;
            txtEmail.Text = usuario.Email;
            txtSenha.Text = usuario.Senha;
            txtDataCriacao.Text = usuario.DataCriacao.ToString("dd/MM/yyyy HH:mm");
            txtDataAlteracao.Text = usuario.DataAlteracao?.ToString("dd/MM/yyyy HH:mm");
            cbmFiltra.SelectedIndex = (int)usuario.Status;

            btnSalvar.Text = "Salvar Alterações";
        }

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            try
            {

                int usuarioId = Convert.ToInt32(txtID.Text);


                var usuarioRepo = new UsuarioRepositories();
                bool sucesso = usuarioRepo.DeletarUsuario(usuarioId);

                if (sucesso)
                {
                    MessageBox.Show("Usuário deletado com sucesso!");
                    AtualizarListaUsuarios();
                }
                else
                {
                    MessageBox.Show("Erro ao deletar o usuário. Tente novamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void AtualizarListaUsuarios()
        {
            var usuarioRepo = new UsuarioRepositories();
            var usuarios = usuarioRepo.ObterUsuarios();
            dataGridView1.DataSource = usuarios;
        }

        private void dataGridViewUsuarios_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var row = dataGridView1.Rows[e.RowIndex];
            var id = (int)row.Cells[0].Value;

            var usuario = _usuarioRepo.ObterUsuarioPorId(id);

            if (usuario == null)
            {
                MessageBox.Show($"Usuário com ID {id} não encontrado.");
                return;
            }

            txtID.Text = usuario.Id.ToString();
            txtNome.Text = usuario.NomeCompleto;
            txtCPF.Text = usuario.CPF;
            txtEmail.Text = usuario.Email;
            txtSenha.Text = usuario.Senha;
            txtDataCriacao.Text = usuario.DataCriacao.ToString("dd/MM/yyyy HH:mm");
            txtDataAlteracao.Text = usuario.DataAlteracao?.ToString("dd/MM/yyyy HH:mm");
            cbmFiltra.SelectedIndex = (int)usuario.Status;

            btnSalvar.Text = "Salvar Alterações";
            btnExcluir.Enabled = true;
        }

      
    }
}



