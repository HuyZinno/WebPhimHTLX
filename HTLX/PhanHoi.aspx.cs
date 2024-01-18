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
    public partial class PhanHoi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('Vui lòng đăng nhập');</script>");
                Response.Redirect("Login.aspx");
            }
            BindGridView();

            if (!IsPostBack)
            {
                CheckSessionAndShowLogoutLink();
            }
        }
        private void CheckSessionAndShowLogoutLink()
        {
            if (Session["UserName"] != null)
            {
                // Người dùng đã đăng nhập, hiển thị liên kết "Đăng xuất"
                logoutLink.Visible = true;
            }
            else
            {
                // Người dùng chưa đăng nhập, ẩn liên kết "Đăng xuất"
                logoutLink.Visible = false;
            }
        }
        protected void Logout_Click(object sender, EventArgs e)
        {
            // Thực hiện xóa các Session cần thiết
            Session.Remove("UserName");
            // Ẩn nút "Đăng xuất" sau khi đăng xuất
            logoutLink.Visible = false;
            // Gọi Response.Redirect để chuyển hướng đến trang đăng nhập hoặc trang khác tùy vào yêu cầu của bạn
            Response.Redirect("Login.aspx");
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