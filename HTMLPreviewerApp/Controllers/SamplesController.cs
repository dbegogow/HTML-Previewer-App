using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Infrastructure;
using HTMLPreviewerApp.Models.Samples;
using HTMLPreviewerApp.Services.Samples;
using Microsoft.AspNetCore.Authorization;
using HTMLPreviewerApp.Services.Conversions;

using static HTMLPreviewerApp.WebConstants;

namespace HTMLPreviewerApp.Controllers
{
    public class SamplesController : Controller
    {
        private const int MaxCodeSizeInMb = 5;

        private readonly ISamplesService _samples;
        private readonly IConvert _convert;

        public SamplesController(
            ISamplesService samples,
            IConvert convert)
        {
            this._samples = samples;
            this._convert = convert;
        }

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
            var size = this._convert
                .ConvertBytesToMegabytes(sample.Code);

            if (size > MaxCodeSizeInMb)
            {
                TempData[ErrorMessageKey] = InvalidSampleSize;
                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessageKey] = InvalidSampleContent;
                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            this._samples
                .Save(sample.Code, User.Id());

            TempData[SuccessMessageKey] = SuccessfulSavedSample;

            return RedirectToAction("All", "Samples", new { area = string.Empty });
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

            var size = this._convert
                .ConvertBytesToMegabytes(sample.Code);

            if (size > MaxCodeSizeInMb)
            {
                TempData[ErrorMessageKey] = InvalidSampleSize;
                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            if (!ModelState.IsValid)
            {
                TempData[ErrorMessageKey] = InvalidSampleContent;

                return RedirectToAction("Index", "Home", new { area = string.Empty });
            }

            this._samples
                .Edit(sample.Id, sample.Code, User.Id());

            TempData[SuccessMessageKey] = SuccessfulEditSample;

            return RedirectToAction("All", "Samples", new { area = string.Empty });
        }
    }
}