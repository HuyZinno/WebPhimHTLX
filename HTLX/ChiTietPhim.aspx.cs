using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace HTLX
{
    public partial class ChiTietPhim : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra xem query string có chứa ID của phim hay không
                if (Request.QueryString["ID"] != null)
                {
                    string idMovie = Request.QueryString["ID"].ToString();
                    // Gọi hàm để lấy thông tin chi tiết của phim
                    LoadMovieDetails(idMovie);
                }
            }
        }
        private void LoadMovieDetails(string idMovie)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT TenPhim, DaoDien, DienVien, ThoiLuong, MoTa, HinhAnh " +
                               "FROM Movie " +
                               "WHERE MaPhim = @idMovie";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@idMovie", idMovie);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                con.Open();
                da.Fill(dt);
                con.Close();


                // Hiển thị thông tin chi tiết của phim lên giao diện
                lblTenPhim.Text = dt.Rows[0]["TenPhim"].ToString();
                lblDaoDien.Text = dt.Rows[0]["DaoDien"].ToString();
                lblDienVien.Text = dt.Rows[0]["DienVien"].ToString();
                lblThoiLuong.Text = dt.Rows[0]["ThoiLuong"].ToString() + " phút";
                lblMoTa.Text = dt.Rows[0]["MoTa"].ToString();
                // Tương tự, bạn có thể hiển thị các thông tin khác của phim
                imgPhim.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();

            }
        }

        protected void btnDatVe_Click(object sender, EventArgs e)
        {
            string idMovie;

            // Kiểm tra xem có tham số ID hay không
            if (Request.QueryString["ID"] != null)
            {
                // Nếu có, sử dụng giá trị từ ID
                idMovie = Request.QueryString["ID"];
            }
            else if (Request.QueryString["idMovie"] != null)
            {
                // Nếu không, sử dụng giá trị từ idMovie
                idMovie = Request.QueryString["idMovie"];
            }
            else
            {
                // Xử lý khi không có cả ID và idMovie
                Response.Write("<script>alert('Không tìm thấy phim!!');</script>");
                return;
            }

            Response.Redirect("MuaVe.aspx?idMovie=" + idMovie);
        }
        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }    
    }
}