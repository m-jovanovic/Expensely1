using System;

namespace Expensely.Domain
{
    public interface IAuditableEntity
    {
        DateTime CreatedOnUtc { get; }

        DateTime? ModifiedOnUtc { get; }
    }
}