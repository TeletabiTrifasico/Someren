using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Collections.Generic;
using System.Diagnostics;

namespace SomerenDAL
{
    public abstract class BaseDao<T>
    {
        protected SqlDataAdapter adapter;
        protected SqlConnection dbConnection;

        public BaseDao()
        {
            dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SomerenDatabase"].ConnectionString);
            adapter = new SqlDataAdapter();
        }

        /*Get All*/

        public List<T> GetAll()
        {
            SqlParameter[] sqlParameters = Array.Empty<SqlParameter>();
            return ReadTables(ExecuteSelectQuery(GetAllQuery(), sqlParameters));
        }

        protected List<T> ReadTables(DataTable dataTable)
        {
            List<T> items = new();

            foreach (DataRow reader in dataTable.Rows)
            {
                T item = ConvertItem(reader);
                items.Add(item);
            }

            return items;
        }

        internal protected abstract T ConvertItem(DataRow reader);

        private protected abstract string GetAllQuery();

        /*Getting data*/
        protected void ExecuteEditQuery(string query, SqlParameter[] sqlParameters)
        {
            try
            {
                dbConnection.Open();
                Debug.WriteLine("Connection opened successfully."); 
                using SqlCommand command = new(query, dbConnection);
                command.Parameters.AddRange(sqlParameters);
                adapter.InsertCommand = command;
                command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw new Exception("SQL Error: " + ex.Message);
            }

            finally
            {
                dbConnection.Close();
            }
        }


        protected DataTable ExecuteSelectQuery(string query, params SqlParameter[] sqlParameters)
        {
            DataTable dataTable = new();

            try
            {
                dbConnection.Open();
                Debug.WriteLine("Connection opened successfully.");

                using (SqlCommand command = new(query, dbConnection))
                {
                  
                    command.Parameters.AddRange(sqlParameters);

                    using (SqlDataAdapter adapter = new(command))
                    {
                        Debug.WriteLine("SqlCommand and SqlDataAdapter created successfully.");

                        adapter.Fill(dataTable);
                        Debug.WriteLine("Data retrieved successfully.");
                    }
                }
            }
            catch (SqlException ex)
            {
                Debug.WriteLine("SqlException occurred: " + ex.Message);
                throw new Exception("Error executing select query: " + ex.Message);
            }
            finally
            {
                if (dbConnection.State == ConnectionState.Open)
                {
                    dbConnection.Close();
                    Debug.WriteLine("Connection closed.");
                }
            }

            return dataTable;
        }



        protected bool IdExists(int id, string tableName, string columnName)
        {
            dbConnection.Open();

            string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @id";
            SqlCommand command = new(query, dbConnection);
            command.Parameters.Add(new SqlParameter("@id", id));
            int count = Convert.ToInt32(command.ExecuteScalar());

            dbConnection.Close();
            return count > 0;
        }

        /*Validation*/

        protected bool RoomExists(int roomNumber)
        {
            dbConnection.Open();

            string query = $"SELECT COUNT(*) FROM room WHERE roomID = @roomID";
            SqlCommand command = new(query, dbConnection);
            command.Parameters.Add(new SqlParameter("@roomID", roomNumber));
            int count = Convert.ToInt32(command.ExecuteScalar());

            dbConnection.Close();
            return count > 0;
        }
        protected int PeopleInRoom(int roomNumber, string table)
        {
            dbConnection.Open();

            string query = $"SELECT COUNT(*) FROM {table} WHERE roomID = @roomID";
            SqlCommand command = new(query, dbConnection);
            command.Parameters.Add(new SqlParameter("@roomID", roomNumber));
            int countOfPeople = (int)command.ExecuteScalar();

            dbConnection.Close();
            return countOfPeople;
        }

        protected int PersonIdInRoom(int roomNumber, int personId, string tableName, string numberColumn, string columnName)
        {
            dbConnection.Open();

            string query = $"SELECT {columnName} FROM {tableName} WHERE roomID = @roomID AND {numberColumn} = @person_number";
            SqlCommand command = new(query, dbConnection);
            command.Parameters.Add(new SqlParameter("@roomID", roomNumber));
            command.Parameters.Add(new SqlParameter("@person_number", personId));
            int PersonID = Convert.ToInt32(command.ExecuteScalar());

            dbConnection.Close();
            return PersonID;
        }
    }
}