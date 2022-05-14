﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using C1System.Dtos.Media;
using C1System.Media;

namespace C1System.Location;

[Table("Location")]
public class LocationEntity {
    [Key]
    public int Id { get; set; }

    public int? ParentId { get; set; }

    [ForeignKey(nameof(ParentId))]
    public LocationEntity? Parent { get; set; }

    [Required]
    [StringLength(100)]
    public string Title { get; set; }

    public IEnumerable<MediaEntity>? Media { get; set; }

    [Required]
    [EnumDataType(typeof(LocationType))]
    public LocationType Type { get; set; }

    public double? Latitude { get; set; }

    public double? Longitude { get; set; }

    // public UserEntity? User { get; set; }
    // public string? UserId { get; set; }
    //
    // public ProductEntity? Product { get; set; }
    // public Guid? ProductId { get; set; }
    //
    // public ProjectEntity? Project { get; set; }
    // public Guid? ProjectId { get; set; }
    //
    // public TutorialEntity? Tutorial { get; set; }
    // public Guid? TutorialId { get; set; }
    //
    // public EventEntity? Event { get; set; }
    // public Guid? EventId { get; set; }
    //
    // public AdEntity? Ad { get; set; }
    // public Guid? AdId { get; set; }
    //
    // public CompanyEntity? Company { get; set; }
    // public Guid? CompanyId { get; set; }
    //
    // public TenderEntity? Tender { get; set; }
    // public Guid? TenderId { get; set; }
    //
    // public ServiceEntity? Service { get; set; }
    // public Guid? ServiceId { get; set; }
    //
    // public MagazineEntity? Magazine { get; set; }
    // public Guid? MagazineId { get; set; }
}

public class LocationReadDto {
    public int Id { get; set; }
    public string Title { get; set; }
    public int? ParentId { get; set; }
    public LocationReadDto? Parent { get; set; }
    public double? Latitude { get; set; }
    public double? Longitude { get; set; }
    public IEnumerable<MediaDto>? Media { get; set; }
    public LocationType Type { get; set; }
}

public class LocationProfile : Profile {
    public LocationProfile() {
        CreateMap<LocationEntity, LocationReadDto>().ReverseMap();
    }
}