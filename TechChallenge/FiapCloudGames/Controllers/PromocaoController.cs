using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PromocaoController : ControllerBase
    {
        private IPromocaoRepository _promocaoRepository;
        public PromocaoController(IPromocaoRepository promocaoRepository)
        {
            _promocaoRepository = promocaoRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CriarPromocao([FromBody] PromocaoInput input)
        {
            try
            {
                var promocao = new Promocao
                {
                    JogoId = input.JogoId,
                    PercentualDesconto = input.PercentualDesconto,
                    DataInicio = input.DataInicio,
                    DataFim = input.DataFim,
                    Ativa = input.Ativa
                };

                _promocaoRepository.Cadastrar(promocao);
                return Ok("Promoção criada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
