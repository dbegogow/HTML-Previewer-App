using Microsoft.AspNetCore.Mvc;

namespace HTMLPreviewerApp.Controllers
{
    public class SamplesController : Controller
    {
        public IActionResult All()
        {
            return View();
        }
    }
}
