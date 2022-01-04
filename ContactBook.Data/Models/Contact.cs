﻿using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ContactBook.Data.Models
{
    public class Contact : INotifyPropertyChanged
    {
        #region Properties
        private int _id;

        // the Id property access modifier is set as "Internal" to be access in the assembly when generating the JSON file only
        // in the case of an actual DB it should be private.
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _firstName;

        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        private string _lastName;

        public string LastName
        {
            get { return _lastName; }
            set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(FullName));
                }
            }
        }

        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }

        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                if (_phone != value)
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _image;

        public string Image
        {
            get { return _image; }
            set
            {
                if (_image != value)
                {
                    _image = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _email;

        public string Email
        {
            get { return _email; }
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _company;

        public string Company
        {
            get { return _company; }
            set
            {
                if (_company != value)
                {
                    _company = value;
                    OnPropertyChanged();
                }
            }
        }
        #endregion

        // using delegate {} is what called delegate trick to avoid checking if the event is null
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
