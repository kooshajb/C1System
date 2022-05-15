﻿using System;
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
    bool AddPodcastsForTag(List<Tag_PodcastEntity> tagPodcasts);
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
        PodcastEntity entity = _mapper.Map<PodcastEntity>(dto);

        EntityEntry<PodcastEntity> i = await _context.Set<PodcastEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPodcastDto>(_mapper.Map<GetPodcastDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetPodcastDto>>> Get()
    {
        IEnumerable<PodcastEntity> i = await _context.Set<PodcastEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetPodcastDto>>(_mapper.Map<IEnumerable<GetPodcastDto>>(i));
    }

    public async Task<GenericResponse<GetPodcastDto>> GetById(Guid id)
    {
        PodcastEntity? i = await _context.Set<PodcastEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.PodcastId == id);
        return new GenericResponse<GetPodcastDto>(_mapper.Map<GetPodcastDto>(i));
    }

    public async Task<GenericResponse<GetPodcastDto>> Update(Guid id, AddUpdatePodcastDto dto)
    {
        var i = _context.Set<PodcastEntity>()
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
        
        _context.Set<PodcastEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetPodcastDto>(_mapper.Map<GetPodcastDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetPodcastDto> i = await GetById(id);
        _context.Set<PodcastEntity>().Remove(_mapper.Map<PodcastEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Podcast {i.Result.Title} delete Success {i.Result.PodcastId}");
    }
    
    public bool ExistPodcast(string title, Guid podcastId)
    {
        return _context.Podcasts.Any(p =>
            p.Title == title && p.PodcastId != podcastId);
    }
    
    public bool AddPodcastsForTag(List<Tag_PodcastEntity> tagPodcasts)
    {
        try
        {
            _context.TagPodcasts.AddRange(tagPodcasts);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    // public async Task<List<UpdatePortfolioCatViewModel>> ShowPodcastsForUpdate(Guid podcastId)
    // {
    //     List<UpdatePortfolioCatViewModel> updates = await (from cp in _context.CategoryPortfolios
    //         join p in _context.Portfolios on cp.PortfolioId equals p.PortfolioId
    //         where (cp.PortfolioId == portfolioId)
    //         select new UpdatePortfolioCatViewModel()
    //         {
    //             CategoryPortfolioId = cp.CategoryPortfolioId,
    //             CategoryId = cp.CategoryId,
    //             PortfolioId = p.PortfolioId,
    //             PortfolioTitle = p.Title
    //         }).ToListAsync();
    //
    //     return updates;
    // }
}