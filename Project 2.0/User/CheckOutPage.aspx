<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckOutPage.aspx.cs" Inherits="Project_2._0.User.CheckOutPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
       <div class="container">
        <h2>Checkout</h2>
        <hr />

        <asp:Label runat="server" ID="lblMessage" CssClass="text-success"></asp:Label>

        <div class="form-group">
            <label for="txtEmail">Email:</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email" Required="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtNumberOfPeople">Number of People:</label>
            <asp:TextBox ID="txtNumberOfPeople" runat="server" CssClass="form-control" placeholder="Enter the number of people" Required="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtNoOfDays">Number of Days:</label>
            <asp:TextBox ID="txtNoOfDays" runat="server" CssClass="form-control" placeholder="Enter the number of days" Required="true"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="txtPhoneNumber">Phone Number:</label>
            <asp:TextBox ID="txtPhoneNumber" runat="server" CssClass="form-control" placeholder="Enter your phone number" Required="true"></asp:TextBox>
        </div>


        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
    </div>
</asp:Content>
