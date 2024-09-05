using System;
using SomerenModel;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SomerenDAL
{
    public class ActivityDao : BaseDao<Activity>
    {
        internal protected override Activity ConvertItem(DataRow reader)
        {
            int id = (int)reader["activityID"];
            string name = (string)reader["name"];
            DateTime startDayTime = (DateTime)reader["start_day_time"];
            DateTime endDayTime = (DateTime)reader["end_day_time"];

            return new Activity(id, name, startDayTime, endDayTime);
        }

        private protected override string GetAllQuery()
        {
            return "SELECT activityID, name, start_day_time, end_day_time FROM activity";
        }

        public List<Activity> GetActivitiesForParticipant(Student student)
        {
            string query = "SELECT A.* FROM activity A JOIN participatesIn AP ON A.activityID = AP.activityID JOIN student S ON S.student_number = AP.student_number WHERE S.student_number = @student_number;";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@student_number", SqlDbType.Int) {Value = student.PersonID}
            };

            return ReadTables(ExecuteSelectQuery(query, parameters));
        }


    }
}