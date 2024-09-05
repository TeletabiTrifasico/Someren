using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SomerenModel;

namespace SomerenDAL
{
    public class StudentDao : BaseDao<Student>
    {
        private const string StudentsRoomType = "dormitory";
        private const string StudentsTable = "student";
        private const string StudentNumberColumn = "student_number";
        private const int PeoplePerDormitory = 8;
        private const string ActivityIdColumn = "activityID";

        /*Student*/

        internal protected override Student ConvertItem(DataRow reader)
        {
            int studentNumber = (int)reader["student_number"];
            string firstName = (string)reader["first_name"];
            string lastName = (string)reader["last_name"];
            string className = (string)reader["class"];
            string telephoneNumber = (string)reader["phone_number"];
            int roomNumber = (int)reader["roomID"];

            return new Student(studentNumber, firstName, lastName, className, telephoneNumber, roomNumber);
        }

        private protected override string GetAllQuery()
        {
            return "SELECT student_number, first_name, last_name, class, phone_number, roomID FROM student";
        }

        public void DeleteStudent(Student student)
        {
            string query = "DELETE FROM student WHERE student_number = @student_number";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@student_number", SqlDbType.Int) {Value = student.PersonID}
            };

            ExecuteEditQuery(query, parameters);
        }

        public void AddStudent(Student student)
        {
            CheckStudentValues(student);

            string query = "INSERT student(student_number, first_name, last_name, class, phone_number, roomID) VALUES (@student_number, @first_name, @last_name, @class, @phone_number, @roomID)";

            ExecuteEditQuery(query, StudentParameters(student));
        }

        private void CheckStudentValues(Student student)
        {
            if (IdExists(student.PersonID, "student", "student_number"))
            {
                throw new Exception("This id already exists!");
            }

            CheckRoom(student);
        }

        private void CheckRoom(Student student)
        {
            if (!RoomExists(student.RoomNumber))
            {
                throw new Exception("This room does not exist!");
            }
            else if (PeopleInRoom(student.RoomNumber, StudentsTable) == PeoplePerDormitory && student.PersonID != PersonIdInRoom(student.RoomNumber, student.PersonID, StudentsTable, StudentNumberColumn, StudentNumberColumn))
            {
                throw new Exception($"The room {student.RoomNumber} has to many people!");
            }
        }

        public void UpdateStudent(Student student)
        {
            CheckRoom(student);

            string query = "UPDATE student SET first_name = @first_name, last_name = @last_name, class = @class, phone_number = @phone_number, roomID = @roomID WHERE student_number = @student_number";
            ExecuteEditQuery(query, StudentParameters(student));
        }

        private SqlParameter[] StudentParameters(Student student)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@student_number", SqlDbType.Int) {Value = student.PersonID},
                new("@first_name", SqlDbType.VarChar) {Value = student.FirstName},
                new("@last_name", SqlDbType.VarChar) {Value = student.LastName},
                new("@class", SqlDbType.VarChar) {Value = student.ClassName},
                new("@phone_number", SqlDbType.VarChar) {Value = student.PhoneNumber},
                new("@roomID", SqlDbType.Int) {Value = student.RoomNumber}
            };

            return parameters;
        }

        /*Participants*/

        public void AddParticipant(Student student, Activity activity)
        {
            string query = "INSERT participatesIn(student_number, activityID) VALUES(@student_number, @activityID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@student_number", SqlDbType.Int) {Value = student.PersonID},
                new("@activityID", SqlDbType.Int) {Value = activity.ActivityID}
            };

            ExecuteEditQuery(query, parameters);
        }

        public void DeleteParticipant(Student student, Activity activity)
        {
            string query = "DELETE FROM participatesIn WHERE student_number = @student_number AND activityID = @activityID";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new("@student_number", SqlDbType.Int) {Value = student.PersonID},
                new("@activityID", SqlDbType.Int) {Value = activity.ActivityID},

            };

            ExecuteEditQuery(query, parameters);
        }

        public List<Student> ActivityInParticipants(Activity activity, bool differentmethod)
        {
            string difference = differentmethod ? "IN" : "NOT IN";
            string query = $@"SELECT s.student_number, s.first_name, s.last_name, s.class, s.phone_number, s.roomID FROM student s WHERE s.student_number {difference} (SELECT asv.student_number FROM participatesIn asv WHERE asv.activityID = @activityID)";

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter(ActivityIdColumn, SqlDbType.Int) { Value = activity.ActivityID }
            };

            return ReadTables(ExecuteSelectQuery(query, parameters));
        }
    }
}