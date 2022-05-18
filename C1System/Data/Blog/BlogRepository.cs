using AutoMapper;
using C1System.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;

public interface IBlogRepository
{
    Task<GenericResponse<GetBlogDto>> Add(AddBlogDto dto);
    Task<GenericResponse<IEnumerable<GetBlogDto>>> Get();
    Task<GenericResponse<GetBlogDto>> GetById(Guid id);
    Task<GenericResponse<GetBlogDto>> Update(Guid id, UpdateBlogDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistBlog(string title, Guid blogId);
    bool AddBlogsForTag(List<Tag_BlogEntity> tagBlogs);
    bool AddBlogsForCategory(List<Blog_BlogCategoryEntity> blogCategories);
    Task<List<UpdateBlogTagViewModel>> ShowBlogsTagForUpdate(Guid blogId);
    Task<List<UpdateBlogBlogCategoryViewModel>> ShowBlogsCatForUpdate(Guid blogCatId);
    bool DeleteBlogForTag(Guid blogId);
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

    public async Task<GenericResponse<GetBlogDto>> Add(AddBlogDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        BlogEntity blog = _mapper.Map<BlogEntity>(dto);

        EntityEntry<BlogEntity> i = await _context.Set<BlogEntity>().AddAsync(blog);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetBlogDto>(_mapper.Map<GetBlogDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetBlogDto>>> Get()
    {
        IEnumerable<BlogEntity> i = await _context.Set<BlogEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetBlogDto>>(_mapper.Map<IEnumerable<GetBlogDto>>(i));
    }
    
    public async Task<GenericResponse<GetBlogDto>> GetById(Guid id)
    {
        BlogEntity? i = await _context.Set<BlogEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.BlogId == id);
        return new GenericResponse<GetBlogDto>(_mapper.Map<GetBlogDto>(i));
    }

    public async Task<GenericResponse<GetBlogDto>> Update(Guid id, UpdateBlogDto dto)
    {
        var i = _context.Set<BlogEntity>()
            .Where(p => p.BlogId == id).First();

        i.Title = dto.Title;
        i.Description = dto.Description;
        i.Lid = dto.Lid;
        i.StudyTime = dto.StudyTime;

        _context.Set<BlogEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetBlogDto>(_mapper.Map<GetBlogDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetBlogDto> i = await GetById(id);
        _context.Set<BlogEntity>().Remove(_mapper.Map<BlogEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Blog {i.Result.Title} delete Success {i.Result.BlogId}");
    }

    public bool ExistBlog(string title, Guid blogId)
    {
        return _context.Blogs.Any(b =>
            b.Title == title && b.BlogId != blogId);
    }
    
    public bool AddBlogsForTag(List<Tag_BlogEntity> tagBlogs)
    {
        try
        {
            _context.TagBlogs.AddRange(tagBlogs);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public bool AddBlogsForCategory(List<Blog_BlogCategoryEntity> blogCategories)
    {
        try
        {
            _context.BlogBlogCategory.AddRange(blogCategories);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public async Task<List<UpdateBlogTagViewModel>> ShowBlogsTagForUpdate(Guid blogId)
    {
        List<UpdateBlogTagViewModel> updates = await (from tp in _context.TagBlogs
            join p in _context.Blogs on tp.BlogId equals p.BlogId
            where (tp.BlogId == blogId)
            select new UpdateBlogTagViewModel()
            {
                TagBlogId = tp.TagBlogId,
                TagId = tp.TagId,
                BlogId = p.BlogId,
                BlogTitle = p.Title
            }).ToListAsync();
    
        return updates;
    }
    
    public async Task<List<UpdateBlogBlogCategoryViewModel>> ShowBlogsCatForUpdate(Guid blogCatId)
    {
        List<UpdateBlogBlogCategoryViewModel> updates = await (from bc in _context.BlogBlogCategory
            join c in _context.BlogCategories on bc.BlogCategoryId equals c.BlogCategoryId
            where (bc.BlogCategoryId == blogCatId)
            select new UpdateBlogBlogCategoryViewModel()
            {
                BlogBlogCategoryId =  bc.BlogBlogCategoryId,
                BlogCategoryId = bc.BlogCategoryId,
                BlogId = c.BlogCategoryId,
                BlogTitle = c.Title
            }).ToListAsync();
    
        return updates;
    }
    
    public bool DeleteBlogForTag(Guid blogId)
    {
        try
        {
            List<Tag_BlogEntity> tags = _context.TagBlogs.Where(c => c.BlogId == blogId).ToList();
            _context.TagBlogs.RemoveRange(tags);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return true;
        }
    }
}