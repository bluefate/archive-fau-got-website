

using System;
using System.Data;

namespace FauGotWebSite.Business
{
    public class Business
    {
        private static Data.Data dataObj = new Data.Data();

        public static DataTable Test()
        {
            try
            {
                return dataObj.Test().Tables[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
