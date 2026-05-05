using Core.Dto;
using Core.Entity;

namespace Core.Repository
{
    public interface IJogoRepository : IRepository<Jogo>
    {
        ICollection<JogoDisponivelDto> ObterJogosDisponiveis();
    }
}
