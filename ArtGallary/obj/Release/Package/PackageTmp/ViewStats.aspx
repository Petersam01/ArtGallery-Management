<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="ViewStats.aspx.cs" Inherits="ArtGallary.ViewStats" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
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

    
        <!-- Charts Start-->
      <!--  <div class="charts-area mg-b-15">
            <div class="container-fluid">
                <div class="row">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <div class="charts-single-pro responsive-mg-b-30">
                            <div class="alert-title">
                                <h2>Bar Chart</h2>
                                <p>A bar chart provides a way of showing data values. It is sometimes used to show trend data. we create a bar chart for a single dataset and render that in our page.</p>
                            </div>
                            <div id="bar1-chart">
                                <canvas id="barchart1"></canvas>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <div class="charts-single-pro">
                            <div class="alert-title">
                                <h2>Bar Chart vertical</h2>
                                <p>A bar chart provides a way of showing data values represented as vertical bars. It is sometimes used to show trend data, and the comparison of multiple data sets</p>
                            </div>
                            <div id="line2-chart">
                                <canvas id="barchart2"></canvas>
                            </div>
                        </div>
                    </div>
                </div>
         
            </div>
        </div> -->


    <div style="display: flex; justify-content: space-between;">
     <div class=" container chart-container" style="width: 50%; height: 300px;margin-top:6%;">
         <center><h3>Registrations</h3></center> 
         <!-- Your bar graph content here -->
         <canvas id="myBarChart" width="400" height="200"></canvas>
     </div>   

     <div class=" container chart-container" style="width: 50%; height: 300px;margin-top:6%;">
         <!-- Your pie chart content here -->
         <center><h3>number of people registered</h3></center>
         <canvas id="myPieChart" width="400" height="200"></canvas>
     </div>

    <div class="container justify-content-center" style="margin-top:6%;justify-content:center;align-items:center;" id="count" runat="server">
      
    </div>

 </div>

  
    

<script>
    var itemsData = <%= ItemsData %>;

    var ctx1 = document.getElementById("myBarChart").getContext("2d");
    var myBarChart = new Chart(ctx1, {
        type: 'bar',
        data: itemsData,
        options: {
            scales: {
                y: {
                    beginAtZero: true
                }
            }
        }
    });
</script>

<script>
    var pieData = <%= ItemsPieData %>;

    var ctx2 = document.getElementById("myPieChart").getContext("2d");
    var myPieChart = new Chart(ctx2, {
        type: 'pie',
        data: pieData,
        options: {
            plugins: {
                legend: {
                    display: true,
                    position: 'top'
                }
            }
        }
    });
</script>

    <div class=" py-3" ></div>
    <div class=" py-3" ></div>
    <div class=" py-3" ></div>

    <div class="container" id="exdata" runat="server">
          <!--   <h3>Popular Exhibitions by Registrations</h3>
<table class="table table-striped table-bordered">
    <thead>
        <tr>
            <th>Exhibition Name</th>
            <th>Number of Registrations</th>
            <th>Number of People registered</th>
            <th>Popularity</th>
        </tr>
    </thead>
    <tbody>
         
        <tr>
            <td>Example Exhibition 1</td>
            <td>123</td>
             <td>123</td>
             <td>Most porpular</td>
        </tr>
        <tr>
            <td>Example Exhibition 2</td>
            <td>456</td>
             <td>456</td>
             <td>least porpular</td>
        </tr>
        
    </tbody>
</table> -->

    </div>


     <div class=" py-3" ></div>

    <div class="container" id="exdata2" runat="server">
 <%--       
<h3>Number of Bookings Per Day for Each Exhibition</h3>
<table class="table table-striped table-bordered">
    <thead>
        <tr>
            <th>Exhibition Name</th>
            <th>Booking Date</th>
            <th>Number of Bookings</th>
        </tr>
    </thead>
    <tbody>
        <!-- Data rows will be added here -->
        <tr>
            <td>Example Exhibition 1</td>
            <td>2024-09-15</td>
            <td>10</td>
        </tr>
        <tr>
            <td>Example Exhibition 2</td>
            <td>2024-09-16</td>
            <td>20</td>
        </tr>
        <!-- Add more rows as needed -->
    </tbody>
</table>--%>
    </div>



        <!-- Charts End-->

</asp:Content>
