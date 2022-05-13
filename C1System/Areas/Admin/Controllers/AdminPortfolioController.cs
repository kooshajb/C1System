using System;
using System.Linq;
using System.Threading.Tasks;
using C1System.Core.Dtos.Category;
using C1System.Core.Dtos.Portfolio;
using C1System.Core.Services.category;
using C1System.Core.Services.portfolio;
using C1System.DataLayar.Entities;
using C1System.DataLayar.Entities.Utilities.Enums;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminPortfolioController : Controller
{
    private readonly IPortfolioRepository _portfolioRepository;

    public AdminPortfolioController(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _portfolioRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddPortfolio(int? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPortfolio(AddUpdatePortfolioDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_portfolioRepository.ExistPortfolio(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorPortfolio", "نمونه کار تکراری است");
        //     return View(dto);
        // }
        var newPortfolio = await _portfolioRepository.Add(dto);
        TempData["Result"] = newPortfolio.Result.PortfolioId != null  ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePortfolio(Guid id)
    {
        var portfolio = await _portfolioRepository.GetById(id);
        if (portfolio.Result == null)
        {
            TempData["NotFoundPortfolio"] = "true";
            return RedirectToAction(nameof(Index));
        }
        return View(portfolio.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePortfolio(AddUpdatePortfolioDto dto, Guid id)
    {
        var category = await _portfolioRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(category.Result);
        }
        
        var updateCategory = await _portfolioRepository.Update(id, dto);
        
        TempData["Result"] = updateCategory.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeletePortfolio(Guid id)
    {
        var portfolio = await _portfolioRepository.GetById(id);
        if (portfolio.Result == null)
        {
            TempData["NotFoundPortfolio"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(portfolio.Result);
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