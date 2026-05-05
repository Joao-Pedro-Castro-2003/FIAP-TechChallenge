using Core.Dto;

namespace Core.Repository
{
    public interface IBibliotecaRepository 
    {
        void AdicionarJogo(int usuarioId, int jogoId);
        ICollection<BibliotecaDto> ObterBibliotecaUsuario(int usuarioId);
    }
}
