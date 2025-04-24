using FluentValidation;

namespace BookStore.BookOperations.GetBooks
{
    public class GetBookByIdQueryValidator : AbstractValidator<GetBookByIdQuery>
    {
        public GetBookByIdQueryValidator()
        {
            RuleFor(query => query.BookId)
                .GreaterThan(0)
                .WithMessage("BookId 0'dan büyük olmalıdır.");
        }
    }
}

