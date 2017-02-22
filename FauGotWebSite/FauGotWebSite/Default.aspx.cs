using FauGotWebSite.Tools;
using System;
using System.Data;

namespace FauGotWebSite
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Test();
        }

        protected void Test()
        {
            if ( !IsPostBack)
            {
                try
                {
                    DataTable dt = FauGotWebSite.Business.Business.Test();
                    ucTest.DataSource = dt;
                    ucTest.DataBind();
                }
                catch (Exception ex)
                {
                    Helper.W("Error", ex);
                }
            }
        }
    }
}