using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.category
{
    public interface ICategoryPackageItemService
    {
        //List<CategoryPackageItem> GetAllCategoryPackageItem();
        //CategoryPackageItem GetCategoryPackageItemById(Guid id);
        //bool AddCategoryPackageItem(CategoryPackageItem categoryPackage);
        //bool DeleteCategoryPackageItem(CategoryPackageItem categoryPackage);
        //bool UpdateCategoryPackageItem(CategoryPackageItem categoryPackage);
    }
    public class CategoryPackageItemService : ICategoryPackageItemService
    {
        //private readonly C1SystemContext _context;
        //public CategoryPackageItemService(C1SystemContext context)
        //{
        //    _context = context;
        //}
        //public bool AddCategoryPackageItem(CategoryPackageItem categoryPackage)
        //{
        //    try
        //    {
        //        _context.CategoryPackageItems.Add(categoryPackage);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool DeleteCategoryPackageItem(CategoryPackageItem categoryPackage)
        //{
        //    if (categoryPackage != null)
        //    {
        //        try
        //        {
        //            _context.CategoryPackageItems.Remove(categoryPackage);
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

        //public List<CategoryPackageItem> GetAllCategoryPackageItem()
        //{
        //    return _context.CategoryPackageItems.ToList();
        //}

        //public CategoryPackageItem GetCategoryPackageItemById(Guid id)
        //{
        //    return _context.CategoryPackageItems.Find(id);
        //}

        //public bool UpdateCategoryPackageItem(CategoryPackageItem categoryPackage)
        //{
        //    if (categoryPackage != null)
        //    {
        //        try
        //        {
        //            _context.CategoryPackageItems.Update(categoryPackage);
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
