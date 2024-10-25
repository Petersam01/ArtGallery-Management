<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="AddArtist.aspx.cs" Inherits="ArtGallary.AddArtist" %>
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
    
                <div class="container text-center">
        <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
        <asp:HyperLink ID="hlViewArtist" runat="server" CssClass="btn btn-primary" Visible="false" Text="View Artist"></asp:HyperLink>
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
                <input type="text" class="form-control " runat="server" id="name" placeholder="Enter Artist Name">
            </div>
			<div class="form-group">
                <label for="fullName"> Surname</label>
                <input type="text" class="form-control " runat="server" id="surname" placeholder="Enter artist surname">
            </div>

            <!-- Company -->
            <div class="form-group">
                <label for="company">Email</label>
                <input type="text" class="form-control " runat="server" id="email" placeholder="Enter Artist email">
            </div>

            <!-- Contact Number -->
            <div class="form-group">
                <label for="contactNumber">Nationality</label>
                <input type="text" class="form-control" runat="server" id="country" placeholder="Enter  artist nationality "/>
                </div>

              
           

             <div class="form-group">
                <label class="text-dark text-left text-left" for="moderatorImg">Upload Artist Picture</label>
                <asp:FileUpload type="file" runat="server" class="form-control-file" id="picture" name="artistImg"/>
            </div>

           

            <!-- Create Account Button -->
           
            <div class="col text-center">
             <!--   <a href="addContent.html" type="submit" class="btn btn-primary">Add Artist </a> -->
                <asp:Button ID="Button1" runat="server" Text="Add Artist" type="submit" class="btn btn-primary" OnClick="Button1_Click"/>
            </div>
			<div class=" py-2" ></div>

        </form>

    </div>
        </div>
            </div>
        </div>

	<!--end of form-->

</asp:Content>
