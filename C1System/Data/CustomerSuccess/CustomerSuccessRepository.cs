using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface ICustomerSuccessRepository
{
    Task<GenericResponse<GetCustomerSuccessDto>> Add(AddCustomerSuccessDto dto);
    Task<GenericResponse<IEnumerable<GetCustomerSuccessDto>>> Get();
    Task<GenericResponse<GetCustomerSuccessDto>> GetById(Guid id);
    Task<GenericResponse<GetCustomerSuccessDto>> Update(Guid id, UpdateCustomerSuccessDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistCustomerSuccess(string startupName, Guid customerSuccessId);
}

public class CustomerSuccessRepository : ICustomerSuccessRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;
    public CustomerSuccessRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetCustomerSuccessDto>> Add(AddCustomerSuccessDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        CustomerSuccessEntity entity = _mapper.Map<CustomerSuccessEntity>(dto);

        EntityEntry<CustomerSuccessEntity> i = await _context.Set<CustomerSuccessEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetCustomerSuccessDto>(_mapper.Map<GetCustomerSuccessDto>(i.Entity));
    }

    public async Task<GenericResponse<IEnumerable<GetCustomerSuccessDto>>> Get()
    {
        IEnumerable<CustomerSuccessEntity> i = await _context.Set<CustomerSuccessEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetCustomerSuccessDto>>(_mapper.Map<IEnumerable<GetCustomerSuccessDto>>(i));
    }
    
    public async Task<GenericResponse<GetCustomerSuccessDto>> GetById(Guid id)
    {
        CustomerSuccessEntity? i = await _context.Set<CustomerSuccessEntity>().AsNoTracking()
            .FirstOrDefaultAsync(i => i.CustomerSuccessId == id);
        return new GenericResponse<GetCustomerSuccessDto>(_mapper.Map<GetCustomerSuccessDto>(i));
    }
    
    public async Task<GenericResponse<GetCustomerSuccessDto>> Update(Guid id, UpdateCustomerSuccessDto dto)
    {
        var i = _context.Set<CustomerSuccessEntity>()
            .Where(p => p.CustomerSuccessId == id).First();

        i.ManagerName = dto.ManagerName;
        i.ManagerSide = dto.ManagerSide;
        i.CompanyName = dto.CompanyName;
        i.StartupName = dto.StartupName;
        i.ActivityName = dto.ActivityName;
        i.ManagerSpeech = dto.ManagerSpeech;
        i.Description = dto.Description;
        i.VideoTitle = dto.VideoTitle;
        i.VideoSubTitle = dto.VideoSubTitle;
        
        _context.Set<CustomerSuccessEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetCustomerSuccessDto>(_mapper.Map<GetCustomerSuccessDto>(i));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetCustomerSuccessDto> i = await GetById(id);
        _context.Set<CustomerSuccessEntity>().Remove(_mapper.Map<CustomerSuccessEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"CustomerSuccess {i.Result.ManagerName} delete Success {i.Result.CustomerSuccessId}");
    }

    public bool ExistCustomerSuccess(string startupName, Guid customerSuccessId)
    {
        return _context.CustomerSuccesses.Any(p =>
           p.ManagerName == startupName && p.CustomerSuccessId != customerSuccessId);
    }
}