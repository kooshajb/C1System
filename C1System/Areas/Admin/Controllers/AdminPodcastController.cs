using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminPodcastController : Controller
{
    private readonly IPodcastRepository _podcastRepository;
    private readonly ITagRepository _tagRepository;

    public AdminPodcastController(IPodcastRepository podcastRepository, ITagRepository tagRepository)
    {
        _podcastRepository = podcastRepository;
        _tagRepository = tagRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _podcastRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddPodcast(Guid id)
    {
        var tags = await _tagRepository.Get();
        ViewBag.Tag = tags.Result;
        
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPodcast(AddPodcastDto dto, List<Guid> tagId)
    {
        if (!ModelState.IsValid)
        {
            var tags = await _tagRepository.Get();
            ViewBag.Tag = tags.Result;
            return View(dto);
        }
        // if (_portfolioRepository.ExistPortfolio(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorPortfolio", "نمونه کار تکراری است");
        //     return View(dto);
        // }
        
        var podcast = await _podcastRepository.Add(dto);
        Guid podcastId = podcast.Result.PodcastId;
        if (podcastId == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        //tags        
        List<Tag_PodcastEntity> addTagPodcast = new List<Tag_PodcastEntity>();
        
        foreach (var item in tagId)
        {
            addTagPodcast.Add(new Tag_PodcastEntity()
            {
                TagId = item,
                PodcastId = podcastId
            });
        }

        bool res = _podcastRepository.AddPodcastsForTag(addTagPodcast);
        TempData["Result"] = res ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePodcast(Guid id)
    {
        var tags = await _tagRepository.Get();
        ViewBag.Tag = tags.Result;
        
        ViewBag.PodcastTag = await _podcastRepository.ShowPodcastsForUpdate(id);

        
        var podcast = await _podcastRepository.GetById(id);
        if (podcast.Result == null)
        {
            TempData["NotFoundPodcast"] = "true";
            return RedirectToAction(nameof(Index));
        }

        return View(podcast.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePodcast(UpdatePodcastDto dto, List<Guid> tagId)
    {

        if (!ModelState.IsValid)
        {
            var tagForUpdate = await _tagRepository.Get();
            ViewBag.Tag = tagForUpdate.Result;

            ViewBag.Podcast = await _podcastRepository.ShowPodcastsForUpdate(dto.PodcastId);
            
            return View();
        }
        
        //tag
        var updatePodcast = _podcastRepository.Update(dto.PodcastId, dto);
        
        if (updatePodcast.Result == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        bool deletePodcast = _podcastRepository.DeletePodcastForTag(dto.PodcastId);
        if (!deletePodcast)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        List<Tag_PodcastEntity> tagResult = new List<Tag_PodcastEntity>();
        foreach (var item in tagId)
        {
            tagResult.Add(new Tag_PodcastEntity
            {
                TagId = item,
                PodcastId = dto.PodcastId,
            });
        }
        
        bool addPodcastForTag= _podcastRepository.AddPodcastsForTag(tagResult);
        TempData["Result"] = addPodcastForTag ? "true" : "false";
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeletePodcast(Guid id)
    {
        var tags = await _tagRepository.Get();
        ViewBag.Tag = tags.Result;
        
        ViewBag.PodcastTag = await _podcastRepository.ShowPodcastsForUpdate(id);
        
        var podcast = await _podcastRepository.GetById(id);
        if (podcast.Result == null)
        {
            TempData["NotFoundPodcast"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(podcast.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeletePodcastById(Guid id)
    {
        var response = await _podcastRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}