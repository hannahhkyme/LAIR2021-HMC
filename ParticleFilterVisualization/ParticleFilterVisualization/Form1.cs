using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace ParticleFilterVisualization
{
    public partial class Form1 : Form
    {
        private Thread cpuThread;
        private double[] w1xArray = new double[5];
        private double[] w1yArray = new double[5];
        private double[] w2xArray = new double[60];
        private double[] w2yArray = new double[60];
        private double[] w3xArray = new double[60];
        private double[] w3yArray = new double[60];

        public Form1()
        {
            InitializeComponent();
            
        }

        private void getParticleCoordinates()
        {
            Random random_num = new Random();

            while (true)
            {
                for (int i = 0; i < w1xArray.Length - 1; ++i)
                {
                    w1xArray[i] = random_num.Next(-150, 150);
                    w1yArray[i] = random_num.Next(-150, 150);


                    w2xArray[i] = random_num.Next(-150, 150);
                    w2yArray[i] = random_num.Next(-150, 150);
                }

                Array.Copy(w1yArray, 0, w1yArray, 0, w1yArray.Length - 1);
                Array.Copy(w1xArray, 0, w1xArray, 0, w1xArray.Length - 1);
                if (cpuChart.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateCpuChart(); });
                }
                else
                {
                    //......
                }

                if (chart1.IsHandleCreated)
                {
                    this.Invoke((MethodInvoker)delegate { UpdateChart1(); });
                }
                else
                {
                    //......
                }

                Thread.Sleep(100);
            }
        }

        private void UpdateCpuChart()
        {
            cpuChart.Series["Series1"].Points.Clear();
            cpuChart.Series["Series2"].Points.Clear();
            for (int i = 0; i < w1xArray.Length - 1; ++i)
            {
                cpuChart.Series["Series1"].Points.AddXY(w1xArray[i], w1yArray[i]);
                cpuChart.Series["Series2"].Points.AddXY(w2xArray[i], w2yArray[i]);
            }
        }

        private void UpdateChart1()
        {
            chart1.Series["Series1"].Points.Clear();
            for (int i = 0; i < w1xArray.Length - 1; ++i)
            {
                chart1.Series["Series1"].Points.AddXY(w1xArray[i], w1yArray[i]);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
