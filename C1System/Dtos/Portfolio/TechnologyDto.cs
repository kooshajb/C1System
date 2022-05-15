using System;
using AutoMapper;
using C1System;

public class GetTechnologyDto
{
    public string Title { get; set; }
    public string TechnologyImage { get; set; }
}

public class AddTechnologyDto
{
    public Guid TechnologyPortfolioId { get; set; }
    public string Title { get; set; }
    public string TechnologyImage { get; set; }
}

public class UpdateTechnologyDto
{
    public Guid TechnologyPortfolioId { get; set; }
    public string Title { get; set; }
    public string TechnologyImage { get; set; }
}

public class AutoMapperTechnology : Profile {
    public AutoMapperTechnology() {
        CreateMap<TechnologyEntity, AddTechnologyDto>().ReverseMap();
        CreateMap<TechnologyEntity, UpdateTechnologyDto>().ReverseMap();
        CreateMap<TechnologyEntity, GetTechnologyDto>().ReverseMap();
        CreateMap<AddTechnologyDto, GetTechnologyDto>().ReverseMap();
        CreateMap<UpdateTechnologyDto, GetTechnologyDto>().ReverseMap();
    }
}