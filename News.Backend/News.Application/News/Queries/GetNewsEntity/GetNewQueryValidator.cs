using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace News.Application.News.Queries.GetNews
{
    public class GetNewsEntityValidator : AbstractValidator<GetNewsEntityQuery>
    {
        public GetNewsEntityValidator()
        {
            RuleFor(newsCommand =>
            newsCommand.NewsId).NotEqual(Guid.Empty);
        }
    }
}
