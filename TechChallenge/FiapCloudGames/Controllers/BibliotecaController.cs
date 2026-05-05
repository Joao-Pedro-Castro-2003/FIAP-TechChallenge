using Core.Entity;
using Core.Input;
using Core.Repository;
using Infrastructure.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BibliotecaController : ControllerBase
    {
        private IBibliotecaRepository _bibliotecaRepository;
        public BibliotecaController(IBibliotecaRepository bibliotecaoRepository)
        {
            _bibliotecaRepository = bibliotecaoRepository;
        }

        [Authorize]
        [HttpPost]
        public IActionResult AdicionarJogoNaBibliotecaDoUsuarioLogado([FromBody] BibliotecaInput input)
        {
            try
            {
                var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

                _bibliotecaRepository.AdicionarJogo(usuarioId, input.JogoId);

                return Ok("Jogo adicionado a biblioteca");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("me")]
        public IActionResult BuscarBibliotecaDoUsuarioLogado()
        {
            var usuarioId = int.Parse(User.FindFirst(ClaimTypes.NameIdentifier)!.Value);

            return Ok(_bibliotecaRepository.ObterBibliotecaUsuario(usuarioId));
        }
    }
}
