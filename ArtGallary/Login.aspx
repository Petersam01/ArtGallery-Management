<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArtGallary.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <!--Banner-->

	<div id="banner" class="banner slide" data-ride="banner" data-interval="2000">

		<!-- Carousel Content -->
		<div class="r" >
			<div class="">
				<img src="img/carousel/7.jpg" alt="" class="w-100 h-10"></img>
				<div class="">
					<div class="container">
						<div class="row justify-content-center">
							<div class="col-12 bg-custom d-none d-lg-block py-3">
								<h4 class="text-dark text-center"><b>Login</b></h4>
								<div class="border-top border-dark w-80"></div>
							</div>
						</div>
					</div>
				</div>
			</div>
		</div>
	</div>

	<!--end of banner-->

	<div class=" py-3" ></div>

    <!--contact section-->

	

<!--new-->

<div class="container" style="background-color: lightgrey;">
	<div class=" py-3" ></div>
	<div class=" py-3" ></div>
    <div class="row">
       <!-- Left column: Art Gallery Information -->
<div class="col-md-6">
    <h4>About Our Art Gallery</h4>
    <p><strong>Welcome to the Art Haven Gallery!</strong></p>
    <p>We showcase a diverse range of contemporary and classic art from talented artists around the world. Our gallery offers a unique space where art lovers and collectors can explore and purchase extraordinary pieces.</p>
    <p><strong>Opening Hours:</strong></p>
    <ul>
        <li>Monday to Friday: 10:00 AM - 6:00 PM</li>
        <li>Saturday: 11:00 AM - 5:00 PM</li>
        <li>Sunday: Closed</li>
    </ul>
    <p><strong>Location:</strong></p>
    <p>123 Art Lane, Creative City, Artland</p>
    <p><strong>Contact:</strong></p>
    <p>Phone: +27 65 456 7890</p>
    <p>Email: info@arthavengallery.com</p>
</div>


        <!-- Right column: Message Form -->
        <div class="col-md-6">
            <h4  style="margin-top: 22%;">Login To Petersam Art Gallary</h4>
            <form >
                
                <div class="form-group">
                    <label for="email">Email</label>
                    <input type="email" class="form-control" id="email" runat="server" placeholder="Enter your email">
                </div>
				<div class="form-group">
                    <label for="about">Password</label>
                    <input type="text" class="form-control" id="password" runat="server" placeholder="Enter your Password">
                </div>
                
              <!--  <a href="AddContent.aspx" type="submit" class="btn btn-primary">Login To Art Gallary </a> -->
                <asp:Button ID="signin" runat="server"  href="AddContent.aspx" type="submit" class="btn btn-primary" Text="Login To Art Gallary" OnClick="signin_Click"  />
			<!--	<a href="CurrentExhibition.aspx" type="submit" class="btn btn-primary">View Art Gallary </a> -->
                <asp:Button   ID="view" runat="server" href="CurrentExhibition.aspx" type="submit" class="btn btn-primary" Text="View Art Gallary" OnClick="view_Click" />
            </form>
        </div>
		<div class=" py-3" ></div>
    </div>
	<div class=" py-3" ></div>
	<div class=" py-3" ></div>
</div>

<div class=" py-3" ></div>
    <!--end of contact section-->

</asp:Content>
