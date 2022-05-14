using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController : Controller
{
    private readonly BlogRepository _blogRepository;

    public AdminBlogController(BlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _blogRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddBlog(Guid? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddBlog(AddUpdateBlogDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_blogRepository.ExistBlog(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorBlog", "پست تکراری است");
        //     return View(dto);
        // }
        var newBlog = await _blogRepository.Add(dto);
        TempData["Result"] = newBlog.Result.BlogId != null  ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateBlog(Guid id)
    {
        var blog = await _blogRepository.GetById(id);
        if (blog.Result == null)
        {
            TempData["NotFoundBlog"] = "true";
            return RedirectToAction(nameof(Index));
        }
        return View(blog.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateBlog(AddUpdateBlogDto dto, Guid id)
    {
        var blog = await _blogRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(blog.Result);
        }
        
        var updateBlog = await _blogRepository.Update(id, dto);
        
        TempData["Result"] = updateBlog.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteBlog(Guid id)
    {
        var blog = await _blogRepository.GetById(id);
        if (blog.Result == null)
        {
            TempData["NotFoundBlog"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(blog.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteBlogById(Guid id)
    {
        var response = await _blogRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}