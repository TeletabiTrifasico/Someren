using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            List<string> studentValues = new() {studentAddNumberTextbox.Text, studentAddFirstNameTextbox.Text,
                studentAddLastNameTextbox.Text, studentAddClasstextbox.Text, studentAddTelephoneNumberTextbox.Text, studentAddRoomTextbox.Text};

            try
            {
                AddStudent(studentValues);
                MessageBox.Show("Student added!");
            }
            catch (Exception eu)
            {
                MessageBox.Show(eu.Message);
            }
        }

        private Student FillStudent(List<string> list)
        {
            int studentNumber = int.Parse(list[0]);
            int roomNumber = int.Parse(list[5]);

            return new Student(studentNumber, list[1], list[2], list[3], list[4], roomNumber);
        }

        private void AddStudent(List<string> list)
        {
            if (list.Any(x => x == ""))
            {
                throw new Exception("Enter all values!");
            }
            else
            {
                StudentService studentService = new();
                studentService.AddStudent(FillStudent(list));
                Close();
            }
        }
    }
}
