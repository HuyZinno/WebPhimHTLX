using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HTLX
{
    public partial class MuaVe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra xem có tham số idMovie trong URL không
                if (Request.QueryString["idMovie"] != null)
                {
                    string idMovie = Request.QueryString["idMovie"];
                    DisplayMovieInformation(idMovie);
                }
            }

            if (Session["idMovie"] != null)
            {
                // Lấy giá trị idMovie từ Session
                string idMovie = Session["idMovie"].ToString();
            }
        }
        private void btnMuaVe_Click(object sender, EventArgs e)
        {
            string idMovie = Session["idMovie"].ToString();
            string selectedSeats = Session["selectedSeats"].ToString();
            string totalPrice = Session["totalPrice"].ToString();

            // Gọi hàm xử lý đặt vé
            InsertHoaDon(idMovie, selectedSeats, totalPrice);

            // Sau khi lưu vào CSDL, bạn có thể chuyển hướng đến trang HoaDon.aspx
            Response.Redirect("HoaDon.aspx");
        }

        private void InsertHoaDon(string idMovie, string selectedSeats, string totalPrice)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO HoaDonPhim (MaKhachHang, MaGhe, MaPhim, TongTien) VALUES (@MaKhachHang, @MaGhe, @MaPhim, @TongTien)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Lấy thông tin khách hàng từ Session (giả sử bạn có thông tin khách hàng trong Session)
                    string maKhachHang = Session["username"].ToString();

                    // Thực hiện lưu dữ liệu vào bảng HoaDon
                    command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                    command.Parameters.AddWithValue("@MaGhe", selectedSeats);
                    command.Parameters.AddWithValue("@MaPhim", idMovie);
                    command.Parameters.AddWithValue("@TongTien", Convert.ToInt32(totalPrice));

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }

            Response.Write("<script>alert('Đặt vé thành công!');</script>");
        }

        private void DisplayMovieInformation(string idMovie)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Movie WHERE MaPhim = @IdMovie";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@IdMovie", idMovie);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            ImageFilm.ImageUrl = reader["HinhAnh"].ToString();                            
                        }
                        else
                        {
                            // Xử lý trường hợp không tìm thấy phim với ID đã chọn
                            Response.Write("<script>alert('Không tìm thấy phim!!');</script>");
                            Response.Redirect("PhimDangChieu.aspx");
                        }
                    }
                }
            }
        }
    }
}