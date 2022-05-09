using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.podcast
{
    public interface IPodcastService
    {
        List<Podcast> GetAllTag();
        Podcast GetPodcastById(Guid id);
        bool AddPodcastg(Podcast podcast);
        bool DeleteTag(Podcast podcast);
        bool UpdateTag(Podcast podcast);
    }

    public class PodcastService : IPodcastService
    {
        private readonly C1SystemContext _context;
        public PodcastService(C1SystemContext context)
        {
            _context = context;
        }

        public bool AddPodcastg(Podcast podcast)
        {
            try
            {
                _context.Podcasts.Add(podcast);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteTag(Podcast podcast)
        {
            if (podcast != null)
            {
                try
                {
                    _context.Podcasts.Remove(podcast);
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

        public List<Podcast> GetAllTag()
        {
            return _context.Podcasts.ToList();
        }

        public Podcast GetPodcastById(Guid id)
        {
            return _context.Podcasts.Find(id);
        }

        public bool UpdateTag(Podcast podcast)
        {
            if (podcast != null)
            {
                try
                {
                    _context.Podcasts.Update(podcast);
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
