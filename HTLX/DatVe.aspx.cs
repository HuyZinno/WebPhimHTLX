using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

namespace HTLX
{
    public partial class DatVe : Page
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
        }

        private void DisplayMovieInformation(string idMovie)
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
                imgPhim.ImageUrl = dt.Rows[0]["HinhAnh"].ToString();

            }
        }

        protected void btnDatVe_Click(object sender, EventArgs e)
        {
            // Xử lý khi nút đặt vé được nhấn
            string idMovie = Request.QueryString["idMovie"];
            Response.Redirect("MuaVe.aspx?idMovie=" + idMovie);
        }
        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect("PhimDangChieu.aspx");
        }
    }
}
