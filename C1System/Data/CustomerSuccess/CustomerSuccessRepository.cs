using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface ICustomerSuccessRepository
{
    Task<GenericResponse<GetCustomerSuccessDto>> Add(AddUpdateCustomerSuccessDto dto);
    Task<GenericResponse<IEnumerable<GetCustomerSuccessDto>>> Get();
    Task<GenericResponse<GetCustomerSuccessDto>> GetById(Guid id);
    Task<GenericResponse<GetCustomerSuccessDto>> Update(Guid id, AddUpdateCustomerSuccessDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistCustomerSuccess(string ManagerName, Guid CustomerSuccessId);
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

    public async Task<GenericResponse<GetCustomerSuccessDto>> Add(AddUpdateCustomerSuccessDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        CustomerSuccessEntity entity = _mapper.Map<CustomerSuccessEntity>(dto);

        EntityEntry<CustomerSuccessEntity> i = await _context.Set<CustomerSuccessEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetCustomerSuccessDto>(_mapper.Map<GetCustomerSuccessDto>(i.Entity));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetCustomerSuccessDto> i = await GetById(id);
        _context.Set<CustomerSuccessEntity>().Remove(_mapper.Map<CustomerSuccessEntity>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Podcast {i.Result.ManagerName} delete Success {i.Result.CustomerSuccessId}");
    }

    public bool ExistCustomerSuccess(string ManagerName, Guid CustomerSuccessId)
    {
        return _context.CustomerSuccesses.Any(p =>
           p.ManagerName == ManagerName && p.CustomerSuccessId != CustomerSuccessId);
    }

    public async Task<GenericResponse<IEnumerable<GetCustomerSuccessDto>>> Get()
    {
        IEnumerable<CustomerSuccessEntity> i = await _context.Set<CustomerSuccessEntity>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetCustomerSuccessDto>>(_mapper.Map<IEnumerable<GetCustomerSuccessDto>>(i));
    }

   

    public async Task<GenericResponse<GetCustomerSuccessDto>> GetById(Guid id)
    {
        //Project? i = await _context.Set<Models.CustomerSuccess.CustomerSuccess>().AsNoTracking()
        //   .FirstAsync(i=> i.CustomerSuccessId == id);
        //return new GenericResponse<GetCustomerSuccessDto>(_mapper.Map<GetCustomerSuccessDto>(i));
        throw new NotImplementedException();
    }

    public async Task<GenericResponse<GetCustomerSuccessDto>> Update(Guid id, AddUpdateCustomerSuccessDto dto)
    {
        var i = _context.Set<CustomerSuccessEntity>()
              .Where(p => p.CustomerSuccessId == id).First();

     i.ManagerName = dto.ManagerName;
        i.ManagerSide = dto.ManagerSide;
        i.CompanyName = dto.CompanyName;
        i.StartupName = dto.StartupName;
        i.ActivityName = dto.ActivityName;
        i.CompanyLogo = dto.CompanyLogo;
        i.ManagerSpeech = dto.ManagerSpeech;
        i.Description = dto.Description;
        i.VideoFile = dto.VideoFile;
        i.CoverVideoImage = dto.CoverVideoImage;
        i.VideoTitle = dto.VideoTitle;
        i.VideoSubTitle = dto.VideoSubTitle;
        i.Media = dto.Media;

        _context.Set<CustomerSuccessEntity>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetCustomerSuccessDto>(_mapper.Map<GetCustomerSuccessDto>(i));
    }
}