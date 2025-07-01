using MediatR;
using News.Application.Interfaces;
using Serilog;

namespace News.Application.Common.Behaviours;

public class LoggingBehaviour<TRequest, TResponse> 
    : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : IRequest<TResponse>
{
    private ICurrentUserService _currentUserService;

    public LoggingBehaviour(ICurrentUserService currentUserService)
    {
        _currentUserService = currentUserService;
    }

    public async Task<TResponse> Handle(TRequest request, 
        RequestHandlerDelegate<TResponse> next, 
        CancellationToken cancellationToken)
    {
        var requestName = typeof(TRequest).Name;
        var userId = _currentUserService.UserId;
        Log.Information("News Request: {Name} {@User} {@Request}",
            requestName, userId, request);
        
        var response = await next();
        
        return response;
    }
}