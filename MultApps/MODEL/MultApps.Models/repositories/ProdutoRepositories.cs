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
    public class ProdutoRepositories
    {
        private string ConnectionString = "Server=localhost;Database=multapps_dev;Uid=root;Pwd=root";

        public List<Categoria> ListarCategorias()
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var sql = "SELECT Id, Nome FROM categoria";
                return db.Query<Categoria>(sql).AsList();
            }
        }

        public bool CadastrarProduto(Produto produto)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                string sql = @"INSERT INTO Produto (Nome, Descricao, CategoriaId, Preco, QuantidadeEmEstoque, UrlImagem, Ativo)
                           VALUES (@Nome, @Descricao, @CategoriaId, @Preco, @QuantidadeEmEstoque, @UrlImagem, @Ativo)";
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

        public List<Produto> listarProduto()
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
                               Preco = @Preco, QuantidadeEmEstoque = @QuantidadeEmEstoque, 
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
            return listarProduto();
        }

        public bool DeletarPorNome(string nome)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"DELETE FROM produto WHERE Nome = @Nome";

                var parametros = new DynamicParameters();
                parametros.Add("@Nome", nome);

                var linhasAfetadas = db.Execute(comandoSql, parametros);
                return linhasAfetadas > 0;
            }
        }

        public DataTable ListarProdutoPorStatus(int status)
        {
            using (IDbConnection db = new MySqlConnection(ConnectionString))
            {
                var comandoSql = @"SELECT Id, Nome, Descricao, CategoriaId, Preco, QuantidadeEmEstoque, UrlImagem, Ativo 
                           FROM produto 
                           WHERE Ativo = @Status";

                var parametros = new DynamicParameters();
                parametros.Add("@Status", status);

                var produtos = db.Query<Produto>(comandoSql, parametros).ToList();

                var dataTable = new DataTable();
                dataTable.Columns.Add("Id", typeof(int));
                dataTable.Columns.Add("Nome", typeof(string));
                dataTable.Columns.Add("Descrição", typeof(string));
                dataTable.Columns.Add("CategoriaId", typeof(int));
                dataTable.Columns.Add("Preço", typeof(decimal));
                dataTable.Columns.Add("Estoque", typeof(int));
                dataTable.Columns.Add("Imagem", typeof(string));
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


      

       




    
    
