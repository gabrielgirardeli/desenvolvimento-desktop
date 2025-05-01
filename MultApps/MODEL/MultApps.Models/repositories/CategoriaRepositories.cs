using Dapper;
using MultApps.Models.Entities;
using MySql.Data.MySqlClient;
using Mysqlx.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.repositories
{
    public class CategoriaRepositories
    {
        public string ConnectionString = "Server=localhost;Database=multapps_dev;Uid=root;Pwd=root";



        

        public List<Categoria> ListarCategorias()
        {
            using (var db = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT Id, Nome FROM categoria"; // Tabela no seu banco
                return db.Query<Categoria>(sql).ToList();
            }
        }







        public bool CadastrarCategoria(Categoria categoria)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"INSERT INTO categoria (Nome, Status)  
                    VALUES(@Nome, @Status)";


                var parametros = new DynamicParameters();
                parametros.Add("@Nome", categoria.Nome);
                parametros.Add("@Status", categoria.Status.ToString());

                var resultado = db.Execute(comandoSql, parametros);
                return resultado > 0;
            }
        }


        public bool AtualizarCategoria(Categoria categoria)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"UPDATE categoria  SET nome = @Nome, status = @status WHERE id = @Id";

                var parametros = new DynamicParameters();
                parametros.Add("@id", categoria.Id);
                parametros.Add("@nome", categoria.Nome);
                parametros.Add("@status", categoria.Status);

                var resposta = db.Execute(comandoSql);

                return resposta > 0;


            }


        }



        public bool DeletarCategoria(int id)
        {
             using (IDbConnection db= new MySqlConnection(ConnectionString))
             {
                var comandoSql = @"DELETE FROM categoria WHERE id = @id";


                var parametros = new DynamicParameters();
                parametros.Add("@Id", id);


                var resultado = db.Execute(comandoSql,parametros);
                return resultado > 0;

             }
        }



        public List<Categoria> ListarTodasCategoria()
        { 
            using (IDbConnection db = new MySqlConnection(ConnectionString)) 
            {
                var comandoSql = @"SELECT id, nome, DataCriacao AS DataCadastro,  DataAlteracao AS DataAlteracao, status
                                   FROM categoria";
            
                var resultado  = db.Query<Categoria>(comandoSql).ToList();
                return resultado;
            }
              
        }



        public Categoria ObterCategoriaPorId(int id)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT id, nome,  DataCriacao,  DataAlteracao, status
                                   FROM categoria WHERE id = @Id";
                var parametros = new DynamicParameters();
                parametros.Add("@Id", id);
                var resultado = db.Query<Categoria>(comandoSql, parametros).FirstOrDefault();
                return resultado;
            }
        }
    } 
}
