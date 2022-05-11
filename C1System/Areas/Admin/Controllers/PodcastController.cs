using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Area("Admin")]
public class PodcastController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
