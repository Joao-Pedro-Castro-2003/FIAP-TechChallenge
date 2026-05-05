using Core.Input;
using FiapCloudGames.Validators;
using FluentValidation.TestHelper;

namespace FiapCloudGames.Tests.UsuarioTests
{
    public class UsuarioInputValidatorTests
    {
        [Fact]
        public void Usuario_QuandoSenhaFraca_DeveSerInvalido()
        {
            var validator = new UsuarioInputValidator();

            var input = new UsuarioInput
            {
                Nome = "João",
                Email = "joao@fiap.com",
                Senha = "12345678"
            };

            var result = validator.TestValidate(input);

            result.ShouldHaveValidationErrorFor(x => x.Senha);
        }

        [Fact]
        public void Usuario_QuandoEmailInvalido_DeveSerInvalido()
        {
            var validator = new UsuarioInputValidator();

            var input = new UsuarioInput
            {
                Nome = "João",
                Email = "email-invalido",
                Senha = "Senha@123"
            };

            var result = validator.TestValidate(input);

            result.ShouldHaveValidationErrorFor(x => x.Email);
        }
    }
}
