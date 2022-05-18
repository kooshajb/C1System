using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminConsultingController : Controller
{
    private readonly IConsultingRepository _consultingRepository;

    public AdminConsultingController(IConsultingRepository consultingRepository)
    {
        _consultingRepository = consultingRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _consultingRepository.Get();
        return View(model.Result);
    }

    [HttpGet]
    public async Task<IActionResult> DeleteConsulting(Guid id)
    {
        var consulting = await _consultingRepository.GetById(id);
        if (consulting.Result == null)
        {
            TempData["NotFoundConsulting"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(consulting.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteConsultingById(Guid id)
    {
        var response = await _consultingRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}