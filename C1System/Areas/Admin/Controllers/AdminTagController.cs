using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminTagController : Controller
{
    private readonly ITagRepository _tagRepository;

    public AdminTagController(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _tagRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddTag(Guid? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTag(AddUpdateTagDto dto)
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
        
        var tag = await _tagRepository.Add(dto);
        Guid tagId = tag.Result.TagId;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTag(Guid id)
    {
        var tag = await _tagRepository.GetById(id);
        if (tag.Result == null)
        {
            TempData["NotFoundTag"] = "true";
            return RedirectToAction(nameof(Index));
        }

        return View(tag.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateTag(AddUpdateTagDto dto, Guid id)
    {
        var tag = await _tagRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(tag.Result);
        }
        
        var updateTag = await _tagRepository.Update(id, dto);
        
        TempData["Result"] = updateTag.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteTag(Guid id)
    {
        var tag = await _tagRepository.GetById(id);
        if (tag.Result == null)
        {
            TempData["NotFoundTag"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(tag.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteTagById(Guid id)
    {
        var response = await _tagRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}