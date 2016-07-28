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

namespace PrimesCalculator
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cancellation;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int firstNum, secondNum;
            if (int.TryParse(textBox1.Text, out firstNum) &&
            int.TryParse(textBox2.Text, out secondNum))
            {
                CalcPrimes calc = new CalcPrimes();
                cancellation = new CancellationTokenSource();
                var newTask = Task<List<int>>.Run(() => calc.ReturnPrimes(firstNum, secondNum, cancellation.Token), cancellation.Token).
                ContinueWith(t =>
                {
                    foreach (var result in t.Result)
                    {
                        this.Invoke((MethodInvoker)(() => listBox1.Items.Add(result)));
                    }
                }, TaskContinuationOptions.OnlyOnRanToCompletion);
            }
            else
            {
                listBox1.Items.Add("Please enter numbers");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
               if (cancellation != null)
              {
                cancellation.Cancel();
                cancellation.Dispose();
                listBox1.Items.Add("Process stopped");
              }
        }
    }
}