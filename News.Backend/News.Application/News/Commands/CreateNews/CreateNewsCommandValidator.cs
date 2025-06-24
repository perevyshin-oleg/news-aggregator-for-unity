using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.News.Commands.CreateNews
{
    public class UpdateNewsCommandValidator : AbstractValidator<CreateNewsEntityCommand>
    {
        public UpdateNewsCommandValidator()
        {
            RuleFor(createNewsCommand =>
            createNewsCommand.Title).NotEmpty().MaximumLength(256);
            RuleFor(createNewsCommand =>
            createNewsCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
