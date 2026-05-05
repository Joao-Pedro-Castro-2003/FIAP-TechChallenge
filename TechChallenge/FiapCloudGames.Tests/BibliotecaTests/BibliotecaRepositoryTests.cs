using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;

namespace FiapCloudGames.Tests.BibliotecaTests
{
    public class BibliotecaRepositoryTests
    {
        [Fact]
        public void AdicionarJogo_QuandoJogoJaExiste_DeveLancarExcecao()
        {
            //Gera um banco em memória sempre limpo e novo
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            //Cria o DbContext usando o banco em memória
            using var context = new ApplicationDbContext(options);

            //Cria o repository usando o banco em memória
            var repository = new BibliotecaRepository(context);

            repository.AdicionarJogo(1, 2);

            var exception = Assert.Throws<Exception>(() =>
                repository.AdicionarJogo(1, 2));

            Assert.Equal("Este jogo já está na biblioteca do usuário.", exception.Message);
        }

        [Fact]
        public void AdicionarJogo_QuandoValido_DeveAdicionarNaBiblioteca()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            using var context = new ApplicationDbContext(options);

            var repository = new BibliotecaRepository(context);

            repository.AdicionarJogo(1, 2);

            var existe = context.Biblioteca
                .Any(b => b.UsuarioId == 1 && b.JogoId == 2);

            Assert.True(existe);
        }
    }
}
