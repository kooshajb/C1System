using System;
using System.Linq;
using System.Threading.Tasks;
using C1System.Core.Dtos.Category;
using C1System.Core.Services.category;
using C1System.DataLayar.Entities;
using C1System.DataLayar.Entities.Utilities.Enums;
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

    public async Task<IActionResult> ShowAllCategories()
    {
        var list = await _categoryRepository.Get();
        var model = list.Result.Where(c => !c.IsDelete && c.ParentId == null).ToList();
        return View(model);
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
        if (_categoryRepository.ExistCategory(dto.Title,0))
        {
            ModelState.AddModelError("ErrorPortfolio", "دسته بندی تکراری است");
            return View(dto);
        }
        var newCategory = await _categoryRepository.Add(dto);
        TempData["Result"] = newCategory.Result.CategoryId > 0  ? "true" : "false";
        return RedirectToAction(nameof(ShowAllCategories));
    }
    
    [HttpGet]
    public async Task<IActionResult> ShowAllSubCategories(int id)
    {
        ViewBag.Id = id;
        // var list = await _categoryRepository.Get();
        // var model = list.Result.Where(s => !s.IsDelete && s.SubCategory == id);
        var model = await _categoryRepository.ShowAllSubCategories(id);
        return View(model.Result);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllSubCategoryThree(int id)
    {
        ViewBag.Id = id;
        var model = await _categoryRepository.ShowAllSubCategories(id);
        return View(model.Result);
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var category = await _categoryRepository.GetById(id);
        if (category.Result == null)
        {
            TempData["NotFoundCategory"] = "true";
            return RedirectToAction(nameof(ShowAllCategories));
        }
        return View(category.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCategory(AddUpdateCategoryDto dto, int id)
    {
        var category = await _categoryRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(category.Result);
        }
        
        var updateCategory = await _categoryRepository.Update(id, dto);
        
        TempData["Result"] = updateCategory.Result != null ? "true" : "false";
        return RedirectToAction(nameof(ShowAllCategories));
    }


    [HttpGet]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var category = await _categoryRepository.GetById(id);
        if (category.Result == null)
        {
            TempData["NotFoundCategory"] = true;
            return RedirectToAction(nameof(ShowAllCategories));
        }
        return View(category.Result);
    }
    
    // [HttpPost]
    // public async Task<IActionResult> DeleteCategory(int id)
    // {
    //     // bool deleteImage = dto.DeleteImage("ImageSite", dto.SliderImg);
    //     // if (!deleteImage)
    //     // {
    //     //     TempData["Result"] = "false";
    //     //     return RedirectToAction(nameof(ShowAllCategories));
    //     // }
    //     var response = await _categoryRepository.Delete(id);
    //     TempData["Result"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
    //     return RedirectToAction(nameof(ShowAllCategories));
    // }
}