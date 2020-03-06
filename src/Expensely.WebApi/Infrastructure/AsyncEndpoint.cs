using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Expensely.WebApi.Infrastructure
{
    [ApiController]
    public abstract class AsyncEndpoint<TRequest, TResponse> : ControllerBase
    {
        public abstract Task<ActionResult<TResponse>> HandleAsync(TRequest request);
    }
}
