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

public class AddUpdateBlogDto
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
        CreateMap<Blog, AddUpdateBlogDto>().ReverseMap();
        CreateMap<Blog, GetBlogDto>().ReverseMap();
        CreateMap<AddUpdateBlogDto, GetBlogDto>().ReverseMap();
    }
}