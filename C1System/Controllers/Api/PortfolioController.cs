using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Controllers.Api;

[Route("api/[controller]")]
[ApiController]
public class PortfolioController : ControllerBase
{
    private readonly IPortfolioRepository _portfolioRepository;

    public PortfolioController(IPortfolioRepository portfolioRepository)
    {
        _portfolioRepository = portfolioRepository;
    }

    [HttpGet]
    public async Task<ActionResult<GenericResponse<IEnumerable<GetPortfolioDto>>>> GetPortfolios()
    {
        var portfolios = await _portfolioRepository.Get();
        return Ok(portfolios.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePortfolio([FromBody]AddPortfolioDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdPortfolio = await _portfolioRepository.Add(dto);
        return CreatedAtAction(nameof(GetPortfolio), new { id = createdPortfolio.Id}, createdPortfolio.Result);
    }
        
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetCategoryDto>> GetPortfolio(Guid id)
    {
        var category = await _portfolioRepository.GetById(id);

        if (category == null) return NotFound();

        return Ok(category.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetCategoryDto>> UpdatePortfolio([FromBody]UpdatePortfolioDto dto, Guid id)
    {
        var category =  await _portfolioRepository.Update(id, dto);
        return Ok(category.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletePortfolio(Guid id)
    {
        await _portfolioRepository.Delete(id);
        return NoContent();
    }
}