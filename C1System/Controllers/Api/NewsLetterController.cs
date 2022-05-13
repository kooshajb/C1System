
using C1System.Dtos.NewsLetter;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsLetterController : Controller
    {
        private readonly INewsLetterRepository _newsLetterRepository;
        public NewsLetterController(INewsLetterRepository newsLetterRepository)
        {
            _newsLetterRepository = newsLetterRepository;
        }

        [HttpGet]
        public async Task<ActionResult<GenericResponse<IEnumerable<GetNewsLetterDto>>>> GetNewsLetter()
        {
            var podcasts = await _newsLetterRepository.Get();
            return Ok(podcasts.Result);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewsLetter([FromBody] AddUpdateNewsLetterDto dto)
        {
            if (dto == null) return BadRequest();
            var createdNewsletter = await _newsLetterRepository.Add(dto);
            return CreatedAtAction(nameof(GetNewsLetter), new { id = createdNewsletter.Id }, createdNewsletter.Result);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<GetNewsLetterDto>> GetNewsLetter(Guid id)
        {
            var newsLetter = await _newsLetterRepository.GetById(id);

            if (newsLetter == null) return NotFound();

            return Ok(newsLetter.Result);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<GetNewsLetterDto>> UpdateNewsLetter([FromBody] AddUpdateNewsLetterDto dto, Guid id)
        {
            var newsLetter = await _newsLetterRepository.Update(id, dto);
            return Ok(newsLetter.Result);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteNewsLetter(Guid id)
        {
            await _newsLetterRepository.Delete(id);
            return NoContent();
        }
    }
}
