﻿using C1System.Core.Services.podcast;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Area("Admin")]
public class AdminPodcastController : Controller
{
    private readonly IPodcastRepository _podcastRepository;

    public AdminPodcastController(IPodcastRepository podcastRepository)
    {
        _podcastRepository = podcastRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _podcastRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddPodcast(Guid? id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPodcast(AddUpdatePodcastDto dto)
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
        var newPodcast = await _podcastRepository.Add(dto);
        TempData["Result"] = newPodcast.Result.PodcastId != null  ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePodcast(Guid id)
    {
        var podcast = await _podcastRepository.GetById(id);
        if (podcast.Result == null)
        {
            TempData["NotFoundPodcast"] = "true";
            return RedirectToAction(nameof(Index));
        }
        return View(podcast.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePodcast(AddUpdatePodcastDto dto, Guid id)
    {
        var podcast = await _podcastRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(podcast.Result);
        }
        
        var updatePodcast = await _podcastRepository.Update(id, dto);
        
        TempData["Result"] = updatePodcast.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeletePodcast(Guid id)
    {
        var podcast = await _podcastRepository.GetById(id);
        if (podcast.Result == null)
        {
            TempData["NotFoundPodcast"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(podcast.Result);
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