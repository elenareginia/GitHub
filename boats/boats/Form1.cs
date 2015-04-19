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

namespace boats
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != string.Empty)
            {
                if (label1.Text == " ")
                {
                    label1.Text = comboBox1.Text;
                    fillProgressBar(progressBar1, label1);

                }
                else if (label2.Text == " ")
                {
                    label2.Text = comboBox1.Text;
                    fillProgressBar(progressBar2, label2);
                }
                else if (label3.Text == " ")
                {
                    label3.Text = comboBox1.Text;
                    fillProgressBar(progressBar3, label3);
                }
                else
                    return;
            }
        }

        private void fillProgressBar(ProgressBar pb, Label l)
        {
            Thread backgroundThread = new Thread(
    new ThreadStart(() =>
    {
        for (int n = 0; n < 100; n++)
        {
            Thread.Sleep(50);
            pb.BeginInvoke(
                new Action(() =>
                {
                    pb.Value = n;
                }
            ));
        }

        MessageBox.Show("Thread completed!");
        l.Text=" ";
        pb.BeginInvoke(
            new Action(() =>
            {
                pb.Value = 0;
            }
        ));
    }
    ));
            backgroundThread.Start();
        }





        
    }
}
