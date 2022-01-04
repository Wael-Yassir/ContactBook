using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactBook.WPF.Base
{
    public class BindableBase : INotifyPropertyChanged
    {
        protected virtual void SetPropery<T>(ref T member, T value, 
            [CallerMemberName] string propertyName = null)
        {
            if (object.Equals(member, value)) 
                return;

            member = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
    }
}
