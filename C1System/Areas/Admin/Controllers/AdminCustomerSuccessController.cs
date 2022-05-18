using C1System.Dtos.Media;
using C1System.Media;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminCustomerSuccessController : Controller
{
    private readonly ICustomerSuccessRepository _customerSuccessRepository;
    private readonly IUploadRepository _uploadRepository;

    public AdminCustomerSuccessController(ICustomerSuccessRepository customerSuccessRepository, IUploadRepository uploadRepository)
    {
        _customerSuccessRepository = customerSuccessRepository;
        _uploadRepository = uploadRepository;

    }

    public async Task<IActionResult> Index()
    {
        var model = await _customerSuccessRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddCustomerSuccess(Guid id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddCustomerSuccess(AddCustomerSuccessDto dto,  List<IFormFile> companyLogoFile, List<IFormFile> videoFile, List<IFormFile> videoCoverFile)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_customerSuccessRepository.ExistCustomerSuccess(dto.StartupName,0))
        // {
        //     ModelState.AddModelError("ErrorCustomerSuccess", "موفقیت مشتری تکراری است");
        //     return View(dto);
        // }
        
        var newCustomerSuccess = await _customerSuccessRepository.Add(dto);
        Guid customerSuccessId = newCustomerSuccess.Result.CustomerSuccessId;
        
        //upload images and video
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> fileResult = new List<IFormFile>();

        uploadDto.CustomerSuccessId = newCustomerSuccess.Result.CustomerSuccessId;

        foreach (var fileItem in companyLogoFile)
        {
            fileResult.Add(fileItem);
        }
        foreach (var audio in videoFile)
        {
            fileResult.Add(audio);
        }
        foreach (var audio in videoCoverFile)
        {
            fileResult.Add(audio);
        }
        uploadDto.Files = fileResult;
        await _uploadRepository.UploadMedia(uploadDto);
        
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCustomerSuccess(Guid id)
    {
        var customerSuccess = await _customerSuccessRepository.GetById(id);
        if (customerSuccess.Result == null)
        {
            TempData["NotFoundCustomerSuccess"] = "true";
            return RedirectToAction(nameof(Index));
        }

        return View(customerSuccess.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateCustomerSuccess(UpdateCustomerSuccessDto dto, Guid id)
    {
        var customerSuccess = await _customerSuccessRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(customerSuccess.Result);
        }
        
        var updateCustomerSuccess = await _customerSuccessRepository.Update(id, dto);
        
        TempData["Result"] = updateCustomerSuccess.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteCustomerSuccess(Guid id)
    {
        var customerSuccess = await _customerSuccessRepository.GetById(id);
        if (customerSuccess.Result == null)
        {
            TempData["NotFoundCustomerSuccess"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(customerSuccess.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteCustomerSuccessById(Guid id)
    {
        var response = await _customerSuccessRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}