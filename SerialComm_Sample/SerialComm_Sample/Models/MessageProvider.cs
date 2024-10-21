using Prism.Mvvm;
using System;
using System.IO.Ports;
using System.Text;
using System.Windows;

namespace SerialComm_Sample.Models
{
    public class MessageProvider : BindableBase
    {
        private SerialPort m_SerialPort = null;

        private string m_RecvMessage = null;
        public string RecvMessage
        {
            get { return m_RecvMessage; }
            set { SetProperty( ref m_RecvMessage, value ); }
        }

        public MessageProvider( )
        {
            m_SerialPort = new SerialPort( );
            m_SerialPort.PortName = "COM3";
            m_SerialPort.BaudRate = 9600;
            m_SerialPort.DataBits = 8;
            m_SerialPort.Parity = Parity.None;
            m_SerialPort.Encoding = Encoding.UTF8;
            m_SerialPort.WriteTimeout = 5000;
            m_SerialPort.ReadTimeout = 5000;
            m_SerialPort.DtrEnable = true;

            m_SerialPort.DataReceived += ( sender, e ) =>
            {
                try
                {
                    string message = m_SerialPort.ReadExisting();

                    Application.Current.Dispatcher.Invoke( ( ) =>
                    {
                        RecvMessage = message;
                    } );
                } catch ( Exception ex )
                {
                    MessageBox.Show( ex.Message );
                }
            };
        }

        public void Connect( )
        {
            try
            {
                m_SerialPort.Open( );
            } catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }

        public void Disconnect( )
        {
            try
            {
                m_SerialPort.Close( );
            } catch ( Exception ex )
            {
                MessageBox.Show( ex.Message );
            }
        }
    }
}
