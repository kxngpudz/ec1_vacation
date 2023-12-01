<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookDestination.aspx.cs" Inherits="Project_2._0.User.BookDestination" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <style>
        .destination-card {
            margin: 15px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
            border: 1px solid #e1e1e1;
            border-radius: 8px;
            overflow: hidden;
            transition: transform 0.2s ease-in-out;
        }

        .destination-card:hover {
            transform: scale(1.05);
        }

        .destination-card img {
            max-width: 100%;
            height: auto;
        }

        .destination-details {
            padding: 15px;
        }

        .add-destination-btn {
            margin-bottom: 20px;
        }
    </style>

    <div class="container">
        <div class="row">
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <div class="col-md-3">
                        <div class="card destination-card">
                            <asp:Label runat="server" ID="Identifier" Visible="false"><%# Eval("Id") %></asp:Label>
                            <img src='<%# Eval("ImageURL") %>' alt="Destination Image" />
                            <div class="destination-details">
                                <h4><%# Eval("Title") %></h4>
                                <p><%# Eval("Description") %></p>
                                <p>Price: $<%# Eval("Price") %></p>
                                <asp:Button runat="server" CssClass="btn btn-success" Text="Book Destination" CommandName="BookDestination" CommandArgument='<%# Eval("Id") %>' />
                            </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
