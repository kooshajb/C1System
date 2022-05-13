using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryController(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetCategoryDto>>>> GetCategories()
    {
        var categories = await _categoryRepository.Get();
        return Ok(categories.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreateCategory([FromBody]AddUpdateCategoryDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdCategory = await _categoryRepository.Add(dto);
        return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.Id}, createdCategory.Result);
    }
        
    [HttpGet("{id:int}")]
    public async Task<ActionResult<GetCategoryDto>> GetCategory(int id)
    {
        var category = await _categoryRepository.GetById(id);

        if (category == null) return NotFound();

        return Ok(category.Result);
    }

    [HttpPut("{id:int}")]
    public async Task<ActionResult<GetCategoryDto>> UpdateProduct([FromBody]AddUpdateCategoryDto dto, int id)
    {
        var category =  await _categoryRepository.Update(id, dto);
        return Ok(category.Result);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteCategory(int id)
    {
        await _categoryRepository.Delete(id);
        return NoContent();
    }
}