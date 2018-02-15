using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DemoSerialPort
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }
        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            clear();
            textBox1.Text = serialPort1.ReadLine().Trim();
            string[] str = textBox1.Text.Split(',');
            textBox1.Text = str[0];
            textBox2.Text = str[1];
            textBox3.Text = str[2];
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            comboBox1.Items.AddRange(ports);
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void clear()
        {
            textBox1.Text = null;
            textBox2.Text = null;
            textBox3.Text = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            clear();
            serialPort1.Close();
            serialPort1.PortName = comboBox1.SelectedItem.ToString();
            serialPort1.BaudRate = 115200;
            serialPort1.Open();
        }
    }
}
