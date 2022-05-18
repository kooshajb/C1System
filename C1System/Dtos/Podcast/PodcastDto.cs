using System;
using AutoMapper;
using C1System;

public class GetPodcastDto
{
    public Guid PodcastId { get; set; }
    public int PodcastNumber { get; set; }
    public string Title { get; set; }
    public string StudyTime { get; set; }
    public string Description { get; set; }
    public bool? IsLike { get; set; }
    public bool? IsTopTag { get; set; }
    public bool? IsSelected { get; set; }
    public int? Point { get; set; }
}

public class AddPodcastDto
{
    public int PodcastNumber { get; set; }
    public string Title { get; set; }
    public string StudyTime { get; set; }
    public string Description { get; set; }
    public bool? IsLike { get; set; }
    public bool? IsTopTag { get; set; }
    public bool? IsSelected { get; set; }
    public int? Point { get; set; }
}

public class UpdatePodcastDto
 {
     public Guid PodcastId { get; set; }
     public int PodcastNumber { get; set; }
     public string Title { get; set; }
     public string StudyTime { get; set; }
     public string Description { get; set; }
     public bool? IsLike { get; set; }
     public bool? IsTopTag { get; set; }
     public bool? IsSelected { get; set; }
     public int? Point { get; set; }
 }

public class AutoMapperPodcast : Profile {
    public AutoMapperPodcast() {
        CreateMap<PodcastEntity, AddPodcastDto>().ReverseMap();
        CreateMap<PodcastEntity, UpdatePodcastDto>().ReverseMap();
        CreateMap<PodcastEntity, GetPodcastDto>().ReverseMap();
        CreateMap<AddPodcastDto, GetPodcastDto>().ReverseMap();
        CreateMap<UpdatePodcastDto, GetPodcastDto>().ReverseMap();
    }
}