using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMVVMPatternExample.Utilities;

namespace WpfMVVMPatternExample.ViewModels
{
    internal class LoginFormViewModel : MvvmBindableBase
    {

        public ICommand SubmitCommand { get; set; }
        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set
            {
                SetProperty(ref _userId, value, "UserId");
            }
        }

        private string _userPassword;

        public string UserPassword
        {
            get { return _userPassword; }
            set { _userPassword = value; }
        }
        public LoginFormViewModel()
        {
            //SubmitCommand = new DelegateCommand(SubmitCommandHandler);  //Without Parameter
            SubmitCommand = new DelegateCommand<string>((obj)=>SubmitCommandHandler(obj));//With parameter
        }

        private void SubmitCommandHandler(string parameter)
        {
            MessageBox.Show("User Id :"+UserId+"   "+"User Password :"+UserPassword +"  Command Parameter :-"+parameter);
        }
    }
}
