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
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] != null)
                {
                    string userName = Session["UserName"].ToString();

                    // Truy vấn CSDL để lấy thông tin người dùng dựa trên tên người dùng
                    string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "SELECT HoTen, Phone, Email, DiaChi FROM [User] WHERE Phone = @Phone";

                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@Phone", userName);

                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            txtName.Text = reader["HoTen"].ToString();
                            txtPhone.Text = reader["Phone"].ToString();
                            txtEmail.Text = reader["Email"].ToString();
                            txtAddress.Text = reader["DiaChi"].ToString();
                        }
                        reader.Close();
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            string newName = txtName.Text;
            string newPhone = txtPhone.Text;
            string newEmail = txtEmail.Text;
            string newAddress = txtAddress.Text;
           

            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE [User] SET HoTen = @HoTen, Phone = @Phone, Email = @Email, DiaChi = @DiaChi WHERE Phone = @Phone";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTen", txtName.Text);
                command.Parameters.AddWithValue("@Phone", txtPhone.Text);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@DiaChi", txtAddress.Text);
                

                connection.Open();
                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    Response.Write("<script>alert('Thông tin đã được cập nhật.')</script>");
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Đã xảy ra lỗi khi cập nhật thông tin.')</script>");
                }
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
    }
 }
