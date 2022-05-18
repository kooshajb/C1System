using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class BlogCategoryController : ControllerBase
{
    private readonly IBlogCategoryRepository _blogCategoryRepository;

    public BlogCategoryController(IBlogCategoryRepository blogCategoryRepository)
    {
        _blogCategoryRepository = blogCategoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetBlogCategoryDto>>>> GetBlogCategory()
    {
        var blogCats = await _blogCategoryRepository.Get();
        return Ok(blogCats.Result);
    }

    [HttpPost]
    public async Task<ActionResult> AddBlogCategory([FromBody]AddBlogCategoryDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdBlogCat = await _blogCategoryRepository.Add(dto);
        return CreatedAtAction(nameof(GetBlogCategory), new { id = createdBlogCat.Id}, createdBlogCat.Result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetBlogDto>> GetBlogCategory(Guid id)
    {
        var blogCat = await _blogCategoryRepository.GetById(id);

        if (blogCat == null) return NotFound();

        return Ok(blogCat.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetBlogCategoryDto>> UpdateBlogCategory([FromBody]UpdateBlogCategoryDto dto, Guid id)
    {
        var blogCat =  await _blogCategoryRepository.Update(id, dto);
        return Ok(blogCat.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteBlogCategory(Guid id)
    {
        await _blogCategoryRepository.Delete(id);
        return NoContent();
    }
}
