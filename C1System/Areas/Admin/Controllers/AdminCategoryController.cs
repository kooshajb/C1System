using System;
using System.Linq;
using System.Threading.Tasks;
using C1System.Dtos.Media;
using C1System.Media;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCategoryController : Controller
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUploadRepository _uploadRepository;

    public AdminCategoryController(ICategoryRepository categoryRepository, IUploadRepository uploadRepository)
    {
        _categoryRepository = categoryRepository;
        _uploadRepository = uploadRepository;
    }

    public async Task<IActionResult> ShowAllCategories()
    {
        var list = await _categoryRepository.Get();
        var model = list.Result.Where(c => !c.IsDelete && c.ParentId == null).ToList();
        return View(model);
    }

    [HttpGet]
    public IActionResult AddCategory(Guid? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCategory(AddCategoryDto dto, List<IFormFile> iconImageFile, List<IFormFile> videoIntroFile)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_categoryRepository.ExistCategory(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorPortfolio", "دسته بندی تکراری است");
        //     return View(dto);
        // }
        var newCategory = await _categoryRepository.Add(dto);
        TempData["Result"] = newCategory.Result.CategoryId != null  ? "true" : "false";
        
        //upload images
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> filesResult = new List<IFormFile>();

        uploadDto.CategoryId = newCategory.Result.CategoryId;

        foreach (var fileItem in iconImageFile)
        {
            filesResult.Add(fileItem);
        }

        uploadDto.Files = filesResult;
        await _uploadRepository.UploadMedia(uploadDto);
        
        //upload videoIntro
        UploadDto uploadDtovideo = new UploadDto();
        List<IFormFile> videoFileResult = new List<IFormFile>();

        uploadDtovideo.CategoryId = newCategory.Result.CategoryId;

        foreach (var video in videoIntroFile)
        {
            videoFileResult.Add(video);
        }

        uploadDto.Files = videoFileResult;
        await _uploadRepository.UploadMedia(uploadDto);

        return RedirectToAction(nameof(ShowAllCategories));
    }
    
    [HttpGet]
    public async Task<IActionResult> ShowAllSubCategories(Guid id)
    {
        ViewBag.Id = id;
        // var list = await _categoryRepository.Get();
        // var model = list.Result.Where(s => !s.IsDelete && s.SubCategory == id);
        var model = await _categoryRepository.ShowAllSubCategories(id);
        return View(model.Result);
    }

    [HttpGet]
    public async Task<IActionResult> ShowAllSubCategoryThree(Guid id)
    {
        ViewBag.Id = id;
        var model = await _categoryRepository.ShowAllSubCategories(id);
        return View(model.Result);
    }
    
    [HttpGet]
    public async Task<IActionResult> UpdateCategory(Guid id)
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
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto dto, Guid id)
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
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        var category = await _categoryRepository.GetById(id);
        if (category.Result == null)
        {
            TempData["NotFoundCategory"] = true;
            return RedirectToAction(nameof(ShowAllCategories));
        }
        return View(category.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteCategoryById(Guid id)
    {
        var response = await _categoryRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(ShowAllCategories));
    }
}