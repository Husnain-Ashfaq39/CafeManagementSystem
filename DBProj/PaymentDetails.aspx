<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PaymentDetails.aspx.cs" Inherits="DBProj.PaymentDetails" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Payment Details</title>
   <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

               .navbar {
            background-color: #f28e63;
            overflow: hidden;
            display: flex;
            justify-content: space-between;
            align-items: center;
            padding: 10px 0;
        }

        .navbar .menu {
            margin-left: 20px;
        }

        .navbar .menu a {
            color: white;
            padding: 8px 16px;
            text-decoration: none;
            display: inline-block;
        }

        .navbar .menu a:hover {
            background-color: #d27657;
            color: black;
        }

        .navbar .sign-out {
            margin-right: 20px;
        }

        .total-earnings {
            margin-top: 20px;
            text-align: center;
            font-size: 20px;
            font-weight:bolder;
            margin-bottom:100px;
        }

        .navbar button {
            background-color: #007bff;
            color: white;
            border: none;
            padding: 8px 16px;
            border-radius: 4px;
            cursor: pointer;
        }

        .navbar button:hover {
            background-color: #0056b3;
        }
        .centered-content {
            text-align: center;
            margin: 20px;
        }

        /* GridView styling */
        .grid-view {
            margin: auto;
            width: auto;
            padding: 20px;
            border-collapse: collapse;
        }

        .grid-view th {
            background-color: #f28e63;
            color: white;
            padding: 10px;
        }

        .grid-view td {
            padding: 10px;
            border: 1px solid #ddd;
        }

        .grid-view tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .grid-view tr:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
           <div class="navbar">
        <div class="menu">
              <a href="ManagerHome.aspx">Manager Home</a>
            <a href="ManageMenu.aspx">Manage Menu</a>
            <a href="PaymentDetails.aspx">View Earnings</a>&nbsp;
        
        </div>
        <div class="sign-out">
        <a href="LoginPage.aspx" style="float:right; background-color: #ffc778; padding: 10px 15px; border-radius: 20px; color: white; text-decoration: none; box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); transition: box-shadow 0.3s;" onmouseover="this.style.boxShadow='0 8px 16px rgba(0, 0, 0, 0.2)';" onmouseout="this.style.boxShadow='0 4px 8px rgba(0, 0, 0, 0.1)';">Sign Out</a>
        </div>
    </div>
        <div class="centered-content">
            <h2>Payment Details</h2>
            
               <div class="grid-view">
            <asp:GridView ID="GridViewPayments" runat="server" AutoGenerateColumns="False" CssClass="grid-view">
    <Columns>
        <asp:BoundField DataField="OrderId" HeaderText="Order ID" />
        <asp:BoundField DataField="Username" HeaderText="Username" /> 
        <asp:BoundField DataField="OrderDate" HeaderText="Order Date" DataFormatString="{0:dd/MM/yyyy}" />
        <asp:BoundField DataField="TotalAmount" HeaderText="Total Amount" DataFormatString="{0:C}" />
    </Columns>
</asp:GridView>
        </div>
        <div class="total-earnings">
            <asp:Label ID="lblTotalEarnings" runat="server" Text="Total Earnings: $0.00"></asp:Label>
        </div>
           </div>
        
    </form>
</body>
</html>
