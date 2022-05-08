using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface IPodcastService
    {
        List<Podcast> GetAllTag();
        Podcast GetPodcastById(Guid id);
        bool AddPodcastg(Podcast podcast);
        bool DeleteTag(Podcast podcast);
        bool UpdateTag(Podcast podcast);
    }
}
