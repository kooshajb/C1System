using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface ITagService 
    {
        List<Tag> GetAllTag();
        Tag GetTagById(Guid id);
        bool AddTag(Tag tag);
        bool DeleteTag(Tag tag);
        bool UpdateTag(Tag tag);
    }
}
