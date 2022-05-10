using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

public class CategoryController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}