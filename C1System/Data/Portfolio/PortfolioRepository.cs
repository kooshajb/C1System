using System.Linq;
using AutoMapper;
using C1System.Media;
using C1System.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface IPortfolioRepository
{
    Task<GenericResponse<GetPortfolioDto>> Add(AddPortfolioDto dto);
    Task<GenericResponse<IEnumerable<GetPortfolioDto>>> Get();
    Task<GenericResponse<GetPortfolioDto>> GetById(Guid id);
    Task<GenericResponse<GetPortfolioDto>> Update(Guid id, UpdatePortfolioDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistPortfolio(string title, Guid portfolioId);
    bool AddPortfoliosForCategory(List<Category_PortfolioEntity> categoryPortfolios);
    bool AddPortfoliosForTechnology(List<Technology_PortfolioEntity> portfolioTechnologies);
    Task<List<UpdatePortfolioCatViewModel>>ShowPortfoliosCatForUpdate(Guid portfolioId);
    Task<List<UpdatePortfolioTechViewModel>> ShowPortfoliosTechForUpdate(Guid portfolioId);
    bool DeletePortfolioForCategory(Guid portfolioId);
    bool DeletePortfolioForTechnology(Guid portfolioId);
    Task<List<UpdatePortfolioMediaViewModel>> ShowPortfoliosMediaForUpdate(Guid portfolioId);
}

public class PortfolioRepository : IPortfolioRepository
{
    private C1SystemContext _context;
    private readonly IMapper _mapper;

    public PortfolioRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetPortfolioDto>> Add(AddPortfolioDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        PortfolioEntity portfolio = _mapper.Map<PortfolioEntity>(dto);

        EntityEntry<PortfolioEntity> i = await _context.Set<PortfolioEntity>().AddAsync(portfolio);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetPortfolioDto>>> Get()
    {
        IEnumerable<PortfolioEntity> i = await _context.Set<PortfolioEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetPortfolioDto>>(_mapper.Map<IEnumerable<GetPortfolioDto>>(i));
    }
    
    public async Task<GenericResponse<GetPortfolioDto>> GetById(Guid id)
    {
        PortfolioEntity? i = await _context.Set<PortfolioEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.PortfolioId == id);
        return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i));
    }

    public async Task<GenericResponse<GetPortfolioDto>> Update(Guid id, UpdatePortfolioDto dto)
    {
        var i = _context.Set<PortfolioEntity>()
            .Where(p => p.PortfolioId == id).First();

        i.Title = dto.Title;
        i.SubTitle = dto.SubTitle;
        i.Description = dto.Description;
        i.SiteAddress = dto.SiteAddress;
        i.CompanyName = dto.CompanyName;
        i.CompanyLogo = dto.CompanyLogo;
        i.FeatureMedia = dto.FeatureMedia;
        // if ()
        // {
        //     i.Media.fi = dto.Media.Files;
        // }
        
        i.Point = dto.Point;
        i.IsActive = dto.IsActive;
        i.PortfolioSort = dto.PortfolioSort;
        
        _context.Set<PortfolioEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetPortfolioDto> i = await GetById(id);
        _context.Set<PortfolioEntity>().Remove(_mapper.Map<PortfolioEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Portfolio {i.Result.Title} delete Success {i.Result.PortfolioId}");
    }

    public bool ExistPortfolio(string title, Guid portfolioId)
    {
        return _context.Portfolios.Any(p =>
            p.Title == title && p.PortfolioId != portfolioId);
    }
    
    public bool AddPortfoliosForCategory(List<Category_PortfolioEntity> categoryPortfolios)
    {
        try
        {
            _context.CategoryPortfolios.AddRange(categoryPortfolios);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public bool AddPortfoliosForTechnology(List<Technology_PortfolioEntity> portfolioTechnologies)
    {
        try
        {
            _context.TechnologyPortfolios.AddRange(portfolioTechnologies);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public async Task<List<UpdatePortfolioCatViewModel>> ShowPortfoliosCatForUpdate(Guid portfolioId)
    {
        List<UpdatePortfolioCatViewModel> updates = await (from cp in _context.CategoryPortfolios
            join p in _context.Portfolios on cp.PortfolioId equals p.PortfolioId
            where (cp.PortfolioId == portfolioId)
            select new UpdatePortfolioCatViewModel()
            {
                CategoryPortfolioId = cp.CategoryPortfolioId,
                CategoryId = cp.CategoryId,
                PortfolioId = p.PortfolioId,
                PortfolioTitle = p.Title
            }).ToListAsync();
    
        return updates;
    }
    
    public async Task<List<UpdatePortfolioTechViewModel>> ShowPortfoliosTechForUpdate(Guid portfolioId)
    {
        List<UpdatePortfolioTechViewModel> updates = await (from tp in _context.TechnologyPortfolios
            join p in _context.Portfolios on tp.PortfolioId equals p.PortfolioId
            where (tp.PortfolioId == portfolioId)
            select new UpdatePortfolioTechViewModel()
            {
                TechnologyPortfolioId = tp.TechnologyPortfolioId,
                TechnologyId = tp.TechnologyId,
                PortfolioId = p.PortfolioId,
                PortfolioTitle = p.Title
            }).ToListAsync();
    
        return updates;
    }
    
    public bool DeletePortfolioForCategory(Guid portfolioId)
    {
        try
        {
            List<Category_PortfolioEntity> categories = _context.CategoryPortfolios.Where(c => c.PortfolioId == portfolioId).ToList();
            _context.CategoryPortfolios.RemoveRange(categories);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return true;
        }
    }
    
    public bool DeletePortfolioForTechnology(Guid portfolioId)
    {
        try
        {
            List<Technology_PortfolioEntity> technologies = _context.TechnologyPortfolios.Where(t => t.PortfolioId == portfolioId).ToList();
            _context.TechnologyPortfolios.RemoveRange(technologies);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return true;
        }
    }
    
    public async Task<List<UpdatePortfolioMediaViewModel>> ShowPortfoliosMediaForUpdate(Guid portfolioId)
    {
        var result = await (from p in _context.Portfolios
            join m in _context.Media on p.PortfolioId equals m.PortfolioId
            where (p.PortfolioId == portfolioId)
            select new UpdatePortfolioMediaViewModel()
            {
                PortfolioId = p.PortfolioId,
                FileName = m.FileName,
            }).ToListAsync();
        
        return result;
    }
}
