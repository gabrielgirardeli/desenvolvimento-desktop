using Dapper;
using MultApps.Models.Entities;
using MultApps.Models.Enums;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.repositories
{



    public class UsuarioRepositories
    {
        public string ConnectionString = "Server=localhost;Database=multapps_dev;Uid=root;Pwd=root";


        public bool CadastrarUsuario(Usuario usuario)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"INSERT INTO usuario (NomeCompleto, CPF, Email, Senha, status)  
                    VALUES(@NomeCompleto,@CPF,@Email ,@Senha, @status)";


                var parametros = new DynamicParameters();
                parametros.Add("@NomeCompleto", usuario.NomeCompleto);
                parametros.Add("@CPF", usuario.CPF);
                parametros.Add("@Email", usuario.Email);
                parametros.Add("@Senha", usuario.Senha);
                parametros.Add("@Status", usuario.Status);

                var resultado = db.Execute(comandoSql, parametros);
                return resultado > 0;
            }


        }

        public bool emailExiste(string email)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT COUNT(*) FROM usuario WHERE email = @Email";
                var parametros = new DynamicParameters();
                parametros.Add("@Email", email);
                var resultado = db.ExecuteScalar<int>(comandoSql, parametros);
                return resultado > 0;
            }
        }


        public DataTable listarUsuario()
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT id AS Id, 
                                          NomeCompleto AS NomeCompleto, 
                                          cpf AS CPF, 
                                          email AS Email, 
                                          DataCriacao AS DataCriacao,
                                         DataAlteracao AS DataAlteracao,
                                         DataAlteracao AS DataUltimoAcesso     
                                   FROM usuario";
                var usuarios = db.Query<Usuario>(comandoSql).ToList();
                // Converte a lista de usuários para um DataTable
                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nome", typeof(string));
                dataTable.Columns.Add("Cpf", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Data cadastro", typeof(DateTime));
                dataTable.Columns.Add("Data Alteracao", typeof(DateTime));
                dataTable.Columns.Add("Data ultimo acesso", typeof(DateTime));
                foreach (var usuario in usuarios)
                {
                    dataTable.Rows.Add(
                        usuario.Id,
                        usuario.NomeCompleto,
                        usuario.CPF,
                        usuario.Email,
                        usuario.DataCriacao,
                        usuario.DataAlteracao,
                        usuario.DataUltimoAcesso);
                }
                return dataTable;
            }

        }

        public DataTable listarUsuarioPorSatus(int status)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT id AS Id, 
                                          NomeCompleto AS NomeCompleto, 
                                          cpf AS CPF, 
                                          email AS Email, 
                                          DataCriacao AS DataCriacao,
                                         DataAlteracao AS DataAlteracao,
                                         DataAlteracao AS DataUltimoAcesso     
                                   FROM usuario
                                   WHERE status = @Status";
                var parametro = new DynamicParameters();
                parametro.Add("@Status", status);

                var usuarios = db.Query<Usuario>(comandoSql,parametro).ToList();
                // Converte a lista de usuários para um DataTable
                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nome", typeof(string));
                dataTable.Columns.Add("Cpf", typeof(string));
                dataTable.Columns.Add("Email", typeof(string));
                dataTable.Columns.Add("Data cadastro", typeof(DateTime));
                dataTable.Columns.Add("Data Alteracao", typeof(DateTime));
                dataTable.Columns.Add("Data ultimo acesso", typeof(DateTime));
                foreach (var usuario in usuarios)
                {
                    dataTable.Rows.Add(usuario.Id,
                        usuario.NomeCompleto,
                        usuario.CPF,
                        usuario.Email,
  
                        usuario.DataCriacao,
                        usuario.DataAlteracao,
                        usuario.DataUltimoAcesso);
                }
                return dataTable;
            }
        }


        public Usuario ObterCategoriaPorId(int id)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT id, nome,  DataCriacao,  DataAlteracao, status
                                   FROM categoria WHERE id = @Id";
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id);
                var resultado = db.Query<Usuario>(comandoSql, parametros).FirstOrDefault();
                return resultado;
            }
        }


    }
      


}

    





