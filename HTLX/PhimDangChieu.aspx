<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhimDangChieu.aspx.cs" Inherits="HTLX.PhimDangChieu" MasterPageFile="~/Site.master" %>

<asp:Content ID="NavContent" ContentPlaceHolderID="NavContent" runat="server">
    <title>Movie List</title>
    <link rel="stylesheet" href="content/site.css">
    <style>
        body {
            font-family: 'Arial', sans-serif;
            color: #333;
            margin: 0;
            padding: 0;
            background-image: url('images/background.jpg'); /* Đường dẫn tới hình ảnh nền */
            background-size: auto;
            background-position: center;
            background-repeat: no-repeat;
        }

        header {
            background-color: #007bff;
            color: #fff;
            text-align: center;
            padding: 20px 0;
        }

        h2 {
            margin-bottom: 20px;
        }

        ul {
            list-style-type: none;
            padding: 0;
        }

        li {
            margin-bottom: 20px;
        }

        .movie-item {
            border: 1px solid #ddd;
            border-radius: 5px;
            background-color: #fff;
            display: flex;
            overflow: hidden;
        }

        .movie-container {
            width: 80%;
            margin: 20px auto;
        }

        img {
            border-radius: 5px;
            max-width: 400px;
            max-height: 500px;
            width: auto;
            height: auto;
            margin-right: 20px;
        }

        .movie-info {
            flex-grow: 1;
            padding: 20px;
        }

        h3 {
            margin-top: 10px;
        }

        p {
            margin: 5px 0;
        }

        footer {
            background-color: #333;
            color: #fff;
            text-align: center;
            padding: 10px 0;
            position: fixed;
            bottom: 0;
            width: 100%;
        }

        .custom-button {
            /* CSS tùy chỉnh cho nút */
            background-color: #007bff;
            color: white;
            border: none;
            padding: 15px 30px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 1cm; /* Hạ thấp nút xuống 1cm */
        }

        .custom-button:hover {
            /* Hiệu ứng khi di chuột vào */
            background-color: #0056b3;
        }
    </style>

</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <h1 style="color: white; text-align: center;">Danh sách phim đang phát sóng</h1>

            <div class="movie-container">
                <ul>
                    <% if (Movies != null && Movies.Any())
                       {
                           foreach (var movie in Movies)
                           {
                    %>
                               <li>
                                   <div class="movie-item">
                                       <img src='<%= movie.ImageUrl %>' />
                                       <div class="movie-info">
                                           <h3>Mã phim: <%= movie.IdMovie %></h3>
                                           <h3><%= movie.Title %></h3>
                                           <p><strong>Diễn viên:</strong> <%= movie.Actors %></p>
                                           <p><strong>Thời lượng:</strong> <%= movie.Duration %> phút</p>
                                           <p><strong>Mô tả:</strong> <%= movie.Description %></p>
                                           <div style="text-align: right; margin-top: 20px;">
                                               <input type="button" value="Chi tiết" class="custom-button" onclick='<%= "BookFilm(" + movie.IdMovie + ")" %>' />
                                           </div>
                                       </div>
                                   </div>
                               </li>
                    <% 
                           }
                       }
                       else
                       {
                           Response.Write("Không có phim nào được tìm thấy.");
                       }
                    %>
                </ul>
            </div>
    </div>
    <script type="text/javascript">
        function BookFilm(idMovie) {
            // Chuyển hướng đến trang DatVe.aspx với query string
            window.location.href = "DatVe.aspx?idMovie=" + idMovie;
        }
    </script>
    <br /><br /><br /><br /><br />
</asp:Content>
