using SomerenModel;
using SomerenService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SomerenUI
{
    public partial class UpdateStudentForm : Form
    {
        private Student oldStudent;

        public UpdateStudentForm(Student student)
        {
            InitializeComponent();
            oldStudent = student;
            FillBoxesWithOldValues();
            InitializeTextBoxEvent();
        }

        private void updateStudentButton_Click(object sender, EventArgs e)
        {
            List<string> studentValues = new() {studentFirstNameTextbox.Text, studentLastNameTextbox.Text,
                studentClasstextbox.Text, studentTelephoneNumberTextbox.Text, studentRoomNumberTextbox.Text};

            try
            {
                UpdateStudent(studentValues);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private Student FillStudent(List<string> list)
        {
            string firstName = string.IsNullOrEmpty(list[0]) ? oldStudent.FirstName : list[0];
            string lastname = string.IsNullOrEmpty(list[1]) ? oldStudent.LastName : list[1];
            string className = string.IsNullOrEmpty(list[2]) ? oldStudent.ClassName : list[2];
            string telephoneNumber = string.IsNullOrEmpty(list[3]) ? oldStudent.PhoneNumber : list[3];
            int roomNumber = string.IsNullOrEmpty(list[4]) ? oldStudent.RoomNumber : int.Parse(list[4]);

            return new Student(oldStudent.PersonID, firstName, lastname, className, telephoneNumber, roomNumber);
        }

        private void UpdateStudent(List<string> list)
        {
            StudentService studentService = new();
            studentService.UpdateStudent(FillStudent(list));

            MessageBox.Show("Student updated!");
        }

        private void FillBoxesWithOldValues()
        {
            studentFirstNameTextbox.Text = oldStudent.FirstName;
            studentLastNameTextbox.Text = oldStudent.LastName;
            studentClasstextbox.Text = oldStudent.ClassName;
            studentTelephoneNumberTextbox.Text = oldStudent.PhoneNumber;
            studentRoomNumberTextbox.Text = oldStudent.RoomNumber.ToString();
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
    }
}