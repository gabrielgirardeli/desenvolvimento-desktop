using Dapper;
using MultApps.Models.Entities;
using MultApps.Models.Entities.Abstract;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MultApps.Models.repositories
{
    public class ProdutoRepositories
    {
        private string ConnectionString = "Server=localhost;Database=multapps_dev;Uid=root;Pwd=root";

        public List<Categoria> ListarCategorias()
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT Id, Nome FROM categoria";
                return db.Query<Categoria>(sql).ToList();
            }
        }

        public bool CadastrarProduto(Produto produto)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = @"INSERT INTO Produto (Nome, Descricao, CategoriaId, Preco, Estoque, UrlImagem, Ativo)
                           VALUES (@Nome, @Descricao, @CategoriaId, @Preco, @Estoque, @UrlImagem, @Ativo)";
                int resultado = db.Execute(sql, produto);
                return resultado > 0;
            }
        }

        public bool ProdutoExiste(string nome)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT COUNT(*) FROM Produto WHERE Nome = @Nome";
                int count = db.ExecuteScalar<int>(sql, new { Nome = nome });
                return count > 0;
            }
        }

        public List<Produto> ListarProduto()
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM Produto";
                return db.Query<Produto>(sql).ToList();
            }
        }

        public Produto ObterProdutoPorId(int id)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = "SELECT * FROM Produto WHERE Id = @Id";
                return db.QueryFirstOrDefault<Produto>(sql, new { Id = id });
            }
        }

        public bool AtualizarProduto(Produto produto)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = @"UPDATE Produto 
                           SET Nome = @Nome, Descricao = @Descricao, CategoriaId = @CategoriaId, 
                               Preco = @Preco, Estoque = @Estoque, 
                               UrlImagem = @UrlImagem, Ativo = @Ativo
                           WHERE Id = @Id";
                int resultado = db.Execute(sql, produto);
                return resultado > 0;
            }
        }

        public bool DeletarProduto(int id)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = "DELETE FROM Produto WHERE Id = @Id";
                int resultado = db.Execute(sql, new { Id = id });
                return resultado > 0;
            }
        }

        public List<Produto> ListarTodos()
        {
            return ListarProduto();
        }

        public bool DeletarPorNome(string nome)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = "DELETE FROM Produto WHERE Nome = @Nome";
                int linhasAfetadas = db.Execute(sql, new { Nome = nome });
                return linhasAfetadas > 0;
            }
        }

        public DataTable ListarProdutoPorStatus(int status)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = @"SELECT Id, Nome, Descricao, CategoriaId, Preco, Estoque, UrlImagem, Ativo 
                           FROM Produto 
                           WHERE Ativo = @Status";

                var produtos = db.Query<Produto>(sql, new { Status = status }).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nome", typeof(string));
                dataTable.Columns.Add("Descricao", typeof(string));
                dataTable.Columns.Add("CategoriaId", typeof(int));
                dataTable.Columns.Add("Preco", typeof(decimal));
                dataTable.Columns.Add("Estoque", typeof(int));
                dataTable.Columns.Add("UrlImagem", typeof(string));
                dataTable.Columns.Add("Ativo", typeof(bool));

                foreach (var produto in produtos)
                {
                    dataTable.Rows.Add(
                        produto.Id,
                        produto.Nome,
                        produto.Descricao,
                        produto.CategoriaId,
                        produto.Preco,
                        produto.Estoque,
                        produto.UrlImagem,
                        produto.Ativo
                    );
                }

                return dataTable;
            }
        }
    }
}


      

       




    
    
