using MultApps.Models.Entities;
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
    public partial class Principal : Form
    {
        public Usuario Usuariologado { get; set; }
        public Principal()
        {
            InitializeComponent();
        }
         public Principal(Usuario usuario)
        {
            InitializeComponent();
            Usuariologado = usuario;
        }

        private void menuCalculadoraImc_Click(object sender, EventArgs e)
        {
          
            var form = new FrmCalculadoraIMC();
            form.MdiParent = this;
            form.Show();

        }

        private void Principal_Load(object sender, EventArgs e)
        {
            statusLabelUsuario.Text = Usuariologado.NomeCompleto;
        }
    }
    




 }

