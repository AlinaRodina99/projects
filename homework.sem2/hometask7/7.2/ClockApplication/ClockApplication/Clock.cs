using System;
using System.Windows.Forms;

namespace ClockApplication
{
    /// <summary>
    /// Class for clock functionality.
    /// </summary>
    public partial class Clock : Form
    {
        /// <summary>
        /// Contstructor that initializes form.
        /// </summary>
        public Clock()
        {
            InitializeComponent();
            Timer.Enabled = true;
        }

        /// <summary>
        /// Method to show current time.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void Timer_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToLongTimeString();
        }
    }
}
