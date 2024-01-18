using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using static HTLX.PhimDangChieu;

namespace HTLX
{
    public partial class ListFilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('Vui lòng đăng nhập');</script>");
                Response.Redirect("Login.aspx");
            }
            if (!IsPostBack)
            {
                LoadDataToGridView();
            }
            if (!IsPostBack)
            {
                CheckSessionAndShowLogoutLink();
            }
        }
        private void CheckSessionAndShowLogoutLink()
        {
            if (Request.QueryString["MaPhim"] != null)
            {
                // Nếu có, sử dụng giá trị từ ID
                string idMovie = Request.QueryString["ID"];
            }
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
        private void LoadDataToGridView()
        {
            // Chuỗi kết nối đến CSDL
            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            // Tạo đối tượng SqlConnection để kết nối đến CSDL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Chuỗi truy vấn SQL để lấy dữ liệu từ bảng Movie
                string selectQuery = "SELECT MaPhim, TenPhim, DaoDien, DienVien, ThoiLuong, MoTa, HinhAnh FROM Movie";

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ CSDL
                using (SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, connection))
                {
                    // Tạo đối tượng DataTable để chứa dữ liệu
                    DataTable dt = new DataTable();

                    // Đổ dữ liệu từ CSDL vào DataTable
                    adapter.Fill(dt);

                    // Gán DataTable làm nguồn dữ liệu cho GridView
                    GWFilm.DataSource = dt;
                    GWFilm.DataBind();
                }
            }
        }
        protected void GWFilm_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy MaPhim của hàng được chọn để truyền qua trang UpdateFilm
            string maPhim = GWFilm.SelectedRow.Cells[0].Text;

            // Chuyển hướng đến trang UpdateFilm và truyền mã phim qua QueryString
            Response.Redirect("UpdateFilm.aspx?MaPhim" + maPhim );            
        }

        protected void GWFilm_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update" && e.CommandArgument != null)
            {
                string maPhim = e.CommandArgument.ToString();

                // Lưu giá trị MaPhim vào Session
                Session["MaPhim"] = maPhim;

                // Chuyển hướng đến trang UpdateFilm.aspx
                Response.Redirect("UpdateFilm.aspx?MaPhim" + maPhim);
            }
        }

        protected void GWFilm_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            // Lấy MaPhim của hàng được chọn để xóa
            string maPhim = GWFilm.DataKeys[e.RowIndex].Values["MaPhim"].ToString();
            

            // Thực hiện câu lệnh SQL để xóa dữ liệu từ cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString))
            {
                connection.Open();
                string sqlDelete = "DELETE FROM Movie WHERE MaPhim = @MaPhim";
                using (SqlCommand cmd = new SqlCommand(sqlDelete, connection))
                {
                    cmd.Parameters.AddWithValue("@MaPhim", maPhim);
                    cmd.ExecuteNonQuery();
                }
            }

            // Cập nhật GridView
            Response.Write("<script>alert('Xóa phim thành công!');</script>");
            LoadDataToGridView(); // Gọi hàm để load lại dữ liệu vào GridView sau khi xóa
        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchKeyword = txtSearch.Text.Trim();

            // Chuỗi kết nối đến CSDL
            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            // Tạo đối tượng SqlConnection để kết nối đến CSDL
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Chuỗi truy vấn SQL để tìm phim theo MaPhim hoặc TenPhim
                string searchQuery = "SELECT MaPhim, TenPhim, DaoDien, DienVien, ThoiLuong, MoTa, HinhAnh FROM Movie WHERE MaPhim LIKE @SearchKeyword OR TenPhim LIKE @SearchKeyword";

                // Tạo đối tượng SqlDataAdapter để lấy dữ liệu từ CSDL
                using (SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, connection))
                {
                    // Tạo đối tượng DataTable để chứa dữ liệu
                    DataTable dt = new DataTable();

                    // Đặt giá trị tham số cho truy vấn
                    adapter.SelectCommand.Parameters.AddWithValue("@SearchKeyword", "%" + searchKeyword + "%");

                    // Đổ dữ liệu từ CSDL vào DataTable
                    adapter.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        // Gán DataTable làm nguồn dữ liệu cho GridView
                        GWFilm.DataSource = dt;
                        GWFilm.DataBind();
                    }
                    else
                    {
                        Response.Write("<script>alert('Không tìm thấy phim!');</script>");
                        
                    }    
                }
            }
        }

    }
}