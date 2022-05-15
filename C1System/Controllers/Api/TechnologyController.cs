using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class TechnologyController : ControllerBase
{
    private readonly ITechnologyRepository _technologyRepository;

    public TechnologyController(ITechnologyRepository technologyRepository)
    {
        _technologyRepository = technologyRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetTechnologyDto>>>> GetTechnologies()
    {
        var technologies = await _technologyRepository.Get();
        return Ok(technologies.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateTechnology([FromBody]AddUpdateTechnologyDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdTechnology = await _technologyRepository.Add(dto);
        return CreatedAtAction(nameof(GetTechnology), new { id = createdTechnology.Id}, createdTechnology.Result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPortfolioDto>> GetTechnology(Guid id)
    {
        var technology = await _technologyRepository.GetById(id);

        if (technology == null) return NotFound();

        return Ok(technology.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetTechnologyDto>> UpdateTechnology([FromBody]AddUpdateTechnologyDto dto, Guid id)
    {
        var technology =  await _technologyRepository.Update(id, dto);
        return Ok(technology.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteTechnology(Guid id)
    {
        await _technologyRepository.Delete(id);
        return NoContent();
    }
}
