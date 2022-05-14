﻿using System.Linq;
using AutoMapper;
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
    bool AddPortfoliosForCategory(List<Category_Portfolio> categoryPortfolios);
    Task<List<UpdatePortfolioViewModel>>ShowPortfoliosForUpdate(Guid portfolioId);
    bool DeletePortfolioForCategory(Guid portfolioId);
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
        Portfolio portfolio = _mapper.Map<Portfolio>(dto);

        EntityEntry<Portfolio> i = await _context.Set<Portfolio>().AddAsync(portfolio);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetPortfolioDto>>> Get()
    {
        IEnumerable<Portfolio> i = await _context.Set<Portfolio>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetPortfolioDto>>(_mapper.Map<IEnumerable<GetPortfolioDto>>(i));
    }
    
    public async Task<GenericResponse<GetPortfolioDto>> GetById(Guid id)
    {
        Portfolio? i = await _context.Set<Portfolio>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.PortfolioId == id);
        return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i));
    }

    public async Task<GenericResponse<GetPortfolioDto>> Update(Guid id, UpdatePortfolioDto dto)
    {
        var i = _context.Set<Portfolio>()
            .Where(p => p.PortfolioId == id).First();

        i.Title = dto.Title;
        i.SubTitle = dto.SubTitle;
        i.Description = dto.Description;
        i.SiteAddress = dto.SiteAddress;
        i.CompanyName = dto.CompanyName;
        i.CompanyLogo = dto.CompanyLogo;
        i.FeatureMedia = dto.FeatureMedia;
        i.Media = dto.Media;
        i.Point = dto.Point;

        _context.Set<Portfolio>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetPortfolioDto> i = await GetById(id);
        _context.Set<Portfolio>().Remove(_mapper.Map<Portfolio>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Portfolio {i.Result.Title} delete Success {i.Result.PortfolioId}");
    }

    public bool ExistPortfolio(string title, Guid portfolioId)
    {
        return _context.Portfolios.Any(p =>
            p.Title == title && p.PortfolioId != portfolioId);
    }
    
    public bool AddPortfoliosForCategory(List<Category_Portfolio> categoryPortfolios)
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
    
    public async Task<List<UpdatePortfolioViewModel>> ShowPortfoliosForUpdate(Guid portfolioId)
    {
        List<UpdatePortfolioViewModel> updates = await (from cp in _context.CategoryPortfolios
            join p in _context.Portfolios on cp.PortfolioId equals p.PortfolioId
            where (cp.PortfolioId == portfolioId)
            select new UpdatePortfolioViewModel()
            {
                CategoryPortfolioId = cp.CategoryPortfolioId,
                CategoryId = cp.CategoryId,
                PortfolioId = p.PortfolioId,
                PortfolioTitle = p.Title
            }).ToListAsync();
    
        return updates;
    }
    
    public bool DeletePortfolioForCategory(Guid portfolioId)
    {
        try
        {
            List<Category_Portfolio> categories = _context.CategoryPortfolios.Where(c => c.PortfolioId == portfolioId).ToList();
            _context.CategoryPortfolios.RemoveRange(categories);
            _context.SaveChanges();
            return true;
        }
        catch (Exception)
        {
            return true;
        }
    }
}
