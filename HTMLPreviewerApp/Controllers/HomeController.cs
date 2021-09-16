using System.Diagnostics;
using HTMLPreviewerApp.Models;
using Microsoft.AspNetCore.Mvc;
using HTMLPreviewerApp.Infrastructure;
using HTMLPreviewerApp.Models.Samples;
using HTMLPreviewerApp.Services.Samples;

namespace HTMLPreviewerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISamplesService _samples;

        public HomeController(ISamplesService samples)
            => this._samples = samples;

        public IActionResult Index(string id)
        {
            var sample = this._samples.SampleCode(id);

            if (sample != null)
            {
                return View(new SampleFormModel { Code = sample.Code });
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
