using System;
using System.IO;
using ContactBook.Data.Validation;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Data.Models
{
    public class Contact : ValidatableBindableBase
    {
        private Guid _id;
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _firstName;
        [Required(ErrorMessage = "The First Name field is required!")]
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                SetProperty(ref _firstName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        private string _lastName;
        [Required(ErrorMessage = "The Last Name field is required!")]
        public string LastName
        {
            get { return _lastName; }
            set
            {
                SetProperty(ref _lastName, value);
                OnPropertyChanged(nameof(FullName));
            }
        }

        public string FullName
        {
            get { return _firstName + " " + _lastName; }
        }

        private string _phone;
        [Required, RegularExpression(@"\(?\+([0-9]{2})\)? ?([0-9]{10})", 
            ErrorMessage = "The Phone number must match this expression: (+XX) XXXXXXXXXX")]
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        private string _image =
            Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName + @"\Resources\avatar.png";
        public string Image
        {
            get { return _image; }
            set { SetProperty(ref _image, value); }
        }

        private string _email;
        [EmailAddress(ErrorMessage = "Please, enter a valid email!")]
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private string _company;
        public string Company
        {
            get { return _company; }
            set { SetProperty(ref _company, value); }
        }
    }
}
