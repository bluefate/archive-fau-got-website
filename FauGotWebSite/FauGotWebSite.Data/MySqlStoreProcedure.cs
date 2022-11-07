using FauGotWebSite.Tools;
using MySqlConnector;
using System;
using System.Data;


namespace FauGotWebSite.Data
{

    class MySqlStoreProcedure
    {
        MySqlConnection conn;
        MySqlCommand cmd;
        DataSet ds;

        public MySqlStoreProcedure(string StoreProcedureName)
        {
            try
            {
                conn = new MySqlConnection();
                conn.ConnectionString = Helper.GetSettingsValue("connString").ToString();

                cmd = new MySqlCommand();
                cmd.CommandText = StoreProcedureName;
                cmd.CommandType = CommandType.StoredProcedure;

            }
            catch (MySqlException ex)
            {
                Helper.W("Error Connecting to database", ex);
            }
            catch (Exception ex)
            {
                Helper.W("Exception", ex);
            }
        }
        ~MySqlStoreProcedure()
        {
            // Destructor
            Close();
            conn = null;
            cmd = null;
            ds = null;
        }

        public void ExecuteDataSet()
        {
            MySqlDataAdapter adp = new MySqlDataAdapter();
            try
            {
                ds = new DataSet();
                Open();
                adp.SelectCommand = cmd;
                adp.Fill(ds);
            }
            finally
            {
                adp.Dispose();
            }
        }
        public void ExecuteNonQuery()
        {
            Open();
            cmd.ExecuteNonQuery();
        }
        public object GetOutputValue(string parameterName)
        {
            try
            {
                return cmd.Parameters["?" + parameterName].Value;
            }
            catch
            {
                return null;
            }
        }
        public DataSet GetDataset()
        {
            try
            {
                if (ds != null)
                    return ds;
                else
                    return null;
            }
            catch
            {
                return null;
            }
        }

        public void AddInputParameter(string parameterName, object parameterValue, MySqlDbType paraemterDataType)
        {
            MySqlParameter param = new MySqlParameter("?" + parameterName, paraemterDataType);
            param.Value = parameterValue;
            param.Direction = ParameterDirection.Input;
            cmd.Parameters.Add(param);
        }
        public void AddOutputParameter(string parameterName, object parameterValue, MySqlDbType paraemterDataType)
        {
            MySqlParameter param = new MySqlParameter("?" + parameterName, paraemterDataType);
            param.Value = parameterValue;
            param.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(param);
        }

        public void Close()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
                conn.Close();
            conn.Dispose();
        }

        public void Open()
        {
            if (conn != null && conn.State != ConnectionState.Open)
                conn.Open();
            cmd.Connection = conn;
        }


    }
}


