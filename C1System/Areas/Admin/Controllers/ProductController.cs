using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

public class ProductController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}