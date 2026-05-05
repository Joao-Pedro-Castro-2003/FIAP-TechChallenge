namespace Core.Entity
{
    public class Biblioteca
    {
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public int JogoId { get; set; }
        public Jogo Jogo { get; set; }
        public DateTime DataAquisicao { get; set; }
    }
}
