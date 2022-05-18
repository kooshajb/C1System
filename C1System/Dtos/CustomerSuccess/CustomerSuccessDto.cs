using AutoMapper;
using C1System;

public class GetCustomerSuccessDto
{
    public Guid CustomerSuccessId { get; set; }
    public string ManagerName { get; set; }
    public string ManagerSide { get; set; }
    public string CompanyName { get; set; }
    public string StartupName { get; set; }
    public string ActivityName { get; set; }
    public string ManagerSpeech { get; set; }
    public string Description { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoSubTitle { get; set; }
}

public class AddCustomerSuccessDto
{
    public string ManagerName { get; set; }
    public string ManagerSide { get; set; }
    public string CompanyName { get; set; }
    public string StartupName { get; set; }
    public string ActivityName { get; set; }
    public string ManagerSpeech { get; set; }
    public string Description { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoSubTitle { get; set; }
}

public class UpdateCustomerSuccessDto
{
    public Guid CustomerSuccessId { get; set; }
    public string ManagerName { get; set; }
    public string ManagerSide { get; set; }
    public string CompanyName { get; set; }
    public string StartupName { get; set; }
    public string ActivityName { get; set; }
    public string ManagerSpeech { get; set; }
    public string Description { get; set; }
    public string? VideoTitle { get; set; }
    public string? VideoSubTitle { get; set; }
}

public class AutoMapperCustomerSuccess : Profile {
    public AutoMapperCustomerSuccess() {
        CreateMap<CustomerSuccessEntity, AddCustomerSuccessDto>().ReverseMap();
        CreateMap<CustomerSuccessEntity, UpdateCustomerSuccessDto>().ReverseMap();
        CreateMap<CustomerSuccessEntity, GetCustomerSuccessDto>().ReverseMap();
        CreateMap<AddCustomerSuccessDto, GetCustomerSuccessDto>().ReverseMap();
        CreateMap<UpdateCustomerSuccessDto, GetCustomerSuccessDto>().ReverseMap();
    }
}