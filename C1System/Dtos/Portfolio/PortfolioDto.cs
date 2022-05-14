using System;
using AutoMapper;
using C1System;

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
    public string? Media { get; set; }
    public int? Point { get; set; }
}

public class AddPortfolioDto
{
    public string Title { get; set; }
    public string SubTitle { get; set; }
    public string Description { get; set; }
    public string? SiteAddress { get; set; }
    public string CompanyName { get; set; }
    public string CompanyLogo { get; set; }
    public string FeatureMedia { get; set; }
    public string? Media { get; set; }
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
    public string? Media { get; set; }
    public int? Point { get; set; }
}

public class AutoMapperPortfolio : Profile {
    public AutoMapperPortfolio() {
        CreateMap<Portfolio, AddPortfolioDto>().ReverseMap();
        CreateMap<Portfolio, UpdatePortfolioDto>().ReverseMap();
        CreateMap<Portfolio, GetPortfolioDto>().ReverseMap();
        CreateMap<AddPortfolioDto, GetPortfolioDto>().ReverseMap();
        CreateMap<UpdatePortfolioDto, GetPortfolioDto>().ReverseMap();
    }
}