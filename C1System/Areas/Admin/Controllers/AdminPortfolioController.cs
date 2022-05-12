using System;
using System.Threading.Tasks;
using C1System.Core.Dtos.Category;
using C1System.Core.Dtos.Portfolio;
using C1System.Core.Services.category;
using C1System.Core.Services.portfolio;
using C1System.DataLayar.Entities;
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
        return View(model);
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
    
    // [HttpPost]
    // public async Task<IActionResult> AddPortfolio(AddUpdatePortfolioDto dto)
    // {
    //     if (!ModelState.IsValid)
    //     {
    //         return View(dto);
    //     }
    //     // if (_portfolioRepository.ExistPortfolio(dto.Title,0))
    //     // {
    //     //     ModelState.AddModelError("ErrorPortfolio", "نمونه کار تکراری است");
    //     //     return View(dto);
    //     // }
    //     var newPortfolio = await _portfolioRepository.Add(dto);
    //     TempData["Result"] = newPortfolio.Result.PortfolioId > 0  ? "true" : "false";
    //     return RedirectToAction(nameof(Index));
    // }
    
    // [HttpPost]
    // public IActionResult UpdatePortfolio(MainSlider mainSlider, IFormFile file)
    // {
    //     if (file != null)
    //     {
    //         string imgName = UploadImg.CreateImage(file);
    //         if (imgName == "false")
    //         {
    //             TempData["Result"] = "false";
    //             return RedirectToAction(nameof(Index));
    //         }
    //         bool deleteImage = UploadImg.DeleteImage("ImageSite", mainSlider.SliderImg);
    //         if (!deleteImage)
    //         {
    //             TempData["Result"] = "false";
    //             return RedirectToAction(nameof(Index));
    //         }
    //         mainSlider.SliderImg = imgName;
    //     }
    //     
    //     if (!ModelState.IsValid)
    //     {
    //         return View(mainSlider);
    //     }
    //     
    //     bool res = _sliderService.Update(mainSlider);
    //     TempData["Result"] = res ? "true" : "false";
    //     return RedirectToAction(nameof(Index));
    // }
    
    
    // [HttpGet]
    // public async Task<IActionResult> DeletePortfolio(Guid id)
    // {
    //     var portfolioDto = await _portfolioRepository.GetById(id);
    //     if (portfolioDto == null)
    //     {
    //         TempData["NotFoundPortfolio"] = true;
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(portfolioDto);
    // }
}