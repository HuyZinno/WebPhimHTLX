<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="HTLX.Registration" %>

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
            height: 580px;
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
            height: 58px;
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



        .auto-style1 {
            height: 608px;
        }
        .auto-style2 {
            height: 57px;
        }
        


    </style>
</head>
<body>
    <div class="login-container" style="background-image: url('images/z486047177692_291b6f2187119116fdc9156bf1f3f2c0.jpg'); background-repeat: no-repeat">
        <form id="form1" runat="server" style="font-family: 'SVN-Agency FB'; font-weight: bold; font-size: medium; " class="auto-style1">
        <h2 style="font-family: 'SVN-New Athletic M54'; font-weight: normal;">

            <label for="password">
            <asp:Image ID="Image1" runat="server" Height="85px" ImageUrl="~/images/z4860471776920_291b6f2187119116fdc9156bf1f3f2c0.jpg" Width="134px" />
            </label>
            Đăng ký tài khoản</h2>
            <label for="password" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter">

            <label for="sdt" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter">Họ và tên:<asp:TextBox ID="txtName" runat="server" CssClass="center-textbox"></asp:TextBox>
            </label>
            Số điện thoại:<asp:TextBox ID="txtPhone" runat="server" CssClass="center-textbox"></asp:TextBox>
            </label>
            <label for="email" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter">Mật Khẩu:<asp:TextBox ID="txtPassword" runat="server" CssClass="center-textbox" TextMode="Password"></asp:TextBox>
            </label>
            <label for="address" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter" class="auto-style2">Email:<asp:TextBox ID="txtEmail" runat="server" CssClass="center-textbox"></asp:TextBox>

            </label><label for="ho ten" style="font-family: 'SVN-New Athletic M54'; font-weight: lighter">Địa chỉ:<asp:TextBox ID="txtAddress" runat="server" CssClass="center-textbox"></asp:TextBox>
            </label>
            <div class="login-button">
                <asp:Button ID="bnRegistration" runat="server" Text="Đăng ký" OnClick="bnRegistration_Click" />
            </div>
           <br />
           Trở lại <a href="Login.aspx"> Đăng nhập</a>
        </form>
    </div>
</body>
</html>

