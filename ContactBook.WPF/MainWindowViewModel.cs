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
        private ContactListViewModel _contactListViewModel = new ContactListViewModel();
        private IContactRepository _repo = new ContactRepositoryJson();
        
        public void OnApplicationShutdown()
        {
            MessageBox.Show("dddd");
        }
    }
}
