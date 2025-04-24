using FluentValidation;

namespace BookStore.BookOperations.DeleteBook
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.Model.Id).GreaterThan(0);
        }
    }
}
