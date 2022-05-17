using System;
using System.Threading.Tasks;
using C1System.Dtos.Media;
using C1System.Media;
using C1System.ViewModels;
using Microsoft.AspNetCore.Mvc;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminPortfolioController : Controller
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly ITechnologyRepository _technologyRepository;
    private readonly IUploadRepository _uploadRepository;
    private readonly IMediaRepository _mediaRepository;
    private readonly IHostingEnvironment _environment;

    public AdminPortfolioController(IPortfolioRepository portfolioRepository, ICategoryRepository categoryRepository,ITechnologyRepository technologyRepository, IUploadRepository uploadRepository, IMediaRepository mediaRepository, IHostingEnvironment environment)
    {
        _portfolioRepository = portfolioRepository;
        _categoryRepository = categoryRepository;
        _technologyRepository = technologyRepository;
        _uploadRepository = uploadRepository;
        _mediaRepository = mediaRepository;
        _environment = environment;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _portfolioRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public async Task<IActionResult> AddPortfolio()
    {
        var categories = await _categoryRepository.Get();
        ViewBag.Category = categories.Result;
        
        var technologies = await _technologyRepository.Get();
        ViewBag.Technology = technologies.Result;
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPortfolio(AddPortfolioDto dto, List<Guid> categoryId, List<Guid> technologyId, List<IFormFile> files)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _categoryRepository.Get();
            ViewBag.Category = categories.Result;
            var technologies = await _technologyRepository.Get();
            ViewBag.Technology = technologies.Result;

            return View(dto);
        }
        // if (_portfolioRepository.ExistPortfolio(dto.Title, 0))
        // {
        //     ModelState.AddModelError("PortfolioTitle", "نمونه کار تکراری است");
        //     return View(dto);
        // }
        
        if (dto.PortfolioSort <= 0)
        {
            ModelState.AddModelError("ErrorSort", "لطفا ترتیب نمونه کار را وارد نمایید.");
            return View(dto);
        }
        
        if (files == null)
        {
            ModelState.AddModelError("PortfolioImg", "لطفا یک تصویر برای نمونه کار انتخاب نمایید.");
            return View(dto);
        }
        
        var portfolio = await _portfolioRepository.Add(dto);
        Guid portfolioId = portfolio.Result.PortfolioId;
        if (portfolioId == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }

        //upload images
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> filesResult = new List<IFormFile>();
        
        uploadDto.PortfolioId = dto.PortfolioId;
        
        foreach (var fileItem in files)
        {
            filesResult.Add(fileItem);
        }
        uploadDto.Files = filesResult;
        await _uploadRepository.UploadMedia(uploadDto);
        
        //categories
        List<Category_PortfolioEntity> addCatPortfolio = new List<Category_PortfolioEntity>();
        
        foreach (var item in categoryId)
        {
            addCatPortfolio.Add(new Category_PortfolioEntity()
            {
                CategoryId = item,
                PortfolioId = portfolioId
            });
        }

        bool resCat = _portfolioRepository.AddPortfoliosForCategory(addCatPortfolio);
        TempData["Result"] = resCat ? "true" : "false";
        
        //technology
        List<Technology_PortfolioEntity> addPortfolioTech = new List<Technology_PortfolioEntity>();
        
        foreach (var item in technologyId)
        {
            addPortfolioTech.Add(new Technology_PortfolioEntity()
            {
                TechnologyId = item,
                PortfolioId = portfolioId
            });
        }

        bool resTech = _portfolioRepository.AddPortfoliosForTechnology(addPortfolioTech);
        TempData["Result"] = resTech ? "true" : "false";
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePortfolio(Guid id)
    {
        var categories = await _categoryRepository.Get();
        ViewBag.Category = categories.Result;
        
        var technologies = await _technologyRepository.Get();
        ViewBag.Technology = technologies.Result;

        ViewBag.PortfolioCat = await _portfolioRepository.ShowPortfoliosCatForUpdate(id);
        ViewBag.PortfolioTech = await _portfolioRepository.ShowPortfoliosTechForUpdate(id);
        
        var portfolio = _portfolioRepository.GetById(id).Result;
        
        //image
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> filesResult = new List<IFormFile>();
        
        List<UpdatePortfolioMediaViewModel> mediaList = await _portfolioRepository.ShowPortfoliosMediaForUpdate(portfolio.Result.PortfolioId);

        ViewBag.MediaImage = mediaList;
        
        return View(portfolio.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePortfolio(UpdatePortfolioDto dto, List<Guid> categoryId, List<Guid> technologyId, List<IFormFile> files)
    {
        if (!ModelState.IsValid)
        {
            var categoryForUpdate = await _categoryRepository.Get();
            ViewBag.Category = categoryForUpdate.Result;
            
            var technologies = await _technologyRepository.Get();
            ViewBag.Technology = technologies.Result;
            
            ViewBag.PortfolioCat = await _portfolioRepository.ShowPortfoliosCatForUpdate(dto.PortfolioId);
            ViewBag.PortfolioTech = await _portfolioRepository.ShowPortfoliosTechForUpdate(dto.PortfolioId);
            
            return View();
        }
        
        if (files != null)
        {
            
            UploadDto uploadDto = new UploadDto();
            List<IFormFile> filesResult = new List<IFormFile>();
        
            uploadDto.PortfolioId = dto.PortfolioId;
        
            foreach (var fileItem in files)
            {
                filesResult.Add(fileItem);
            }

            uploadDto.Files = filesResult;
            await _uploadRepository.UploadMedia(uploadDto);
        }
        
        // if (_portfolioRepository.ExistPortfolio(dto.Title, dto.PortfolioId))
        // {
        //     ModelState.AddModelError("PortfolioTitle", "نمونه کار تکراری است .");
        //     return View(dto);
        // }
        
        //category
        var updatePortfolio = _portfolioRepository.Update(dto.PortfolioId, dto);
        
        if (updatePortfolio.Result == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        bool deletePortfolio = _portfolioRepository.DeletePortfolioForCategory(dto.PortfolioId);
        if (!deletePortfolio)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        List<Category_PortfolioEntity> categories = new List<Category_PortfolioEntity>();
        foreach (var item in categoryId)
        {
            categories.Add(new Category_PortfolioEntity
            {
                CategoryId = item,
                PortfolioId = dto.PortfolioId,
            });
        }
        bool addPortfolioForCategory = _portfolioRepository.AddPortfoliosForCategory(categories);
        TempData["Result"] = addPortfolioForCategory ? "true" : "false";
        
        //technology
        bool deleteTech = _portfolioRepository.DeletePortfolioForTechnology(dto.PortfolioId);
        if (!deleteTech)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }
        
        List<Technology_PortfolioEntity> techs = new List<Technology_PortfolioEntity>();
        foreach (var item in technologyId)
        {
            techs.Add(new Technology_PortfolioEntity
            {
                TechnologyId = item,
                PortfolioId = dto.PortfolioId,
            });
        }
        bool addPortfolioForTechnology = _portfolioRepository.AddPortfoliosForTechnology(techs);
        TempData["Result"] = addPortfolioForTechnology ? "true" : "false";

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
    
    [HttpPost]
    public async Task<IActionResult> DeletePortfolioById(Guid id)
    {
        var response = await _portfolioRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}
