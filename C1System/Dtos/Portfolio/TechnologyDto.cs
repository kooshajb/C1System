using System;
using AutoMapper;
using C1System;

public class GetTechnologyDto
{
    public Guid TechnologyId { get; set; }
    public string Title { get; set; }
    public string TechnologyImage { get; set; }
}

public class AddUpdateTechnologyDto
{
    public string Title { get; set; }
    public string TechnologyImage { get; set; }
}

public class AutoMapperTechnology : Profile {
    public AutoMapperTechnology() {
        CreateMap<TechnologyEntity, AddUpdateTechnologyDto>().ReverseMap();
        CreateMap<TechnologyEntity, GetTechnologyDto>().ReverseMap();
        CreateMap<AddUpdateTechnologyDto, GetTechnologyDto>().ReverseMap();
    }
}