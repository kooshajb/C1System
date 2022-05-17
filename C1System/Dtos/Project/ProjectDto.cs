using AutoMapper;
using C1System;
    
public class GetProjectDto
{
    public Guid ProjectId { get; set; }
    public string Picture { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; }
    public string Media { get; set; }
}
public class AddProjectDto
{
    public string Picture { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; }
    public string Media { get; set; }
}

public class UpdateProjectDto
{
    public string Picture { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public bool IsDelete { get; set; }
    public string Media { get; set; }
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