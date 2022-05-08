using C1System.DataLayar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C1System.Core.Services.Interface
{
    public interface ICustomerSpeechService
    {
        List<CustomerSpeech> GetAllCustomerSpeech();
        CustomerSpeech GetCustomerSpeechById(Guid id);
        bool AddCustomerSpeech(CustomerSpeech customerSpeech);
        bool DeleteCustomerSpeech(CustomerSpeech customerSpeech);
        bool UpdateCustomerSpeech(CustomerSpeech customerSpeech);
    }
}
