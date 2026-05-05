using Core.Dto;
using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{ 
    public class BibliotecaRepository : IBibliotecaRepository
    {
        private readonly ApplicationDbContext _context;

        public BibliotecaRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AdicionarJogo(int usuarioId, int jogoId)
        {
            if(UsuarioPossuiJogo(usuarioId, jogoId))
                throw new Exception("Este jogo já está na biblioteca do usuário.");

            var biblioteca = new Biblioteca
            {
                UsuarioId = usuarioId,
                JogoId = jogoId,
                DataAquisicao = DateTime.Now
            };

            _context.Add(biblioteca);
            _context.SaveChanges();
        }

        public ICollection<BibliotecaDto> ObterBibliotecaUsuario(int usuarioId)
        {
            return _context.Biblioteca
                .Where(b => b.UsuarioId == usuarioId)
                .Select(b => new BibliotecaDto
                {
                    UsuarioId = b.UsuarioId,
                    JogoId = b.JogoId,
                    NomeJogo = b.Jogo.Nome,
                    DataAquisicao = b.DataAquisicao
                })
                .ToList(); 
        }

        public bool UsuarioPossuiJogo(int usuarioId, int jogoId)
        {
            return _context.Biblioteca
                .Any(b => b.UsuarioId == usuarioId && b.JogoId == jogoId);
        }
    }
}
