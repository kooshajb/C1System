using System;
using System.Threading.Tasks;
using C1System.Dtos.Media;
using C1System.Media;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminPortfolioController : Controller
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUploadRepository _uploadRepository;
    public AdminPortfolioController(IPortfolioRepository portfolioRepository, ICategoryRepository categoryRepository, IUploadRepository uploadRepository)
    {
        _portfolioRepository = portfolioRepository;
        _categoryRepository = categoryRepository;
        _uploadRepository = uploadRepository;
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
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPortfolio(AddPortfolioDto dto, List<Guid> categoryId, UploadDto uploadDto)
    {
        if (!ModelState.IsValid)
        {
            var categories = await _categoryRepository.Get();
            ViewBag.Category = categories.Result;
            return View(dto);
        }
        // if (_portfolioRepository.ExistPortfolio(dto.Title, 0))
        // {
        //     ModelState.AddModelError("PortfolioTitle", "نمونه کار تکراری است");
        //     return View(dto);
        // }
        
        if (dto.PortfolioSort <= 0)
        {
            ModelState.AddModelError("ErrorSort", "لطفا ترتیب نمونه کار را وارد نمایید .");
            return View(dto);
        }
        
        if (file == null)
        {
            ModelState.AddModelError("PortfolioImg", "لطفا یک تصویر برای نمونه کار انتخاب نمایید .");
            return View(dto);
        }

        _uploadRepository.UploadMedia(uploadDto);
        
        //image
        // string imgname = uplodimg.CreateImage(file);
        // if (imgname == "false")
        // {
        //     TempData["Result"] = "false";
        //     return RedirectToAction(nameof(Index));
        // }
        // dto.FeatureMedia = imgname;
        // var res = _portfolioRepository.Add(dto);
        // TempData["Result"] = res.Result != null ? "true" : "false";
        // return RedirectToAction(nameof(Index));
        
        
        var portfolio = await _portfolioRepository.Add(dto);
        Guid portfolioId = portfolio.Result.PortfolioId;
        if (portfolioId == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }

        List<Category_PortfolioEntity> addCatProduct = new List<Category_PortfolioEntity>();
        
        foreach (var item in categoryId)
        {
            addCatProduct.Add(new Category_PortfolioEntity()
            {
                CategoryId = item,
                PortfolioId = portfolioId
            });
        }

        bool res = _portfolioRepository.AddPortfoliosForCategory(addCatProduct);
        TempData["Result"] = res ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdatePortfolio(Guid id)
    {
        var categories = await _categoryRepository.Get();
        ViewBag.Category = categories.Result;
        ViewBag.Portfolio = await _portfolioRepository.ShowPortfoliosForUpdate(id);
        
        var portfolio = _portfolioRepository.GetById(id).Result;
        return View(portfolio.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdatePortfolio(UpdatePortfolioDto dto, List<Guid> categoryId)
    {
        if (!ModelState.IsValid)
        {
            var categoryForUpdate = await _categoryRepository.Get();
            ViewBag.Category = categoryForUpdate.Result;
            ViewBag.Property = _portfolioRepository.ShowPortfoliosForUpdate(dto.PortfolioId);
            return View();
        }
        
        // if (_portfolioRepository.ExistPortfolio(dto.Title, dto.PortfolioId))
        // {
        //     ModelState.AddModelError("PortfolioTitle", "نمونه کار تکراری است .");
        //     return View(dto);
        // }
        
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