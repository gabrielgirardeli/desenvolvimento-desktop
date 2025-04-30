using MultApps.Models.Entities.Abstract;


namespace MultApps.Models.Entities
{
     public class Produto
    {
        public int Id { get; set; }
        public int CategoriaId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public string Descricao { get; set; }
        public string Categoria {  get; set; }
        public  string UrlImagem { get; set; }
        public bool  Ativo { get; set; }    


    }
}
