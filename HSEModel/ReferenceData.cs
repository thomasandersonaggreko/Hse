namespace HSEModel
{
    using System.Collections.Generic;

    /// <summary>
    /// The reference data.
    /// </summary>
    public class ReferenceData
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>
        /// The items.
        /// </value>
        public IList<ReferenceDataItem> Items { get; set; }

        /// <summary>
        /// Gets or sets the type.
        /// </summary>
        /// <value>
        /// The type.
        /// </value>
        public ReferenceDataEnum Type { get; set; }
    }
}