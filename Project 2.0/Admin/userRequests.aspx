<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userRequests.aspx.cs" Inherits="Project_2._0.Admin.userRequests" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="container mt-3">
        <h2>User Requests</h2>
        <asp:GridView ID="GridViewRequests" runat="server" AutoGenerateColumns="False" CssClass="table">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Request ID" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="NumberOfPeople" HeaderText="Number of People" />
                <asp:BoundField DataField="NoOfDays" HeaderText="Number of Days" />
                <asp:BoundField DataField="PhoneNumber" HeaderText="Phone Number" />
                <asp:BoundField DataField="Destination" HeaderText="Destination ID" />
                <asp:BoundField DataField="FlightId" HeaderText="Flight ID" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnApprove" runat="server" Text="Approve" CssClass="btn btn-success" OnClick="btnApprove_Click" CommandArgument='<%# Eval("Id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
