using System;
using System.ComponentModel.DataAnnotations;

using static HTMLPreviewerApp.Data.DataConstants.Common;

namespace HTMLPreviewerApp.Data.Models
{
    public class Sample
    {
        [Key]
        [Required]
        [MaxLength(IdMaxLength)]
        public string Id { get; init; } = Guid.NewGuid().ToString();

        [Required]
        public string Code { get; set; }

        public DateTime Creation { get; set; }

        public DateTime LastEdit { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
