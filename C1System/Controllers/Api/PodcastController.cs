using C1System.Core.Services.podcast;
using C1System.DataLayar.Entities;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class PodcastController : ControllerBase
    {
    //    private readonly IPodcastService _service;
    //    public PodcastController(IPodcastService service)
    //    {
    //        _service = service;
    //    }

    //    [HttpGet]
    //    public IEnumerable<Podcast> GetAllPodcasts()
    //    {
    //        return _service.GetAllPodcast();
    //    }

    //    [HttpGet("{id}")]
    //    public IActionResult GetPodcast(Guid id)
    //    {
    //        Podcast pod = _service.GetPodcastById(id);
    //        if (pod != null)
    //        {
    //            return Ok(pod);
    //        }
    //        return NotFound();
    //    }

        
    //    [HttpPost]
    //    public IActionResult AddPodcast([FromBody] Podcast podcast)
    //    {
    //        bool pod = _service.AddPodcast(podcast);
    //        if (pod == true)
    //        {
    //            return Ok();
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }


    //    }

    //    [HttpPut]
    //    public IActionResult UpdatePodcast( [FromBody] Podcast podcast)
    //    {
    //        bool pod =_service.UpdatePodcast(podcast);
    //        if (pod == true)
    //        {
    //            return Ok();
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }

    //    [HttpPost]
    //    public IActionResult DeletePodcast([FromBody] Podcast podcast)
    //    {
    //        bool pod = _service.DeletePodcast(podcast);
    //        if (pod == true)
    //        {
    //            return Ok();
    //        }
    //        else
    //        {
    //            return BadRequest();
    //        }
    //    }


    }
}
