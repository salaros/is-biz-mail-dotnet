using System.Collections.Generic;
using Newtonsoft.Json;

namespace Salaros.Email.Test
{
    internal class EmailSamples
    {
        /// <summary>
        /// Gets or sets the list of business emails.
        /// </summary>
        /// <value>
        /// The list of business emails.
        /// </value>
        [JsonProperty("business")]
        public List<string> BusinessEmails { get; internal set; }

        /// <summary>
        /// Gets or sets the list free emails.
        /// </summary>
        /// <value>
        /// The list free emails.
        /// </value>
        [JsonProperty("free")]
        public List<string> FreeEmails { get; internal set; }

        /// <summary>
        /// Gets or sets the list of domain patterns.
        /// </summary>
        /// <value>
        /// The list of domain patterns.
        /// </value>
        [JsonProperty("pattern")]
        public List<string> DomainPatterns { get; internal set; }

        /// <summary>
        /// Gets or sets the list of invalid emails.
        /// </summary>
        /// <value>
        /// The invalid emails.
        /// </value>
        [JsonProperty("invalid")]
        public List<string> InvalidEmails { get; internal set; }

        /// <summary>
        /// Gets or sets the list of values triggering errors.
        /// </summary>
        /// <value>
        /// The list of values triggering errors.
        /// </value>
        [JsonProperty("throws")]
        public List<object> Throws { get; internal set; }
    }
}
