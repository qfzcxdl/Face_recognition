using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Runtime.InteropServices;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private SerialPort port = null;
        private Thread thread = null;

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        public delegate void CSCallback(int x, int y);
        public CSCallback callback;


        [DllImport("win32dll.dll", EntryPoint = "setCallBack")]
        public static extern void setCallBack(CSCallback callback);
        [DllImport("win32dll.dll", EntryPoint = "runCapture")]
        public static extern int runCapture();
         
        public Form1()
        {
            InitializeComponent();
            callback = CSCallbackFunction;
        }


        public void CSCallbackFunction(int x, int y)
        {
            if (this.sendBox.Checked)
            {
                if (x > 45)
                {
                    this.port.Write("0");
                }
                else if (x < -45)
                {
                    this.port.Write("1");
                }

                if (y > 40)
                {
                    this.port.Write("2");
                }
                else if (y < -40)
                {
                    this.port.Write("3");
                }
                
            }
            
        }


        public void dataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            this.RefreshInfoTextBox();
        }

        private void threadRun()
        {
            runCapture();
        }

        private void beginSerial(object sender, EventArgs e)
        {
            setCallBack(callback);

            if (this.thread == null)
            {
                this.thread = new Thread(threadRun);
            }
            this.thread.Start();
            
            string portStr = Properties.Settings.Default.portName;
            string[] ports = SerialPort.GetPortNames();
            if (!ports.Contains(portStr))
            {
                this.outPutText.Text += "com3 port is not exsit \n";
                if (this.thread.IsAlive)
                {
                    this.thread.Abort();
                }
                this.thread = null;
                return;
            }


            this.port = new SerialPort(portStr, 9600);
            if (this.port != null && this.port.IsOpen)
            {
                port.Close();
            }
            port.Encoding = Encoding.ASCII;
            if (this.receviceBox.Checked)
            {
                port.DataReceived += dataReceived;
            }
            

            this.sendBox.Enabled = false;
            this.receviceBox.Enabled = false;
            this.button1.Enabled = false;
            this.button2.Enabled = true;
            
            try
            {
                port.Open();
            }
            catch (System.Exception ex)
            {
                this.sendBox.Enabled = true;
                this.receviceBox.Enabled = true;
                this.button1.Enabled = true;
                this.button2.Enabled = false;
                this.outPutText.Text += "com3 port is not open \n";
                port.Dispose();
                if (this.thread.IsAlive)
                {
                    this.thread.Abort();
                }
                this.thread = null;
            }
            

        }

        private void endSerial(object sender, EventArgs e)
        {
            if (this.port != null)
            {
                try
                {
                    if (this.port.IsOpen)
                    {
                        this.port.Close();
                    }
                    this.port.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("关闭串口发生错误：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (this.thread!=null && this.thread.IsAlive)
            {
                this.thread.Abort();
            }
            this.thread = null; 
            this.sendBox.Enabled = true;
            this.receviceBox.Enabled = true;
            this.button1.Enabled = true;
            this.button2.Enabled = false;

        }

        private string ReadSerialData()
        {
            string value = "";
            try
            {
                if (this.port != null && this.port.BytesToRead > 0)
                {
                    value = this.port.ReadExisting();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("读取串口数据发生错误：" + ex.Message, "提示信息", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return value;
        }

        private void RefreshInfoTextBox()
        {
            string value = this.ReadSerialData();
            Action<string> setValueAction = text => this.outPutText.Text += text;

            if (this.outPutText.InvokeRequired)
            {
                this.outPutText.Invoke(setValueAction, value);
            }
            else
            {
                setValueAction(value);
            }
        }


    }
}
