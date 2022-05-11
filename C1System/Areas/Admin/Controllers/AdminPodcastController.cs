using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Area("Admin")]
public class AdminPodcastController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}