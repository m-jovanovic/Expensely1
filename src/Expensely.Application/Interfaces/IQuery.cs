using MediatR;

namespace Expensely.Application.Interfaces
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {
    }
}