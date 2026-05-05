using Core.Entity;

namespace Core.Dto
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Biblioteca> Biblioteca { get; set; }
    }
}
