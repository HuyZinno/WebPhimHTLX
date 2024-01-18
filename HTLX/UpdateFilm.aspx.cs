using System;
using System.Data.SqlClient;
using System.IO;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace HTLX
{
    public partial class UpdateFilm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra xem có tham số MaPhim trong Session không
                if (Session["MaPhim"] != null)
                {
                    string maPhim = Session["MaPhim"].ToString();

                    // Thực hiện truy vấn CSDL để lấy thông tin phim dựa trên mã phim
                    string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT * FROM Movie WHERE MaPhim = @MaPhim";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@MaPhim", maPhim);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            // Cập nhật các controls với thông tin tương ứng
                            txtTenPhim.Text = reader["TenPhim"].ToString();
                            txtDaoDien.Text = reader["DaoDien"].ToString();
                            txtDienVien.Text = reader["DienVien"].ToString();
                            txtThoiLuong.Text = reader["ThoiLuong"].ToString();
                            txtMoTa.Text = reader["MoTa"].ToString();
                            // Cập nhật HinhAnh nếu cần thiết
                            // hinhAnhControl.Text = reader["HinhAnh"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
        }

        
        protected void bntSave_Click1(object sender, EventArgs e)
        {
            // Lấy giá trị MaPhim từ Session
            if (Session["MaPhim"] != null)
            {
                string maPhim = Session["MaPhim"].ToString();

                // Lấy thông tin từ các controls trên trang
                string tenPhim = txtTenPhim.Text;
                string daoDien = txtDaoDien.Text;
                string dienVien = txtDienVien.Text;
                string thoiLuong = txtThoiLuong.Text;
                string moTa = txtMoTa.Text;
                
                

                // Thực hiện câu lệnh SQL để cập nhật dữ liệu vào cơ sở dữ liệu
                string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "UPDATE Movie SET TenPhim = @TenPhim, DaoDien = @DaoDien, DienVien = @DienVien, ThoiLuong = @ThoiLuong, MoTa = @MoTa WHERE MaPhim = @MaPhim";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenPhim", tenPhim);
                    command.Parameters.AddWithValue("@DaoDien", daoDien);
                    command.Parameters.AddWithValue("@DienVien", dienVien);
                    command.Parameters.AddWithValue("@ThoiLuong", thoiLuong);
                    command.Parameters.AddWithValue("@MoTa", moTa);
                    
                    command.Parameters.AddWithValue("@MaPhim", maPhim);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                // Xóa giá trị MaPhim khỏi Session sau khi sử dụng
                Session.Remove("MaPhim");
                Response.Write("<script>alert('Cập nhật thành công!');</script>");
                // Chuyển hướng về trang ListFilm.aspx hoặc trang khác tùy thuộc vào yêu cầu của bạn
                Response.Redirect("ListFilm.aspx");
            }
        }


    }
}
