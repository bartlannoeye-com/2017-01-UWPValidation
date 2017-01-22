using Prism.Commands;
using Prism.Mvvm;
using Validation.Models;

namespace Validation.ViewModels
{
    internal class MainViewModel : BindableBase
    {
        public MainViewModel()
        {
            MyAccount = new Account();

            ValidateCommand = new DelegateCommand(OnValidate);
        }

        private Account _myAccount;
        public Account MyAccount
        {
            get { return _myAccount; }
            set { SetProperty(ref _myAccount, value); }
        }

        public DelegateCommand ValidateCommand { get; private set; }

        private void OnValidate()
        {
            bool? result = MyAccount?.ValidateProperties();
        }
    }
}
