using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class UpdateLecturerForm : Form
    {
        private Lecturer oldLecturer;

        public UpdateLecturerForm(Lecturer lecturer)
        {
            InitializeComponent();
            oldLecturer = lecturer;
            InitializeDateTimePicker();
        }

        private void InitializeDateTimePicker()
        {
            lecturerUpdateAgeDateTime.Format = DateTimePickerFormat.Custom;
            lecturerUpdateAgeDateTime.CustomFormat = "dd, MM, yyyy";
            FillBoxesWithOldValues();
            InitializeTextBoxEvent();
            lecturerUpdateAgeDateTime.MaxDate = DateTime.Today.AddYears(-18);
        }

        private void updateLecturerButton_Click(object sender, EventArgs e)
        {
            List<string> lecturerValues = new() {lecturerFirstNameTextbox.Text, lecturerLastNameTextbox.Text,
                 lecturerTelephoneNumberTextbox.Text, lecturerRoomNumberTextbox.Text};

            try
            {
                UpdateLecturer(lecturerValues);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Lecturer FillLecturer(List<string> list)
        {
            string firstName = string.IsNullOrEmpty(list[0]) ? oldLecturer.FirstName : list[0];
            string lastName = string.IsNullOrEmpty(list[1]) ? oldLecturer.LastName : list[1];
            string telephoneNumber = string.IsNullOrEmpty(list[2]) ? oldLecturer.PhoneNumber : list[2];
            int roomNumber = string.IsNullOrEmpty(list[3]) ? oldLecturer.RoomNumber : int.Parse(list[3]);
            DateTime age = lecturerUpdateAgeDateTime.Value;

            return new Lecturer(oldLecturer.PersonID, firstName, lastName, age, telephoneNumber, roomNumber);
        }

        private void FillBoxesWithOldValues()
        {
            lecturerFirstNameTextbox.Text = oldLecturer.FirstName;
            lecturerLastNameTextbox.Text = oldLecturer.LastName;
            lecturerUpdateAgeDateTime.Value = oldLecturer.Age;
            lecturerTelephoneNumberTextbox.Text = oldLecturer.PhoneNumber;
            lecturerRoomNumberTextbox.Text = oldLecturer.RoomNumber.ToString();
        }

        private void UpdateLecturer(List<string> list)
        {
            LecturerService lecturerService = new();
            lecturerService.UpdateLecturer(FillLecturer(list));

            MessageBox.Show("Lecturer updated!");
        }

        private void TextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            textBox.Clear();
        }

        private void InitializeTextBoxEvent()
        {
            foreach (Control control in Controls)
            {
                if (control is TextBox)
                {
                    control.MouseDoubleClick += TextBox_MouseDoubleClick;
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
