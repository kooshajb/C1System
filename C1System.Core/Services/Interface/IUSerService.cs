using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface IUSerService
    {
        List<User> GetAllUser();
        User GetUserById(Guid id);
        bool AddUser(User user);
        bool DeleteUser(User user);
        bool UpdateUser(User user);
    }
}
