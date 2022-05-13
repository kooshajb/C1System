using C1System.Core.Services.project;
using C1System.DataLayar.Entities.Responses;
using Microsoft.AspNetCore.Mvc;


namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController : ControllerBase
{ 
//{
//    private readonly IProjectRepository _projectRepository;
//    public ProjectsController(IProjectRepository projectRepository)
//    {
//        _projectRepository = projectRepository;
//    }

//    [HttpGet]
//    public async Task<ActionResult<GenericResponse<IEnumerable<GetTagDto>>>> GetTag()
//    {
//        var tag = await _tagRepository.Get();
//        return Ok(tag.Result);
//    }

//    [HttpPost]
//    public async Task<ActionResult> CreateTag([FromBody] AddUpdateTagDto dto)
//    {
//        if (dto == null) return BadRequest();
//        var tag = await _tagRepository.Add(dto);
//        return CreatedAtAction(nameof(GetTag), new { id = tag.Id }, tag.Result);
//    }

//    [HttpGet("{id:guid}")]
//    public async Task<ActionResult<GetTagDto>> GetTag(Guid id)
//    {
//        var tag = await _tagRepository.GetById(id);

//        if (tag == null) return NotFound();

//        return Ok(tag.Result);
//    }

//    [HttpPut("{id:guid}")]
//    public async Task<ActionResult<GetTagDto>> UpdateTag([FromBody] AddUpdateTagDto dto, Guid id)
//    {
//        var tag = await _tagRepository.Update(id, dto);
//        return Ok(tag.Result);
//    }

//    [HttpDelete("{id:guid}")]
//    public async Task<ActionResult> DeleteTag(Guid id)
//    {
//        await _tagRepository.Delete(id);
//        return NoContent();
//    }
}