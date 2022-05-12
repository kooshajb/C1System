using AutoMapper;
using C1System.Core.Dtos.Portfolio;
using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using C1System.DataLayar.Entities.Responses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace C1System.Core.Services.portfolio
{
    public interface IPortfolioRepository
    {
        //Task<GenericResponse<GetPortfolioDto>> Add(AddUpdatePortfolioDto dto);
        //Task<GenericResponse<IEnumerable<GetPortfolioDto>>> Get();
        //Task<GenericResponse<GetPortfolioDto>> GetById(Guid? id);
        //Task<GenericResponse<GetPortfolioDto>> Update(Guid id, AddUpdatePortfolioDto dto);
        //bool Delete(Guid id);
        
    }

    public class PortfolioRepository : IPortfolioRepository
    {
        //private C1SystemContext _context;
        //private readonly IMapper _mapper;
        //public PortfolioRepository(C1SystemContext context , IMapper mapper)
        //{
        //    _context = context;
        //    _mapper = mapper;
        //}

        //public async Task<GenericResponse<GetPortfolioDto>> Add(AddUpdatePortfolioDto dto)
        //{
        //    if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        //    Portfolio portfolio = _mapper.Map<Portfolio>(dto);

        //    EntityEntry<Portfolio> i = await _context.Set<Portfolio>().AddAsync(portfolio);
        //    await _context.SaveChangesAsync();
        //    return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i.Entity));
        //}

        //public async Task<GenericResponse<IEnumerable<GetPortfolioDto>>> Get()
        //{
        //    List<Portfolio> Portfolio = await _context.Set<Portfolio>()
        //       .Where(c => c.IsDelete == null)
        //       .ToListAsync();
        //    List<GetPortfolioDto> PortfolioDtos = _mapper.Map<List<GetPortfolioDto>>(Portfolio);

        //    return new GenericResponse<IEnumerable<GetPortfolioDto?>>(PortfolioDtos, C1System.DataLayar.Entities.Utilities.Enums.UtilitiesStatusCodes.Success,
        //    message: "Success");
        //}

        //public async Task<GenericResponse<GetPortfolioDto>> GetById(Guid? id)
        //{
        //    Portfolio? Content = await _context.Set<Portfolio>()
        //        .FirstOrDefaultAsync(c => c.PortfolioId == id);

        //    GetPortfolioDto PortfolioDtos = _mapper.Map<GetPortfolioDto>(Content);

        //    return new GenericResponse<GetPortfolioDto?>(PortfolioDtos, C1System.DataLayar.Entities.Utilities.Enums.UtilitiesStatusCodes.Success,
        //    message: "Success");
        //}

        //public async Task<GenericResponse<GetPortfolioDto>> Update(Guid id, AddUpdatePortfolioDto dto)
        //{
        //    var i = _context.Set<Portfolio>()
        //        .Where(p => p.PortfolioId == id).First();

        //    i.Title = dto.Title;
        //    i.SubTitle = dto.SubTitle;
        //    i.Description = dto.Description;
        //    i.SiteAddress = dto.SiteAddress;
        //    i.CompanyName = dto.CompanyName;
        //    i.CompanyLogo = dto.CompanyLogo;
        //    i.FeatureMedia = dto.FeatureMedia;
        //    i.Media = dto.Media;
        //    i.Point = dto.Point;

        //    _context.Set<Portfolio>().Update(i);
        //    await _context.SaveChangesAsync();
        //    return new GenericResponse<GetPortfolioDto>(_mapper.Map<GetPortfolioDto>(i));

        //}

        //public bool Delete(Guid id)
        //{
        //    try
        //    {
        //        Portfolio i = _context.Portfolios.Find(id);

        //        _context.Portfolios.Remove(i);
        //         _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
            
        //}
    }
}
