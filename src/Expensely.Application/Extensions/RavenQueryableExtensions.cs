using Raven.Client.Documents.Linq;

namespace Expensely.Application.Extensions
{
    public static class RavenQueryableExtensions
    {
        public static IRavenQueryable<T> NoTracking<T>(this IRavenQueryable<T> queryable)
            => queryable.Customize(x => x.NoTracking());
    }
}
