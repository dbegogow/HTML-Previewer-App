using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Models.Samples;
using HTMLPreviewerApp.Services.Samples;

namespace HTMLPreviewerApp.Controllers.Api
{
    [Route("api/checkOriginal")]
    [ApiController]
    public class CheckOriginalApiController : ControllerBase
    {
        private readonly ISamplesService _samples;

        public CheckOriginalApiController(ISamplesService samples)
            => this._samples = samples;

        [HttpPost]
        public IActionResult Check(SampleApiModel sample)
        {
            var result = this._samples
                .CheckOriginal(sample.Id, sample.Code);

            return new JsonResult(result);
        }
    }
}
