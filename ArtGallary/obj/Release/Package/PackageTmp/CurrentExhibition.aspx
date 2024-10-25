<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="CurrentExhibition.aspx.cs" Inherits="ArtGallary.CurrentExhibition" %>
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

	<!--events-->

    <!--line-->

	<div class="container">
		<div class="row justify-content-center">
			<div class="col-12 bg-custom d-none d-lg-block py-3">
				<h4 class="text-dark text-center"><b>Current Exhibition</b></h4>
				<div class="border-top border-dark w-80"></div>
			</div>
		</div>
	</div>
	<div class="container">
		<div class="row my-5">

			<div class=" col-md-3 my-3"  runat="server" id="loadExhibits">
				<!-- <a href="NatureExhibitions.aspx"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Nature Exhibition</h5>
				<div class="py-1"></div>
				<a href="NatureExhibitions.aspx" class="btn btn-outline-primary btn-md">Read More</a> -->
			</div>
			
			<div class="col-md-3 my-3" runat="server" id="loadExhibits2">
			<!--	<a href="AbstractExhibitions.aspx"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Abstract Exhibition</h5>
				<div class="py-1"></div>
				<a href="#" class="btn btn-outline-primary btn-md mr-3">Register</a>
				<a href="AbstractExhibitions.aspx" class="btn btn-outline-primary btn-md">Read More</a> -->
			</div>
			
			<div class="col-md-3 my-3" runat="server" id="loadExhibits3">
			<!--	<a href="HistoricalExhibition.aspx"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Historic Exhibition</h5>
				<div class="py-1"></div>
				<a href="#" class="btn btn-outline-primary btn-md mr-3">Register</a>
				<a href="HistoricalExhibition.aspx" class="btn btn-outline-primary btn-md">Read More</a> -->
			</div>

			<div class="col-md-3 my-3" runat="server" id="loadExhibits4">
			<!--	<a href="AnimalExhibitions.aspx"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Animal Exhibition</h5>
				<div class="py-1"></div>
				<a href="#" class="btn btn-outline-primary btn-md mr-3">Register</a>
				<a href="AnimalExhibitions.aspx" class="btn btn-outline-primary btn-md">Read More</a> -->
			</div>
			 
			
		</div>
	</div>

    <!--end of events-->

</asp:Content>
