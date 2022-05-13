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

public class AddUpdatePortfolioDto
{
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
        CreateMap<Portfolio, AddUpdatePortfolioDto>().ReverseMap();
        CreateMap<Portfolio, GetPortfolioDto>().ReverseMap();
        CreateMap<AddUpdatePortfolioDto, GetPortfolioDto>().ReverseMap();
    }
}