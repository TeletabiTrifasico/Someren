namespace SomerenModel
{
    public abstract class Person
    {
        public int PersonID { get; private set; }
        public string FullName { get => $"{FirstName} {LastName}"; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string PhoneNumber { get; private set; }
        public int RoomNumber { get; private set; }

        public Person(int PersonID, string firstName, string lastName, string telephoneNumber, int roomNumber)
        {
            this.PersonID = PersonID;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = telephoneNumber;
            RoomNumber = roomNumber;
        }
    }
}