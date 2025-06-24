using AutoMapper;
using News.Application.Common.Mapping;
using News.Domain;

namespace News.Application.News.Queries.GetNews;

public class NewsEntityVm : IMapWith<NewsEntity>
{
    public Guid Id { get; set; }
    public string[]? Tags { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedTime { get; set; }
    public DateTime? ModifiedTime { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewsEntityVm, NewsEntity>()
            .ForMember(newsVm => newsVm.Id, 
                opt => opt.MapFrom(src => src.Id))
            .ForMember(newsVm => newsVm.Tags,
                opt => opt.MapFrom(src => src.Tags))
            .ForMember(newsVm => newsVm.Title, 
                opt => opt.MapFrom(src => src.Title))
            .ForMember(newsVm => newsVm.Content, 
                opt => opt.MapFrom(src => src.Content))
            .ForMember(newsVm => newsVm.CreatedTime, 
                opt => opt.MapFrom(src => src.CreatedTime))
            .ForMember(newsVm => newsVm.ModifiedTime, 
                opt => opt.MapFrom(src => src.ModifiedTime));
    }
}