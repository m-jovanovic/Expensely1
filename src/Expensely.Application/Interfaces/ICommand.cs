using MediatR;

namespace Expensely.Application.Interfaces
{
    public interface ICommand<out TResult> : IRequest<TResult>
    {
    }
}