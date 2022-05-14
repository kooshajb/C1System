using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;

public interface IPodcastRepository
{
    Task<GenericResponse<GetPodcastDto>> Add(AddUpdatePodcastDto dto);
    Task<GenericResponse<IEnumerable<GetPodcastDto>>> Get();
    Task<GenericResponse<GetPodcastDto>> GetById(Guid id);
    Task<GenericResponse<GetPodcastDto>> Update(Guid id, AddUpdatePodcastDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistPodcast(string title, Guid podcastId);
}

public class PodcastRepository : IPodcastRepository
{
     private readonly C1SystemContext _context;
    private readonly IMapper _mapper;

    public PodcastRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetPodcastDto>> Add(AddUpdatePodcastDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        Podcast entity = _mapper.Map<Podcast>(dto);

        EntityEntry<Podcast> i = await _context.Set<Podcast>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPodcastDto>(_mapper.Map<GetPodcastDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetPodcastDto>>> Get()
    {
        IEnumerable<Podcast> i = await _context.Set<Podcast>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetPodcastDto>>(_mapper.Map<IEnumerable<GetPodcastDto>>(i));
    }

    public async Task<GenericResponse<GetPodcastDto>> GetById(Guid id)
    {
        Podcast? i = await _context.Set<Podcast>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.PodcastId == id);
        return new GenericResponse<GetPodcastDto>(_mapper.Map<GetPodcastDto>(i));
    }

    public async Task<GenericResponse<GetPodcastDto>> Update(Guid id, AddUpdatePodcastDto dto)
    {
        var i = _context.Set<Podcast>()
            .Where(p => p.PodcastId == id).First();

        i.PodcastNumber = dto.PodcastNumber;
        i.Title = dto.Title;
        i.StudyTime = dto.StudyTime;
        i.FeatureImage = dto.FeatureImage;
        i.Description = dto.Description;
        i.Audio = dto.Audio;
        i.IsLike = dto.IsLike;
        i.IsTopTag = dto.IsTopTag;
        i.IsSelected = dto.IsSelected;
        i.Point = dto.Point;
        
        _context.Set<Podcast>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPodcastDto>(_mapper.Map<GetPodcastDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetPodcastDto> i = await GetById(id);
        _context.Set<Podcast>().Remove(_mapper.Map<Podcast>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Podcast {i.Result.Title} delete Success {i.Result.PodcastId}");
    }
    
    public bool ExistPodcast(string title, Guid podcastId)
    {
        return _context.Podcasts.Any(p =>
            p.Title == title && p.PodcastId != podcastId);
    }
}