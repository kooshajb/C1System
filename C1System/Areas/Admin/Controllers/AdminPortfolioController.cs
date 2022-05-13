using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminPortfolioController : Controller
{
    private readonly IPortfolioRepository _portfolioRepository;
    private readonly ICategoryRepository _categoryRepository;

    public AdminPortfolioController(IPortfolioRepository portfolioRepository, ICategoryRepository categoryRepository)
    {
        _portfolioRepository = portfolioRepository;
        _categoryRepository = categoryRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _portfolioRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddPortfolio()
    {
        ViewBag.Category = _categoryRepository.ShowSubCategory();
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPortfolio(AddUpdatePortfolioDto dto, List<Guid> categoryIds)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Category = _categoryRepository.ShowSubCategory();
            return View(dto);
        }
        // if (_portfolioRepository.ExistPortfolio(dto.Title, 0))
        // {
        //     ModelState.AddModelError("PortfolioTitle", "نمونه کار تکراری است");
        //     return View(dto);
        // }
        var portfolio = await _portfolioRepository.Add(dto);
        Guid portfolioId = portfolio.Result.PortfolioId;
        if (portfolioId == null)
        {
            TempData["Result"] = "false";
            return RedirectToAction(nameof(Index));
        }

        List<Category_Product> addCatProduct = new List<Category_Product>();
        
        foreach (var item in categoryIds)
        {
            addCatProduct.Add(new Category_Product()
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
    
    [HttpPost]
    public async Task<IActionResult> DeletePortfolioById(Guid id)
    {
        var response = await _portfolioRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}