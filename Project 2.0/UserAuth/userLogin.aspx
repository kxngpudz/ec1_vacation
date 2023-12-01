<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="userLogin.aspx.cs" Inherits="Project_2._0.UserAuth.userLogin" %>
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
                <h2 class="text-center mb-4">Sign In</h2>
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
                <asp:Button ID="btnSignIn" runat="server" CssClass="btn btn-primary form-control" Text="Sign In" OnClick="btnSignIn_Click" />

                <div class="text-center mt-3">
                    <a href="#" class="text-muted">Forgot Password?</a>
                </div>
                <hr />
                <div class="text-center">
                    <p class="text-muted">Don't have an account? <a href="#" class="text-primary">Sign Up</a></p>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
