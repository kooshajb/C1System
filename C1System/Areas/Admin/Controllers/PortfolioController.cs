using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.API.Admin.Controllers;

[Area("Admin")]
public class PortfolioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}