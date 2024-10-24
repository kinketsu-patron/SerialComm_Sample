using Prism.Mvvm;

namespace SerialComm_Sample.Models
{
    public class MessageProvider : BindableBase
    {
        private string m_RecvMessage = "";
        public string RecvMessage
        {
            get { return m_RecvMessage; }
            set { SetProperty( ref m_RecvMessage, value ); }
        }

        public void SetMessage( string p_Message )
        {
            RecvMessage = string.Concat( m_RecvMessage, p_Message );
        }
    }
}
