<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="AddContent.aspx.cs" Inherits="ArtGallary.AddContent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="container my-5">
         
                    <div class="container" style="padding-left:30%;margin-top:5%;">
                        <h1 class="container justify-content-center align-items-center" >Artist Information</h1>
                    </div>
                <div class="row">
                    <!-- Add Artists and Artwork -->
                    <div class="col-md-6">
                        <div class="feature-box">
                            <div class="icon-container">
                                <i class="bi bi-plus-circle"></i>
                            </div>
                            <h5>Add Artists and Artwork</h5>
                            <p>Upload new artists and artworks to our gallery.</p>
                            <!-- Link or Form for Adding Artists/Artwork -->
                            <a href="AddArtist.aspx" class="btn btn-primary">Add Now</a>
                        </div>
                    </div>
                    <!-- Remove Artists and Artwork -->
                    <div class="col-md-6">
                        <div class="feature-box">
                            <div class="icon-container">
                                <i class="bi bi-trash"></i>
                            </div>
                            <h5>Remove Artists and Artwork</h5>
                            <p>Remove existing artists and artworks from our gallery.</p>
                            <!-- Link or Form for Removing Artists/Artwork -->
                            <a href="RemoveArtAndArtist.aspx" class="btn btn-danger">Remove Now</a>
                        </div>
                    </div>
                </div>

          <div class="container" style="padding-left:30%;margin-top:5%;">
            <h1>Statistics information</h1>
              </div>
                <div class="row mt-4">
                    <!-- View Stats -->
                    <div class="col-md-6">
                        <div class="feature-box">
                            <div class="icon-container">
                                <i class="bi bi-bar-chart"></i>
                            </div>
                            <h5>View Stats</h5>
                            <p>Get insights and statistics about our gallery performance.</p>
                            <!-- Link or Section for Viewing Stats -->
                            <a href="ViewStats.aspx" class="btn btn-success">View Stats</a>
                        </div>
                    </div>
                    <!-- Current Exhibition -->
                    <div class="col-md-6">
                        <div class="feature-box">
                            <div class="icon-container">
                                <i class="bi bi-calendar-event"></i>
                            </div>
                            <h5>Current Exhibition</h5>
                            <p>Find out about our ongoing exhibitions and events.</p>
                            <!-- Link or Section for Current Exhibition -->
                            <a href="CurrentExhibition.aspx" class="btn btn-success">See Exhibition</a>
                        </div>
                    </div>
                </div>

             <div class="container" style="padding-left:30%;margin-top:5%;">
                <h1>Exhibition section</h1>
                 </div>
                <div class="row mt-4">
                    <!-- View Stats -->
                    <div class="col-md-6">
                        <div class="feature-box">
                            <div class="icon-container">
                                <i class="bi bi-bar-chart"></i>
                            </div>
                            <h5>Add to Exhibition</h5>
                            <p>Get insights and statistics about our gallery performance.</p>
                            <!-- Link or Section for Viewing Stats -->
                            <a href="RemoveArtAndArtist.aspx" class="btn btn-primary">Add to Exhibition</a>
                        </div>
                    </div>

                     <!-- Remove Artists and Artwork -->
                    <div class="col-md-6">
                        <div class="feature-box">
                            <div class="icon-container">
                                <i class="bi bi-trash"></i>
                            </div>
                            <h5>Create Exhibition</h5>
                            <p>Create an exhibition for our gallery.</p>
                            <!-- Link or Form for Removing Artists/Artwork -->
                            <a href="CreateExhibition.aspx" class="btn btn-primary">Create Now</a>
                        </div>
                    </div>
                   
                </div>
            </div>
            
            <!-- Bootstrap JS (Optional) -->
            <script src="https://stackpath.bootstrapcdn.com/bootstrap/5.3.0/js/bootstrap.bundle.min.js"></script>
            
</asp:Content>
