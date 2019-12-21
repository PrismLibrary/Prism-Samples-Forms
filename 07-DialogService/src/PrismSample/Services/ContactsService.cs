using System.Collections.Generic;
using System.Threading.Tasks;
using PrismSample.Models;

namespace PrismSample.Services
{
    public class ContactsService : IContactsService
    {
        public async Task<List<Contact>> GetContacts()
        {
            return new List<Contact>
            {
                new Contact{ Name = "Marion Drew", Email = "abc@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=monsterid"},
                new Contact{ Name = "John Doe", Email = "john@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=wavatar"},
                new Contact{ Name = "Marry Jane", Email = "marry@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=robohash"},
                new Contact{ Name = "Nathan Valley", Email = "marry@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=retro"},
                new Contact{ Name = "Richard Franklin", Email = "marry@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=monsterid"},
                new Contact{ Name = "Nora Hamilton", Email = "marry@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=monsterid"},
                new Contact{ Name = "Nick Fury", Email = "marry@company.com", Avatar = "https://www.gravatar.com/avatar/00000000000000000000000000000000?d=wavatar"},
            };
        }
    }
}