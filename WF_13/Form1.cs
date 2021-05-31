using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] A = new int[5];
        int xx;

        private void button1_Click(object sender, EventArgs e)
        {
            double param = Convert.ToDouble(textBox1.Text);
            int N = Convert.ToInt32(textBox2.Text);
            Geometriс geometric = new Geometriс();


            A = geometric.Statistical(param, N);

            Random random = new Random();
            textBox3.Text = "";
            double[] last = new double[5];

            for (int i = 0; i < 5; i++)
            {
                textBox3.Text += "x" + i + " = " + (Math.Round(((double)A[i] / N), 3)).ToString() + Environment.NewLine;
                last[i] = Math.Round(((double)A[i] / N), 3);
            }




            chart1.Series[0].Points.Clear();
            chart1.Series[0].Points.AddXY(0, 0);
            xx = 0;
            timer1.Start();

            Mathematics mathematics = new Mathematics();
            double a = mathematics.Average(geometric.P);
            label3.Text = "Average: " + mathematics.Average(last).ToString() + " (error = " + mathematics.Prosent(mathematics.Average(last), a) + "%)";
            a = mathematics.Variance(geometric.P);
            label4.Text = "Variance: " + mathematics.Variance(last).ToString() + " (error = " + mathematics.Prosent(mathematics.Variance(last), a) + "%)";


            double m = mathematics.Xi(A, N, geometric.P);
            if (m > N)
            {
                label5.Text = "Chi - squared: " + Math.Round(m, 3).ToString() + ">" + "9.488" + " true";
            }
            else
            {
                label5.Text = "Chi - squared: " + Math.Round(m, 3).ToString() + "<" + "9.488" + " false";
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (xx < 5)
            {

                chart1.Series[0].Points.AddXY(0, A[xx]);
                xx++;
            }
            else
            {
                timer1.Stop();
            }

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
