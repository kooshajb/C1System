using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using C1System.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface ICategoryRepository
{
    Task<GenericResponse<GetCategoryDto>> Add(AddCategoryDto dto);
    Task<GenericResponse<IEnumerable<GetCategoryDto>>> Get();
    Task<GenericResponse<GetCategoryDto>> GetById(Guid id);
    Task<GenericResponse<GetCategoryDto>> Update(Guid id, UpdateCategoryDto dto);
    Task<GenericResponse> Delete(Guid id);
    Task<GenericResponse<IEnumerable<GetCategoryDto>>> ShowAllSubCategories(Guid categoryId);
    bool ExistCategory(string title, Guid categoryId);
    Task<GenericResponse<List<GetCategoryDto>>> ShowSubCategory();
    bool DeleteCategoryForMedia(Guid mediaId);
    Task<List<UpdateCategoryMediaViewModel>> ShowCategoriesMediaForUpdate(Guid categoryId);
    Task<List<UpdateCategoryMediaViewModel>> DeleteMediasForCategory(Guid categoryId);
}

public class CategoryRepository : ICategoryRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;

    public CategoryRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetCategoryDto>> Add(AddCategoryDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        CategoryEntity entity = _mapper.Map<CategoryEntity>(dto);

        EntityEntry<CategoryEntity> i = await _context.Set<CategoryEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetCategoryDto>(_mapper.Map<GetCategoryDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetCategoryDto>>> Get()
    {
        IEnumerable<CategoryEntity> i = await _context.Set<CategoryEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetCategoryDto>>(_mapper.Map<IEnumerable<GetCategoryDto>>(i));
    }

    public async Task<GenericResponse<GetCategoryDto>> GetById(Guid id)
    {
        CategoryEntity? i = await _context.Set<CategoryEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.CategoryId == id);
        return new GenericResponse<GetCategoryDto>(_mapper.Map<GetCategoryDto>(i));
    }

    public async Task<GenericResponse<GetCategoryDto>> Update(Guid id, UpdateCategoryDto dto)
    {
        var i = _context.Set<CategoryEntity>()
            .Where(p => p.CategoryId == id).First();

        i.Title = dto.Title;
        i.SubTitle = dto.SubTitle;
        i.Description = dto.Description;
        i.IntroDescription = dto.IntroDescription;
        i.BannerTitle = dto.BannerTitle;
        i.BannerDescription = dto.BannerDescription;

        _context.Set<CategoryEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetCategoryDto>(_mapper.Map<GetCategoryDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetCategoryDto> i = await GetById(id);
        _context.Set<CategoryEntity>().Remove(_mapper.Map<CategoryEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Category {i.Result.Title} delete Success {i.Result.CategoryId}");
    }
    
    public async Task<GenericResponse<IEnumerable<GetCategoryDto>>> ShowAllSubCategories(Guid categoryId)
    {
        var i = await _context.Set<CategoryEntity>().AsNoTracking()
            .Where(s => !s.IsDelete && s.ParentId == categoryId).ToListAsync();
        return new GenericResponse<IEnumerable<GetCategoryDto>>(_mapper.Map<IEnumerable<GetCategoryDto>>(i));
    }

    public bool ExistCategory(string title, Guid categoryId)
    {
        return _context.Categories.Any(c =>
            c.Title == title && c.CategoryId != categoryId);
    }

    public async Task<GenericResponse<List<GetCategoryDto>>> ShowSubCategory()
    {
        IEnumerable<CategoryEntity> i = await _context.Set<CategoryEntity>().AsNoTracking()
           .Where(c => c.ParentId != null).ToListAsync();
       return new GenericResponse<List<GetCategoryDto>>(_mapper.Map<List<GetCategoryDto>>(i));
    }
    
    public bool DeleteCategoryForMedia(Guid mediaId)
    {
        try
        {
            var media = _context.Media.Where(m => m.Id == mediaId);
            _context.Media.RemoveRange(media);
            _context.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }
    
    public async Task<List<UpdateCategoryMediaViewModel>> ShowCategoriesMediaForUpdate(Guid categoryId)
    {
        var result = await (from p in _context.Categories
            join m in _context.Media on p.CategoryId equals m.CategoryId
            where (p.CategoryId == categoryId)
            select new UpdateCategoryMediaViewModel()
            {
                CategoryId = p.CategoryId,
                MediaId = m.Id,
                FileName = m.FileName,
            }).ToListAsync();
        
        return result;
    }
    
    public async Task<List<UpdateCategoryMediaViewModel>> DeleteMediasForCategory(Guid categoryId)
    {
        var resultTodelete = await (from p in _context.Categories
            join m in _context.Media on p.CategoryId equals m.CategoryId
            where (p.CategoryId == categoryId)
            select new UpdateCategoryMediaViewModel()
            {
                CategoryId = p.CategoryId,
                MediaId = m.Id,
                FileName = m.FileName,
            }).ToListAsync();
        
        return resultTodelete;
    }

}