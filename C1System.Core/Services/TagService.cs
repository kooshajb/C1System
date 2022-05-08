using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public class TagService : ITagService
    {
        private readonly C1SystemContext _context;
        public TagService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddTag(Tag tag)
        {
            try
            {
                _context.Tags.Add(tag);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTag(Tag tag)
        {
            if (tag != null)
            {
                try
                {
                    _context.Tags.Remove(tag);
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

        public List<Tag> GetAllTag()
        {
            return _context.Tags.ToList();
        }

        public Tag GetTagById(Guid id)
        {
            return _context.Tags.Find(id);
        }

        public bool UpdateTag(Tag tag)
        {
            if (tag != null)
            {
                try
                {
                    _context.Tags.Update(tag);
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
