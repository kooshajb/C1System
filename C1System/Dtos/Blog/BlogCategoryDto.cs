using AutoMapper;
using C1System;

public class GetBlogCategoryDto
{
    public Guid BlogCategoryId { get; set; }
    public string Title { get; set; }
}

public class AddBlogCategoryDto
{
    public string Title { get; set; }
}

public class UpdateBlogCategoryDto
{
    public Guid BlogCategoryId { get; set; }
    public string Title { get; set; }
}

public class AutoMapperBlogCategory : Profile {
    public AutoMapperBlogCategory() {
        CreateMap<BlogCategoryEntity, AddBlogCategoryDto>().ReverseMap();
        CreateMap<BlogCategoryEntity, UpdateBlogCategoryDto>().ReverseMap();
        CreateMap<BlogCategoryEntity, GetBlogCategoryDto>().ReverseMap();
        CreateMap<AddBlogCategoryDto, GetBlogCategoryDto>().ReverseMap();
        CreateMap<UpdateBlogCategoryDto, GetBlogCategoryDto>().ReverseMap();
    }
}