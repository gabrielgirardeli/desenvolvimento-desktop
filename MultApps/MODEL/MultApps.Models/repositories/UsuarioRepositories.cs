using MultApps.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.repositories
{
    internal class UsuarioRepositories
    {
        internal class UsuarioRepository
        {
            private List<Usuario> usuarios = new List<Usuario>();

            public List<Usuario> ObterTodos() => usuarios;

            public void Adicionar(Usuario usuario) => usuarios.Add(usuario);

            public void Atualizar(Usuario usuarioAntigo, Usuario usuarioNovo)
            {
                int index = usuarios.IndexOf(usuarioAntigo);
                if (index >= 0)
                    usuarios[index] = usuarioNovo;
            }

            public void Remover(Usuario usuario) => usuarios.Remove(usuario);

            public List<Usuario> FiltrarPorStatus(string status)
            {
                if (status == "Ativos")
                    return usuarios.Where(u => u.Ativo).ToList();
                else if (status == "Inativos")
                    return usuarios.Where(u => !u.Ativo).ToList();
                else
                    return usuarios;
            }


        }
    }
}


