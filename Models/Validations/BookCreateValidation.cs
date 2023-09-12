using FluentValidation;
using Minimal_API.Models.DTOs;

namespace Minimal_API.Models.Validations
{
	public class BookCreateValidation : AbstractValidator<BookCreateDTO>
	{
        public BookCreateValidation()
        {
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Author).NotEmpty();
        }
    }
}
