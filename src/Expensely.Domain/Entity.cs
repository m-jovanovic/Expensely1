using System;

namespace Expensely.Domain
{
    /// <summary>
    /// Represents the base class that all entities derive from.
    /// </summary>
    public abstract class Entity : IEquatable<Entity>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Entity"/> class.
        /// </summary>
        /// <param name="id">The entity identifier.</param>
        protected Entity(string id)
        {
            Id = id;
        }

        /// <summary>
        /// Gets or sets the entity identifier.
        /// </summary>
        public string Id { get; protected set; }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
            {
                return true;
            }

            if (a is null || b is null)
            {
                return false;
            }

            return a.Equals(b);
        }

        public static bool operator !=(Entity a, Entity b) => !(a == b);

        /// <inheritdoc />
        public bool Equals(Entity? other)
        {
            if (other is null)
            {
                return false;
            }

            return ReferenceEquals(this, other) || Id == other.Id;
        }

        /// <inheritdoc />
        public override bool Equals(object? obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != GetType())
            {
                return false;
            }

            if (!(obj is Entity other))
            {
                return false;
            }

            if (string.IsNullOrEmpty(Id) || string.IsNullOrEmpty(other.Id))
            {
                return false;
            }

            return Id == other.Id;
        }

        /// <inheritdoc />
        public override int GetHashCode()
        {
            return Id.GetHashCode(StringComparison.InvariantCultureIgnoreCase) * 41;
        }
    }
}