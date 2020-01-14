using System.Collections.Generic;
using System.Threading.Tasks;
using PrismSample.Models;

namespace PrismSample.Services
{
    public interface IContactsService
    {
        Task<List<Contact>> GetContacts();
    }
}