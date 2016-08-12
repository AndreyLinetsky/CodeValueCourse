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
using System.IO;

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellation;
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            button1.Enabled = false;
            int firstNum, secondNum;
            if (int.TryParse(textBox1.Text, out firstNum) &&
            int.TryParse(textBox2.Text, out secondNum) &&
            !string.IsNullOrWhiteSpace(output.Text))
            {
                CalcPrimes calc = new CalcPrimes();
                cancellation = new CancellationTokenSource();
                button2.Enabled = true;
                try
                {
                    int primeCount = await calc.CountPrimesAsync(firstNum, secondNum, cancellation.Token);
                    label4.Text = $"Prime numbers count is {primeCount}";
                    using (StreamWriter streamWriter = new StreamWriter(output.Text, true))
                    {
                        streamWriter.WriteLine("Prime numbers count is " + primeCount);
                    }
                }
                catch (OperationCanceledException)
                {
                    label4.Text = "Process has stopped";

                }
                catch (IOException ex)
                {
                    label4.Text = ex.Message;
                }

            }
            else
            {
                label4.Text = "Please enter correct values";
            }
            button1.Enabled = true;
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (cancellation != null)
            {
                cancellation.Cancel();
                cancellation.Dispose();
            }
        }
    }
}