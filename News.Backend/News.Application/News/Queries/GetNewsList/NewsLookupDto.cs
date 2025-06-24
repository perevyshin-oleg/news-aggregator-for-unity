using AutoMapper;
using News.Application.Common.Mapping;
using News.Domain;

namespace News.Application.News.Queries.GetNewsList;

public class NewsLookupDto : IMapWith<NewsEntity>
{
    public Guid Id { get; set; }
    public string Title { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewsEntity, NewsLookupDto>()
            .ForMember(newsDto => newsDto.Id,
                opt => opt.MapFrom(src => src.Id))
            .ForMember(newsDto => newsDto.Title,
                opt => opt.MapFrom(src => src.Title));
    }
}