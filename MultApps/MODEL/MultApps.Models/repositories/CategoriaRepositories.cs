using Dapper;
using MultApps.Models.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.repositories
{
    public class CategoriaRepositories
    {
        public string ConnectionString = "Server=localhost;Database=multapps_dev;Uid=root;Pwd=root";


        public bool CadastrarCategoria(Categoria categoria)
        {
          using (IDbConnection db = new  MySqlConnection(ConnectionString))
          {
                var comandoSql = @"INSERT INTO categoria (Nome, Status)  
                    VALUES(@Nome, @Status)";
                                  

                var parametros = new DynamicParameters();
                parametros.Add("@Nome", categoria.Nome);
                parametros.Add("@Status", categoria.Status);
                
                var resultado = db.Execute(comandoSql,parametros);
                return resultado > 0;
          }
        }
    } 
}
