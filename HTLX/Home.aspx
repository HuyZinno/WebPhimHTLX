<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HTLX.Home" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Trang Chủ - Bán Vé Phim</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('images/background.jpg'); /* Đường dẫn tới hình ảnh nền */
            background-size: cover;
            background-position: center;
            background-repeat: no-repeat;
        }

        header {
            background-color: #333;
            color: #fff;
            padding: 1em;
            text-align: center;
        }

        nav {
            background-color: #444;
            padding: 1em;
            text-align: center;
        }

        nav a {
            color: #fff;
            text-decoration: none;
            padding: 1em;
            margin: 0 1em;
        }

        nav form {
             display: block; /* Thay đổi từ inline-block thành block */
             position: absolute;
             bottom: 0;
             left: 0;
             margin-right: 1em;
        }


        nav input[type="text"] {
            padding: 0.5em;
            width: 150px;
            left: 0;
        }

        nav button {
            padding: 0.5em;
            background-color: #555;
            color: #fff;
            border: none;
            cursor: pointer;
        }

        section {
            padding: 2em;
            text-align: center;
        }

        section h2 {
            text-align: center;
        }

        section img {
            max-width: 120%;
            max-height: 450px;
            margin-top: 1em;
            transition: opacity 1s ease-in-out;
        }

        /* Thêm CSS cho nút điều hướng */
        #prevBtn,
        #nextBtn {
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            font-size: 24px;
            background-color: transparent;
            border: none;
            color: white;
            cursor: pointer;
            outline: none;
        }

        #prevBtn {
            left: 10px;
        }

        #nextBtn {
            right: 10px;
        }

        footer {
            background-color: #333;
            color: #fff;
            padding: 1em;
            text-align: center;
            position: fixed;
            bottom: 0;
            width: 100%;
            left: 0px;
            height: 2px;
        }
        #nextBtn {
            right: 10px;
        }
        .auto-style1 {
            left: -20px;
            bottom: 1px;
            height: 34px;
        }
        input#txtSearch {
          float: left;
          padding: 8px; /* Đệm bên trong ô nhập liệu */
    font-size: 16px; /* Kích thước chữ */
    border: 1px solid #ccc; /* Viền */
    border-radius: 4px; /* Đường cong viền */
    width: 200px; /* Chiều rộng của ô nhập liệu */
    box-sizing: border-box; 

        }

        input#btnSearch {
            padding: 10px 20px; /* Kích thước đệm cho nút */
    font-size: 16px; /* Kích thước chữ */
    background-color: #3498db; /* Màu nền */
    color: #fff; /* Màu chữ */
    border: none; /* Bỏ viền */
    border-radius: 5px; /* Đường cong viền */
    cursor: pointer; /* Con trỏ chuột khi di chuột qua */
    text-align: center; /* Căn giữa nội dung */
    text-decoration: none; /* Bỏ gạch chân */
    display: inline-block; /* Hiển thị như block nhưng không chiếm toàn bộ chiều ngang */
            float: left; /* Đẩy nút tìm kiếm về phía trái */
        }
        .button {
     
            margin-right: 10px; /* Khoảng cách giữa các nút */
            padding: 10px 20px; /* Kích thước đệm cho nút */
            font-size: 16px; /* Kích thước chữ */
            background-color: #3498db; /* Màu nền */
            color: #fff; /* Màu chữ */
            border: none; /* Bỏ viền */
            border-radius: 5px; /* Đường cong viền */
            cursor: pointer; /* Con trỏ chuột khi di chuột qua */
            text-align: center; /* Căn giữa nội dung */
            text-decoration: none; /* Bỏ gạch chân */
            display: inline-block; /* Hiển thị như block nhưng không chiếm toàn bộ chiều ngang */
            float: right;
        }

