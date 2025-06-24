using Microsoft.AspNetCore.Mvc;
using News.Application.News.Queries.GetNewsList;
using News.Application.News.Queries.GetNews;
using AutoMapper;
using News.Application.News.Commands.CreateNews;
using News.WebAPI.Models;
using News.Application.News.Commands.UpdateNews;
using News.Application.News.Commands.DeleteNews;

namespace News.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewsController : BaseController
    {
        private readonly IMapper _mapper;

        public NewsController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet("all")]
        public async Task<ActionResult<NewsListVm>> GetAll()
        {
            GetNewsListQuery query = new GetNewsListQuery();
            NewsListVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NewsEntityVm>> Get(Guid id)
        {
            GetNewsEntityQuery query = new GetNewsEntityQuery()
            {
                NewsId = id
            };
            NewsEntityVm vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateNewsDto createNewsDto)
        {
            CreateNewsEntityCommand command = _mapper.Map<CreateNewsEntityCommand>(createNewsDto);
            command.UserId = UserId;
            object? noteId = await Mediator.Send(command);
            return Ok(noteId);
        }

        [HttpPost]
        public async Task<ActionResult<IActionResult>> Update([FromBody] UpdateNewsDto updateNewsDto)
        {
            UpdateNewsEntityCommand command = _mapper.Map<UpdateNewsEntityCommand>(updateNewsDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<IActionResult>> Delete(Guid id)
        {
            DeleteNewsEntityCommand command = new DeleteNewsEntityCommand()
            {
                NewsId = id,
                UserId = UserId
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
