using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Data
{
    public class Database
    {
        private SqlConnection sqlConnection = new SqlConnection();
        private SqlCommand sqlCommand = new SqlCommand();

        private void Connect()
        {
            sqlConnection.ConnectionString = @"Data Source=.;Initial Catalog=Roomy;Integrated Security=True";
            sqlConnection.Open();
        }

        private void Disconnect()
        {
            sqlConnection.Close();
            sqlConnection.Dispose();
        }

        public string Write(string storedProcedure, SqlParameter[] parameters)
        {
            Connect();
            try
            {
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandText = storedProcedure;
                sqlCommand.Connection = sqlConnection;
                sqlCommand.Parameters.AddRange(parameters);
                int af = sqlCommand.ExecuteNonQuery();
                Disconnect();
                if (af == 0)
                {
                    throw new Exception("No se ha realizado ninguna modificacion");
                }
                return "done";
            }
            catch (Exception error)
            {
                Disconnect();
                throw new Exception(error.Message);
            }
        }

        public DataTable Read(string storedProcedure, SqlParameter[] parameters)
        {
            Connect();
            try
            {
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                sqlDataAdapter.SelectCommand.CommandText = storedProcedure;
                sqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                sqlDataAdapter.SelectCommand.Connection = sqlConnection;

                if (parameters != null)
                {
                    sqlDataAdapter.SelectCommand.Parameters.AddRange(parameters);
                }

                sqlDataAdapter.SelectCommand.ExecuteNonQuery();
                sqlDataAdapter.Fill(dataTable);
                Disconnect();
                return dataTable;
            }
            catch (Exception error)
            {
                Disconnect();
                throw new Exception(error.Message);
            }
        }
    }

}
