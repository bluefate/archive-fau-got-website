using System;
using System.Configuration;
using System.Diagnostics;
using System.Web;

namespace FauGotWebSite.Tools
{
    public class Helper
    {
        static public object GetSettingsValue(string configName)
        {
            try
            {
                return ConfigurationSettings.AppSettings[configName];
            }
            catch
            {
                return null;
            }
        }
        static public void W(string message)
        {
            Debug.Write(message);
            HttpContext.Current.Response.Write("<span style='colo:red;background-color:white;'><b>" + message + "</span><br><br>");
        }
        static public void W(string message, Exception ex)
        {
            Debug.Write(message);
            HttpContext.Current.Response.Write("<span style='colo:red;background-color:white;'><b>" + message + ":</b> " + ex.Message + "</span><br><br>");
        }
    }
}
