using System;
using System.ComponentModel.DataAnnotations;
using Prism.Windows.Validation;

namespace Validation.Models
{
    public class Account : ValidatableBindableBase
    {
        private string _name;
        private string _firstname;
        private int _age;
        private string _sex;
        private string _phone;
        private string _pinCode;
        private decimal _balance;

        [Required]
        public string Name
        {
            get { return _name; }
            set { SetProperty(ref _name, value); }
        }

        [Required]
        public string Firstname
        {
            get { return _firstname; }
            set { SetProperty(ref _firstname, value); }
        }

        public int Age
        {
            get { return _age; }
            set { SetProperty(ref _age, value); }
        }

        [Required]
        [CustomValidation(typeof(Account), nameof(ValidateSex))]
        public string Sex
        {
            get { return _sex; }
            set { SetProperty(ref _sex, value); }
        }

        [RegularExpression(RegexConstants.PhoneRegexPattern, ErrorMessage = "Phone is incorrect.")]
        public string Phone
        {
            get { return _phone; }
            set { SetProperty(ref _phone, value); }
        }

        [RegularExpression(RegexConstants.PinRegexPattern, ErrorMessage = "Pin has to be 4 digits.")]
        public string PinCode
        {
            get { return _pinCode; }
            set { SetProperty(ref _pinCode, value); }
        }

        public decimal Balance
        {
            get { return _balance; }
            set { SetProperty(ref _balance, value); }
        }

        public static ValidationResult ValidateSex(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }

            string selectedValue = (string) value;
            if (selectedValue == "M" || selectedValue == "F")
                return ValidationResult.Success;

            return new ValidationResult("Sex is not correct.");
        }
    }
}
