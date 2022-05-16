
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System;

public interface ITagRepository
{
    Task<GenericResponse<GetTagDto>> Add(AddUpdateTagDto dto);
    Task<GenericResponse<IEnumerable<GetTagDto>>> Get();
    Task<GenericResponse<GetTagDto>> GetById(Guid id);
    Task<GenericResponse<GetTagDto>> Update(Guid id, AddUpdateTagDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistTag(string title, Guid tagId);
}

public class TagRepository : ITagRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;
    public TagRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetTagDto>> Add(AddUpdateTagDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        TagEntity entity = _mapper.Map<TagEntity>(dto);

        EntityEntry<TagEntity> i = await _context.Set<TagEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetTagDto>(_mapper.Map<GetTagDto>(i.Entity));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetTagDto> i = await GetById(id);
        _context.Set<TagEntity>().Remove(_mapper.Map<TagEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Podcast {i.Result.Title} delete Success {i.Result.TagId}");
    }

    public bool ExistTag(string title, Guid tagId)
    {
        return _context.Tags.Any(p =>
           p.Title == title && p.TagId != tagId);
    }

    public async Task<GenericResponse<IEnumerable<GetTagDto>>> Get()
    {
        IEnumerable<TagEntity> i = await _context.Set<TagEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetTagDto>>(_mapper.Map<IEnumerable<GetTagDto>>(i));
    }

    public async Task<GenericResponse<GetTagDto>> GetById(Guid id)
    {
        TagEntity? i = await _context.Set<TagEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.TagId == id);
        return new GenericResponse<GetTagDto>(_mapper.Map<GetTagDto>(i));
    }

    public async Task<GenericResponse<GetTagDto>> Update(Guid id, AddUpdateTagDto dto)
    {
        var i = _context.Set<TagEntity>()
              .Where(p => p.TagId == id).First();

       i.Title = dto.Title;
       i.Link = dto.Link;

        _context.Set<TagEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetTagDto>(_mapper.Map<GetTagDto>(i));
    }
}

