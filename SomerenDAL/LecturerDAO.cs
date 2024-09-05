using SomerenModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class LecturerDao : BaseDao<Lecturer>
    {
        private const string LecturersRoomType = "single room";
        private const string LecturersTable = "lecturer";
        private const string ActivityTable = "activity";
        private const string ActivitySuperviceTable = "supervises";
        private const string LecturerNumberColumn = "lecturer_ID";
        private const string ActivityIdColumn = "activityId";

        private const int PeoplePerSingleRoom = 1;

        /*Lecturer*/

        internal protected override Lecturer ConvertItem(DataRow reader)
        {
            int lecturerNumber = (int)reader["lecturer_ID"];
            string firstName = (string)reader["first_name"];
            string lastName = (string)reader["last_name"];
            DateTime age = (DateTime)reader["age"];
            string telephoneNumber = (string)reader["phone_number"];
            int roomNumber = (int)reader["roomID"];

            return new Lecturer(lecturerNumber, firstName, lastName, age, telephoneNumber, roomNumber);
        }

        private protected override string GetAllQuery()
        {
            return "SELECT lecturer_ID, first_name, last_name, age, phone_number, roomID FROM lecturer";
        }

        public void DeleteLecturer(Lecturer lecturer)
        {
            string query = "DELETE FROM lecturer WHERE lecturer_ID = @lecturer_ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@lecturer_ID", SqlDbType.Int) {Value = lecturer.PersonID}
            };

            ExecuteEditQuery(query, parameters);
        }

        public void AddLecturer(Lecturer lecturer)
        {
            CheckLecturerValues(lecturer);

            string query = "INSERT INTO lecturer(first_name, last_name, age, phone_number, roomID) VALUES (@first_name, @last_name, @age, @phone_number, @roomID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@first_name", SqlDbType.VarChar) {Value = lecturer.FirstName},
                new("@last_name", SqlDbType.VarChar) {Value = lecturer.LastName},
                new("@age", SqlDbType.Date) {Value = lecturer.Age},
                new("@phone_number", SqlDbType.VarChar) {Value = lecturer.PhoneNumber},
                new("@roomID", SqlDbType.Int) {Value = lecturer.RoomNumber}
            };

            ExecuteEditQuery(query, parameters);
        }

        private void CheckLecturerValues(Lecturer lecturer)
        {
            if (IdExists(lecturer.PersonID, "lecturer", "lecturer_ID"))
            {
                throw new Exception("This id already exists!");
            }

            CheckRoom(lecturer);
        }

        private void CheckRoom(Lecturer lecturer)
        {
            if (!RoomExists(lecturer.RoomNumber))
            {
                throw new Exception("This room does not exist!");
            }
            else if (PeopleInRoom(lecturer.RoomNumber, LecturersTable) == PeoplePerSingleRoom && lecturer.PersonID != PersonIdInRoom(lecturer.RoomNumber, lecturer.PersonID, LecturersTable, LecturerNumberColumn, LecturerNumberColumn))
            {
                throw new Exception($"The room {lecturer.RoomNumber} has too many people!");
            }
        }

        public void UpdateLecturer(Lecturer lecturer)
        {
            CheckRoom(lecturer);

            string query = "UPDATE lecturer SET first_name = @first_name, last_name = @last_name, age = @age, phone_number = @phone_number, roomID = @roomID WHERE lecturer_ID = @lecturer_ID";
            ExecuteEditQuery(query, LecturerParameters(lecturer));
        }

        private SqlParameter[] LecturerParameters(Lecturer lecturer)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@lecturer_ID", SqlDbType.Int) {Value = lecturer.PersonID},
                new("@first_name", SqlDbType.VarChar) {Value = lecturer.FirstName},
                new("@last_name", SqlDbType.VarChar) {Value = lecturer.LastName},
                new("@age", SqlDbType.Date) {Value = lecturer.Age},
                new("@phone_number", SqlDbType.VarChar) {Value = lecturer.PhoneNumber},
                new("@roomID", SqlDbType.Int) {Value = lecturer.RoomNumber}
            };

            return parameters;
        }

        /*Supervisors*/

        public void AddSupervisor(int lecturerNumber, int activityId)
        {
            string query = "INSERT INTO supervises (lecturer_ID, activityID) VALUES (@lecturer_ID, @activityID)";
            AddSupervisorException(lecturerNumber, activityId);

            SqlParameter[] parameters = new SqlParameter[]
            {
            new(LecturerNumberColumn, SqlDbType.Int) { Value = lecturerNumber },
            new(ActivityIdColumn, SqlDbType.Int) { Value = activityId }
            };

            ExecuteEditQuery(query, parameters);
        }

        private void AddSupervisorException(int lecturerNumber, int activityId)
        {
            if (!IdExists(activityId, ActivityTable, ActivityIdColumn))
            {
                throw new Exception("Invalid input");
            }
            if (!IdExists(lecturerNumber, LecturersTable, LecturerNumberColumn))
            {
                throw new Exception("Invalid input");
            }
            if (IdExists(lecturerNumber, ActivitySuperviceTable, LecturerNumberColumn))
            {
                throw new Exception("Lecturer is already a supervisor for this activity.");
            }
        }

        public void DeleteSupervisor(Lecturer lecturer)
        {
            string query = "DELETE FROM supervises WHERE lecturer_ID = @lecturer_ID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new(LecturerNumberColumn, SqlDbType.Int) { Value = lecturer.PersonID }
            };

            ExecuteEditQuery(query, parameters);
        }

        public List<Lecturer> ActivityInSupervisors(Activity activity, bool differentmethod)
        {
            string difference = differentmethod ? "IN" : "NOT IN";
            string query = $@"SELECT l.lecturer_ID, l.first_name, l.last_name, l.age, l.phone_number, l.roomID 
                    FROM lecturer l 
                    WHERE l.lecturer_ID {difference} 
                        (SELECT asv.lecturer_ID 
                        FROM supervises asv 
                        WHERE asv.activityID = @activityID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@activityID", SqlDbType.Int) { Value = activity.ActivityID }
            };

            return ReadTables(ExecuteSelectQuery(query, parameters));
        }

    }
}