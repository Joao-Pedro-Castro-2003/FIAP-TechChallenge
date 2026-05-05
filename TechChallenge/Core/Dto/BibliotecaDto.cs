using Core.Entity;

namespace Core.Dto
{
    public class BibliotecaDto
    {
        public int UsuarioId { get; set; }
        public int JogoId { get; set; }
        public string NomeJogo { get; set; }
        public DateTime DataAquisicao { get; set; }
    }
}
