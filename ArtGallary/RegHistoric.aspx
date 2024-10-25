<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="RegHistoric.aspx.cs" Inherits="ArtGallary.RegHistoric" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


        <!--banner section-->
  <section id="aboutbanner3">
    <div class="container">
        <div class="row">
            <div class="col-md-8">
                <p class="about-title">Welcome to Art Haven</p>
                <p class="title">Exclusive Art Membership & Rewards Program</p>
                <p class="story">EARN REWARDS BY PARTICIPATING IN ART-RELATED EVENTS AND EXHIBITIONS ORGANIZED BY ART HAVEN</p>
                
                
            </div>
           
        </div>
    </div>

 </section>
 <!--end of banner section-->




	<div class=" py-3" ></div>
       <!-- Success Message Section -->
    <div class="container text-center mt-4">
        <asp:Label ID="lblSuccessMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
    </div>

	<!--form-->

	<div class="container   text-center" style="background-color: lightgrey;  border-radius: 2%;">

		<div class="container">
    <div class="row justify-content-center">
        <div class="col-md-6">

        <form class="col-12">
            <!-- Name and Surname -->
            <div class="form-group text-center">
                <label for="fullName">Name </label>
                <input type="text" class="form-control " runat="server" id="name" placeholder="Enter your full name or group name">
            </div>
			<div class="form-group">
                <label for="phone"> Phone</label>
                <input type="text" class="form-control " runat="server" id="phone" placeholder="Enter phone number">
            </div>

            <!-- Company -->
            <div class="form-group">
                <label for="company">Email</label>
                <input type="text" class="form-control " runat="server" id="email" placeholder="Enter  email">
            </div>

            <!-- Contact Number -->
          <div class="form-group">
    <label for="number">Number of people attending</label>
    <input type="number" class="form-control" runat="server" id="number" 
           placeholder="Enter number of people attending" min="1" step="1" required />
</div>

                <!-- passowerd -->
            <div class="form-group">
                <label for="company">Password</label>
                <input type="text" class="form-control " runat="server" id="password" placeholder="Enter  password">
            </div>
          

            <!-- Create Account Button -->
           
            <div class="col text-center">
             <!--   <a href="addContent.html" type="submit" class="btn btn-primary">Add Artist </a> -->
                <asp:Button ID="Register" runat="server" Text="Register" type="submit" class="btn btn-primary" OnClick="Register_Click"/>
            </div>
			<div class=" py-2" ></div>
        </form>
    </div>
        </div>
            </div>
        </div>

  

	<!--end of form-->

</asp:Content>
