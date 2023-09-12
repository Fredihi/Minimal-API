using FluentValidation;
using Minimal_API.Models.DTOs;

namespace Minimal_API.Models.Validations
{
	public class BookUpdateValidation : AbstractValidator<BookUpdateDTO>
	{
        public BookUpdateValidation()
        {
            RuleFor(model => model.ID).NotEmpty();
            RuleFor(model => model.Name).NotEmpty();
            RuleFor(model => model.Author).NotEmpty();
        }
    }
}
