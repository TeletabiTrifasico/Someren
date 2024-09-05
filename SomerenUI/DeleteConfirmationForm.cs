using System;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class DeleteConfirmationForm : Form
    {
        public DeleteConfirmationForm(string message)
        {
            InitializeComponent();
            DeleteItemMessageLabel.Text = message;
        }

        public bool DeleteMessage()
        {
            return DialogResult == DialogResult.OK;
        }

        private void YesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
