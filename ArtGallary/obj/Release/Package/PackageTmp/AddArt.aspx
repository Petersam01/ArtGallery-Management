<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="AddArt.aspx.cs" Inherits="ArtGallary.AddArt" %>
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
                <label for="fullName">Art Name </label>
                <input type="text" class="form-control " runat="server" id="artname" placeholder="Enter Artist Name">
            </div>
			<div class="form-group">
                <label for="fullName"> Genre</label>
                <input type="text" class="form-control " runat="server" id="genre" placeholder="Enter artist surname">
            </div>

            <!-- Company -->
            <div class="form-group">
                <label for="company">ArtType</label>
                <input type="text" class="form-control " runat="server" id="arttype" placeholder="Enter Artist email">
            </div>

              <div class="form-group">
                <label class="text-dark text-left text-left" for="moderatorImg">Upload Artwor</label>
                <asp:FileUpload type="file" runat="server" class="form-control-file" id="picture" name="artistImg"/>
            </div>


            <!-- Contact Number -->
            <div class="form-group">
                <label for="contactNumber">discription</label>
                <input type="text" class="form-control" runat="server" id="discription" placeholder="Enter  artist nationality "/>
                </div>

           

            <!-- Create Account Button -->
           
            <div class="col text-center">
             <!--   <a href="addContent.html" type="submit" class="btn btn-primary">Add Artist </a> -->
                <asp:Button ID="addArtwork" runat="server" Text="Add Artwork" type="submit" class="btn btn-primary" OnClick="addArtwork_Click" />
            </div>
			<div class=" py-2" ></div>

        </form>

    </div>
        </div>
            </div>
        </div>

	<!--end of form-->
</asp:Content>
