using AutoMapper;
using C1System;

public class GetCategoryDto
{
    public Guid CategoryId { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string IconImage { get; set; }
    public string IntroDescription { get; set; }
    public string IntroImage { get; set; }
    public string BannerTitle { get; set; }
    public string BannerDescription { get; set; }
    public string BannerImage { get; set; }
    public string IconMenuImage { get; set; }
    public string? VideoIntro { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsDelete { get; set; }
}    


public class AddUpdateCategoryDto
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string IconImage { get; set; }
    public string IntroDescription { get; set; }
    public string IntroImage { get; set; }
    public string BannerTitle { get; set; }
    public string BannerDescription { get; set; }
    public string BannerImage { get; set; }
    public string IconMenuImage { get; set; }
    public string? VideoIntro { get; set; }
    public Guid? ParentId { get; set; }
    public bool IsDelete { get; set; }
}


public class AutoMapperCategory : Profile {
    public AutoMapperCategory() {
        CreateMap<CategoryEntity, AddUpdateCategoryDto>().ReverseMap();
        CreateMap<CategoryEntity, GetCategoryDto>().ReverseMap();
        CreateMap<AddUpdateCategoryDto, GetCategoryDto>().ReverseMap();
    }
}