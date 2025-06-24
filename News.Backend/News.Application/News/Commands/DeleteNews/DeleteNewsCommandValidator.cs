using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.News.Commands.DeleteNews
{
    public class DeleteNewsCommandValidator : AbstractValidator<DeleteNewsEntityCommand>
    {
        public DeleteNewsCommandValidator()
        {
            RuleFor(newsCommand =>
            newsCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(newsCommand =>
            newsCommand.NewsId).NotEqual(Guid.Empty);
        }
    }
}
