using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C1System.DataLayar.Entities;

namespace C1System.Core.Dtos.Portfolio
{
    public class GetPortfolioDto
    {
        public Guid PortfolioId { get; set; } = Guid.NewGuid();
        public string? Title { get; set; }
        public string? SubTitle { get; set; }
        public string? Description { get; set; }
        public bool IsDelete { get; set; }
        public string? SiteAddress { get; set; }
        public string? CompanyName { get; set; }
        public string? CompanyLogo { get; set; }
        public string? FeatureMedia { get; set; }
        public string? Media { get; set; }
        public int? Point { get; set; }
    }
    public class AddUpdatePortfolioDto
    {
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Description { get; set; }
        public bool IsDelete { get; set; }
        public string? SiteAddress { get; set; }
        public string CompanyName { get; set; }
        public string CompanyLogo { get; set; }
        public string FeatureMedia { get; set; }
        public string? Media { get; set; }
        public int? Point { get; set; }
    }

    public class AutoMapperPortfolio : Profile
    {
        public AutoMapperPortfolio()
        {
            CreateMap<C1System.DataLayar.Entities.Portfolio, GetPortfolioDto>().ReverseMap();
            CreateMap<C1System.DataLayar.Entities.Portfolio, AddUpdatePortfolioDto>().ReverseMap();
        }
    }
}
