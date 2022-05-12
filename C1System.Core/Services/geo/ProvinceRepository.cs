using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.Geo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.geo
{
    public interface IProvinceService
    {
        //List<Province> GetAllProvince();
        //Province GetProvinceById(Guid id);
        //bool AddProvince(Province province);
        //bool DeleteProvince(Province province);
        //bool UpdateProvince(Province province);
    }
    public class ProvinceService : IProvinceService
    {
        //private readonly C1SystemContext _context;
        //public ProvinceService(C1SystemContext context)
        //{
        //    _context = context;
        //}
        //public bool AddProvince(Province province)
        //{
        //    try
        //    {
        //        _context.Provinces.Add(province);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool DeleteProvince(Province province)
        //{
        //    if (province != null)
        //    {
        //        try
        //        {
        //            _context.Provinces.Remove(province);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            return false;
        //        }
        //    }
        //    else
        //        return false;
        //}

        //public List<Province> GetAllProvince()
        //{
        //    return _context.Provinces.ToList();
        //}

        //public Province GetProvinceById(Guid id)
        //{
        //    return _context.Provinces.Find(id);
        //}

        //public bool UpdateProvince(Province province)
        //{
        //    if (province != null)
        //    {
        //        try
        //        {
        //            _context.Provinces.Update(province);
        //            _context.SaveChanges();
        //            return true;
        //        }
        //        catch (Exception)
        //        {

        //            throw;
        //        }
        //    }
        //    else
        //        return false;
        //}
    }
}
