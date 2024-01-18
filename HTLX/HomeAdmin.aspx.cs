using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTLX
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        // Thêm một biến để lưu trữ đường dẫn tệp tin đã tải lên
        private string uploadedFilePath;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('Vui lòng đăng nhập');</script>");
                Response.Redirect("Login.aspx");
            }

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

        protected void bntSave_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện khi nhấn nút "Thêm Phim"
            if (IsPostBack)
            {
                // Kiểm tra xem có đủ thông tin cần thiết không
                if (string.IsNullOrEmpty(txtmaPhim.Text) || string.IsNullOrEmpty(txtTenPhim.Text) ||
                    string.IsNullOrEmpty(txtDaoDien.Text) || string.IsNullOrEmpty(txtDienVien.Text) ||
                    string.IsNullOrEmpty(txtThoiLuong.Text) || string.IsNullOrEmpty(txtMoTa.Text) || hinhAnh.PostedFile == null)
                {
                    // Hiển thị thông báo JavaScript nếu thông tin chưa đủ
                    Response.Write("<script>alert('Vui lòng nhập đủ thông tin.');</script>");
                    return;
                }

                // Chuỗi kết nối đến CSDL
                string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

                // Tạo đối tượng SqlConnection để kết nối đến CSDL
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Mở kết nối
                    connection.Open();

                    // Kiểm tra xem MaPhim đã tồn tại chưa
                    string checkMaPhim = "SELECT COUNT(*) FROM Movie WHERE MaPhim = @MaPhim";
                    using (SqlCommand checkCmd = new SqlCommand(checkMaPhim, connection))
                    {
                        checkCmd.Parameters.AddWithValue("@MaPhim", txtmaPhim.Text);
                        int duplicateCount = (int)checkCmd.ExecuteScalar();

                        if (duplicateCount > 0)
                        {
                            // Hiển thị thông báo JavaScript nếu MaPhim đã tồn tại
                            Response.Write("<script>alert('Mã phim đã tồn tại.');</script>");
                            return;
                        }
                    }

                    // Chuỗi truy vấn SQL để thêm dữ liệu vào bảng Movie
                    string insertQuery = "INSERT INTO Movie (MaPhim, TenPhim, DaoDien, DienVien, ThoiLuong, MoTa, HinhAnh) VALUES (@MaPhim, @TenPhim, @DaoDien, @DienVien, @ThoiLuong, @MoTa, @HinhAnh)";

                    // Tạo đối tượng SqlCommand để thực thi truy vấn
                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        // Đặt giá trị cho các tham số từ dữ liệu nhập từ form
                        cmd.Parameters.AddWithValue("@MaPhim", txtmaPhim.Text);
                        cmd.Parameters.AddWithValue("@TenPhim", txtTenPhim.Text);
                        cmd.Parameters.AddWithValue("@DaoDien", txtDaoDien.Text);
                        cmd.Parameters.AddWithValue("@DienVien", txtDienVien.Text);
                        cmd.Parameters.AddWithValue("@ThoiLuong", txtThoiLuong.Text);
                        cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                        cmd.Parameters.AddWithValue("@HinhAnh", "/images/" + hinhAnh.FileName);

                        // Thực thi truy vấn
                        cmd.ExecuteNonQuery();

                        // Hiển thị thông báo JavaScript
                        Response.Write("<script>alert('Thêm phim thành công!');</script>");

                        // Đặt lại giá trị của TextBox và FileUpload controls sau khi thêm thành công
                        txtmaPhim.Text = "";
                        txtTenPhim.Text = "";
                        txtDaoDien.Text = "";
                        txtDienVien.Text = "";
                        txtThoiLuong.Text = "";
                        txtMoTa.Text = "";
                        hinhAnh.Dispose();
                    }
                }
            }
        }

    }
}