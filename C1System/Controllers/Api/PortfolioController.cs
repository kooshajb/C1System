using System.Collections.Generic;
using System.Threading.Tasks;
using C1System.Core.Dtos.Category;
using C1System.Core.Dtos.Portfolio;
using C1System.Core.Services.category;
using C1System.Core.Services.portfolio;
using C1System.DataLayar.Entities.Responses;
using Microsoft.AspNetCore.Mvc;

namespace C1System.Areas.Admin.Controllers;

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
    public async Task<ActionResult<GenericResponse<IEnumerable<GetPortfolioDto>>>> GetCategories()
    {
        var categories = await _portfolioRepository.Get();
        return Ok(categories.Result);
    }

    [HttpPost]
    public async Task<ActionResult> CreatePortfolio([FromBody]AddUpdatePortfolioDto dto)
    {
        if (dto == null)  return BadRequest();
        var createdPortfolio = await _portfolioRepository.Add(dto);
        return CreatedAtAction(nameof(GetPortfolio), new { id = createdPortfolio.Id}, createdPortfolio.Result);
    }
        
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<GetPortfolioDto>> GetPortfolio(Guid id)
    {
        var portfolio = await _portfolioRepository.GetById(id);
       
        if (portfolio == null) return NotFound();

        return Ok(portfolio.Result);
    }

    [HttpPut("{id:guid}")]
    public async Task<ActionResult<GetPortfolioDto>> UpdatePortfolio([FromBody]AddUpdatePortfolioDto dto, Guid id)
    {
        var portfolio =  await _portfolioRepository.Update(id, dto);
        return Ok(portfolio.Result);
    }

    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeletePortfolio(Guid id)
    {
        await _portfolioRepository.Delete(id);
        return NoContent();
    }
}