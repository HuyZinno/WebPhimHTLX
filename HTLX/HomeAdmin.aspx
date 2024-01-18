<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="HTLX.HomeAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-image: url('images/background.jpg'); /* Đường dẫn tới hình ảnh nền */
            background-size: auto;
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

        section img {
            max-width: 120%;
            max-height: 450px;
            margin-top: 1em;
            transition: opacity 1s ease-in-out;
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
                

        
        .button {
     
            margin-right: 10px; /* Khoảng cách giữa các nút */
            padding: 15px 20px; /* Kích thước đệm cho nút */
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
           margin-top: 2.1cm;
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


        /* Thiết lập kiểu cho khung */
        .container {
            text-align:center;
            font-size: larger;
            width: 50%; /* Đặt chiều rộng của khung */
            margin: auto; /* Căn giữa khung */
            border: 1px solid #ccc; /* Đường viền của khung */
            padding: 20px; /* Khoảng cách bên trong khung */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Đổ bóng cho khung */
        }

        /* Thiết lập kiểu cho các hàng */
        .row {
            display: flex; /* Sử dụng Flexbox để căn chỉnh các cột */
            flex-direction: column; /* Xếp cột theo chiều dọc */
            margin-bottom: 15px;
                height: 85px;
            }

        /* Thiết lập kiểu cho các nhãn */
        label {
            font-size:larger;
            margin-bottom: 5px; /* Khoảng cách giữa các nhãn và input */
        }

        /* Thiết lập kiểu cho các input và textarea */
        input, textarea {
            text-align:center;
            width: 100%; /* Đặt chiều rộng của input và textarea là 100% */
            padding: 8px; /* Khoảng cách bên trong input và textarea */
            margin-bottom: 10px; /* Khoảng cách giữa các input và textarea */
        }
        .center-wrapper {
        text-align: center;
}
        .contact-button {
        float: right; /* Đưa div về phải */
        margin-right: 10px; /* Khoảng cách từ phải cùng của thanh menu */
        display: flex; /* Sử dụng Flexbox để căn chỉnh các phần tử bên trong div */
        align-items: center; /* Căn giữa theo chiều dọc */
    }

    .contact-button a {
        text-decoration: none;
        transition: transform 0.3s ease;
        display: inline-block;
        margin-right: 10px;
    }

    .contact-button a span {
        display: inline-block;
        padding: 8px 12px;
    }

    .contact-button a:hover span {
        transform: scale(1.1);
    }

    .contact-button a:active span {
        transform: scale(0.9);
    }
.button:hover {
        background-color: purple;
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


    </style>
</head>
<body>
    <header> 
    <nav>
        <label for="password">
        <asp:Image ID="Image1" runat="server" Height="113px" ImageUrl="~/images/z4860471776920_291b6f2187119116fdc9156bf1f3f2c0.jpg" Width="175px" />
        </label>
    <a href="HomeAdmin.aspx"><span>Trang Chủ</span></a>
    <a href="ListFilm"><span>Danh sách phim</span></a>
    <a href="PhanHoi.aspx"><span>Phản Hồi người dùng</span></a>
    <a href="#" id="logoutLink" runat="server" onserverclick="Logout_Click" visible="true"><span>Đăng xuất</span></a>
    </nav>
        </header>
    
    <div class="container" style="background-image: url('images/z486047177692_291b6f2187119116fdc9156bf1f3f2c0.jpg'); background-repeat: no-repeat">
    <form id="form1" runat="server" style="font-family: 'SVN-Agency FB'; font-weight: bold; font-size: medium; " class="auto-style1">
        <h2 style="font-family: 'SVN-New Athletic M54'; font-weight: normal;">

        Thêm Phim Mới</h2>
        <label for="maphim" >Mã Phim:<asp:TextBox ID="txtmaPhim" runat="server" CssClass="center-textbox"></asp:TextBox>
        </label>
        
        <label for="tenphim" >Tên Phim:<asp:TextBox ID="txtTenPhim" runat="server" CssClass="center-textbox"></asp:TextBox>
        </label>
        <label for="daodien"  class="auto-style2">Đạo Diễn:<asp:TextBox ID="txtDaoDien" runat="server" CssClass="center-textbox"></asp:TextBox>

        </label><label for="dienvien" >Diễn Viên:<asp:TextBox ID="txtDienVien" runat="server" CssClass="center-textbox"></asp:TextBox>
        </label>
        <label for="thoiluong" >Thời lượng:<asp:TextBox ID="txtThoiLuong" runat="server" CssClass="center-textbox"></asp:TextBox>
        </label>
        <label for="mota" >Tóm tắt nội dung phim:<asp:TextBox ID="txtMoTa" runat="server" CssClass="center-textbox" TextMode="MultiLine"></asp:TextBox>
        </label> 
        <div class="center-wrapper" ><label for="HinhAnh">Hình ảnh</label>
        <asp:FileUpload ID="hinhAnh" runat="server" />
        </div>

        <div class="login-button">
            <asp:Button ID="bntSave" runat="server" Text="Thêm Mới" BackColor="#3366FF" Font-Bold="True" Font-Size="Medium" OnClick="bntSave_Click" />
        </div>
       
       <br />
    </form>
</div>
     <div style="position: absolute; top: 130px; right: 200px; color: white; font-size:medium">
    <% if (Session["UserName"] != null) { %>
        <span style="float: left;">Xin chào, <%= Session["UserName"].ToString() %></span>
         
    <% } %>
</div>
      
</body>
</html>
