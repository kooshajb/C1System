using Microsoft.AspNetCore.Mvc;


namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly IProjectRepository _projectRepository;
    public ProjectsController(IProjectRepository projectRepository)
    {
        _projectRepository = projectRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetProjectDto>>>> GetProject()
    {
        var project = await _projectRepository.Get();
        return Ok(project.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateProject([FromBody] AddUpdateProjectDto dto)
    {
        if (dto == null) return BadRequest();
        var project = await _projectRepository.Add(dto);
        return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project.Result);
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetProjectDto>> GetProject(Guid id)
    {
        var project = await _projectRepository.GetById(id);

        if (project == null) return NotFound();

        return Ok(project.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetProjectDto>> UpdateProject([FromBody] AddUpdateProjectDto dto, Guid id)
    {
        var project = await _projectRepository.Update(id, dto);
        return Ok(project.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteProject(Guid id)
    {
        await _projectRepository.Delete(id);
        return NoContent();
    }
}