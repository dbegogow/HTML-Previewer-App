using System;
using System.ComponentModel.DataAnnotations;

namespace HTMLPreviewerApp.Data.Models
{
    public class Sample
    {
        [Required]
        public string Code { get; set; }

        public DateTime Creation { get; set; }

        public DateTime LastEdit { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }
    }
}
