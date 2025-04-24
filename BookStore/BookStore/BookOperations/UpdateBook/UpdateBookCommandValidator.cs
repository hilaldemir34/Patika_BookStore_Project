using FluentValidation;

namespace BookStore.BookOperations.UpdateBook
{
    public class UpdateBookCommandValidator : AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.BookId)
                .GreaterThan(0)
                .WithMessage("BookId 0'dan büyük olmalıdır.");

            RuleFor(command => command.Model.Title)
                .NotEmpty()
                .When(command => command.Model.Title != null)
                .WithMessage("Title boş olamaz.");

            RuleFor(command => command.Model.PageCount)
                .GreaterThan(0)
                .When(command => command.Model.PageCount.HasValue)
                .WithMessage("Sayfa sayısı 0'dan büyük olmalıdır.");

            RuleFor(command => command.Model.PublishDate)
                .LessThan(DateTime.Now)
                .When(command => command.Model.PublishDate.HasValue)
                .WithMessage("Yayın tarihi bugünden ileri bir tarih olamaz.");
        }
    }
}
