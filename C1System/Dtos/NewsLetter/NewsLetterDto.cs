using AutoMapper;
using C1System;

public class GetNewsLetterDto
{
    public string FullName { get; set; }
    public string Email { get; set; }
} 

public class AddUpdateNewsLetterDto
{
    public Guid NewsLetterId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}

public class AutoMapperNewsLetter : Profile {
    public AutoMapperNewsLetter() {
        CreateMap<NewsLetterEntity, AddUpdateNewsLetterDto>().ReverseMap();
        CreateMap<NewsLetterEntity, GetNewsLetterDto>().ReverseMap();
        CreateMap<AddUpdateNewsLetterDto, GetNewsLetterDto>().ReverseMap();
    }
}