using System.Linq;
using ContactBook.Data.Base;
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
        public RelayCommand CleanSearchCommand { get; private set; }

        public ContactListViewModel(IContactRepository repo)
        {
            _repo = repo;
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            AddCommand = new RelayCommand(OnAdd);
            SaveChangesCommand = new RelayCommand(OnSave, CanSave);
            CleanSearchCommand = new RelayCommand(OnEscape);
        }

        private Contact _selectedContact;
        public Contact SelectedContact
        {
            get { return _selectedContact; }
            set
            {
                // unsubsribe for the old data to prevent memory leek
                if (_selectedContact != null)
                {
                    _selectedContact.ErrorsChanged -=
                        (sender, args) => SaveChangesCommand.RaiseCanExecuteChange();
                }

                SetProperty(ref _selectedContact, value);
                DeleteCommand.RaiseCanExecuteChange();

                _selectedContact.ErrorsChanged +=
                    (sender, args) => SaveChangesCommand.RaiseCanExecuteChange();
            }
        }

        private List<Contact> _allContacts;

        private ObservableCollection<Contact> _contacts;
        public ObservableCollection<Contact> Contacts
        {
            get { return _contacts; }
            set { SetProperty(ref _contacts, value); }
        }

        private string _searchInput;
        public string SearchInput
        {
            get { return _searchInput; }
            set
            {
                SetProperty(ref _searchInput, value);
                FitlerContact(_searchInput);
            }
        }

        private void FitlerContact(string searchInput)
        {
            if (string.IsNullOrWhiteSpace(searchInput))
            {
                Contacts = new ObservableCollection<Contact>(_allContacts);
                return;
            }

            Contacts = new ObservableCollection<Contact>(
                _allContacts.Where(c => c.FullName.ToLower().Contains(searchInput.ToLower()))
                );
        }

        public async void LoadContacts()
        {
            _allContacts = await _repo.GetContactsAsync();
            Contacts = new ObservableCollection<Contact>(_allContacts);
        }

        private Contact GetNewContact()
        {
            Contact newContact = new Contact();
            newContact.Id = System.Guid.NewGuid();
            newContact.FirstName = "New";
            newContact.LastName = "Contact";
            newContact.Phone = "(+00) 0000000000";

            return newContact;
        }

        private void OnAdd()
        {
            Contact newContact = GetNewContact();

            _allContacts.Add(newContact);
            Contacts.Add(newContact);

            SelectedContact = newContact;
        }

        private void OnDelete()
        {
            _allContacts.Remove(SelectedContact);
            Contacts.Remove(SelectedContact);
        }

        private bool CanDelete()
        {
            if (SelectedContact != null)
                return true;

            return false;
        }

        public void OnSave()
        {
            (_repo as ContactRepositoryJson).Save(_allContacts);
        }

        public bool CanSave()
        {
            if (_allContacts == null)
                return true;

            foreach (Contact contact in _allContacts)
            {
                if (contact.HasErrors)
                    return false;
            }

            return true;
        }

        private void OnEscape()
        {
            SearchInput = null;
        }
    }
}
