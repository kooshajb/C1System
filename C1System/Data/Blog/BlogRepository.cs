﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;

public interface IBlogRepository
{
    Task<GenericResponse<GetBlogDto>> Add(AddUpdateBlogDto dto);
    Task<GenericResponse<IEnumerable<GetBlogDto>>> Get();
    Task<GenericResponse<GetBlogDto>> GetById(Guid id);
    Task<GenericResponse<GetBlogDto>> Update(Guid id, AddUpdateBlogDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistBlog(string title, Guid blogId);
}

public class BlogRepository : IBlogRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;

    public BlogRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetBlogDto>> Add(AddUpdateBlogDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        Blog blog = _mapper.Map<Blog>(dto);

        EntityEntry<Blog> i = await _context.Set<Blog>().AddAsync(blog);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetBlogDto>(_mapper.Map<GetBlogDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetBlogDto>>> Get()
    {
        IEnumerable<Blog> i = await _context.Set<Blog>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetBlogDto>>(_mapper.Map<IEnumerable<GetBlogDto>>(i));
    }
    
    public async Task<GenericResponse<GetBlogDto>> GetById(Guid id)
    {
        Blog? i = await _context.Set<Blog>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.BlogId == id);
        return new GenericResponse<GetBlogDto>(_mapper.Map<GetBlogDto>(i));
    }

    public async Task<GenericResponse<GetBlogDto>> Update(Guid id, AddUpdateBlogDto dto)
    {
        var i = _context.Set<Blog>()
            .Where(p => p.BlogId == id).First();

        i.Title = dto.Title;
        i.Description = dto.Description;
        i.Lid = dto.Lid;
        i.StudyTime = dto.StudyTime;
        i.FeatureImage = dto.FeatureImage;

        _context.Set<Blog>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetBlogDto>(_mapper.Map<GetBlogDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetBlogDto> i = await GetById(id);
        _context.Set<Blog>().Remove(_mapper.Map<Blog>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Blog {i.Result.Title} delete Success {i.Result.BlogId}");
    }

    public bool ExistBlog(string title, Guid blogId)
    {
        return _context.Blogs.Any(b =>
            b.Title == title && b.BlogId != blogId);
    }
}