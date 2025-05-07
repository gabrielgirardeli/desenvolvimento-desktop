using MultApps.Models.Entities;
using MultApps.Models.repositories;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;

namespace MultApps.Windows
{
    public partial class frmGestao : Form
    {
        public frmGestao()
        {
            InitializeComponent();
           
            cmbCategoria.SelectedIndex = 0;
          

            cmbStatus.Items.Add("Todos");
            cmbStatus.Items.Add("Ativos");
            cmbStatus.Items.Add("Inativos");
            cmbStatus.SelectedIndex = 0;

        }


        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (TemCamposEmBranco()) return;
         


            try
            {
                var produto = new Produto
                {
                    Nome = txtNome.Text,
                    Descricao = txtDescricao.Text,
                    CategoriaId = Convert.ToInt32(cmbCategoria.SelectedValue),
                    Preco = decimal.Parse(txtPreco.Text),
                    Estoque = int.Parse(txtEstoque.Text),
                    UrlImagem = txtURL.Text,
                    Ativo = rbAtivo.Checked
                };

                var repo = new ProdutoRepositories();

                if (repo.ProdutoExiste(produto.Nome))
                {
                    MessageBox.Show($"Produto {produto.Nome} já está cadastrado.");
                    txtNome.Focus();
                    return;
                }

                if (repo.CadastrarProduto(produto))
                {
                    MessageBox.Show("Produto cadastrado com sucesso!");
                    AtualizarGrid();
                    limparCampos();
                }
                else
                {
                    MessageBox.Show("Erro ao cadastrar o produto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private bool TemCamposEmBranco()
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Campo Nome é obrigatório");
                txtNome.Focus(); return true;
            }

            if (string.IsNullOrWhiteSpace(txtDescricao.Text))
            {
                MessageBox.Show("Campo Descrição é obrigatório");
                txtDescricao.Focus(); return true;
            }

            if (cmbCategoria.SelectedIndex == -1)
            {
                MessageBox.Show("Selecione uma Categoria");
                cmbCategoria.Focus(); return true;
            }

            if (!decimal.TryParse(txtPreco.Text, out decimal preco) || preco <= 0)
            {
                MessageBox.Show("Preço inválido");
                txtPreco.Focus(); return true;
            }

            if (!int.TryParse(txtEstoque.Text, out int estoque) || estoque < 0)
            {
                MessageBox.Show("Estoque inválido");
                txtEstoque.Focus(); return true;
            }

            if (!rbAtivo.Checked && !rbInativo.Checked)
            {
                MessageBox.Show("Selecione o Status");
                return true;
            }

            return false;
        }

        private void AtualizarGrid()
        {
            var repo = new ProdutoRepositories();
            dataGridView1.DataSource = repo.ListarProduto();
        }

        private void limparCampos()
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtEstoque.Clear();
            cmbCadastraCategoria.Items.Clear();
            cmbCategoria.SelectedIndex = 0;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                MessageBox.Show("Clique inválido na linha.");
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            string nomeProduto = row.Cells["Nome"].Value.ToString();

            var repo = new ProdutoRepositories();
            var produto = repo.ListarTodos().FirstOrDefault(p => p.Nome == nomeProduto);

        

            if (produto == null)
            {
                MessageBox.Show($"Produto {nomeProduto} não encontrado.");
                return;
            }

            txtNome.Text = produto.Nome;
            cmbCategoria.SelectedValue = produto.CategoriaId;
            txtPreco.Text = produto.Preco.ToString("F2");
            txtEstoque.Text = produto.Estoque.ToString();

            btnSalvar.Text = "Salvar Alterações";
            btnLimpar.Enabled = true;
        }

        private void AddImageColumnToDataGridView()
        {
            DataGridViewImageColumn imageColumn = new DataGridViewImageColumn();
            imageColumn.Name = "Imagem";
            imageColumn.HeaderText = "Imagem";
            dataGridView1.Columns.Add(imageColumn);
        }



        private void frmGestao_Load(object sender, EventArgs e)
        {
         

            // só define o índice se houver itens
            if (cmbCadastraCategoria.Items.Count > 0)
                cmbCadastraCategoria.SelectedIndex = 0;

            CarregarTodosProdutos();

            cmbStatus.Items.Clear();
            cmbStatus.Items.Add("Todos");
            cmbStatus.Items.Add("Ativos");
            cmbStatus.Items.Add("Inativos");
            cmbStatus.SelectedIndex = 0;


        }


        private void CarregarTodosProdutos()
        {


            
        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            var produtoRepositories = new ProdutoRepositories();
            switch (cmbStatus.SelectedIndex)
            {



                case 0:
                    CarregarTodosProdutos();
                    break;


                case 1:
                    var produtoAtivos = produtoRepositories.ListarProdutoPorStatus(1);
                    dataGridView1.DataSource = produtoAtivos;
                    break;

                case 2:
                    var produtoInativos = produtoRepositories.ListarProdutoPorStatus(0);
                    dataGridView1.DataSource = produtoInativos;
                    break;
            }
       
        }
      

        private void btnDeletar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNome.Text))
            {
                MessageBox.Show("Selecione um usuário ou produto para deletar.");
                return;
            }

            var resultado = MessageBox.Show("Tem certeza que deseja deletar?", "Confirmação", MessageBoxButtons.YesNo);
            if (resultado == DialogResult.No)
                return;

            var repo = new ProdutoRepositories(); // ou UsuarioRepositories se for usuário
            bool sucesso = repo.DeletarPorNome(txtNome.Text); // ou por ID, dependendo da lógica

            if (sucesso)
            {
                MessageBox.Show("Item deletado com sucesso.");
                limparCampos();
                AtualizarGrid(); // ou CarregarTodosProdutos()
            }
            else
            {
                MessageBox.Show("Erro ao deletar.");
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtNome.Clear();
            txtDescricao.Clear();
            txtPreco.Clear();
            txtEstoque.Clear();
            txtURL.Clear();

            cmbCategoria.SelectedIndex = -1; 
            cmbCadastraCategoria.SelectedIndex = -1;

            rbAtivo.Checked = false;
            rbInativo.Checked = false;

            txtNome.Focus();
        }
       
            
          
        }

    }



