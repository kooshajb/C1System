using C1System.DataLayar.Context;
using C1System.DataLayar.Entities.NewsLetter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.newsLetter
{
    public interface INewsLetterService
    {
        //List<NewsLetter> GetAllNewsLetter();
        //NewsLetter GetNewsLetterById(Guid id);
        //bool AddNewsLetter(NewsLetter newsLetter);
        //bool DeleteNewsLetter(NewsLetter newsLetter);
        //bool UpdateNewsLetter(NewsLetter newsLetter);
    }
    public class NewsLetterService : INewsLetterService
    {
        //private readonly C1SystemContext _context;
        //public NewsLetterService(C1SystemContext context)
        //{
        //    _context = context;
        //}
        //public bool AddNewsLetter(NewsLetter newsLetter)
        //{
        //    try
        //    {
        //        _context.NewsLetters.Add(newsLetter);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool DeleteNewsLetter(NewsLetter newsLetter)
        //{
        //    if (newsLetter != null)
        //    {
        //        try
        //        {
        //            _context.NewsLetters.Remove(newsLetter);
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

        //public List<NewsLetter> GetAllNewsLetter()
        //{
        //    return _context.NewsLetters.ToList();
        //}

        //public NewsLetter GetNewsLetterById(Guid id)
        //{
        //    return _context.NewsLetters.Find(id);
        //}

        //public bool UpdateNewsLetter(NewsLetter newsLetter)
        //{
        //    if (newsLetter != null)
        //    {
        //        try
        //        {
        //            _context.NewsLetters.Update(newsLetter);
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
