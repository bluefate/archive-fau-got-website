
using System.Data;

namespace FauGotWebSite.Data
{
    public class Data
    {
        public DataSet Test()
        {
            MySqlStoreProcedure objSP = new MySqlStoreProcedure("p_testing");
            try
            {
                objSP.ExecuteDataSet();
                return objSP.GetDataset();
            }
            finally
            {
                objSP.Close();
            }
        }
    }
}
