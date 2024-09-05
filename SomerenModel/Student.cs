namespace SomerenModel
{
    public class Student : Person
    {
        public string ClassName { get; private set; }

        public Student(int studentNumber, string firstName, string lastName, string className, string telephoneNumber, int roomNumber)
            : base(studentNumber, firstName, lastName, telephoneNumber, roomNumber)
        {
            ClassName = className;
        }
    }
}