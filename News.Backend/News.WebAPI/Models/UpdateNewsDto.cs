using AutoMapper;
using News.Application.Common.Mapping;
using News.Application.News.Commands.UpdateNews;

namespace News.WebAPI.Models
{
    public class UpdateNewsDto : IMapWith<UpdateNewsEntityCommand>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateNewsDto, UpdateNewsEntityCommand>()
                .ForMember(newsCommand => newsCommand.NewsId, opt =>
                opt.MapFrom(newsDto => newsDto.Id))
                .ForMember(newsCommand => newsCommand.Title, opt =>
                opt.MapFrom(newsDto => newsDto.Title))
                .ForMember(newsCommand => newsCommand.Content, opt =>
                opt.MapFrom(newsDto => newsDto.Content));
        }
    }
}
