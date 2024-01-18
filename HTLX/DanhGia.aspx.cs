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
    public partial class DanhGia : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserName"] == null)
            {
                Response.Write("<script>alert('Vui lòng đăng nhập');</script>");
                Response.Redirect("Login.aspx");
            }
        }

        protected void btnGuiDanhGia_Click(object sender, EventArgs e)
        {
            // Lấy dữ liệu từ các trường nhập liệu
            string hoTen = txtHoTen.Text;
            string email = txtEmail.Text;
            string soDienThoai = txtSoDienThoai.Text;
            string noiDung = txtNoiDung.Text;

            // Lấy giá trị của số sao từ trường đánh giá
            

            // Kiểm tra ràng buộc nhập liệu
            if (string.IsNullOrEmpty(hoTen) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(noiDung))
            {
                Response.Write("<script>alert('Vui lòng điền đầy đủ thông tin đánh giá!');</script>");
                return;
            }
            int rating;
            if (!int.TryParse(selectedRating.Value, out rating))
            {
                // Nếu không thể chuyển đổi, hiển thị thông báo và thoát khỏi hàm
                Response.Write("<script>alert('Vui lòng chọn số sao đánh giá!');</script>");
                return;
            }

            // Ánh xạ số lượng sao sang chuỗi mô tả tương ứng
            string ratingDescription = GetRatingDescription(rating);

            // Thực hiện kết nối đến CSDL và lưu dữ liệu
            string connectionString = ConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO DanhGia (HoTen, Email, SĐT, NoiDung, DanhGia) VALUES (@HoTen, @Email, @SĐT, @NoiDung, @DanhGia)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@SĐT", soDienThoai);
                command.Parameters.AddWithValue("@NoiDung", noiDung);
                command.Parameters.AddWithValue("@DanhGia", ratingDescription);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        successMessage.InnerText = "Đánh giá của bạn đã được gửi thành công!";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ReloadPage", "setTimeout(function(){ window.location.href = 'Home.aspx'; }, 1000);", true);
                    }
                    else
                    {
                        Response.Write("<script>alert('Đã xảy ra lỗi khi đánh giá!!');</script>");
                    }
                }
                catch (Exception ex)
                {
                    // Xử lý exception (hiển thị thông báo lỗi hoặc log lỗi)
                    Response.Write("<script>alert('Đã xảy ra lỗi khi đánh giá!!');</script>");
                }
            }

        }
        private string GetRatingDescription(int rating)
        {
            string description = "";
            switch (rating)
            {
                case 1:
                    description = "Rất tệ";
                    break;
                case 2:
                    description = "Tệ";
                    break;
                case 3:
                    description = "Trung bình";
                    break;
                case 4:
                    description = "Tốt";
                    break;
                case 5:
                    description = "Rất tốt";
                    break;
                default:
                    description = "Không xác định";
                    break;
            }
            return description;
        }
    }
}
            

