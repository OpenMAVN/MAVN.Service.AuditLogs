using System.ComponentModel.DataAnnotations;

namespace MAVN.Service.AuditLogs.Client.Models
{
    /// <summary>
    /// Paged model
    /// </summary>
    public class BasePagedModel
    {
        /// <summary>
        /// The Current Page
        /// </summary>
        [Range(1, 10000)]
        public int CurrentPage { get; set; }

        /// <summary>
        /// The amount of items that the page holds
        /// </summary>
        [Range(1, 1000)]
        public int PageSize { get; set; }
    }
}
