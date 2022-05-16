using AutoMapper;
using C1System;

public class GetBlogDto
{
    public Guid BlogId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Lid { get; set; }
    public string StudyTime { get; set; }
    public string FeatureImage { get; set; }
}

public class AddBlogDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Lid { get; set; }
    public string StudyTime { get; set; }
    public string FeatureImage { get; set; }
}

public class UpdateBlogDto
{
    public Guid BlogId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Lid { get; set; }
    public string StudyTime { get; set; }
    public string FeatureImage { get; set; }
}


public class AutoMapperBlog : Profile {
    public AutoMapperBlog() {
        CreateMap<BlogEntity, AddBlogDto>().ReverseMap();
        CreateMap<BlogEntity, UpdateBlogDto>().ReverseMap();
        CreateMap<BlogEntity, GetBlogDto>().ReverseMap();
        CreateMap<AddBlogDto, GetBlogDto>().ReverseMap();
        CreateMap<UpdateBlogDto, GetBlogDto>().ReverseMap();
    }
}