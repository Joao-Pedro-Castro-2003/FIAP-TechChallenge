using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FiapCloudGames.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginInput input)
        {
            try
            {
                var token = _authRepository.Login(input);
                return Ok(token);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
