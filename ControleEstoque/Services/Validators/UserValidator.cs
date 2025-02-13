using ControleEstoque.Models.DTOs;
using FluentValidation;

namespace ControleEstoque.Services.Validators;

public sealed class UserValidator : AbstractValidator<UserDto>
{
    public UserValidator()
    {
        RuleFor(user => user.Name)
        .NotEmpty().WithMessage("O nome de usuário é obrigatório.")
        .NotNull().WithMessage("O nome de usuário é obrigatório.");

        RuleFor(user => user.Email)
        .Matches(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*").WithMessage("O E-mail é obrigatório")
        .NotEmpty().WithMessage("O email de usuário é obrigatório")
        .NotNull().WithMessage("O email de usuário é obrigatório")
        .EmailAddress().WithMessage("O email fornecido não é válido.");

        RuleFor(user => user.Password)
        .NotEmpty().WithMessage("A senha é obrigatória.")
        .NotNull().WithMessage("A senha é obrigatória.")
        .Matches(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$").WithMessage("A Senha deve ter no mínimo 8 caracteres, uma letra, um caracter especial e um número.");
    }
}