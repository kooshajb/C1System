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
public class AddUpdateProjectDto
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
        CreateMap<ProjectEntity, AddUpdateProjectDto>().ReverseMap();
        CreateMap<ProjectEntity, GetProjectDto>().ReverseMap();
        CreateMap<AddUpdateProjectDto, GetProjectDto>().ReverseMap();
    }
}