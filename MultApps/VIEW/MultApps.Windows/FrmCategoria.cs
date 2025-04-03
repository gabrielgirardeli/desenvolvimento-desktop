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
        public FrmCategoria()
        {
            InitializeComponent();
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


        }
    }
}
