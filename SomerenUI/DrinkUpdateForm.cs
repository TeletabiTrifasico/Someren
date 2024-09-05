using SomerenService;
using System;
using System.Windows.Forms;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenUI
{
    public partial class DrinkUpdateForm : Form
    {
        Drink oldDrink;

        public DrinkUpdateForm(Drink drink)
        {
            InitializeComponent();
            oldDrink = drink;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            List<string> drinkValues = new() { txtName.Text, txtPrice.Text, txtStock.Text, txtVat.Text };

            try
            {
                UpdateDrink(drinkValues);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Something went wrong while updating the drink: " + ex.Message);
            }
        }

        private Drink FillDrink(List<string> list)
        {
            string name = string.IsNullOrWhiteSpace(list[0]) ? oldDrink.Name : list[0];
            decimal price = string.IsNullOrWhiteSpace(list[1]) ? oldDrink.Price : int.Parse(list[1]);
            int stock = string.IsNullOrWhiteSpace(list[2]) ? oldDrink.Stock : int.Parse(list[2]);
            int vat = string.IsNullOrWhiteSpace(list[3]) ? oldDrink.Vat : int.Parse(list[3]);

            return new Drink(oldDrink.Drink_ID, name, price, stock, vat);
        }

        private void UpdateDrink(List<string> list)
        {
            DrinkService drinkService = new();
            drinkService.UpdateDrink(FillDrink(list));

            MessageBox.Show("Drink updated!");
        }
    }
}