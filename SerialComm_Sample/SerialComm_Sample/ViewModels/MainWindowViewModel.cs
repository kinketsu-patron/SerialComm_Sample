using Prism.Mvvm;

namespace SerialComm_Sample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Prism Application";
        public string Title
        {
            get { return _title; }
            set { SetProperty( ref _title, value ); }
        }

        public MainWindowViewModel( )
        {

        }
    }
}
