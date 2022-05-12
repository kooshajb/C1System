using C1System.Core.Dtos.Portfolio;
using C1System.Core.Services.portfolio;
using C1System.DataLayar.Entities;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PortfolioController : Controller
    {
        // private readonly IPortfolioRepository _repository;
        // public PortfolioController(IPortfolioRepository repository)
        // {
        //     _repository = repository;
        // }
        //
        // public async Task<IActionResult> Index()
        // {
        //     var model = await _repository.Get();
        //     return View(model.Result);
        // }
        //
        // #region Add
        // [HttpGet]
        // public async Task<IActionResult> AddPortfolio()
        // {
        //     return View();
        // }
        //
        // [HttpPost]
        // public async Task<IActionResult> AddPortfolio(AddUpdatePortfolioDto dto)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(dto);
        //     }
        //   
        //     var newPortfolio = await _repository.Add(dto);
        //     TempData["Result"] = newPortfolio.Result != null ? "true" : "false";
        //     return RedirectToAction(nameof(Index));
        // }
        // #endregion
        //
        // #region Delete
        //
        // [HttpGet]
        // public IActionResult Delete(Guid? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     var portfolio = _repository.GetById(id);
        //
        //     return View(portfolio.Result);
        // }
        //
        // [HttpPost]
        // public IActionResult Delete(Portfolio portfolio)
        // {
        //
        //     bool res = _repository.Delete(portfolio.PortfolioId);
        //     TempData["Result"] = res ? true : false;
        //
        //     return RedirectToAction(nameof(Index));
        // }
        // #endregion
        //
        // #region Update
        // [HttpGet]
        // public async Task<IActionResult> Update(Guid id)
        // {
        //     var Portfolio = await _repository.GetById(id);
        //     if (Portfolio == null)
        //     {
        //         TempData["NotFoundSlider"] = true;
        //         return RedirectToAction("Index");
        //     }
        //     return View(Portfolio);
        // }
        //
        // [HttpPost]
        // public async Task<IActionResult> Update(Guid id , AddUpdatePortfolioDto dto)
        // {
        //     if (!ModelState.IsValid)
        //     {
        //         return View(dto);
        //     }
        //
        //     var newPortfolio = await _repository.Update(id , dto);
        //     TempData["Result"] = newPortfolio.Result != null ? "true" : "false";
        //     return RedirectToAction(nameof(Index));
        // }
        // #endregion
    }
}
