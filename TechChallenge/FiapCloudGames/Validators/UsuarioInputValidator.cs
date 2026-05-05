using Core.Input;
using FluentValidation;

namespace FiapCloudGames.Validators
{
    public class UsuarioInputValidator : AbstractValidator<UsuarioInput>
    {
        public UsuarioInputValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório");

            RuleFor(x => x.Senha)
                .Cascade(CascadeMode.Stop)
                .NotEmpty().WithMessage("Senha é obrigatória")
                .MinimumLength(8).WithMessage("Senha deve ter no mínimo 8 caracteres")
                .Matches(@"[A-Z]").WithMessage("Senha deve conter pelo menos uma letra maiúscula")
                .Matches(@"\d").WithMessage("Senha deve conter pelo menos um número")
                .Matches(@"[^A-Za-z0-9]").WithMessage("Senha deve conter pelo menos um caractere especial");

            RuleFor(x => x.Email)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("O Email é obrigatório")
            .EmailAddress().WithMessage("Email inválido");
        }
    }
}
