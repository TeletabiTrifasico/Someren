using System.Data;
using SomerenModel;

namespace SomerenDAL
{
    public class RoomDao : BaseDao<Room>
    {
        internal protected override Room ConvertItem(DataRow reader)
        {
            int roomNumber = (int)reader["roomID"];
            string building = (string)reader["building"];
            int floor = (int)reader["floornumber"];
            int bedsAmount = (int)reader["capacity"];

            return new Room(roomNumber, building, floor, bedsAmount);
        }

        private protected override string GetAllQuery()
        {
            return "SELECT roomID, building, floornumber, capacity FROM room";
        }
    }
}