using AutoMapper;

namespace C1System;

public class GetTagDto
{
    public Guid TagId { get; set; }
    public string Title { get; set; }
    public string Link { get; set; }
}

public class AddUpdateTagDto
{
    public string Title { get; set; }
    public string Link { get; set; }
}

public class AutoMapperTag : Profile {
    public AutoMapperTag() {
        CreateMap<TagEntity, AddUpdateTagDto>().ReverseMap();
        CreateMap<TagEntity, GetTagDto>().ReverseMap();
        CreateMap<AddUpdateTagDto, GetTagDto>().ReverseMap();
    }
}