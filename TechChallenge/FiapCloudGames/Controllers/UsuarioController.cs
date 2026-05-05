using Core.Dto;
using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CadastrarUsuario([FromBody] UsuarioInput usuarioInput)
        {
            try
            {
                var usuario = new Usuario()
                {
                    Nome = usuarioInput.Nome,
                    Email = usuarioInput.Email,
                    Senha = usuarioInput.Senha
                };
                _usuarioRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult BuscarTodosUsuarios()
        {
            try
            {
                var usuariosDto = new List<UsuarioDto>();
                var usuarios = _usuarioRepository.ObterTodos();

                foreach (var usuario in usuarios)
                {
                    usuariosDto.Add(new UsuarioDto()
                    {
                        Id = usuario.Id,
                        DataCriacao = usuario.DataCriacao,
                        Nome = usuario.Nome,
                        Email = usuario.Email,
                        Senha = usuario.Senha
                    });
                }
                return Ok(usuariosDto);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("{id:int}")]
        public IActionResult BuscarUsuarioPorId([FromRoute] int id)
        {
            try
            {
                return Ok(_usuarioRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPut]
        public IActionResult AtualizarUsuario([FromBody] UsuarioUpdateInput input)
        {
            try
            {
                var usuario = _usuarioRepository.ObterPorId(input.Id);
                usuario.Nome = input.Nome;
                usuario.Email = input.Email;
                usuario.Senha = input.Senha;
                _usuarioRepository.Alterar(usuario);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id:int}")]
        public IActionResult DeletarUsuario([FromRoute] int id)
        {
            try
            {
                _usuarioRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
