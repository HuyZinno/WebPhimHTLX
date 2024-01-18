<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListFilm.aspx.cs" Inherits="HTLX.ListFilm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
        <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;s
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
           margin-top: 0.5cm;
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
        .fixed-gridview {
        
        position: absolute;
        /* Đặt giá trị top theo yêu cầu của bạn */
        left: 0px; /* Đặt giá trị left theo yêu cầu của bạn */
        margin: auto;
        width: 100%;
        text-align:center;
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
    <form id="form1" runat="server">
        <div>
        <asp:TextBox ID="txtSearch" runat="server" placeholder="Nhập tên phim..."></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" Height="36px" OnClick="btnSearch_Click" />

        <asp:GridView ID="GWFilm" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GWFilm_SelectedIndexChanged" DataKeyNames="MaPhim" OnRowDeleting="GWFilm_RowDeleting" OnRowCommand="GWFilm_RowCommand" CssClass="fixed-gridview" CellPadding="4" ForeColor="#333333" GridLines="None">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
    <Columns>
        <asp:BoundField DataField="MaPhim" HeaderText="Mã Phim" SortExpression="MaPhim" />
        <asp:BoundField DataField="TenPhim" HeaderText="Tên Phim" SortExpression="TenPhim" />
        <asp:BoundField DataField="DaoDien" HeaderText="Đạo Diễn" SortExpression="DaoDien" />
        <asp:BoundField DataField="DienVien" HeaderText="Diễn Viên" SortExpression="DienVien" />
        <asp:BoundField DataField="ThoiLuong" HeaderText="Thời Lượng" SortExpression="ThoiLuong" />
        <asp:BoundField DataField="MoTa" HeaderText="Tóm Tắt Nội Dung" SortExpression="MoTa" />
        <asp:TemplateField HeaderText="Hình Ảnh">
            <ItemTemplate>
                <asp:Image ID="imgHinhAnh" runat="server" ImageUrl='<%# Eval("HinhAnh", "~/{0}") %>' Height="180" Width="300" />
            </ItemTemplate>

        </asp:TemplateField>
                <asp:TemplateField HeaderText="Hành Động">
            <ItemTemplate>
                <asp:Button runat="server" CommandName="Delete" Text="Xóa" />
                <asp:Button runat="server" CommandName="Update" Text="Cập nhật" CommandArgument='<%# Eval("MaPhim") %>' />

            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
        </div>
    </form>
</body>

</html>
