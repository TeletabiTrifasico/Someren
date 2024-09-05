using SomerenDAL;
using SomerenModel;
using System.Collections.Generic;

namespace SomerenService
{
    public class DrinkService
    {
        private DrinkDao drinkDao;

        public DrinkService()
        {
            drinkDao = new();
        }

        public List<Drink> GetDrinks()
        {
            return drinkDao.GetAll();
        }

        public void AddDrink(Drink drink)
        {
            drinkDao.AddDrink(drink);
        }

        public void DeleteDrink(Drink drink)
        {
            drinkDao.DeleteDrink(drink);
        }

        public void UpdateDrink(Drink drink)
        {
            drinkDao.UpdateDrink(drink);
        }
    }
}