using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.category
{
    public interface ICategoryPackageService
    {
        List<CategoryPackage> GetAllCategoryPackage();
        CategoryPackage GetCategoryPackageById(Guid id);
        bool AddCategoryPackage(CategoryPackage categoryPackage);
        bool DeleteCategoryPackage(CategoryPackage categoryPackage);
        bool UpdateCategoryPackage(CategoryPackage categoryPackage);
    }

    public class CategoryPackageService : ICategoryPackageService
    {
        private readonly C1SystemContext _context;
        public CategoryPackageService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddCategoryPackage(CategoryPackage categoryPackage)
        {
            try
            {
                _context.CategoryPackages.Add(categoryPackage);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategoryPackage(CategoryPackage categoryPackage)
        {
            if (categoryPackage != null)
            {
                try
                {
                    _context.CategoryPackages.Remove(categoryPackage);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    return false;
                }
            }
            else
                return false;
        }

        public List<CategoryPackage> GetAllCategoryPackage()
        {
            return _context.CategoryPackages.ToList();
        }

        public CategoryPackage GetCategoryPackageById(Guid id)
        {
            return _context.CategoryPackages.Find(id);
        }

        public bool UpdateCategoryPackage(CategoryPackage categoryPackage)
        {
            if (categoryPackage != null)
            {
                try
                {
                    _context.CategoryPackages.Update(categoryPackage);
                    _context.SaveChanges();
                    return true;
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
                return false;
        }
    }
}
