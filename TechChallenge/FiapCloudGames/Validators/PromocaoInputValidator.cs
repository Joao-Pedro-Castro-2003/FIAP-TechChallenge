using Core.Input;
using FluentValidation;

namespace FiapCloudGames.Validators
{
    public class PromocaoInputValidator : AbstractValidator<PromocaoInput>
    {
        public PromocaoInputValidator()
        {
            RuleFor(p => p.JogoId)
                .NotEmpty()
                .WithMessage("Selecione o jogo");

            RuleFor(p => p.PercentualDesconto)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Informe o percentual de desconto")
                .GreaterThan(0).WithMessage("O desconto deve ser maior que 0")
                .LessThanOrEqualTo(100).WithMessage("O desconto deve ser menor ou igual a 100");

            RuleFor(p => p.DataInicio)
                .NotEmpty()
                .WithMessage("Informe a data de início");

            RuleFor(p => p.DataFim)
                .Cascade(CascadeMode.Stop)
                .NotEmpty()
                .WithMessage("Informe a data de fim")
                .GreaterThan(p => p.DataInicio)
                .WithMessage("A data final deve ser maior que a data inicial");

            RuleFor(p => p.Ativa)
                .NotNull()
                .WithMessage("Informe se a promoção está ativa");
        }
    }
}
