using System.Windows;
using System.Windows.Input;
using WpfMVVMPatternExample.Utilities;

namespace WpfMVVMPatternExample.ViewModels
{
    public class MainWindowViewModel : MvvmBindableBase
    {
        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value, "UserId"); }
        }
        private string _password;

        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value, "Password"); }
        }

        //public ICommand SubmitCommand { get; set; }
        public ICommand SubmitCommand { get; set; }
        public MainWindowViewModel()
        {
            SubmitCommand = new DelegateCommand<string>((obj)=>SubmitCommandHandler(obj));
        }
        private void SubmitCommandHandler(string parameter)
        {
            MessageBox.Show("MVVM design pattern");
        }
    }
}
