using Core.Entity;

namespace Core.Input
{
    public class PromocaoInput
    {
        public int JogoId { get; set; }
        public int PercentualDesconto { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public bool Ativa { get; set; }
    }
}
