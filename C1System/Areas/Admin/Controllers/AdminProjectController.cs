using C1System.Dtos.Media;
using C1System.Media;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

[Area("Admin")]
public class AdminProjectController : Controller
{
    private readonly IProjectRepository _projectRepository;
    private readonly IUploadRepository _uploadRepository;

    public AdminProjectController(IProjectRepository projectRepository, IUploadRepository uploadRepository)
    {
        _projectRepository = projectRepository;
        _uploadRepository = uploadRepository;
    }
    
    public async Task<IActionResult> Index()
    {
        var model = await _projectRepository.Get();
        return View(model.Result);
    }
    
    [HttpGet]
    public IActionResult AddProject(Guid id)
    {
        if (id != null)
        {
            ViewBag.Id = id;
        }
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> AddProject(AddProjectDto dto, List<IFormFile> featureFile)
    {
        if (!ModelState.IsValid)
        {
            return View(dto);
        }
        // if (_projectRepository.ExistProject(dto.Title,0))
        // {
        //     ModelState.AddModelError("ErrorProject", "پروژه تکراری است");
        //     return View(dto);
        // }
        
        var newProject = await _projectRepository.Add(dto);
        Guid projectId = newProject.Result.ProjectId;
        
        //upload image
        UploadDto uploadDto = new UploadDto();
        List<IFormFile> fileResult = new List<IFormFile>();

        uploadDto.ProjectId = newProject.Result.ProjectId;

        foreach (var fileItem in featureFile)
        {
            fileResult.Add(fileItem);
        }

        uploadDto.Files = fileResult;
        await _uploadRepository.UploadMedia(uploadDto);

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> UpdateProject(Guid id)
    {
        var project = await _projectRepository.GetById(id);
        if (project.Result == null)
        {
            TempData["NotFoundProject"] = "true";
            return RedirectToAction(nameof(Index));
        }

        return View(project.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> UpdateProject(UpdateProjectDto dto, Guid id)
    {
        var tag = await _projectRepository.GetById(id);
        if (!ModelState.IsValid)
        {
            return View(tag.Result);
        }
        
        var updateProject = await _projectRepository.Update(id, dto);
        
        TempData["Result"] = updateProject.Result != null ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> DeleteProject(Guid id)
    {
        var project = await _projectRepository.GetById(id);
        if (project.Result == null)
        {
            TempData["NotFoundProject"] = true;
            return RedirectToAction(nameof(Index));
        }
        return View(project.Result);
    }
    
    [HttpPost]
    public async Task<IActionResult> DeleteProjectById(Guid id)
    {
        var response = await _projectRepository.Delete(id);
        TempData["ResultDelete"] = response.Status == UtilitiesStatusCodes.Success ? "true" : "false";
        return RedirectToAction(nameof(Index));
    }
}