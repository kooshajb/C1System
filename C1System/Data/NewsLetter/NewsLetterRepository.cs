using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System;
public interface INewsLetterRepository
{
    Task<GenericResponse<GetNewsLetterDto>> Add(AddNewsLetterDto dto);
    Task<GenericResponse<IEnumerable<GetNewsLetterDto>>> Get();
    Task<GenericResponse<GetNewsLetterDto>> GetById(Guid id);
    Task<GenericResponse<GetNewsLetterDto>> Update(Guid id, UpdateNewsLetterDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistNewsLetter(string fullName, Guid newsletterId);
}

public class NewsLetterRepository : INewsLetterRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;
    public NewsLetterRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<GenericResponse<GetNewsLetterDto>> Add(AddNewsLetterDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        NewsLetterEntity entity = _mapper.Map<NewsLetterEntity>(dto);
    
        EntityEntry<NewsLetterEntity> i = await _context.Set<NewsLetterEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetNewsLetterDto>(_mapper.Map<GetNewsLetterDto>(i.Entity));
    }
    
    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetNewsLetterDto> i = await GetById(id);
        _context.Set<NewsLetterEntity>().Remove(_mapper.Map<NewsLetterEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"NewsLetter {i.Result.FullName} delete Success {i.Result.FullName}");
    }
    
    public bool ExistNewsLetter(string fullName, Guid newsletterId)
    {
        return _context.NewsLetters.Any(p =>
                p.FullName == fullName && p.NewsLetterId != newsletterId);
    }
    
    public async Task<GenericResponse<IEnumerable<GetNewsLetterDto>>> Get()
    {
        IEnumerable<NewsLetterEntity> i = await _context.Set<NewsLetterEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetNewsLetterDto>>(_mapper.Map<IEnumerable<GetNewsLetterDto>>(i));
    }
    
    public async Task<GenericResponse<GetNewsLetterDto>> GetById(Guid id)
    {
        NewsLetterEntity? i = await _context.Set<NewsLetterEntity>().AsNoTracking()
                .FirstOrDefaultAsync(i => i.NewsLetterId == id);
        return new GenericResponse<GetNewsLetterDto>(_mapper.Map<GetNewsLetterDto>(i));
    }
    
    public async Task<GenericResponse<GetNewsLetterDto>> Update(Guid id, UpdateNewsLetterDto dto)
    {
        var i = _context.Set<NewsLetterEntity>()
                  .Where(p => p.NewsLetterId == id).First();
    
        i.FullName = dto.FullName;
        i.Email = dto.Email;
    
        _context.Set<NewsLetterEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetNewsLetterDto>(_mapper.Map<GetNewsLetterDto>(i));
    }
}