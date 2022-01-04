using System.Linq;
using ContactBook.WPF.Base;
using ContactBook.Data.Models;
using ContactBook.WPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ContactBook.WPF.Contacts
{
    public class ContactListViewModel : BindableBase
    {
        private IContactRepository _repo;

        public ContactListViewModel(IContactRepository repo)
        {
            _repo = repo;
        }

        private ObservableCollection<Contact> contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return contacts; }
            set { SetProperty(ref contacts, value); }
        }


        public async void LoadContacts()
        {
            List<Contact> contactList = await _repo.GetContactsAsync();
            Contacts = new ObservableCollection<Contact>(contactList);
        }

        public void Save()
        {
            (_repo as ContactRepositoryJson).Save(Contacts.ToList());
        }
    }
}
