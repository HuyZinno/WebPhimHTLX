using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace HTLX
{
    public partial class LienHeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindGridView();
        }
        private void BindGridView()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT HoTen, Email, SĐT, NoiDung, DanhGia FROM DanhGia";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    GridView1.DataSource = reader;
                    GridView1.DataBind();
                    reader.Close();
                }
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                // Lấy giá trị từ cột trong dòng hiện tại
                string hoTen = DataBinder.Eval(e.Row.DataItem, "HoTen").ToString();
                string email = DataBinder.Eval(e.Row.DataItem, "Email").ToString();
                string sdt = DataBinder.Eval(e.Row.DataItem, "SĐT").ToString();
                string noiDung = DataBinder.Eval(e.Row.DataItem, "NoiDung").ToString();
                string danhGia = DataBinder.Eval(e.Row.DataItem, "DanhGia").ToString();

                // Gán giá trị cho các ô trong GridView
                e.Row.Cells[0].Text = hoTen;
                e.Row.Cells[1].Text = email;
                e.Row.Cells[2].Text = sdt;
                e.Row.Cells[3].Text = noiDung;
                e.Row.Cells[4].Text = danhGia;
            }
        }
    }
}