using ArtezaStudio.Api.Dtos.Usuario;
using FluentValidation;

namespace ArtezaStudio.Api.Validations
{
    public class UsuarioCreateDtoValidator : AbstractValidator<UsuarioDto>
    {
        public UsuarioCreateDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório.")
                .MaximumLength(100).WithMessage("O nome deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("O username é obrigatório.")
                .MaximumLength(50).WithMessage("O username deve ter no máximo 50 caracteres.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O email é obrigatório.")
                .EmailAddress().WithMessage("O email deve ser válido.");

            RuleFor(x => x.ImagemPerfilUrl)
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("A URL da imagem de perfil deve ser válida.");
        }
    }
}
