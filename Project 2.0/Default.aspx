<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Project_2._0._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


            <section class="hero-section text-center">
        <div class="container">
            <h1 class="display-4">BookingsRUs</h1>
            <p class="lead">Your One-Stop Booking Destination</p>
            <a href="#features" class="btn btn-primary btn-lg">Explore Now</a>
        </div>
    </section>

    <section class="feature-section text-center" id="features">
        <div class="container">
            <h2 class="mb-5">Why BookingsRUs?</h2>
            <div class="row">
                <div class="col-md-4">
                    <img src="images/Online-Booking-696x462.jpg" alt="Feature 1" class="img-fluid">
                    <h4 class="mt-3">Easy Booking Process</h4>
                    <p>Our simple and user-friendly booking process makes it easy for you to book flights, hotels,
                        cruises, and more.</p>
                </div>
                <div class="col-md-4">
                    <img src="images/1.png" alt="Feature 2" class="img-fluid">
                    <h4 class="mt-3">Wide Range of Options</h4>
                    <p>Choose from a wide range of flights, hotels, cruises, and activities to plan your perfect
                        trip.</p>
                </div>
                <div class="col-md-4">
                    <img src="images/OIP.jpeg" alt="Feature 3" class="img-fluid">
                    <h4 class="mt-3">Great Deals & Discounts</h4>
                    <p>Get access to exclusive deals and discounts on bookings, making your travel budget-friendly.
                    </p>
                </div>
            </div>
        </div>
    </section>
    <section class="booking-section text-center py-5">
        <div class="container">
            <h2 class="mb-4">Ready to Book Your Next Adventure?</h2>
            <div class="row">
                <div class="col-md-6">
                    <img src="images/france.jpg" alt="Book Flight" class="img-fluid mb-4">
                   
                </div>
                <div class="col-md-6">
                    <img src="images/cr.jpeg" alt="Book Cruise" class="img-fluid mb-4">
                    
                </div>
            </div>
        </div>
    </section>

    <section class="footer-section text-center text-white bg-dark py-5">
        <div class="container">
            <p class="lead">Start planning your next trip with BookingsRUs!</p>
            <a href="#" class="btn btn-primary btn-lg">Book Now</a>
        </div>
    </section>    

</asp:Content>
        