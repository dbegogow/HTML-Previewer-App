using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Infrastructure;
using HTMLPreviewerApp.Models.Samples;
using HTMLPreviewerApp.Services.Samples;
using Microsoft.AspNetCore.Authorization;

namespace HTMLPreviewerApp.Controllers
{
    public class SamplesController : Controller
    {
        private readonly ISamplesService _samples;

        public SamplesController(ISamplesService samples)
            => this._samples = samples;

        [Authorize]
        public IActionResult All()
        {
            var samples = this._samples
                .All(User.Id());

            return View(samples);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Save(SampleFormModel sample)
        {
            this._samples
                .Save(sample.Code, User.Id());

            return RedirectToAction("Index", "Home", new { area = "" });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(SampleFormModel sample)
        {
            var isExist = this._samples
                .IsSampleExist(sample.Id, User.Id());

            if (!isExist)
            {
                return BadRequest();
            }

            this._samples
                .Edit(sample.Id, sample.Code, User.Id());

            return RedirectToAction("All", "Samples", new { area = "" });
        }
    }
}