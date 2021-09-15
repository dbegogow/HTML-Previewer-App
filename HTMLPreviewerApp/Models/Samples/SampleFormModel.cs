using System.ComponentModel.DataAnnotations;

namespace HTMLPreviewerApp.Models.Samples
{
    public class SampleFormModel
    {
        [Required]
        public string Code { get; init; }
    }
}
