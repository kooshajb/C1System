using AutoMapper;
using C1System.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;

public interface IBlogCategoryRepository
{
    Task<GenericResponse<GetBlogCategoryDto>> Add(AddBlogCategoryDto dto);
    Task<GenericResponse<IEnumerable<GetBlogCategoryDto>>> Get();
    Task<GenericResponse<GetBlogCategoryDto>> GetById(Guid id);
    Task<GenericResponse<GetBlogCategoryDto>> Update(Guid id, UpdateBlogCategoryDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistBlogCategory(string title, Guid blogCategoryId);
}

public class BlogCategoryRepository : IBlogCategoryRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;

    public BlogCategoryRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetBlogCategoryDto>> Add(AddBlogCategoryDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        BlogCategoryEntity blog = _mapper.Map<BlogCategoryEntity>(dto);

        EntityEntry<BlogCategoryEntity> i = await _context.Set<BlogCategoryEntity>().AddAsync(blog);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetBlogCategoryDto>(_mapper.Map<GetBlogCategoryDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetBlogCategoryDto>>> Get()
    {
        IEnumerable<BlogCategoryEntity> i = await _context.Set<BlogCategoryEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetBlogCategoryDto>>(_mapper.Map<IEnumerable<GetBlogCategoryDto>>(i));
    }
    
    public async Task<GenericResponse<GetBlogCategoryDto>> GetById(Guid id)
    {
        BlogCategoryEntity? i = await _context.Set<BlogCategoryEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.BlogCategoryId == id);
        return new GenericResponse<GetBlogCategoryDto>(_mapper.Map<GetBlogCategoryDto>(i));
    }

    public async Task<GenericResponse<GetBlogCategoryDto>> Update(Guid id, UpdateBlogCategoryDto dto)
    {
        var i = _context.Set<BlogCategoryEntity>()
            .Where(p => p.BlogCategoryId == id).First();

        i.Title = dto.Title;

        _context.Set<BlogCategoryEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetBlogCategoryDto>(_mapper.Map<GetBlogCategoryDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetBlogCategoryDto> i = await GetById(id);
        _context.Set<BlogCategoryEntity>().Remove(_mapper.Map<BlogCategoryEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"BlogCategory {i.Result.Title} delete Success {i.Result.BlogCategoryId}");
    }

    public bool ExistBlogCategory(string title, Guid blogCategoryId)
    {
        return _context.BlogCategories.Any(b =>
            b.Title == title && b.BlogCategoryId != blogCategoryId);
    }
}