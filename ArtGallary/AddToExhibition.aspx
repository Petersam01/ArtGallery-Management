<%@ Page Title="" Language="C#" MasterPageFile="~/ArtGallery.Master" AutoEventWireup="true" CodeBehind="AddToExhibition.aspx.cs" Inherits="ArtGallary.AddToExhibition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .container {
            padding: 30px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .btn-custom {
            background-color: #007bff;
            color: white;
        }
        .btn-custom:hover {
            background-color: #0056b3;
        }
        .advice-tag {
            margin-top: 20px;
            padding: 10px;
            background-color: #e9ecef;
            border-radius: 5px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Use the form from the master page -->
    <div class="container">
        <h1 class="mb-4">Artist Information</h1>
        <div class="form-group" runat="server" id="loadArtist"></div>
    </div>

    <div class="container">
        <h1 class="mb-4">Add to Exhibition</h1>
        
        <!-- Everything here is within the same form -->
        <div class="form-group">
            <label for="artwork-genre">Enter Genre of Artwork</label>
            <asp:TextBox ID="selectGenre" runat="server" CssClass="form-control" placeholder="Enter genre"></asp:TextBox>
        </div>

        <div class="form-group">
            <label for="artwork-type">Enter Type of Artwork</label>
            <asp:TextBox ID="selectArtType" runat="server" CssClass="form-control" placeholder="Enter type"></asp:TextBox>
        </div>

        <asp:Button ID="check" runat="server" Text="Check Compatibility" CssClass="btn btn-custom" OnClick="check_Click" />
        
        <div class="form-group mt-3">
            <label for="compati">Compatibility</label>
            <asp:Label ID="CompatibilityStatusLabel" runat="server" CssClass="form-control"></asp:Label>
        </div>

        <div class="form-group mt-3">
            <label for="suggestion">Suggestion</label>
            <asp:Label ID="suggestion" runat="server" CssClass="form-control"></asp:Label>
        </div>

        <asp:Button ID="add" runat="server" Text="Add to Exhibition" CssClass="btn btn-custom mt-3" OnClick="add_Click" />

         <!-- Success Message Section -->
        <div class="container text-center mt-4">
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success" Visible="false"></asp:Label>
            <asp:HyperLink ID="hlViewExhibition" runat="server" CssClass="btn btn-primary" Visible="false" Text="View Exhibition"></asp:HyperLink>
        </div>
    </div>
</asp:Content>
