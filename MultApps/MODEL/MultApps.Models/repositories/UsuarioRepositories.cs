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


            public bool CadastrarUsuario(Usuario  usuario)
            {
                using (IDbConnection db = new MySqlConnection(ConnectionString))
                {
                    var comandoSql = @"INSERT INTO categoria (Nome, CPF, email, senha Status)  
                    VALUES(@Nome,@CPF,@Email ,@Senha @Status)";


                    var parametros = new DynamicParameters();
                    parametros.Add("@Nome", usuario.NomeCompleto);
                    parametros.Add("@CPF", usuario.CPF);
                    parametros.Add("Email", usuario.Email);
                    parametros.Add("Senha", usuario.Senha);
                    parametros.Add("@Status", usuario.Status.ToString());

                    var resultado = db.Execute(comandoSql, parametros);
                    return resultado > 0;
                }


            }
           
             public bool emailExiste(string email)
             {
                using(IDbConnection db = new MySqlConnection(ConnectionString))
                {
                  var comandoSql = @"SELECT COUNT(*) FROM usuario WHERE email = @Email";
                  var parametros = new DynamicParameters();
                  parametros.Add("@Email", email);
                  var resultado = db.ExecuteScalar<int>(comandoSql, parametros);
                 return resultado > 0;
                }
             }
        }
      


}

    





