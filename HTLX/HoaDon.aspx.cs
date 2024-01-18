using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Configuration;
using static HTLX.PhimDangChieu;


namespace HTLX
{
    public partial class HoaDon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra session username
            if (Session["username"] == null)
            {
                Response.Write("<script>alert('Bạn chưa đăng nhập!');</script>");
                Response.Redirect("DangNhap.aspx");
            }
            if (Session["idMovie"] != null)
            {
                // Lấy giá trị idMovie từ Session
                string idMovie = Session["idMovie"].ToString();
            }
                        
            if (!IsPostBack)
            {
                // Kiểm tra xem có tham số idMovie trong URL không
                if (Request.QueryString["idMovie"] != null)
                {
                    string idMovie = Request.QueryString["idMovie"];
                    DisplayMovieInformation(idMovie);  
                    // Lấy thông tin về ghế đã chọn từ Session
                    string selectedSeats = Session["selectedSeats"] as string;

                    // Lấy tổng tiền từ Session
                    if (Session["totalPrice"] != null)
                    {
                        string totalPrice = Session["totalPrice"].ToString();

                        // Lưu thông tin vào bảng HoaDon
                        

                        // Hiển thị thông tin
                                              
                    }
                }
            }
            
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
                            imgMovie.ImageUrl = reader["HinhAnh"].ToString();
                            lblNameMovie.Text = reader["TenPhim"].ToString();
                        }
                        else
                        {
                            // Xử lý trường hợp không tìm thấy phim với ID đã chọn
                            Response.Write("<script>alert('Đã xảy ra lỗi!');</script>");
                            Response.Redirect("PhimDangChieu.aspx");
                        }
                    }
                }
            }
        }

        protected void btnHome_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
}
