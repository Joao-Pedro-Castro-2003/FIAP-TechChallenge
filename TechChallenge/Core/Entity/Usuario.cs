namespace Core.Entity
{
    public class Usuario : EntityBase
    {
        public required string Nome { get; set; }
        public required string Email { get; set; }
        public required string Senha { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<Biblioteca> Biblioteca { get; set; }
    }
}
