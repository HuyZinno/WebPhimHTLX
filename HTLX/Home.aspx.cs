using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace HTLX
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra nếu session có tồn tại
                if (Session["UserName"] != null)
                {
                    btnLogin.Visible = false; // Ẩn nút Đăng nhập khi đã đăng nhập
                    btnRegistration.Visible = false; // Ẩn nút Đăng ký khi đã đăng nhập
                    btnLogout.Visible = true; // Hiển thị nút Đăng xuất khi đã đăng nhập
                }
                else
                {
                    btnLogin.Visible = true; // Hiển thị nút Đăng nhập khi chưa đăng nhập
                    btnRegistration.Visible = true; // Hiển thị nút Đăng ký khi chưa đăng nhập
                    btnLogout.Visible = false; // // Ẩn nút Đăng xuất khi chưa đăng nhập
                }
            }
        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Session.Clear(); // Xóa tất cả các biến session
            Response.Redirect("Login.aspx"); // Chuyển hướng đến trang đăng nhập (ví dụ: Login.aspx)
        }

        protected void btnRegistration_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registration.aspx"); // Chuyển hướng đến trang đăng ký (ví dụ: Registration.aspx)
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string connectionString = ConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "SELECT MaPhim, TenPhim, DaoDien, DienVien, ThoiLuong, MoTa, HinhAnh " +
                                   "FROM Movie " +
                                   "WHERE TenPhim LIKE '%' + @searchText + '%'";

                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    con.Open();
                    da.Fill(dt);
                    con.Close();

                    if (dt.Rows.Count > 0)
                    {
                        // Nếu tìm thấy phim, chuyển hướng đến trang cụ thể và truyền ID của phim
                        string movieId = dt.Rows[0]["MaPhim"].ToString();
                        Response.Redirect($"ChiTietPhim.aspx?ID={movieId}");
                    }
                    else
                    {
                        // Nếu không tìm thấy phim, hiển thị thông báo không có phim
                        Response.Write("<script>alert('Không tìm thấy phim!!');</script>");
                    }
                }
            }
        }



    }
}
        