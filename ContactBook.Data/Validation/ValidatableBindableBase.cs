using System;
using System.Linq;
using System.Collections;
using System.ComponentModel;
using ContactBook.Data.Base;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.ComponentModel.DataAnnotations;

namespace ContactBook.Data.Validation
{
    public class ValidatableBindableBase : BindableBase, INotifyDataErrorInfo
    {
        private Dictionary<string, List<string>> _errors = new Dictionary<string, List<string>>();

        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged = delegate { };

        public IEnumerable GetErrors(string propertyName)
        {
            if (_errors.ContainsKey(propertyName))
                return _errors[propertyName];
            else
                return null;
        }

        public bool HasErrors
        {
            get { return _errors.Count > 0; }
        }

        protected override void SetProperty<T>(ref T member, T value, 
            [CallerMemberName] string propertyName = null)
        {
            base.SetProperty(ref member, value, propertyName);
            ValidateProperty(propertyName, value);
        }

        private void ValidateProperty<T>(string propertyName, T value)
        {
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(this);
            context.MemberName = propertyName;

            Validator.TryValidateProperty(value, context, results);

            if (results.Any())
            {
                _errors[propertyName] = results.Select(r => r.ErrorMessage).ToList();
            }
            else
            {
                _errors.Remove(propertyName);
            }

            ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
        }
    }
}
