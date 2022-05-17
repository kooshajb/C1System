using AutoMapper;
using C1System;

public class GetNewsLetterDto
{
    public Guid NewsLetterId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
} 

public class AddNewsLetterDto
{ 
    public string FullName { get; set; }
    public string Email { get; set; }
}

public class UpdateNewsLetterDto
{
    public Guid NewsLetterId { get; set; }
    public string FullName { get; set; }
    public string Email { get; set; }
}

public class AutoMapperNewsLetter : Profile {
    public AutoMapperNewsLetter() {
        CreateMap<NewsLetterEntity, AddNewsLetterDto>().ReverseMap();
        CreateMap<NewsLetterEntity, UpdateNewsLetterDto>().ReverseMap();
        CreateMap<NewsLetterEntity, GetNewsLetterDto>().ReverseMap();
        CreateMap<AddNewsLetterDto, GetNewsLetterDto>().ReverseMap();
        CreateMap<UpdateNewsLetterDto, GetNewsLetterDto>().ReverseMap();
    }
}