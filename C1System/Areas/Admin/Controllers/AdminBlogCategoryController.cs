using System;
using System.Threading.Tasks;
using C1System.Dtos.Media;
using C1System.Media;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogCategoryController : Controller
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;

    public AdminBlogCategoryController(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _blogCategoryRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddBlogCategory(Guid id)
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBlogCategory(AddBlogCategoryDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }

        var newBlogCat = await _blogCategoryRepository.Add(dto);
        Guid blogCatId = newBlogCat.Result.BlogCategoryId;
        if (blogCatId == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBlogCategory(Guid id)
    {
        var blogCat = await _blogCategoryRepository.GetById(id);
        if (blogCat.Result == null)
        {
            TempData["NotFoundBlogCat"] = "true";
            return RedirectToAction(nameof(Index));
        }

        return View(blogCat.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBlogCategory(UpdateBlogCategoryDto dto, List<Guid> tagId)
    {
        if (!ModelState.IsValid)
        {
            return View();
        }
        
        var updateBlogCat = _blogCategoryRepository.Update(dto.BlogCategoryId, dto);
        
        if (updateBlogCat.Result == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteBlogCategory(Guid id)
    {
        var blogCat = await _blogCategoryRepository.GetById(id);
        if (blogCat.Result == null)
        {
            TempData["NotFoundBlogCat"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(blogCat.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteBlogCategoryById(Guid id)
    {
        var response = await _blogCategoryRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}