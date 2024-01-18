<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginAdmin.aspx.cs" Inherits="HTLX.LoginAdmin" %>

<!DOCTYPE html>

<html>
<head>
    <style>
        body {
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
            background-image: url('images/4927.jpg_wh860.jpg'); /* Đường dẫn tới hình ảnh nền */
            background-size: cover;
            background-repeat: no-repeat;
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }
        .login-container {
            background-color: #f0f0f0;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.2);
            width: 400px;
            height: 520px;
        }
        .login-container h2 {
            text-align: center;
        }
        .login-container form {
            text-align: center;
        }
        .login-container label, .login-container input {
            display: block;
            margin-bottom: 10px;
        }
        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 5px;
        }
        .login-container input[type="submit"] {
            border-style: none;
            border-color: inherit;
            border-width: medium;
            background-color: #007bff;
            color: #fff;
            padding: 10px 20px;
            cursor: pointer;
            height: 65px;
            text-align: left;
        }
        login-container .login-button button {
            text-align: center;
            background-color: #007bff;
            color: #fff;
            border: none;
            padding: 10px 20px;
            cursor: pointer;
        }
        .login-button {
    text-align: center;
}

.login-button button,
.login-button input[type="button"],
.login-button input[type="submit"],
.login-button input[type="reset"],
.login-button a {
    display: block;
    margin: 0 auto;
}
.center-textbox {
    text-align: center;
    margin: 0 auto;
}
.center-textbox {
    text-align: center;
    margin: 0 auto;
}
.login-button {
    text-align: center;
}

.login-button button,
.login-button input[type="button"],
.login-button input[type="submit"],
.login-button input[type="reset"],
.login-button a {
        font-family:'SVN-New Athletic M54';
    display: block;
    margin: 0 auto;
}



    </style>
</head>
<body>
    <div class="login-container" style="background-image: url('images/z486047177692_291b6f2187119116fdc9156bf1f3f2c0.jpg'); background-repeat: no-repeat">
        <form id="form1" runat="server" style="font-family: 'SVN-Agency FB'; font-weight: bold; font-size: medium; height: 555px;">
        <h2 style="font-family: 'SVN-New Athletic M54'; font-weight: normal;">

            <label for="password">
            <asp:Image ID="Image1" runat="server" Height="85px" ImageUrl="~/images/z4860471776920_291b6f2187119116fdc9156bf1f3f2c0.jpg" Width="134px" />
            </label>
            QUẢN TRỊ VIÊN ĐĂNG NHẬP</h2>
            <label for="TenDangNhap" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter">Tên đăng nhập:<asp:TextBox ID="txtTDN" runat="server" CssClass="center-textbox"></asp:TextBox>
            </label>
            &nbsp; 
            <label for="MatKhau" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter">Mật khẩu:<asp:TextBox ID="txtMK" runat="server" CssClass="center-textbox" TextMode="Password"></asp:TextBox>
            </label>
            &nbsp;         


            <div class="login-button">
                <asp:Button ID="btnLogin" runat="server" Text="Đăng nhập" CssClass="login-button" OnClick="btnLogin_Click"  />
            </div>
           <br />
                <br />
                <a href="Login.aspx">Quay lại</a> 
            
        </form>
    </div>
   
</body>
</html>

