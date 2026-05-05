using Core.Entity;
using Core.Input;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace FiapCloudGames.Tests.AuthTests
{
    public class AuthRepositoryTests
    {
        private static IConfiguration CriarConfiguracaoJwt()
        {
            var dados = new Dictionary<string, string?>
            {
                { "Jwt:Key", "minha-chave-super-secreta-para-testes-jwt-2026" },
                { "Jwt:Issuer", "FiapCloudGames" },
                { "Jwt:Audience", "FiapCloudGames" }
            };

            return new ConfigurationBuilder()
                .AddInMemoryCollection(dados)
                .Build();
        }

        [Fact]
        public void Login_QuandoCredenciaisInvalidas_DeveLancarUnauthorizedAccessException()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(options);

            context.Usuario.Add(new Usuario
            {
                Id = 1,
                Nome = "João",
                Email = "joao@fiap.com",
                Senha = "Senha@123",
                IsAdmin = false,
                DataCriacao = DateTime.Now
            });

            context.SaveChanges();

            var repository = new AuthRepository(context, CriarConfiguracaoJwt());

            var input = new LoginInput
            {
                Email = "joao@fiap.com",
                Senha = "senhaerrada"
            };

            var exception = Assert.Throws<UnauthorizedAccessException>(() =>
                repository.Login(input));

            Assert.Equal("Email ou senha inválidos", exception.Message);
        }

        [Fact]
        public void Login_QuandoCredenciaisValidas_DeveRetornarTokenJwt()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(options);

            context.Usuario.Add(new Usuario
            {
                Id = 1,
                Nome = "Admin",
                Email = "admin@fiap.com",
                Senha = "Senha@123",
                IsAdmin = true,
                DataCriacao = DateTime.Now
            });

            context.SaveChanges();

            var repository = new AuthRepository(context, CriarConfiguracaoJwt());

            var input = new LoginInput
            {
                Email = "admin@fiap.com",
                Senha = "Senha@123"
            };

            var token = repository.Login(input);

            Assert.False(string.IsNullOrWhiteSpace(token));

            var jwt = new JwtSecurityTokenHandler().ReadJwtToken(token);

            Assert.Equal("FiapCloudGames", jwt.Issuer);
            Assert.Contains(jwt.Claims, c => c.Type.Contains("role") && c.Value == "Admin");
            Assert.Contains(jwt.Claims, c => c.Type.Contains("emailaddress") && c.Value == "admin@fiap.com");
        }
    }
}