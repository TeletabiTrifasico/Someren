using System;

namespace SomerenModel
{
    public class Drink
    {
        private int _Vat;
        public int Drink_ID { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string StockToText { get => Stock == 0 ? "Stock empty" : Stock < 20 ? "Stock nearly depleted" : "Stock sufficient"; }
        public int Vat { get => _Vat; private set => _Vat = (value == 21 || value == 9) ? value : throw new Exception("Invalid VAT entered!"); }
        public string Alcohol { get => (Vat == 21) ? "alcoholic" : "non-alcoholic"; }

        public Drink(int id, string name, decimal price, int stock, int vat)
        {
            Drink_ID = id;
            Name = name;
            Price = price;
            Stock = stock;
            Vat = vat;
        }
    }
}