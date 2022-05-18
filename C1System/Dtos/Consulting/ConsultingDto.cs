using AutoMapper;
using C1System;

public class GetConsultingDto
{
    public Guid ConsultingId { get; set; }
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    // public bool? IsRead { get; set; }
}

public class AddConsultingDto
{ 
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    // public bool? IsRead { get; set; }
}

public class UpdateConsultingDto
{
    public Guid ConsultingId { get; set; }
    public string FullName { get; set; }
    public string MobileNumber { get; set; }
    // public bool? IsRead { get; set; }
}

public class AutoMapperConsulting : Profile {
    public AutoMapperConsulting() {
        CreateMap<ConsultingEntity, AddConsultingDto>().ReverseMap();
        CreateMap<ConsultingEntity, UpdateConsultingDto>().ReverseMap();
        CreateMap<ConsultingEntity, GetConsultingDto>().ReverseMap();
        CreateMap<AddConsultingDto, GetConsultingDto>().ReverseMap();
        CreateMap<UpdateConsultingDto, GetConsultingDto>().ReverseMap();
    }
}