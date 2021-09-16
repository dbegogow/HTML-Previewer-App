using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Infrastructure;
using HTMLPreviewerApp.Models.Samples;
using HTMLPreviewerApp.Services.Samples;
using Microsoft.AspNetCore.Authorization;

using static HTMLPreviewerApp.WebConstants;

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
            if (ModelState.IsValid)
            {
                this._samples
                    .Save(sample.Code, User.Id());

                TempData[SuccessMessageKey] = SuccessfulSavedSample;

                return RedirectToAction("All", "Samples", new { area = "" });
            }

            TempData[ErrorMessageKey] = InvalidSampleContent;

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

            if (ModelState.IsValid)
            {
                this._samples
                    .Edit(sample.Id, sample.Code, User.Id());

                TempData[SuccessMessageKey] = SuccessfulEditSample;

                return RedirectToAction("All", "Samples", new { area = "" });
            }

            TempData[ErrorMessageKey] = InvalidSampleContent;

            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}