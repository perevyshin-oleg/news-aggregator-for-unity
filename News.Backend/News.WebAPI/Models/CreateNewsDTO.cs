using AutoMapper;
using News.Application.Common.Mapping;
using News.Application.News.Commands.CreateNews;

namespace News.WebAPI.Models
{
    public class CreateNewsDto : IMapWith<CreateNewsEntityCommand>
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNewsDto, CreateNewsEntityCommand>()
                .ForMember(newsCommand => newsCommand.Title,
                opt => opt.MapFrom(newsDto => newsDto.Title))
                .ForMember(newsCommand => newsCommand.Content,
                opt => opt.MapFrom(newsDto => newsDto.Content));
        }
    }
}
