using MultApps.Models.Entities.Abstract;


namespace MultApps.Models.Entities
{
    internal class Produto : EntidadesBase
    {
        public int  CategoriaId { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int  QuantidadeEmEstoque { get; set; }
      

    }
}
