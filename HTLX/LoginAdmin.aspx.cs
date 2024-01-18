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
    public partial class LoginAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra xem trang đã được load lần đầu hay không (để tránh ghi đè thông tin khi postback)
            if (!IsPostBack)
            {
                // Xác định ID của control được gọi từ client side
                string controlID = Request.Params.Get("__EVENTTARGET");

                // Kiểm tra nếu ID control được gọi là Image1
                if (controlID == Image1.ClientID)
                {
                    // Nếu Image1 được click, thực hiện chuyển hướng đến trang Home.aspx
                    Response.Redirect("HomeAdmin.aspx");
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string tdn = txtTDN.Text;
            string mk = txtMK.Text;

            if (string.IsNullOrEmpty(tdn) || string.IsNullOrEmpty(mk))
            {
                // Hiển thị cảnh báo khi không nhập đủ thông tin
                Response.Write("<script>alert('Vui lòng nhập tài khoản và mật khẩu!!');</script>");
            }
            else
            {
                // Thay đổi chuỗi kết nối tới cơ sở dữ liệu của bạn
                string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Kiểm tra thông tin đăng nhập từ cơ sở dữ liệu
                    string query = "SELECT COUNT(*) FROM [Admin] WHERE TenDangNhap=@TenDangNhap AND MatKhau=@MatKhau";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", tdn);
                        cmd.Parameters.AddWithValue("@MatKhau", mk);

                        int count = (int)cmd.ExecuteScalar();
                        if (count > 0)
                        {
                            // Đăng nhập thành công
                            Session["UserName"] = tdn; // Lưu tên đăng nhập vào session
                            Response.Redirect("HomeAdmin.aspx"); // Chuyển hướng về trang Home
                        }
                        else
                        {
                            Response.Write("<script>alert('Tài khoản hoặc mật khẩu không đúng!!');</script>");
                        }
                    }
                }
            }
        }
    }
}