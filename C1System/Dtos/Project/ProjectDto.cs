using AutoMapper;
using C1System;
    
public class GetProjectDto
{
    public Guid ProjectId { get; set; }
    
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public int Progress { get; set; }
    public DateTime RemainingUntil { get; set; }
    public DateTime RemainingSupport { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ProjectStatusEnum ProjectStatus { get; set; }
    public ProjectSupportStatusEnum ProjectSupportStatus { get; set; }
    public ProjectSupportTypeEnum ProjectSupportType { get; set; }
    public ProjectVideoCategoryEnum ProjectVideoCategory { get; set; }

    
    public bool IsDelete { get; set; }
}
public class AddProjectDto
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public int Progress { get; set; }
    // public DateTime RemainingUntil { get; set; }
    // public DateTime RemainingSupport { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ProjectStatusEnum ProjectStatus { get; set; }
    public ProjectSupportStatusEnum ProjectSupportStatus { get; set; }
    public ProjectSupportTypeEnum ProjectSupportType { get; set; }
    public ProjectVideoCategoryEnum ProjectVideoCategory { get; set; }
}

public class UpdateProjectDto
{
    public Guid ProjectId { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public int Progress { get; set; }
    // public DateTime RemainingUntil { get; set; }
    // public DateTime RemainingSupport { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public ProjectStatusEnum ProjectStatus { get; set; }
    public ProjectSupportStatusEnum ProjectSupportStatus { get; set; }
    public ProjectSupportTypeEnum ProjectSupportType { get; set; }
    public ProjectVideoCategoryEnum ProjectVideoCategory { get; set; }
}

public class AutoMapperProject : Profile {
    public AutoMapperProject() {
        CreateMap<ProjectEntity, AddProjectDto>().ReverseMap();
        CreateMap<ProjectEntity, UpdateProjectDto>().ReverseMap();
        CreateMap<ProjectEntity, GetProjectDto>().ReverseMap();
        CreateMap<AddProjectDto, GetProjectDto>().ReverseMap();
        CreateMap<UpdateProjectDto, GetProjectDto>().ReverseMap();
    }
}