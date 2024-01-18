<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HoaDon.aspx.cs" Inherits="HTLX.HoaDon" %>

<!DOCTYPE html>
<html lang="en">

<head runat="server">
    <meta charset="utf-8" />
    <title>Hóa Đơn - Bán Vé Phim</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            margin: 0;
            padding: 0;
            background-color: #f4f4f4;
        }

        header {
            background-color: #333;
            color: #fff;
            padding: 1em;
            text-align: center;
        }

        section {
            color: black; /* Thay đổi màu chữ thành màu đen */
            padding: 3em;
            text-align: center;
        }

        .movie-info {
            margin-bottom: 20px;
            text-align: center;
        }

        #selectedSeats, #totalPrice {
            margin-top: 20px;
            text-align: center;
        }

        #totalPrice p {
            font-weight: bold;
        }

        #btnHome {
            margin-top: 20px;
            display: block;
            margin: 0 auto;
            background-color:cornflowerblue;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <header>
            <h2>Hóa Đơn</h2>
        </header>
        <div class="movie-info">
            <h2>Thông tin vé phim:</h2>
            <asp:Image ID="imgMovie" runat="server" Width="400px" Height="300px" />
            <h2>
                <asp:Label ID="lblNameMovie" runat="server"></asp:Label>
            </h2>
        </div>
        <div id="selectedSeats"></div>
        <div id="totalPrice"></div>

        <script type="text/javascript">
            window.onload = function () {
                displaySelectedSeats();
                calculateTotalPrice();
            };

            function displaySelectedSeats() {
                var selectedSeats = sessionStorage.getItem("selectedSeats");
                var selectedSeatsContainer = document.getElementById("selectedSeats");

                if (selectedSeats) {
                    // Hiển thị danh sách ghế đã chọn
                    selectedSeatsContainer.innerHTML = "<h2>Ghế đã chọn: " + selectedSeats + "</h2>";
                }
            }

            function calculateTotalPrice() {
                var seatPrice = 49000; // Giá tiền mỗi vé
                var selectedSeats = sessionStorage.getItem("selectedSeats");
                var totalPriceContainer = document.getElementById("totalPrice");

                if (selectedSeats) {
                    var totalSeats = selectedSeats.split(",").length;
                    var totalPrice = totalSeats * seatPrice;

                    // Hiển thị tổng giá tiền
                    totalPriceContainer.innerHTML = "<h2>Tổng tiền: " + totalPrice.toLocaleString("vi-VN", {
                        style: "currency",
                        currency: "VND"
                    }) + "</h2>";
                }
            }
        </script>

        <asp:Button ID="btnHome" runat="server" OnClick="btnHome_Click" Text="Quay lại trang chủ" Font-Bold="False" Font-Size="Large" ForeColor="White" Height="50px" />

    </form>
</body>

</html>
