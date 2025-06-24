using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.News.Commands.UpdateNews
{
    public class DeleteNewsCommandValidator : AbstractValidator<UpdateNewsEntityCommand>
    {
        public DeleteNewsCommandValidator()
        {
            RuleFor(newsCommand =>
                newsCommand.Title).NotEmpty().MaximumLength(256);
            RuleFor(newsCommand =>
            newsCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(newsCommand =>
            newsCommand.NewsId).NotEqual(Guid.Empty);
        }
    }
}
