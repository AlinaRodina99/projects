using System;
using System.Windows.Forms;
using System.Threading;

namespace FinalTest1._3
{
    /// <summary>
    /// Class for functionality of progress indicator.
    /// </summary>
    public partial class FormForProgressBar : Form
    {
        public FormForProgressBar()
        {
            InitializeComponent();
        }

        private void ProgressButton_Click(object sender, EventArgs e)
        {
            timerForBar.Interval = 100;
            timerForBar.Start();
            timerForBar.Tick += TimerForBar_Tick;
        }

        private int Expectation = 0;

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (Expectation < 5)
            {
                Expectation += 1;
            }
            else
            {
                timerForBar.Stop();
                timerForBar.Tick -= Timer_Tick;
                exitButton.Show();
            }
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private static bool NextProgressBar(ProgressBar progressBar, int value)
        {
            if (progressBar.Value + value <= 100)
            {
                progressBar.Value += value;
                return true;
            }
            return false;
        }

        private void TimerForBar_Tick(object sender, EventArgs e)
        {
            if (!NextProgressBar(progressBar, 5))
            {
                timerForBar.Tick -= TimerForBar_Tick;
                timerForBar.Tick += Timer_Tick;
            }
        }
    }
}
