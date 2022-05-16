using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminBlogController : Controller
{
    private readonly IBlogRepository _blogRepository;

    public AdminBlogController(IBlogRepository blogRepository)
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
    public async Task<IActionResult> AddBlog(AddBlogDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_tagRepository.ExistTag(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorTag", "برچسب تکراری است");
        //     return View(dto);
        // }
        
        var blog = await _blogRepository.Add(dto);
        Guid blogId = blog.Result.BlogId;
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
    public async Task<IActionResult> UpdateBlog(UpdateBlogDto dto, Guid id)
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