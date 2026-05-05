namespace Core.Entity
{
    public class Jogo : EntityBase
    {
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public ICollection<Promocao> Promocoes { get; set; }
        public ICollection<Biblioteca> Biblioteca { get; set; }
    }
}
