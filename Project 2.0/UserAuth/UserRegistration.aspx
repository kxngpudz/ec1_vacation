<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserRegistration.aspx.cs" Inherits="Project_2._0.UserAuth.UserRegistration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            overflow: hidden;
        }

        .container {
            padding: 20px;
        }

        .card {
            margin: 0 auto;
            background-color: #fff;
            border: 1px solid #ccc;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        .form-group {
            margin-bottom: 15px;
        }

        .text-muted {
            color: #6c757d;
        }
    </style>

    <div class="container">
        <div class="card shadow-lg p-3 mb-5 bg-white rounded" style="width: 400px;">
            <div class="card-body">
                <h2 class="text-center mb-4">User Registration</h2>
                <div class="form-group">
                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" placeholder="Enter your full name" Required="true"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvFullName" runat="server" ControlToValidate="txtFullName"
                        ErrorMessage="Full name is required." ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter your email" Required="true"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexEmail" runat="server" ControlToValidate="txtEmail"
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ErrorMessage="Enter a valid email address."
                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Enter your password" Required="true"></asp:TextBox>
                    <asp:RegularExpressionValidator ID="regexPassword" runat="server" ControlToValidate="txtPassword"
                        ValidationExpression="^.{6,}$" ErrorMessage="Password must be at least 6 characters long."
                        ForeColor="Red" Display="Dynamic"></asp:RegularExpressionValidator>
                </div>
                <div class="form-group">
                    <asp:TextBox ID="txtConfirmPassword" runat="server" CssClass="form-control" TextMode="Password" placeholder="Confirm your password" Required="true"></asp:TextBox>
                    <asp:CompareValidator ID="cmpPassword" runat="server" ControlToCompare="txtPassword"
                        ControlToValidate="txtConfirmPassword" ErrorMessage="Passwords do not match." ForeColor="Red" Display="Dynamic"></asp:CompareValidator>
                </div>
                <div class="form-group">
                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control" placeholder="Select your gender">
                        <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                        <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
                        <asp:ListItem Text="Other" Value="Other"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary form-control" Text="Register" OnClick="btnRegister_Click" />
            </div>
        </div>
    </div>

</asp:Content>

