<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MuaVe.aspx.cs" Inherits="HTLX.MuaVe" MasterPageFile="~/Site.master" %>
<asp:Content ID="NavContent" ContentPlaceHolderID="NavContent" runat="server">
    <title>Đặt Vé - Bán Vé Phim</title>
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
            color: white;
            padding: 3em;
            text-align: center;
        }

        .seat {
            width: 70px;
            height: 50px;
            margin: 5px;
            background-color: white;
            border: 1px solid #aaa;
            cursor: pointer;
            color: black;
        }

        #seatingArea {
            background-color: black;
            padding: 20px;
            display: flex;
            flex-wrap: wrap;
            justify-content: center;
            max-width: 900px;
            margin: 0 auto;
        }

        #selectedSeats {
            margin-top: 1em;
        }

        #totalPrice {
            margin-top: 1em;
            font-weight: bold;
        }

        footer {
            background-color: #333;
            color: #fff;
            padding: 1em;
            text-align: center;
        }

        /* CSS cho nút button */
        .custom-button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 10px 20px;
            border-radius: 5px;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px; /* Khoảng cách từ nút button đến phần trên */
        }

        .custom-button:hover {
            background-color: #0056b3; /* Màu nền khi di chuột vào */
        }
    </style>
</asp:Content>

<asp:Content ID="MainContent" ContentPlaceHolderID="MainContent" runat="server">
    <header>
        <h2>Chọn ghế ngồi</h2>
    </header>

    <section>
        <asp:Image ID="ImageFilm" runat="server" Style="padding: 50px; width: 550px; height: 350px; " />
        <div id="seatingArea">
            <!-- Dùng JavaScript để tạo nút cho từng ghế ngồi -->
        </div>

        <div id="selectedSeats"></div>
        <div id="totalPrice"></div>
        <div style="margin-top: 20px; text-align: center;">
            <input type="button" value="Thanh toán" class="custom-button" onclick="redirectToComboPage();" />
        </div>
        <br /><br /><br /><br /><br />
        <asp:Image ID="Image1" runat="server" />
    </section>
    <script type="text/javascript">
        function BookFilm(idMovie) {
            // Lấy danh sách ghế đã chọn từ Session
            var selectedSeats = sessionStorage.getItem("selectedSeats");

            // Chuyển hướng đến trang MuaVe.aspx với query string
            window.location.href = "HoaDon.aspx?idMovie=" + idMovie + "&selectedSeats=" + selectedSeats;
        }
    </script>
    <script>
        var rows = 10; // Số hàng
        var seatsPerRow = 5; // Số ghế mỗi hàng
        var selectedSeats = [];

        function createSeatingArea() {
            var seatingArea = document.getElementById("seatingArea");

            for (var row = 0; row < rows; row++) {
                var rowElement = document.createElement("div");
                rowElement.className = "row";

                for (var seatNum = 1; seatNum <= seatsPerRow; seatNum++) {
                    var seat = document.createElement("div");
                    seat.className = "seat";
                    seat.textContent = String.fromCharCode(65 + row) + seatNum;
                    seat.onclick = function () {
                        toggleSeatSelection(this);
                    };

                    rowElement.appendChild(seat);
                }

                seatingArea.appendChild(rowElement);
            }
        }

        function toggleSeatSelection(seat) {
            var seatNumber = seat.textContent;

            if (selectedSeats.includes(seatNumber)) {
                // Nếu ghế đã chọn, hủy chọn
                selectedSeats = selectedSeats.filter(function (item) {
                    return item !== seatNumber;
                });
                seat.style.backgroundColor = "#ccc";
            } else {
                // Nếu ghế chưa chọn, chọn ghế
                selectedSeats.push(seatNumber);
                seat.style.backgroundColor = "#28a745"; // Màu xanh lá cây
            }

            // Hiển thị ngay các ghế đã chọn và giá tiền ngay lập tức
            calculateTotal();
        }

        function redirectToComboPage() {
            var selectedSeatsCount = selectedSeats.length;
            if (selectedSeatsCount > 0) {
                var idMovie = <%= Request.QueryString["idMovie"] %>;
                // Lưu idMovie và danh sách ghế đã chọn vào Session
                sessionStorage.setItem("idMovie", idMovie);
                sessionStorage.setItem("selectedSeats", selectedSeats.join(","));

                // Hiển thị thông báo thay vì chuyển hướng
                var message = "Mã phim: " + idMovie + "\nMã ghế: " + selectedSeats.join(", ");
                alert(message);
                window.location.href = "HoaDon.aspx?idMovie=" + idMovie + "&selectedSeats=" + selectedSeats;
            } else {
                alert("Vui lòng chọn ghế trước khi tiếp tục.");
            }
        }

    /*    function calculateTotal() {
            var seatPrice = 49000; // Giá tiền mỗi vé

            var selectedSeatsText = "Ghế đã chọn: " + selectedSeats.join(", ");
            var totalPrice = selectedSeats.length * seatPrice;
            var totalPriceText = "Tổng Tiền: " + totalPrice.toLocaleString("vi-VN", { style: "currency", currency: "VND" });

            document.getElementById("selectedSeats").innerHTML = selectedSeatsText;
            document.getElementById("totalPrice").innerHTML = totalPriceText;
        }

        // Hàm để lấy giá trị của tham số từ QueryString
        function getParameterByName(name, url) {
            if (!url) url = window.location.href;
            name = name.replace(/[\[\]]/g, "\\$&");
            var regex = new RegExp("[?&]" + name + "(=([^&#]*)|&|#|$)"),
                results = regex.exec(url);
            if (!results) return null;
            if (!results[2]) return "";
            return decodeURIComponent(results[2].replace(/\+/g, " "));
        }
*/
        // Gọi hàm tạo ghế ngồi khi trang được tải
        createSeatingArea();
    </script>
</asp:Content>
