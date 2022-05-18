using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System;
public interface IConsultingRepository
{
    Task<GenericResponse<IEnumerable<GetConsultingDto>>> Get();
    Task<GenericResponse<GetConsultingDto>> GetById(Guid id); 
    Task<GenericResponse> Delete(Guid id);
}

public class ConsultingRepository : IConsultingRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;
    
    public ConsultingRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<GenericResponse<IEnumerable<GetConsultingDto>>> Get()
    {
        IEnumerable<ConsultingEntity> i = await _context.Set<ConsultingEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetConsultingDto>>(_mapper.Map<IEnumerable<GetConsultingDto>>(i));
    }
    public async Task<GenericResponse<GetConsultingDto>> GetById(Guid id)
    {
        ConsultingEntity? i = await _context.Set<ConsultingEntity>().AsNoTracking()
                .FirstOrDefaultAsync(i => i.ConsultingId == id);
        return new GenericResponse<GetConsultingDto>(_mapper.Map<GetConsultingDto>(i));
    }
    
    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetConsultingDto> i = await GetById(id);
        _context.Set<ConsultingEntity>().Remove(_mapper.Map<ConsultingEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Consulting {i.Result.FullName} delete Success {i.Result.ConsultingId}");
    }
}