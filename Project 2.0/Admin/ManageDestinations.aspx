<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ManageDestinations.aspx.cs" Inherits="Project_2._0.Admin.ManageDestinations" %>
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
            <div class="col-md-12 text-right">
                <button class="btn btn-primary add-destination-btn" data-toggle="modal" data-target="#addDestinationModal">Add New Destination</button>
            </div>
        </div>

<div class="row">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="col-md-3">
                <div class="card destination-card">
                    <img src='<%# Eval("ImageURL") %>' alt="Destination Image" />
                    <div class="destination-details">
                        <h4><%# Eval("Title") %></h4>
                        <p><%# Eval("Description") %></p>
                        <p>Price: $<%# Eval("Price") %></p>
                        <button class="btn btn-success">Book Destination</button>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>


    <!-- Add New Destination Modal -->
    <div class="modal fade" id="addDestinationModal" tabindex="-1" role="dialog" aria-labelledby="addDestinationModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="addDestinationModalLabel">Add New Destination</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                   
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                            <div class="form-group">
                                <label for="fileBookImage">Book Image:</label>
                                <asp:FileUpload ID="fileBookImage" runat="server" CssClass="form-control" />
                            </div>
                            <div class="form-group">
                                <label for="destinationTitle">Title:</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" placeholder="Enter destination title" Required="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="destinationDescription">Description:</label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control" TextMode="MultiLine" placeholder="Enter destination description" Required="true"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label for="destinationPrice">Price:</label>
                                <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" placeholder="Enter destination price" Required="true"></asp:TextBox>
                            </div>
                            <asp:Button ID="btnAddDestination" runat="server" Text="Add Destination" CssClass="btn btn-primary" OnClientClick="return validateForm();" OnClick="btnAddDestination_Click" />
                        </ContentTemplate>

                        <Triggers>
                            <asp:PostBackTrigger ControlID="btnAddDestination" />
                        </Triggers>

                    </asp:UpdatePanel>
                </div>
            </div>



     

        </div>
    </div>

    <!-- Bootstrap CSS -->
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css">

    <!-- jQuery -->
    <script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

    <!-- Bootstrap JavaScript (Make sure it's included after jQuery) -->
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js"></script>

    <script type="text/javascript">
        function validateForm() {
            var fileUpload = document.getElementById("<%=fileBookImage.ClientID %>");
             var txtTitle = document.getElementById("<%=txtTitle.ClientID %>").value;
            var txtDescription = document.getElementById("<%=txtDescription.ClientID %>").value;
             var txtPrice = document.getElementById("<%=txtPrice.ClientID %>").value;

             if (fileUpload.value === "" || txtTitle === "" || txtDescription === "" || txtPrice === "") {
                 alert("All fields are required.");
                 return false;
             }

             return true;
         }
    </script>
</asp:Content>