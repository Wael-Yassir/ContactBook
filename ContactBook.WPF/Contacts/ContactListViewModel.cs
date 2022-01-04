using System.Linq;
using ContactBook.WPF.Base;
using ContactBook.WPF.Command;
using ContactBook.Data.Models;
using ContactBook.WPF.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ContactBook.WPF.Contacts
{
    public class ContactListViewModel : BindableBase
    {
        private IContactRepository _repo;
        public RelayCommand DeleteCommand { get; private set; }
        public RelayCommand AddCommand { get; private set; }
        public RelayCommand SaveChangesCommand { get; private set; }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                SetProperty(ref _selectedContact, value);
                DeleteCommand.RaiseCanExecuteChange();
            }
        }

        public ContactListViewModel(IContactRepository repo)
        {
            _repo = repo;
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            AddCommand = new RelayCommand(OnAdd);
            SaveChangesCommand = new RelayCommand(OnSave);
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

        public void OnSave()
        {
            (_repo as ContactRepositoryJson).Save(Contacts.ToList());
        }

        private void OnAdd()
        {
            Contact newContact = new Contact();
            newContact.FirstName = "New";
            newContact.LastName = "Contact";

            Contacts.Add(newContact);
            SelectedContact = newContact;
        }

        private void OnDelete()
        {
            Contacts.Remove(SelectedContact);
        }

        private bool CanDelete()
        {
            if (SelectedContact != null)
                return true;

            return false;
        }
    }
}
