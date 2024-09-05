using System;

namespace SomerenModel
{
    public class Order
    {
        private int _Quantity;
        public int Id { get; private set; }
        public Student Student { get; private set; }
        public Drink Drink { get; private set; }
        public int Quantity { get => _Quantity; private set => _Quantity = (value > 0) ? value : throw new Exception("Select 1 or more"); }
        public DateTime OrderDate { get; private set; }

        public Order(int id, Student student, Drink drink, int quantity, DateTime orderDate)
        {
            Id = id;
            Student = student;
            Drink = drink;
            Quantity = quantity;
            OrderDate = orderDate;
        }
    }
}