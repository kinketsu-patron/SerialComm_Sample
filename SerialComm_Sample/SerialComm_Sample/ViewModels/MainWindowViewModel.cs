using Prism.Commands;
using Prism.Mvvm;
using SerialComm_Sample.Models;

namespace SerialComm_Sample.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private MessageProvider m_MessageProvider = null;

        public DelegateCommand ConnectCommand { get; }
        public DelegateCommand DisconnectCommand { get; }

        public string RecvMessage
        {
            get { return m_MessageProvider.RecvMessage; }
            set { m_MessageProvider.RecvMessage = value; }
        }

        public MainWindowViewModel( )
        {
            m_MessageProvider = new MessageProvider( );
            m_MessageProvider.PropertyChanged += ( sender, e ) => RaisePropertyChanged( e.PropertyName );
            ConnectCommand = new DelegateCommand( Connect_Click );
            DisconnectCommand = new DelegateCommand( Disconnect_Click );
        }

        private void Connect_Click( )
        {
            m_MessageProvider.Connect( );
        }

        private void Disconnect_Click( )
        {
            m_MessageProvider.Disconnect( );
        }
    }
}
