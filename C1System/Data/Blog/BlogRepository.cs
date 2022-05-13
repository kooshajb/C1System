using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System;

public interface IBlogRepository
{
    //List<Blog> GetAllBlog();
    //Blog GetBlogById(Guid id);
    //bool AddBlog(Blog blog);
    //bool DeleteBlog(Blog blog);
    //bool UpdateBlog(Blog blog);
}

public class BlogRepository : IBlogRepository
{
//    private readonly C1SystemContext _context;
//    public BlogInterface(C1SystemContext context)
//    {
//        _context = context;
//    }

//    public bool AddBlog(Blog blog)
//    {
//        try
//        {
//            _context.Blogs.Add(blog);
//            _context.SaveChanges();
//            return true;
//        }
//        catch (Exception)
//        {

//            return false;
//        }
//    }

//    public bool DeleteBlog(Blog blog)
//    {
//        if (blog != null)
//        {
//            try
//            {
//                _context.Blogs.Remove(blog);
//                _context.SaveChanges();
//                return true;
//            }
//            catch (Exception)
//            {

//                return false;
//            }
//        }
//        else
//            return false;
//    }

//    public List<Blog> GetAllBlog()
//    {
//        return _context.Blogs.ToList();
//    }

//    public Blog GetBlogById(Guid id)
//    {
//        return _context.Blogs.Find(id);
//    }

//    public bool UpdateBlog(Blog blog)
//    {
//        if (blog != null)
//        {
//            try
//            {
//                _context.Blogs.Update(blog);
//                _context.SaveChanges();
//                return true;
//            }
//            catch (Exception)
//            {

//                throw;
//            }
//        }
//        else
//            return false;
//    }
}