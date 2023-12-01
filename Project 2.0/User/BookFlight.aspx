<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookFlight.aspx.cs" Inherits="Project_2._0.User.BookFlight" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-3">
        <div class="row">
            <div class="col-md-12">
                <h2>Available Flights</h2>
                <asp:GridView ID="GridViewFlights" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="Flight ID" />
                        <asp:BoundField DataField="DestinationName" HeaderText="Destination Name" />
                        <asp:BoundField DataField="Time" HeaderText="Time" />
                        <asp:BoundField DataField="LeavingFrom" HeaderText="Leaving From" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnBook" runat="server" Text="Book Flight" CssClass="btn btn-danger" OnClick="btnBook_Click" CommandArgument='<%# Eval("Id") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
