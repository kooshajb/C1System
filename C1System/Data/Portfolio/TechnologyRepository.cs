using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using C1System.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface ITechnologyRepository
{
    Task<GenericResponse<GetTechnologyDto>> Add(AddUpdateTechnologyDto dto);
    Task<GenericResponse<IEnumerable<GetTechnologyDto>>> Get();
    Task<GenericResponse<GetTechnologyDto>> GetById(Guid id);
    Task<GenericResponse<GetTechnologyDto>> Update(Guid id, AddUpdateTechnologyDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistPodcast(string title, Guid technologyId);
    Task<List<UpdateTechMediaViewModel>> ShowTechsMediaForUpdate(Guid technologyId);
    Task<List<UpdateTechMediaViewModel>> DeleteMediasForTechnology(Guid technologyId);
}

public class TechnologyRepository : ITechnologyRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;

    public TechnologyRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetTechnologyDto>> Add(AddUpdateTechnologyDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        TechnologyEntity entity = _mapper.Map<TechnologyEntity>(dto);

        EntityEntry<TechnologyEntity> i = await _context.Set<TechnologyEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetTechnologyDto>(_mapper.Map<GetTechnologyDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetTechnologyDto>>> Get()
    {
        IEnumerable<TechnologyEntity> i = await _context.Set<TechnologyEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetTechnologyDto>>(_mapper.Map<IEnumerable<GetTechnologyDto>>(i));
    }

    public async Task<GenericResponse<GetTechnologyDto>> GetById(Guid id)
    {
        TechnologyEntity? i = await _context.Set<TechnologyEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.TechnologyId == id);
        return new GenericResponse<GetTechnologyDto>(_mapper.Map<GetTechnologyDto>(i));
    }

    public async Task<GenericResponse<GetTechnologyDto>> Update(Guid id, AddUpdateTechnologyDto dto)
    {
        var i = _context.Set<TechnologyEntity>()
            .Where(p => p.TechnologyId == id).First();

        i.Title = dto.Title;
        
        _context.Set<TechnologyEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetTechnologyDto>(_mapper.Map<GetTechnologyDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetTechnologyDto> i = await GetById(id);
        _context.Set<TechnologyEntity>().Remove(_mapper.Map<TechnologyEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Technology {i.Result.Title} delete Success {i.Result.TechnologyId}");
    }
    
    public bool ExistPodcast(string title, Guid technologyId)
    {
        return _context.Podcasts.Any(p =>
            p.Title == title && p.PodcastId != technologyId);
    }
    
    public async Task<List<UpdateTechMediaViewModel>> ShowTechsMediaForUpdate(Guid technologyId)
    {
        var result = await (from p in _context.Technologies
            join m in _context.Media on p.TechnologyId equals m.TechnologyId
            where (p.TechnologyId == technologyId)
            select new UpdateTechMediaViewModel()
            {
                TechnologyId = p.TechnologyId,
                MediaId = m.Id,
                FileName = m.FileName,
            }).ToListAsync();
        
        return result;
    }
    
    public async Task<List<UpdateTechMediaViewModel>> DeleteMediasForTechnology(Guid technologyId)
    {
        var resultTodelete = await (from p in _context.Technologies
            join m in _context.Media on p.TechnologyId equals m.TechnologyId
            where (p.TechnologyId == technologyId)
            select new UpdateTechMediaViewModel()
            {
                TechnologyId = p.TechnologyId,
                MediaId = m.Id,
                FileName = m.FileName,
            }).ToListAsync();
        
        return resultTodelete;
    }
}
