namespace Core.Entity
{
    public class Promocao : EntityBase
    {
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public int PercentualDesconto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativa { get; set; }
    }
}
