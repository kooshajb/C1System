using C1System.DataLayar.Context;
using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.user
{
    public interface IAccountTypeService
    {
        //List<AccountType> GetAllAccountType();
        //AccountType GetBlogById(int id);
        //bool AddAccountType(AccountType accountType);
        //bool DeleteAccountType(AccountType accountType);
        //bool UpdateAccountType(AccountType accountType);
    }

    public class AccountTypeService : IAccountTypeService
    {
        //private readonly C1SystemContext _context;
        //public AccountTypeService(C1SystemContext context)
        //{
        //    _context = context;
        //}
        //public bool AddAccountType(AccountType accountType)
        //{
        //    try
        //    {
        //        _context.AccountTypes.Add(accountType);
        //        _context.SaveChanges();
        //        return true;
        //    }
        //    catch (Exception)
        //    {

        //        return false;
        //    }
        //}

        //public bool DeleteAccountType(AccountType accountType)
        //{
        //    if (accountType != null)
        //    {
        //        try
        //        {
        //            _context.AccountTypes.Remove(accountType);
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

        //public List<AccountType> GetAllAccountType()
        //{
        //    return _context.AccountTypes.ToList();
        //}

        //public AccountType GetBlogById(int id)
        //{
        //    return _context.AccountTypes.Find(id);
        //}

        //public bool UpdateAccountType(AccountType accountType)
        //{
        //    if (accountType != null)
        //    {
        //        try
        //        {
        //            _context.AccountTypes.Update(accountType);
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
