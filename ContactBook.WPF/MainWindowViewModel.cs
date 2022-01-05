using ContactBook.WPF.Base;
using ContactBook.WPF.Contacts;
using ContactBook.WPF.Services;

namespace ContactBook.WPF
{
    class MainWindowViewModel : BindableBase
    {
        private IContactRepository _repo = new ContactRepositoryJson();
        private ContactListViewModel _contactListViewModel;

        public MainWindowViewModel()
        {
            _contactListViewModel = new ContactListViewModel(_repo);
            CurrentViewModel = _contactListViewModel;
        }

        private BindableBase _currentViewModel;
        public BindableBase CurrentViewModel
        {
            get { return _currentViewModel; }
            set { SetProperty(ref _currentViewModel, value); }
        }
    }
}
