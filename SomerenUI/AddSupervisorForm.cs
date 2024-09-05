using SomerenService;
using System;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class AddSupervisorForm : Form
    {
        public AddSupervisorForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                LecturerService lecturerService = new();
                lecturerService.AddSupervisor(int.Parse(AddLecNumtxtBox.Text), int.Parse(AddIdtxtBox.Text));
                Close();
                MessageBox.Show("Lecturer added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Close();
            }
        }
    }
}
