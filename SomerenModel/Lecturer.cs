using System;

namespace SomerenModel
{
    public class Lecturer : Person
    {
        public DateTime Age { get; private set; }

        public Lecturer(int lecturerNumber, string firstName, string lastName, DateTime age, string telephoneNumber, int roomNumber)
            : base(lecturerNumber, firstName, lastName, telephoneNumber, roomNumber)
        {
            Age = age;
        }
    }
}