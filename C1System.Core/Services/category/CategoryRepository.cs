using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using C1System.Core.Dtos.Category;
using C1System.DataLayar.Entities.Responses;
using C1System.DataLayar.Entities.Utilities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System.Core.Services.category
{
    public interface ICategoryRepository
    {
        Task<GenericResponse<GetCategoryDto>> Add(AddUpdateCategoryDto dto);
        Task<GenericResponse<IEnumerable<GetCategoryDto>>> Get();
        Task<GenericResponse<GetCategoryDto>> GetById(Guid id);
        Task<GenericResponse<GetCategoryDto>> Update(Guid id, AddUpdateCategoryDto dto);
        Task<GenericResponse> Delete(Guid id);
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
            Category entity = _mapper.Map<Category>(dto);
            
            EntityEntry<Category> i = await _context.Set<Category>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return new GenericResponse<GetCategoryDto>(_mapper.Map<GetCategoryDto>(i.Entity));
        }
        
        public async Task<GenericResponse<IEnumerable<GetCategoryDto>>> Get()
        {
            IEnumerable<Category> i = await _context.Set<Category>().AsNoTracking().ToListAsync();
            return new GenericResponse<IEnumerable<GetCategoryDto>>(_mapper.Map<IEnumerable<GetCategoryDto>>(i));
        }
        
        public async Task<GenericResponse<GetCategoryDto>> GetById(Guid id)
        {
            Category? i = await _context.Set<Category>().AsNoTracking()
                .FirstOrDefaultAsync(i => i.CategoryId == id);
            return new GenericResponse<GetCategoryDto>(_mapper.Map<GetCategoryDto>(i));
        }

        public async Task<GenericResponse<GetCategoryDto>> Update(Guid id, AddUpdateCategoryDto dto)
        {
            var i = _context.Set<Category>()
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
            
            _context.Set<Category>().Update(i);
            await _context.SaveChangesAsync();
            return new GenericResponse<GetCategoryDto>(_mapper.Map<GetCategoryDto>(i));
        }

        public async Task<GenericResponse> Delete(Guid id)
        {
            GenericResponse<GetCategoryDto> i = await GetById(id);
            _context.Set<Category>().Remove(_mapper.Map<Category>(i.Result));
            await _context.SaveChangesAsync();
            return new GenericResponse(UtilitiesStatusCodes.Success, $"Category {i.Result.Title} delete Success {i.Result.CategoryId}");
        }
    }
}