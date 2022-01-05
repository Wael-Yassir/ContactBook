using System;
using System.Threading.Tasks;
using ContactBook.Data.Models;
using System.Collections.Generic;


namespace ContactBook.WPF.Services
{
    public interface IContactRepository
    {
        Task<List<Contact>> GetContactsAsync();
        Task<Contact> GetContactAsync(Guid id);
        Task<Contact> AddContactAsync(Contact contact);
        Task<Contact> UpdateContactAsync(Contact contact);
        Task DeleteContactAsync(Guid id);
    }
}
