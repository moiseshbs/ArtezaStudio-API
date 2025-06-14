using ArtezaStudio.Api.Dtos.Publicacao;
using FluentValidation;

namespace ArtezaStudio.Api.Validations
{
    public class PublicacaoCreateDtoValidator : AbstractValidator<PublicacaoFiltroDto>
    {
        public PublicacaoCreateDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório.")
                .MaximumLength(100).WithMessage("O título deve ter no máximo 100 caracteres.");

            RuleFor(x => x.Descricao)
                .NotEmpty().WithMessage("A descrição é obrigatória.")
                .MaximumLength(500).WithMessage("A descrição deve ter no máximo 500 caracteres.");

            RuleFor(x => x.ImagemUrl)
                .NotEmpty().WithMessage("A URL da imagem é obrigatória.")
                .Must(url => Uri.IsWellFormedUriString(url, UriKind.Absolute))
                .WithMessage("A URL da imagem deve ser válida.");
        }
    }
}
