using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminNewsLetterController : Controller
{
 private readonly INewsLetterRepository _newsLetterRepository;

    public AdminNewsLetterController(INewsLetterRepository newsLetterRepository)
    {
        _newsLetterRepository = newsLetterRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _newsLetterRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddNewsLetter(Guid id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddNewsLetter(AddNewsLetterDto dto)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_newsLetterRepository.ExistNewsLetter(dto.Email,0))
        // {
        //     ModelState.AddModelError("ErrorNewsLetter", "ایمیل تکراری است");
        //     return View(dto);
        // }
        
        var newsLetter = await _newsLetterRepository.Add(dto);
        Guid newsLetterId = newsLetter.Result.NewsLetterId;
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateNewsLetter(Guid id)
    {
        var newsLetter = await _newsLetterRepository.GetById(id);
        if (newsLetter.Result == null)
        {
            TempData["NotFoundNewsLetter"] = "true";
            return RedirectToAction(nameof(Index));
        }
        return View(newsLetter.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateNewsLetter(UpdateNewsLetterDto dto, Guid id)
    {
        var newsLetter = await _newsLetterRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(newsLetter.Result);
        }
        
        var updateNewsLetter = await _newsLetterRepository.Update(id, dto);
        
        TempData["Result"] = updateNewsLetter.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteNewsLetter(Guid id)
    {
        var newsLetter = await _newsLetterRepository.GetById(id);
        if (newsLetter.Result == null)
        {
            TempData["NotFoundNewsLetter"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(newsLetter.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteNewsLetterById(Guid id)
    {
        var response = await _newsLetterRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}