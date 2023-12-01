<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookCruiseAndRooms.aspx.cs" Inherits="Project_2._0.User.BookCruiseAndRooms" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
        <div>
            <h2>Available Cruises</h2>
            <asp:GridView ID="GridViewCruises" runat="server" AutoGenerateColumns="False"  DataKeyNames="Id"  CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Cruise ID" SortExpression="Id" />
                    <asp:BoundField DataField="Destination" HeaderText="Destination" SortExpression="Destination" />
                    <asp:BoundField DataField="SailingDuration" HeaderText="Sailing Duration (Days)" SortExpression="SailingDuration" />
                    <asp:BoundField DataField="Room" HeaderText="Available Rooms" SortExpression="Room" />
                    <asp:BoundField DataField="isBooked" HeaderText="Booked" SortExpression="isBooked" />
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:Button ID="btnBook" runat="server" Text="Book Room" CssClass="btn btn-danger" OnClick="btnBook_Click" CommandArgument='<%# Eval("Id") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <!-- Modal -->
    <div id="myModal" class="modal">
        <div class="modal-content">
            <span class="close" onclick="closeModal()">&times;</span>
            <h3>Enter Number of Rooms</h3>
            <asp:TextBox ID="txtNumberOfRooms" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnConfirmBooking" runat="server" Text="Confirm Booking" CssClass="btn btn-primary" OnClick="btnBook_Click" />
        </div>
    </div>

  

</asp:Content>
