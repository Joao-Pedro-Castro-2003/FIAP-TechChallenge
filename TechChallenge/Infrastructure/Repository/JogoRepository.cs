using Core.Dto;
using Core.Entity;
using Core.Repository;

namespace Infrastructure.Repository
{
    public class JogoRepository : EFRepository<Jogo>, IJogoRepository
    {
        private readonly ApplicationDbContext _context;
        public JogoRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public ICollection<JogoDisponivelDto> ObterJogosDisponiveis()
        {
            var hoje  = DateTime.Now;

            var jogos = _context.Jogo
                .Select(j => new
                {
                    j.Id,
                    j.Nome,
                    j.Preco,
                    Promocao = _context.Promocao
                        .Where(p => p.JogoId == j.Id &&
                                    p.Ativa &&
                                    p.DataInicio <= hoje &&
                                    p.DataFim >= hoje)
                        .Select(p => new
                        {
                            p.PercentualDesconto
                        })
                        .FirstOrDefault()
                })
                .ToList()
                .Select(j => new JogoDisponivelDto
                {
                    Id = j.Id,
                    Nome = j.Nome,
                    PromocaoAtiva = j.Promocao != null,
                    PercentualDesconto = j.Promocao?.PercentualDesconto,
                    Preco = j.Promocao == null
                        ? j.Preco
                        : j.Preco - (j.Preco * j.Promocao.PercentualDesconto / 100)
                })
                .ToList();

            return jogos;
        }
    }
}
