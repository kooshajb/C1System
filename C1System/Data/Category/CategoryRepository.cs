using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface ICategoryRepository
{
    Task<GenericResponse<GetCategoryDto>> Add(AddUpdateCategoryDto dto);
    Task<GenericResponse<IEnumerable<GetCategoryDto>>> Get();
    Task<GenericResponse<GetCategoryDto>> GetById(Guid id);
    Task<GenericResponse<GetCategoryDto>> Update(Guid id, AddUpdateCategoryDto dto);
    Task<GenericResponse> Delete(Guid id);
    Task<GenericResponse<IEnumerable<GetCategoryDto>>> ShowAllSubCategories(Guid categoryId);
    bool ExistCategory(string title, Guid categoryId);
    Task<GenericResponse<List<GetCategoryDto>>> ShowSubCategory();
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

    public async Task<GenericResponse<GetCategoryDto>> Add(AddUpdateCategoryDto dto)
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

    public async Task<GenericResponse<GetCategoryDto>> Update(Guid id, AddUpdateCategoryDto dto)
    {
        var i = _context.Set<CategoryEntity>()
            .Where(p => p.CategoryId == id).First();

        i.Title = dto.Title;
        i.SubTitle = dto.SubTitle;
        i.Description = dto.Description;
        i.IconImage = dto.IconImage;
        i.IntroDescription = dto.IntroDescription;
        i.IntroImage = dto.IntroImage;
        i.BannerTitle = dto.BannerTitle;
        i.BannerDescription = dto.BannerDescription;
        i.BannerImage = dto.BannerImage;
        i.IconMenuImage = dto.IconMenuImage;
        i.VideoIntro = dto.VideoIntro;

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
}