using MultApps.Models.Entities;
using MultApps.Models.repositories;
using MultApps.Models.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultApps.Windows
{
    public partial class frmSistema : Form
    {
        public frmSistema()
        {
            InitializeComponent();
        }

        private void btnEntra_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtUsuario.Text))
            {
                MessageBox.Show("Usuario é obrigatorio");
                txtUsuario.Focus();
                return;

            }

            if(string.IsNullOrEmpty (txtSenha.Text))
            {
                MessageBox.Show("senha é obrigatorio");
                txtSenha.Focus();
                return;
            }


            var usuarioRepositories = new UsuarioRepositories();
            var usuario = usuarioRepositories.ObterUsuarioPorEmail(txtUsuario.Text);

            if (usuario == null || usuario.Email != txtUsuario.Text)
            {
                MessageBox.Show(" Usuario não encontrado");
                txtUsuario.Focus();
                return;
            }

            if (usuario.Status == Models.Enums.StatusEnum.inativo)
            {
                MessageBox.Show("O usuario está inativo");
                txtSenha.Focus();
                return;

            }



            var senhaConfere = CriptografiaService.Verificar(txtSenha.Text, usuario.Senha);

            if (senhaConfere)
            {
                var formPrincipal = new Principal(usuario);
                formPrincipal.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario ou senha invalida");
            }
        }

        private void btnRecuperar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty (txtUsuario.Text))
            {
                MessageBox.Show("Informe  o email do seu usuario");
                txtUsuario.Focus ();
                return;
            }


            var usuarioRepositories = new UsuarioRepositories();


            var novaSenha  = CriptografiaService.Criptografar("123456");

            var senhaAtualizou = usuarioRepositories.AtualizarSenha(novaSenha, txtUsuario.Text);

            if(senhaAtualizou)
            {
                MessageBox.Show($"Senha atualizou com sucesso. A nova senha é: 123456");
            }
            else
            {
                MessageBox.Show("erro ao atualizar a senha");
            }
        }
    }
}
