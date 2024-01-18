<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietPhim.aspx.cs" Inherits="HTLX.ChiTietPhim" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chi Tiết Phim</title>
    <style>
        body {
    font-family: Arial, sans-serif;
    margin: 0;
    padding: 0;
    background-color: #f4f4f4;
    background-image: url('images/background.jpg');
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
}

#form1 {
    max-width: 800px;
    padding: 20px;
    background-color: #fff;
    box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
     align-items: center; 
}

h1 {
    text-align: center;
}

h2 {
    margin-top: 10px;
    margin-bottom: 5px;
}

p {
    margin-bottom: 8px;
}

strong {
    font-weight: bold;
}

#litNotFound {
    color: red;
    font-weight: bold;
}

.custom-button {
    background-color: #007bff;
    color: white;
    border: none;
    padding: 15px 30px;
    border-radius: 5px;
    font-size: 16px;
    cursor: pointer;
    margin-top: 1cm;
    align-self: center; 
}

.custom-button:hover {
    background-color: #0056b3;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <!-- Định dạng để hiển thị thông tin chi tiết phim -->
            <h1>Chi Tiết Phim</h1>
            <div>
                <asp:Image ID="imgPhim" runat="server" Height="200px" />
                <h2><asp:Label ID="lblTenPhim" runat="server" Text=""></asp:Label></h2>
                <p><strong>Đạo diễn:</strong> <asp:Label ID="lblDaoDien" runat="server" Text=""></asp:Label></p>
                <p><strong>Diễn viên:</strong> <asp:Label ID="lblDienVien" runat="server" Text=""></asp:Label></p>
                <p><strong>Thời lượng:</strong> <asp:Label ID="lblThoiLuong" runat="server" Text=""></asp:Label></p>
                <p><strong>Mô tả:</strong> <asp:Label ID="lblMoTa" runat="server" Text=""></asp:Label></p>
                <asp:Button ID="btnDatVe" runat="server" Text="Đặt vé" CssClass="custom-button" OnClick="btnDatVe_Click"  OnClientClick="return checkSession();"/>
                <asp:Button ID="btnQuayLai" runat="server" Text="Quay lại" CssClass="custom-button" OnClick="btnQuayLai_Click"/>
            </div>
        </div>
    </form>
    <script type="text/javascript">
    function checkSession() {
        var username = '<%= Session["username"] %>';
        if (username === undefined || username === null || username === '') {
            alert('Bạn cần đăng nhập để đặt vé.');
            window.location.href = "Login.aspx";
            return false; // Ngăn chặn sự kiện click
        }
        // Sự kiện click sẽ được thực hiện nếu session "username" tồn tại
        return true;
    }
    </script>
</body>
</html>
