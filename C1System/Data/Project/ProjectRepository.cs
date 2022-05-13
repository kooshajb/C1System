using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace C1System;
public interface IProjectRepository
{
    Task<GenericResponse<GetProjectDto>> Add(AddUpdateProjectDto dto);
    Task<GenericResponse<IEnumerable<GetProjectDto>>> Get();
    Task<GenericResponse<GetProjectDto>> GetById(Guid id);
    Task<GenericResponse<GetProjectDto>> Update(Guid id, AddUpdateProjectDto dto);
    Task<GenericResponse> Delete(Guid id);
    bool ExistProject(string Title, Guid projectId);
}

public class ProjectRepository : IProjectRepository
{
    private readonly C1SystemContext _context;
    private readonly IMapper _mapper;
    public ProjectRepository(C1SystemContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<GenericResponse<GetProjectDto>> Add(AddUpdateProjectDto dto)
    {
        if (dto == null) throw new ArgumentException("Dto must not be null", nameof(dto));
        Tag entity = _mapper.Map<Tag>(dto);

        EntityEntry<Tag> i = await _context.Set<Tag>().AddAsync(entity);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetProjectDto>(_mapper.Map<GetProjectDto>(i.Entity));
    }

    public async Task<GenericResponse> Delete(Guid id)
    {
        GenericResponse<GetProjectDto> i = await GetById(id);
        _context.Set<Project>().Remove(_mapper.Map<Project>(i.Result));
        await _context.SaveChangesAsync();
        return new GenericResponse(UtilitiesStatusCodes.Success,
            $"Podcast {i.Result.Title} delete Success {i.Result.ProjectId}");
    }

    public bool ExistProject(string Title, Guid projectId)
    {
        return _context.Prosjects.Any(p =>
           p.Title == Title && p.ProjectId != projectId);
    }

    public async Task<GenericResponse<IEnumerable<GetProjectDto>>> Get()
    {
        IEnumerable<Project> i = await _context.Set<Project>().AsNoTracking().ToListAsync();
        return new GenericResponse<IEnumerable<GetProjectDto>>(_mapper.Map<IEnumerable<GetProjectDto>>(i));
    }

    public async Task<GenericResponse<GetProjectDto>> GetById(Guid id)
    {
        Project? i = await _context.Set<Project>().AsNoTracking()
           .FirstOrDefaultAsync(i => i.ProjectId == id);
        return new GenericResponse<GetProjectDto>(_mapper.Map<GetProjectDto>(i));
    }

    public async Task<GenericResponse<GetProjectDto>> Update(Guid id, AddUpdateProjectDto dto)
    {
        var i = _context.Set<Project>()
               .Where(p => p.ProjectId == id).First();

       i.Picture = dto.Picture;
       i.Title = dto.Title;
       i.SubTitle = dto.SubTitle;
       i.IsDelete = dto.IsDelete;
       i.Media = dto.Media;

        _context.Set<Project>().Update(i);
        await _context.SaveChangesAsync();
        return new GenericResponse<GetProjectDto>(_mapper.Map<GetProjectDto>(i));
    }
}