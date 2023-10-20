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

namespace Practica7EncenderLED
{
    public partial class Form1 : Form
    {
        public SerialPort ArduinoPort { get; }
        public Form1()
        {
            InitializeComponent();
            //Crear serial Port
            ArduinoPort = new System.IO.Ports.SerialPort();
            ArduinoPort.PortName = "COM3"; //Checar en su equipo
            ArduinoPort.BaudRate = 9600;
            ArduinoPort.Open();

            //Vincular eventos
            this.FormClosing += CerrandoForm1;
            this.btn_Apagar.Click+=btn_Apagar_Click;
            this.btn_Encender.Click+=btn_Encender_Click;
        }

        private void btn_Encender_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("b");
        }
        private void CerrandoForm1(object sender, FormClosingEventArgs e)
        {
            //cerrando puerto
            if (ArduinoPort.IsOpen) ArduinoPort.Close();
        }
        private void btn_Apagar_Click(object sender, EventArgs e)
        {
            ArduinoPort.Write("a");
        }
    }
}
