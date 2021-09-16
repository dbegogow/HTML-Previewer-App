using System.ComponentModel.DataAnnotations;

namespace HTMLPreviewerApp.Models.Samples
{
    public class SampleFormModel
    {
        public string Id { get; init; }

        [Required]
        public string Code { get; init; }
    }
}
