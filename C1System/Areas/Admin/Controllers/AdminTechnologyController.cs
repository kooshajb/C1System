using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminTechnologyController : Controller
{
    private readonly ITechnologyRepository _technologyRepository;

    public AdminTechnologyController(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _technologyRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddTechnology(Guid? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddTechnology(AddUpdateTechnologyDto dto)
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
        var newTechnology = await _technologyRepository.Add(dto);
        TempData["Result"] = newTechnology.Result.TechnologyId != null  ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTechnology(Guid id)
    {
        var technology = await _technologyRepository.GetById(id);
        if (technology.Result == null)
        {
            TempData["NotFoundTechnology"] = "true";
            return RedirectToAction(nameof(Index));
        }
        return View(technology.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateTechnology(AddUpdateTechnologyDto dto, Guid id)
    {
        var technology = await _technologyRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(technology.Result);
        }
        
        var updateTechnology = await _technologyRepository.Update(id, dto);
        
        TempData["Result"] = updateTechnology.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteTechnology(Guid id)
    {
        var technology = await _technologyRepository.GetById(id);
        if (technology.Result == null)
        {
            TempData["NotFoundTechnology"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(technology.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteTechnologyById(Guid id)
    {
        var response = await _technologyRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}