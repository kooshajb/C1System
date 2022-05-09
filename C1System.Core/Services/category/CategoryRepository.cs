using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.category
{
    public interface ICategoryService
    {
        List<Category> GetAllCategory();
        Category GetCategoryById(Guid id);
        bool AddCategory(Category category);
        bool DeleteCategory(Category category);
        bool UpdateCategory(Category category);
    }

    public class CategoryService : ICategoryService
    {
        private readonly C1SystemContext _context;
        public CategoryService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddCategory(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteCategory(Category category)
        {
            if (category != null)
            {
                try
                {
                    _context.Categories.Remove(category);
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

        public List<Category> GetAllCategory()
        {
            return _context.Categories.ToList();
        }

        public Category GetCategoryById(Guid id)
        {
            return _context.Categories.Find(id);
        }

        public bool UpdateCategory(Category category)
        {
            if (category != null)
            {
                try
                {
                    _context.Categories.Update(category);
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
