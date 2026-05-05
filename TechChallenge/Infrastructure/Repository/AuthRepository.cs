using Core.Entity;
using Core.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Core.Dto;
using Core.Input;

namespace Infrastructure.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public string Login(LoginInput input)
        {
            var usuario = _context.Usuario
                .FirstOrDefault(x => x.Email == input.Email);

            if (usuario == null || usuario.Senha != input.Senha)
                throw new UnauthorizedAccessException("Email ou senha inválidos");

            return GerarToken(usuario);
        }

        private string GerarToken(Usuario usuario)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.IsAdmin ? "Admin" : "Comum")
            };

            var chave = _configuration["Jwt:Key"];

            if(string.IsNullOrEmpty(chave))
                throw new Exception("Chave JWT não configurada");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(chave));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
