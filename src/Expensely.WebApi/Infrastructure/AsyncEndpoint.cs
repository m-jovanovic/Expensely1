using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace Expensely.WebApi.Infrastructure
{
    [Route("api")]
    [ApiController]
    public abstract class AsyncEndpoint<TRequest, TResponse> : ControllerBase
    {
        private IMediator? _mediator;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();

        public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request);
    }
}