/* Hover effect */
.button:hover {
    background-color: purple; /* Màu nền khi di chuột qua */
}


        .auto-style2 {
            height: 55px;
        }
        nav a {
            text-decoration: none; /* Bỏ gạch chân cho liên kết */
            transition: transform 0.3s ease; /* Hiệu ứng chuyển đổi khi hover */
            display: inline-block; /* Cho phép chúng ta xử lý phần nội dung bên trong */
        }

        nav a span {
            display: inline-block; /* Để phần nội dung (chữ) thành phần inline-block */
            padding: 8px 12px; /* Tạo đệm xung quanh phần nội dung */
        }

        nav a:hover span {
            transform: scale(1.1); /* Hiệu ứng phóng to khi di chuột qua */
        }

        nav a:active span {
            transform: scale(0.9); /* Hiệu ứng thu nhỏ khi liên kết được chọn */
        }

        .image-container {
            position: relative;
            overflow: hidden;
        }

        .image-container img {
            max-width: 100%;
            transition: transform 0.5s ease-in-out;
        }

        #prevBtn,
        #nextBtn {
            position: absolute;
            top: 50%;
            transform: translateY(-50%);
            font-size: 80px;
            background-color: transparent;
            border: none;
            color: white;
            cursor: pointer;
            outline: none;
        }

        #prevBtn {
            left: 300px;
        }

        #nextBtn {
            right: 300px;
        }


        .auto-style3 {
            height: 31px;
        }


    </style>
</head>
<body>

    <header>
        <form id="form1" runat="server" class="auto-style2">
            <asp:TextBox ID="txtSearch" runat="server" Height="36px" placeholder="Nhập tên phim..."></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" Height="36px" OnClick="btnSearch_Click" />
            <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="button" OnClick="btnLogin_Click" Visible="false"/>
            <asp:Button ID="btnRegistration" runat="server" Text="Đăng ký" CssClass="button" OnClick="btnRegistration_Click" Visible="false" />            
            <asp:Button ID="btnLogout" runat="server" Text="Đăng Xuất" CssClass="button" OnClick="btnLogin_Click" Visible="false" />&nbsp;
                 
        </form>
    </header>

    <nav>
    <a href="Home.aspx"><span>Trang Chủ</span></a>
    <a href="PhimDangChieu.aspx"><span>Phim Đang Chiếu</span></a>
    <a href="#"><span>Lịch Chiếu</span></a>
    <a href="DanhGia.aspx"><span>Đánh Giá</span></a>
</nav>


     <section id="slideshow">
    <div class="image-container">
        <img id="slideImg" src="images/nbn.jpg" alt="Ảnh bìa phim">
        <button id="prevBtn" onclick="changeImage(-1)">❮</button>
        <button id="nextBtn" onclick="changeImage(1)">❯</button>
    </div>
</section>
    <br /><br /><br /><br />

    <footer class="auto-style1">
        <p class="auto-style3">© 2023 Bán Vé Phim. Nhóm HTLX - ITQNU K43</p>
    </footer>

    <!-- JavaScript Code -->

    <script>
        var images = ["images/nbn.jpg", "images/geats.jpg", "images/lm.jpg", "images/conan-movie-26.jpg", "images/bogia.jpg", "images/sieu-lua-gap-sieu-lay-1046301.jpg"];
        var currentImageIndex = 0;
        var slideImg = document.getElementById("slideImg");

        function changeImage(direction) {
            currentImageIndex = (currentImageIndex + direction + images.length) % images.length;
            slideImg.src = images[currentImageIndex];
        }

        function autoChangeImage() {
            changeImage(1);
            setTimeout(autoChangeImage, 2000);
        }

        autoChangeImage();

    </script>
    <div style="position: absolute; top: 28px; right: 200px; color: white; font-size:large">
    <% if (Session["UserName"] != null) { %>
        <a href="Profile.aspx">
        <span style="float: left; color: #FFFFFF;">Xin chào, <%= Session["UserName"].ToString() %></span>

    <% } %>

</div>


    


</body>
</html>
