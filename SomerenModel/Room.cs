namespace SomerenModel
{
    public class Room
    {
        public int Number { get; private set; }
        public string Building { get; private set; }
        public int Floor { get; private set; }
        public int Capacity { get; private set; }

        public Room(int number, string building, int floor, int capacity)
        {
            Number = number;
            Building = building;
            Floor = floor;
            Capacity = capacity;
        }
    }
}