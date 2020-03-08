using System;

namespace Expensely.Infrastructure.Persistence
{
    /// <summary>
    /// Represents the RavenDb settings.
    /// </summary>
    public sealed class RavenDbSettings
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RavenDbSettings"/> class.
        /// </summary>
        public RavenDbSettings()
        {
            Urls = Array.Empty<string>();
            Database = string.Empty;
        }

        /// <summary>
        /// Gets or sets the url.
        /// </summary>
        public string[] Urls { get; set; }

        /// <summary>
        /// Gets or sets the database name.
        /// </summary>
        public string Database { get; set; }
    }
}
