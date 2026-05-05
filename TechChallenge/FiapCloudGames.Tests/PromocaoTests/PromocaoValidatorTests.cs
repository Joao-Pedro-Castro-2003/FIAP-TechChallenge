using Core.Input;
using FiapCloudGames.Validators;
using FluentValidation.TestHelper;

namespace FiapCloudGames.Tests.PromocaoTests
{
    public class PromocaoValidatorTests
    {
        [Fact]
        public void Promocao_QuandoDescontoMaiorQue100_DeveSerInvalida()
        {
            // Arrange
            var validator = new PromocaoInputValidator();

            var input = new PromocaoInput
            {
                JogoId = 2,
                PercentualDesconto = 150,
                DataInicio = DateTime.Now,
                DataFim = DateTime.Now.AddDays(1),
                Ativa = true
            };

            // Act
            var result = validator.TestValidate(input);

            // Assert
            result.ShouldHaveValidationErrorFor(p => p.PercentualDesconto);
        }
    }
}
