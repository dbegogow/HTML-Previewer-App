using System;
using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Models.Samples;
using Microsoft.AspNetCore.Authorization;

namespace HTMLPreviewerApp.Controllers
{
    public class SamplesController : Controller
    {
        public IActionResult All()
            => View();

        [Authorize]
        [HttpPost]
        public IActionResult SaveSample(SampleFormModel sample)
        {
            

            return RedirectToAction("Index", "Home");
        }
    }
}
