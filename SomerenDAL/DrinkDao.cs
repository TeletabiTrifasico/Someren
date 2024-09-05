using SomerenModel;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class DrinkDao : BaseDao<Drink>
    {
        internal protected override Drink ConvertItem(DataRow reader)
        {
            int id = (int)reader["drink_ID"];
            string name = (string)reader["drink_name"];
            decimal price = (decimal)reader["price"];
            int stock = (int)reader["stock_amount"];
            int vat = (int)reader["vat"];

            return new Drink(id, name, price, stock, vat);
        }

        private protected override string GetAllQuery()
        {
            return "SELECT drink_ID, drink_name, price, stock_amount, vat FROM drink";
        }

        

        public void AddDrink(Drink drink)
        {
            string query = "INSERT drink(drink_name, price, stock_amount, vat) VALUES (@drink_name, @price, @stock_amount, @vat)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@drink_name", SqlDbType.VarChar) {Value = drink.Name},
                new("@price", SqlDbType.Decimal) {Value = drink.Price},
                new("@stock_amount", SqlDbType.Int) {Value = drink.Stock},
                new("@vat", SqlDbType.Int) {Value = drink.Vat}
            };

            ExecuteEditQuery(query, parameters);
        }

        public void DeleteDrink(Drink drink)
        {
            string query = "DELETE FROM drink WHERE drink_ID = @drink_ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@drink_ID", SqlDbType.Int) {Value = drink.Drink_ID}
            };

            ExecuteEditQuery(query, parameters);
        }

        public void UpdateDrink(Drink drink)
        {
            string query = "UPDATE drink SET drink_name = @drink_name, price = @price, stock_amount = @stock_amount, vat = @vat WHERE drink_ID = @drink_ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@drink_ID", SqlDbType.Int) {Value = drink.Drink_ID},
                new("@drink_name", SqlDbType.VarChar) {Value = drink.Name},
                new("@price", SqlDbType.Decimal) {Value = drink.Price},
                new("@stock_amount", SqlDbType.Int) {Value = drink.Stock},
                new("@vat", SqlDbType.Int) {Value = drink.Vat}
            };

            ExecuteEditQuery(query, parameters);
        }
    }
}