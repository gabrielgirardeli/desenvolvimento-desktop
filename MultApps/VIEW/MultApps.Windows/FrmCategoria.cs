using MultApps.Models.Entities;
using MultApps.Models.Enums;
using MultApps.Models.repositories;
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
    public partial class FrmCategoria : Form
    {
        private object txtDataCadastro;

        public FrmCategoria()
        {
            InitializeComponent();
            CarregarTodasCategoria();
            this.KeyPreview = true;

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            var categoriaRepositories = new CategoriaRepositories();

            var categoria = new Categoria();
            categoria.Nome = txtNome.Text;
            categoria.Status = (StatusEnum)cmbStatus.SelectedIndex;

            var CategoriaRepositories = new CategoriaRepositories();
            var Resultado = CategoriaRepositories.CadastrarCategoria(categoria);
            if (Resultado)
            {
                MessageBox.Show("Categoria cadastra com sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar categoria");
            }
            CarregarTodasCategoria();

        }
        private void CarregarTodasCategoria()
        {
            var categoriaRepositories = new CategoriaRepositories();
            var listaDeCategorias = categoriaRepositories.ListarTodasCategoria();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Columns.Clear();

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id",
                HeaderText = "ID",

            });


            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Nome",
                HeaderText = "Nome da categoria",

            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataCadastro",
                HeaderText = "Data de Cadastro",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:MM" },
                MinimumWidth = 200
            });

            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "DataAlteracao",
                HeaderText = "Data de Alteracao",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy HH:MM" },
                MinimumWidth = 200
            });


            dataGridView1.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Status",
                HeaderText = "Status"

            });


            dataGridView1.DataSource = listaDeCategorias;
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;


        }

        private void FrmCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {

                CarregarTodasCategoria();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].DataPropertyName == "Status")
            {
                if (e.Value != null)
                {
                    StatusEnum status = (StatusEnum)e.Value;
                    switch (status)
                    {
                        case StatusEnum.inativo:
                            e.CellStyle.ForeColor = Color.Gray;
                            break;
                        case StatusEnum.ativo:
                            e.CellStyle.ForeColor = Color.Blue;
                            break;
                        case StatusEnum.excluido:
                            e.CellStyle.ForeColor = Color.Red;
                            break;
                    }
                }
            }
        }







        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtId.Text = string.Empty;
            txtNome.Text = string.Empty;
            txtDataCadastro.Text = string.Empty;
            txtDataAlteracao.Text = string.Empty;
            cmbStatus.SelectedIndex = -1;
        }
    }
    }
    

