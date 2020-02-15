using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GuitarConnector
{
    class Serial
    {
        public string       Port { get; set; }
        public int          Baudrate { get; set; }
        private SerialPort  serial = new SerialPort();

        public Serial()
        {
            serial.NewLine = "\n";
            Baudrate = 0;
        }

        public Serial(string Port)
        {
            serial.NewLine = "\n";
            this.Port = Port;
        }

        public Serial(string Port, int Baudrate)
        {
            serial.NewLine = "\n";
            this.Port = Port;
            this.Baudrate = Baudrate;
        }

        public Serial(string Port, int Baudrate, string Lineending)
        {
            serial.NewLine = Lineending;
            this.Port = Port;
            this.Baudrate = Baudrate;
        }

        public bool Send(string message)
        {
            if (serial == null || !serial.IsOpen)
            {
                Utils.Error(Properties.Strings.error_notopen);
                return false;
            }
            else
            {
                try
                {
                    serial.WriteLine(message);
                }
                catch (Exception e)
                {
                    Utils.Error(Properties.Strings.error_write + "\n" + e.Message);
                    return false;
                }
                Thread.Sleep(20);
                return true;
            }
        }

        public string ReadLine(bool force = false)
        {
            if (force)
                return serial.ReadLine();
            string res;
            if (serial == null || !serial.IsOpen)
            {
                Utils.Error(Properties.Strings.error_notopen);
                return "";
            }
            try
            {
                res = serial.ReadLine();
            }
            catch (Exception e)
            {
                Utils.Error(Properties.Strings.error_read + "\n" + e.Message);
                return "";
            }
            return res;
        }

        public bool Open()
        {
            if (Port == null)
                return false;
            if (Baudrate == 0)
                return false;
            try
            {
                serial.BaudRate = Baudrate;
                serial.PortName = Port;
                serial.Open();
            }
            catch
            {
                return false;
            }
            return true;
        }

        public void Close()
        {
            if (serial.IsOpen)
                serial.Close();
        }

        public bool IsOpen()
        {
            return serial.IsOpen;
        }

        public static string[] GetPorts()
        {
            return SerialPort.GetPortNames();
        }
    }
}
