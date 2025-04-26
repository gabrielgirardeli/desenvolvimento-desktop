using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultApps.Models.Entities.Abstract
{
    public class Produtos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string UrlImagem { get; set; }
        public bool Ativo { get; set; }
    }
}
