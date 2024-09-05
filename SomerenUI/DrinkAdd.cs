using SomerenService;
using System;
using System.Windows.Forms;
using System.Collections.Generic;
using SomerenModel;
using System.Linq;

namespace SomerenUI
{
    public partial class DrinkAddForm : Form
    {
        private const int ObjectIdBeforeDb = 0;

        public DrinkAddForm()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            List<string> drinkValues = new() { txtName.Text, txtPrice.Text, txtStock.Text, txtVat.Text };

            try
            {
                AddDrink(drinkValues);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public Drink TryToFillDrink(List<string> list)
        {
            if (list.Any(x => x == ""))
            {
                throw new Exception("Enter all values!");
            }

            return FillDrink(list);
        }

        private Drink FillDrink(List<string> list)
        {
            int id = ObjectIdBeforeDb;
            string name = list[0];
            decimal price = decimal.Parse(list[1]);
            int stock = int.Parse(list[2]);
            int vat = int.Parse(list[3]);

            return new Drink(id, name, price, stock, vat);
        }

        private void AddDrink(List<string> list)
        {
            DrinkService drinkService = new();
            drinkService.AddDrink(TryToFillDrink(list));

            MessageBox.Show("Drink added!");
        }
    }
}