using ContactBook.WPF.Base;
using ContactBook.WPF.Contacts;
using ContactBook.WPF.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ContactBook.WPF
{
    class MainWindowViewModel : BindableBase
    {
        private IContactRepository _repo = new ContactRepositoryJson();
        private ContactListViewModel _contactListViewModel;

        public MainWindowViewModel()
        {
            _contactListViewModel = new ContactListViewModel(_repo);
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel = _contactListViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }
    }
}
