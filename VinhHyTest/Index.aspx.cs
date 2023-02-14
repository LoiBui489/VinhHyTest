using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace VinhHyTest
{
    public partial class Index : System.Web.UI.Page
    {
        private static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                BindingGrid();
            }
        }

        public void BindingGrid()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Select * From dbo.[User]", conn);
            conn.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            GridView1.DataSource = rd;
            GridView1.DataBind();
            conn.Close();
        }

        [WebMethod]
        public static Boolean Update(string name)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("UPDATE dbo.[User] SET name = '"+ name + "' WHERE id = " + id + ";", conn);
            SqlTransaction transaction;
            transaction = conn.BeginTransaction();
            cmd.Transaction = transaction;
            if (cmd.ExecuteNonQuery() > 0)
            {
                transaction.Commit();
                conn.Close();
                return true;
            }
            else
            {
                transaction.Rollback();
                conn.Close();
                return false;
            }
        }

        [WebMethod]
        public static Boolean Add(string name)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO dbo.[User](name) VALUES ('" + name + "');", conn);
            SqlTransaction transaction;
            transaction = conn.BeginTransaction();
            cmd.Transaction = transaction;
            if (cmd.ExecuteNonQuery() > 0)
            {
                transaction.Commit();
                conn.Close();
                return true;
            }
            else
            {
                transaction.Rollback();
                conn.Close();
                return false;
            }
        }

        [WebMethod]
        public static Boolean Remove()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM dbo.[User] WHERE id = " + id + ";", conn);
            SqlTransaction transaction;
            transaction = conn.BeginTransaction();
            cmd.Transaction = transaction;
            if (cmd.ExecuteNonQuery() > 0)
            {
                transaction.Commit();
                conn.Close();
                return true;
            }
            else
            {
                transaction.Rollback();
                conn.Close();
                return false;
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TxtInput.Text = GridView1.SelectedRow.Cells[2].Text;
            id = Int32.Parse(GridView1.SelectedRow.Cells[1].Text);
        }
    }
}