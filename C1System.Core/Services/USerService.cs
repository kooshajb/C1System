using C1System.Core.Services.Interface;
using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services
{
    public class USerService : IUSerService
    {
        private readonly C1SystemContext _context;
        public USerService(C1SystemContext context)
        {
            _context = context;
        }
        public bool AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool DeleteUser(User user)
        {
            if (user != null)
            {
                try
                {
                    _context.Users.Remove(user);
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

        public List<User> GetAllUser()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public bool UpdateUser(User user)
        {
            if (user != null)
            {
                try
                {
                    _context.Users.Update(user);
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
