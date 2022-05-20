using System;
using System.Threading.Tasks;
using C1System.Dtos.Media;
using C1System.Media;
using C1System.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminPodcastController : Controller
{
    private readonly IPodcastRepository _podcastRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IUploadRepository _uploadRepository;

    public AdminPodcastController(IPodcastRepository podcastRepository, ITagRepository tagRepository, IUploadRepository uploadRepository)
    {
        _podcastRepository = podcastRepository;
        _tagRepository = tagRepository;
        _uploadRepository = uploadRepository;
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
    public async Task<IActionResult> AddPodcast(AddPodcastDto dto, List<Guid> tagId, List<IFormFile> featureImgFile, List<IFormFile> audioFile)
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
        
        var newPodcast = await _podcastRepository.Add(dto);
        Guid podcastId = newPodcast.Result.PodcastId;
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
        
        //upload images and audio
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> fileResult = new List<IFormFile>();

        uploadDto.PodcastId = newPodcast.Result.PodcastId;

        foreach (var fileItem in featureImgFile)
        {
            fileResult.Add(fileItem);
        }
        foreach (var audio in audioFile)
        {
            fileResult.Add(audio);
        }
        
        uploadDto.Files = fileResult;
        await _uploadRepository.UploadMedia(uploadDto);
        
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

        //image
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> filesResult = new List<IFormFile>();
        
        List<UpdatePodcastMediaViewModel> mediaList = await _podcastRepository.ShowPodcastsMediaForUpdate(podcast.Result.PodcastId);
        ViewBag.MediaImage = mediaList;
        
        return View(podcast.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePodcast(UpdatePodcastDto dto, List<Guid> tagId, List<IFormFile> featureImgFile, List<IFormFile> audioFile)
    {

        if (!ModelState.IsValid)
        {
            var tagForUpdate = await _tagRepository.Get();
            ViewBag.Tag = tagForUpdate.Result;

            ViewBag.Podcast = await _podcastRepository.ShowPodcastsForUpdate(dto.PodcastId);
            
            return View();
        }
        
        //upload images
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> filesResult = new List<IFormFile>();
        
        uploadDto.PodcastId = dto.PodcastId;
        
        foreach (var fileItem in featureImgFile)
        {
            filesResult.Add(fileItem);
        }
        foreach (var fileItem in audioFile)
        {
            filesResult.Add(fileItem);
        }
        uploadDto.Files = filesResult;
        await _uploadRepository.UploadMedia(uploadDto);
        
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
        //image
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> filesResult = new List<IFormFile>();
        
        List<UpdatePodcastMediaViewModel> mediaList = await _podcastRepository.ShowPodcastsMediaForUpdate(podcast.Result.PodcastId);
        ViewBag.MediaImage = mediaList;
        
        return View(podcast.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeletePodcastById(Guid podcastId)
    {
        var podcastMediaToDel = _podcastRepository.DeleteMediasForPodcast(podcastId);
        var resMedia = new GenericResponse();
        foreach (var item in podcastMediaToDel.Result)
        {
            resMedia = await _uploadRepository.DeleteMedia(item.MediaId);
        }
        TempData["ResultDelete"] = resMedia.Status == UtilitiesStatusCodes.Success  ? "true" : "false";

        var resData = await _podcastRepository.Delete(podcastId);
        TempData["ResultDelete"] = resData.Status == UtilitiesStatusCodes.Success  ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
    
    public async Task<IActionResult> DeletePodcastMediaById(Guid id, Guid podcastId)
    {
        var response =  await _uploadRepository.DeleteMedia(id);
        return RedirectToAction(nameof(UpdatePodcast), new { id = podcastId});
    }
}