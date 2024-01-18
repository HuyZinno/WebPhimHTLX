using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace HTLX
{
    public partial class PhimDangChieu : System.Web.UI.Page
    {
        protected List<Movie> Movies { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Movies = GetMovieListFromDatabase();
            }
        }

        protected void btnDatVe_Click(object sender, EventArgs e)
        {
            Button btnDatVe = (Button)sender;
            string idMovie = btnDatVe.CommandArgument;

            // Chuyển hướng đến trang DatVe.aspx với query string
            Response.Redirect($"DatVe.aspx?idMovie={idMovie}");
        }

        public class Movie
        {
            public string IdMovie { get; set; }
            public string ImageUrl { get; set; }
            public string Title { get; set; }
            public string Actors { get; set; }
            public int Duration { get; set; }
            public string Description { get; set; }
        }

        public List<Movie> GetMovieListFromDatabase()
        {
            List<Movie> movies = new List<Movie>();

            string connectionString = WebConfigurationManager.ConnectionStrings["HTLX"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT MaPhim, HinhAnh, TenPhim, DienVien, ThoiLuong, MoTa FROM Movie";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Movie movie = new Movie
                            {
                                IdMovie = reader["MaPhim"].ToString(),
                                ImageUrl = reader["HinhAnh"].ToString(),
                                Title = reader["TenPhim"].ToString(),
                                Actors = reader["DienVien"].ToString(),
                                Description = reader["MoTa"].ToString(),
                                Duration = Convert.ToInt32(reader["ThoiLuong"])
                               
                            };

                            movies.Add(movie);
                        }
                    }
                }
            }

            return movies;
        }

    }
}
