using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class PodcastController : ControllerBase
{
    private readonly IPodcastRepository _podcastRepository;

    public PodcastController(IPodcastRepository podcastRepository)
    {
        _podcastRepository = podcastRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetPodcastDto>>>> GetPortfolios()
    {
        var podcasts = await _podcastRepository.Get();
        return Ok(podcasts.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePodcast([FromBody]AddUpdatePodcastDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdPodcast = await _podcastRepository.Add(dto);
        return CreatedAtAction(nameof(GetPodcast), new { id = createdPodcast.Id}, createdPodcast.Result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPortfolioDto>> GetPodcast(Guid id)
    {
        var podcast = await _podcastRepository.GetById(id);

        if (podcast == null) return NotFound();

        return Ok(podcast.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetPortfolioDto>> UpdatePodcast([FromBody]AddUpdatePodcastDto dto, Guid id)
    {
        var podcast =  await _podcastRepository.Update(id, dto);
        return Ok(podcast.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletePodcast(Guid id)
    {
        await _podcastRepository.Delete(id);
        return NoContent();
    }
}
