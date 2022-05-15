using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogRepository _blogRepository;

    public BlogController(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetBlogDto>>>> GetBlogs()
    {
        var blogs = await _blogRepository.Get();
        return Ok(blogs.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateBlog([FromBody]AddUpdateBlogDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdBlog = await _blogRepository.Add(dto);
        return CreatedAtAction(nameof(GetBlog), new { id = createdBlog.Id}, createdBlog.Result);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetBlogDto>> GetBlog(Guid id)
    {
        var blog = await _blogRepository.GetById(id);

        if (blog == null) return NotFound();

        return Ok(blog.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetBlogDto>> UpdateBlog([FromBody]AddUpdateBlogDto dto, Guid id)
    {
        var blog =  await _blogRepository.Update(id, dto);
        return Ok(blog.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteBlog(Guid id)
    {
        await _blogRepository.Delete(id);
        return NoContent();
    }
}
