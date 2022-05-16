using System;
using AutoMapper;
using C1System;
using C1System.Dtos.Media;
using C1System.Media;

public class GetPortfolioDto
{
    public Guid PortfolioId { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string? SiteAddress { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }
    public string FeatureMedia { get; set; }
    public int? Point { get; set; }
    public int PortfolioSort { get; set; }
}

public class AddPortfolioDto
{
    public Guid PortfolioId { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string? SiteAddress { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }
    public string FeatureMedia { get; set; }
    public bool IsActive { get; set; }
    public int PortfolioSort { get; set; }
}


public class UpdatePortfolioDto
{ 
    public Guid PortfolioId { get; set; }
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string? SiteAddress { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }
    public string FeatureMedia { get; set; }
    public int? Point { get; set; }
    public bool IsActive { get; set; }
    public int PortfolioSort { get; set; }
}

public class AutoMapperPortfolio : Profile {
    public AutoMapperPortfolio() {
        CreateMap<PortfolioEntity, AddPortfolioDto>().ReverseMap();
        CreateMap<PortfolioEntity, UpdatePortfolioDto>().ReverseMap();
        CreateMap<PortfolioEntity, GetPortfolioDto>().ReverseMap();
        CreateMap<AddPortfolioDto, GetPortfolioDto>().ReverseMap();
        CreateMap<UpdatePortfolioDto, GetPortfolioDto>().ReverseMap();
    }
}