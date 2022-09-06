using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyect_Restaurant.Sections.Options
{
    public partial class Drinks : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            //Create the connection and DataAdapter for the Authors table.
            SqlConnection cnn = new SqlConnection("server=DESKTOP-B3IRVE0;database=Restaurant; Integrated Security=True");
            SqlDataAdapter cmd1 = new SqlDataAdapter("select * from Bebidas", cnn);

            DataSet ds = new DataSet();
            cmd1.Fill(ds, "Bebidas");

            Repeater1.DataSource = ds;
            Page.DataBind();

            cnn.Close();*/
            
            try
            {
                if (String.IsNullOrEmpty((string)Session["Token"]))
                {
                    Response.Redirect("~/Default.aspx");
                }
                else
                {
                    token.Value = Session["Token"].ToString();
                }
            }
            catch (Exception ex)
            {
                Response.Redirect("~/Default.aspx");
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}