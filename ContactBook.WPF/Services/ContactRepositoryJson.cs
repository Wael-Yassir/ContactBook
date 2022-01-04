using System.IO;
using Newtonsoft.Json;
using System.Threading.Tasks;
using ContactBook.Data.Models;
using System.Collections.Generic;
using ContactBook.Data.DataProvider;

namespace ContactBook.WPF.Services
{
    public class ContactRepositoryJson : IContactRepository
    {
        public async Task<List<Contact>> GetContactsAsync()
        {
            JsonSerializerSettings settings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented,
                NullValueHandling = NullValueHandling.Ignore,
            };

            string content = await Task.Run(() => File.ReadAllText(JsonGeneraor.DbFileName));
            return JsonConvert.DeserializeObject<List<Contact>>(content);
        }

        public Task<Contact> GetContactAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> AddContactAsync(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Task<Contact> UpdateContactAsync(Contact contact)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteContactAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Save(List<Contact> contacts)
        {
            JsonGeneraor.CreateJsonFile(contacts);
        }
    }
}
