using Core.Entity;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapCloudGames.Tests.JogoTests
{
    public class JogoRepositoryTests
    {
        [Fact]
        public void ObterJogosDisponiveis_QuandoJogoTemPromocaoAtiva_DeveRetornarPrecoComDesconto()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(options);

            context.Jogo.Add(new Jogo
            {
                Id = 1,
                Nome = "FIFA 25",
                Preco = 100,
                DataCriacao = DateTime.Now
            });

            context.Promocao.Add(new Promocao
            {
                Id = 1,
                JogoId = 1,
                PercentualDesconto = 20,
                DataInicio = DateTime.Now.AddDays(-1),
                DataFim = DateTime.Now.AddDays(1),
                Ativa = true,
                DataCriacao = DateTime.Now
            });

            context.SaveChanges();

            var repository = new JogoRepository(context);

            var jogos = repository.ObterJogosDisponiveis();

            var jogo = jogos.First();

            Assert.True(jogo.PromocaoAtiva);
            Assert.Equal(20, jogo.PercentualDesconto);
            Assert.Equal(80, jogo.Preco);
        }

        [Fact]
        public void ObterJogosDisponiveis_QuandoNaoTemPromocaoAtiva_DeveRetornarPrecoOriginal()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(options);

            context.Jogo.Add(new Jogo
            {
                Id = 1,
                Nome = "Minecraft",
                Preco = 100,
                DataCriacao = DateTime.Now
            });

            context.SaveChanges();

            var repository = new JogoRepository(context);

            var jogos = repository.ObterJogosDisponiveis();

            var jogo = jogos.First();

            Assert.False(jogo.PromocaoAtiva);
            Assert.Null(jogo.PercentualDesconto);
            Assert.Equal(100, jogo.Preco);
        }
    }
}
