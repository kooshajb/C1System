using C1System.Core.Dtos.Category;
using C1System.Core.Services.category;
using C1System.DataLayar.Entities;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;

    public AdminCategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IActionResult> Index()
    {
        var model = await _categoryRepository.Get();
        return View(model.Result);
    }

    [HttpGet]
    public IActionResult AddCategory(int? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCategory(AddUpdateCategoryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_categoryRepository.ExistCategory(category.CategoryFaTitle, category.CategoryEnTitle, 0))
        // {
        //     ModelState.AddModelError("ErrorCategory", "دسته بندی تکراری است");
        //     return View(dto);
        // }
        var newCategory = await _categoryRepository.Add(dto);
        TempData["Result"] = newCategory.Result != null  ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
    
    
    // [HttpGet]
    // public IActionResult ShowAllSubCategories(int id)
    // {
    //     ViewBag.Id = id;
    //     var model = _categoryRepository.ShowAllSubCategories(id);
    //     return View(model);
    // }
    //
    // [HttpGet]
    // public IActionResult ShowAllSubCategoryThree(int id)
    // {
    //     ViewBag.Id = id;
    //     var model = _categoryRepository.ShowAllSubCategories(id);
    //     return View(model);
    // }
}