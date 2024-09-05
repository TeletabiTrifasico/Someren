using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class AddLecturerForm : Form
    {
        public AddLecturerForm()
        {
            InitializeComponent();
            InitializeDateTimePicker();
        }

        private void InitializeDateTimePicker()
        {
            lecturerAddAgeDateTime.Format = DateTimePickerFormat.Custom;
            lecturerAddAgeDateTime.CustomFormat = "dd, MM, yyyy";
            lecturerAddAgeDateTime.MaxDate = DateTime.Today.AddYears(-18);
        }

        private void addLecturerButton_Click(object sender, EventArgs e)
        {
            List<string> lecturerValues = new() {lecturerAddNumberTextbox.Text, lecturerAddFirstNameTextbox.Text,
                lecturerAddLastNameTextbox.Text,lecturerAddAgeDateTime.Text, lecturerAddTelephoneNumberTextbox.Text, lecturerAddRoomTextbox.Text};

            try
            {
                AddLecturer(lecturerValues);
                MessageBox.Show("Lecturer added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Lecturer FillLecturer(List<string> list)
        {
            int lecturerNumber = int.Parse(list[0]);
            int roomNumber = int.Parse(list[5]);


            DateTime birthDate = lecturerAddAgeDateTime.Value;

            return new Lecturer(lecturerNumber, list[1], list[2], birthDate, list[4], roomNumber);
        }

        private void AddLecturer(List<string> list)
        {
            if (list.Any(x => x == ""))
            {
                throw new Exception("Enter all values!");
            }

            LecturerService lecturerService = new();
            lecturerService.AddLecturer(FillLecturer(list));
            Close();
        }
    }
}
