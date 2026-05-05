using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository;
        public JogoController(IJogoRepository jogoRepository)
        {
            _jogoRepository = jogoRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CadastrarJogo([FromBody] JogoInput jogoInput)
        {
            try
            {
                var jogo = new Jogo()
                {
                    Nome = jogoInput.Nome,
                    Preco = jogoInput.Preco
                };
                _jogoRepository.Cadastrar(jogo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeletarJogo([FromRoute] int id)
        {
            try
            {
                _jogoRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpGet]
        public IActionResult BuscarJogos()
        {
            try
            {
                var jogos = _jogoRepository.ObterJogosDisponiveis();
                return Ok(jogos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
