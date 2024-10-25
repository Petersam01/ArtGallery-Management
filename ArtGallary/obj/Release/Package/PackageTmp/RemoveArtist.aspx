<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="RemoveArtist.aspx.cs" Inherits="ArtGallary.RemoveArtist" %>
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

    <!--Course detais-->

    <div class="container">
        <div class="col-12 text-dark mt-4">
	
            <div class="row my-5" runat="server" id ="loadArtist">
              
              <!--  <div class="col-md-6 my-6">
                    <h2 class="text-dark"><b>Painter and drawer</b></h2>
                    
                    <h4 class="Container text-light text-center" style="background-color: rgb(6, 76, 143);  border-radius: 0%;">Artist Information</h4>
                    <ul class="text-center">
                        <li class="text-center">NAme:</li>
                        <li>Surname</li>
                        <li>Email</li>
                        <li>Qualification</li>
                      </ul>

                      <h4 class="Container text-light text-center" style="background-color: rgb(6, 76, 143);  border-radius: 0%;">Display Information</h4>
                    <ul class="text-center">
                        <li class="text-center">Art 1</li>
                        <li>Art 2</li>
                      </ul>

                      <div class=" py-3" ></div>

                      <div class="col text-center">
                        <a href="#" type="submit" class="btn btn-primary">RemoveArtist </a>
                        <a href="AddToExhibition.aspx" type="submit" class="btn btn-primary">Add To Exhibition </a>
                    </div>
                 </div>
        
        
                <div class="col-md-6 my-6">
                    <img src="img//1.jpeg" alt="" style="width: 20rem; height: 10rem; margin-left: 10%;">
                    <img src="img/2.jpeg" alt="" style="width: 20rem; height: 10rem; margin-left: 10%; margin-top: 10%;">
                </div>
                -->
                
                     
            
            </div>
             <div class="col text-center">
                        <!--<a href="#" type="submit" class="btn btn-primary">RemoveArtist </a> -->
                          <asp:Button ID="remove" runat="server" Text="Remove Artist" type="submit" class="btn btn-danger" OnClick="remove_Click" />
                    

                       <asp:Button ID="addArt" runat="server" Text="Add Art" type="submit" class="btn btn-primary" OnClick="addArt_Click" 
                      />
                    </div>

           
            
        </div>
    </div>

    <!--end of course details-->

</asp:Content>
