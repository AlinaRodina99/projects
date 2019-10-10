using System;
using System.Windows.Forms;

namespace RunningButton
{
    /// <summary>
    /// Class for game when user tries to catch button by hovering over.
    public partial class ClickMouse : Form
    {
        /// <summary>
        /// Constructor for initializing form.
        /// </summary>
        public ClickMouse()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Private method to make the mouse run away from cursor.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void Mouse_MouseMove(object sender, MouseEventArgs e)
        {
            var random = new Random();
            Mouse.Left = random.Next(0, ClientSize.Width - Mouse.Width);
            Mouse.Top = random.Next(0, ClientSize.Height - Mouse.Height);
        }

        /// <summary>
        /// Private method to close program when user clicks the button.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void Mouse_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Private method to make button run away when user tries to change size of the form.
        /// </summary>
        /// <param name="sender">Object that triggered the event.</param>
        /// <param name="e">Argument that holds information about event.</param>
        private void ClickMouse_Resize(object sender, EventArgs e)
        {
            var random = new Random();
            Mouse.Left = random.Next(0, ClientSize.Width - Mouse.Width);
            Mouse.Top = random.Next(0, ClientSize.Height - Mouse.Height);
        }
    }
}
