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
        public RelayCommand CleanSearchCommand { get; private set; }

        public ContactListViewModel(IContactRepository repo)
        {
            _repo = repo;
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            AddCommand = new RelayCommand(OnAdd);
            SaveChangesCommand = new RelayCommand(OnSave);
            CleanSearchCommand = new RelayCommand(OnEscape);
        }

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

        public void OnSave()
        {
            (_repo as ContactRepositoryJson).Save(Contacts.ToList());
        }

        private void OnAdd()
        {
            Contact newContact = new Contact()
            {
                Id = System.Guid.NewGuid(),
                FirstName = "New",
                LastName = "Contact",
            };

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

        private void OnEscape()
        {
            SearchInput = null;
        }
    }
}
