namespace Core.Dto
{
    public class JogoDisponivelDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public decimal Preco { get; set; }
        public bool PromocaoAtiva { get; set; }
        public int? PercentualDesconto { get; set; }
    }
}
