<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="HistoricalExhibition.aspx.cs" Inherits="ArtGallary.HistoricalExhibition" %>
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
                    <a href="regNature.html" type="submit" class="btn btn-primary justify-content-center">Register for Exhibition</a>
                    
                </div>
               
            </div>
        </div>

     </section>
     <!--end of banner section-->


     	<!-- Main Page Heading -->
 
    

         <section id="aboutPin">
            <div class="container">
                <div class="row">
                    <div class="col-12 text-center mt-4">
                        <div class="row my-6">
                            <div class="col-md-7 my-7">
                                <h2 class="text-left about"><b>About Historic Exhibition</b></h2>
                                <p class="  text-dark text-left  firstp">
                                    Lorem ipsum dolor sit amet, consectetur adipisicing elit. Eos impedit placeat ea ipsa veritatis, voluptatem quibusdam 
                                    adipisci minus pariatur
                                     esse accusantium repudiandae mollitia exercitationem. Molestiae necessitatibus veritatis possimus eum animi!
                                     
                                </p>
                                <p class=" text-dark text-left firstp">
                                   Lorem ipsum dolor sit amet consectetur adipisicing elit. Veniam, obcaecati eos atque harum quidem qui eius, at reprehenderit id
                                    mollitia vero sunt, eaque repudiandae molestias soluta eligendi delectus odio maiores?
                                </p>
                                <p class="text-dark text-left">
                                  
                                </p>
                            </div>
                            <div class="col-md-5 my-5">
                                <img src="img/logo.jpeg" alt="" class="img-fluid" style="object-fit: cover; width: 100%; max-height: 100%;margin-top: -10%;">
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row content my-3" >
                    <div class="col-md-4 my-4">
                        <img src="img/1.jpeg" alt="" class="img-fluid" style="object-fit: cover; width: 100%; max-height: 80%; margin-top: -8%;">
                    
                    </div>
                    <div class="col-md-4 my-4">
                        <img src="img/2.jpeg" alt="" class="img-fluid" style="object-fit: cover; width: 100%; max-height: 80%; margin-top: -8%;">
                    </div>
                    <div class="col-md-4 my-4">
                        <img src="img/14.jpeg" alt="" class="img-fluid" style="object-fit: cover; width: 100%; max-height: 80%; margin-top: -8%;">
                    </div>
                </div>
            </div>
        </section>

      <h1 class="text-center" style="text-align: center;"><b>Historic exhibition line-up</b></h1>

    <div class="container">
		<div class="row my-5" runat="server" id="loadArtists">

		<!--	<div class=" col-md-3 my-3" >
				<a href="#"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Artist name</h5>
                <h5 class="my-2 text-dark">Art Type</h5>
                <h6 class="my-2 text-dark">Exhibition info</h6>
				
			</div>
			
			<div class=" col-md-3 my-3" >
				<a href="#"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Artist name</h5>
                <h5 class="my-2 text-dark">Art Type</h5>
                <h6 class="my-2 text-dark">Exhibition info</h6>
				
			</div>
			
			<div class=" col-md-3 my-3" >
				<a href="#"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Artist name</h5>
                <h5 class="my-2 text-dark">Art Type</h5>
                <h6 class="my-2 text-dark">Exhibition info</h6>
				
			</div>

			<div class=" col-md-3 my-3" >
				<a href="#"><img src="img/1.jpg" alt="" class="w-100 h-50"></a> 
				<h5 class="my-2 text-dark">Artist name</h5>
                <h5 class="my-2 text-dark">Art Type</h5>
                <h6 class="my-2 text-dark">Exhibition info</h6>
				
		</div> -->

            </div>
        </div>

        <div class="justify-content-center" style="margin-left: 45%;">
            <asp:Button ID="register" runat="server" Text="Register for Exhibition" type="submit" class="btn btn-primary justify-content-center" OnClick="register_Click"/>
            <asp:Button ID="delete" runat="server" Text="Delete Exhibition"  type="submit" class="btn btn-danger justify-content-center" OnClick="delete_Click"/>
        </div>
        
        <!--end of content-->

</asp:Content>
