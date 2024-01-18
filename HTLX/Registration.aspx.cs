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
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bnRegistration_Click(object sender, EventArgs e)
        {
            string hoTen = txtName.Text;
            string soDienThoai = txtPhone.Text;
            string matKhau = txtPassword.Text;
            string email = txtEmail.Text;
            string diaChi = txtAddress.Text;

            // Kiểm tra điều kiện nhập đầy đủ thông tin
            if (string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(matKhau) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(diaChi))
            {
                Response.Write("<script>alert('Vui lòng nhập đầy đủ thông tin!!');</script>");
                return;
            }

            // Kiểm tra số điện thoại đã tồn tại
            if (IsPhoneNumberExists(soDienThoai))
            {
                Response.Write("<script>alert('Số điện thoại đã tồn tại, vui lòng thử số khác!!');</script>");
                return;
            }
            //kiểm tra email
            if (!IsValidEmail(email))
            {
                Response.Write("<script>alert('Vui lòng nhập đúng định dạng email!!');</script>");
                return;
            }

            // Thay đổi chuỗi kết nối tới cơ sở dữ liệu của bạn
            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thêm người dùng mới vào cơ sở dữ liệu
                string query = "INSERT INTO [User] (HoTen, Phone, Password, Email, DiaChi) VALUES (@Name, @SDT, @MK, @Email, @DiaChi)";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Name", hoTen);
                    cmd.Parameters.AddWithValue("@SDT", soDienThoai);
                    cmd.Parameters.AddWithValue("@MK", matKhau);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@DiaChi", diaChi);

                    int affectedRows = cmd.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        // Hiển thị thông báo đăng ký thành công
                        Response.Write("<script>alert('Đăng kí thành công!');</script>");

                        // Chuyển hướng đến trang đăng nhập
                        Response.Redirect("Login.aspx");
                    }
                    else
                    {
                        // Hiển thị thông báo đăng ký không thành công
                        Response.Write("<script>alert('Đăng kí không thành công, vui lòng thử lại');</script>");
                    }
                }
            }
        }

        private bool IsPhoneNumberExists(string phone)
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            // Sử dụng using để đảm bảo việc đóng kết nối tự động
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Thực hiện truy vấn kiểm tra số điện thoại
                string query = "SELECT COUNT(*) FROM [User] WHERE Phone = @SDT";
                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@SDT", phone);

                    // Lấy số lượng dòng có số điện thoại cụ thể
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Nếu số lượng dòng lớn hơn 0, có nghĩa là số điện thoại đã tồn tại
                    return count > 0;
                }
            }
        }
        private bool IsValidEmail(string email)
        {
            // Sử dụng biểu thức chính quy để kiểm tra định dạng email
            string pattern = @"^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(pattern);

            return regex.IsMatch(email);
        }


    }
}
    
