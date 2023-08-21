<%@ Page Title="" Language="C#" MasterPageFile="~/gentelella-master/production/principal.Master" AutoEventWireup="true" CodeBehind="Galeria.aspx.cs" Inherits="SteelFitnessWEB.Galeria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Steel Fitness - Galeria</title>
    <link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css">    
    <link href="frontend/css/styleIndex.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-bottom:125px"></div>
    <!-- Gallery -->
    <div class="row" >
        <div class="col-lg-4 col-md-12 mb-4 mb-lg-0">
            <img
                src="sources/galeria/sf1.jpg"
                class="w-100 shadow-1-strong rounded mb-4"
                alt="Boat on Calm Water"
            />
            <img
                src="sources/galeria/sf2.jpg"
                class="w-100 shadow-1-strong rounded mb-4"
                alt="Wintry Mountain Landscape"
            />
        </div>
        <div class="col-lg-4 mb-4 mb-lg-0">
            <img
                src="sources/galeria/sf3.jpg"
                class="w-100 shadow-1-strong rounded mb-4"
                alt="Mountains in the Clouds"
            />
            <img
                src="sources/galeria/sf4.jpg"
                class="w-100 shadow-1-strong rounded mb-4"
                alt="Boat on Calm Water"
            />
        </div>
        <div class="col-lg-4 mb-4 mb-lg-0">
            <img
                src="sources/galeria/sf5.jpg"
                class="w-100 shadow-1-strong rounded mb-4"
                alt="Waves at Sea"
            />
            <img
                src="sources/galeria/sf6.jpg"
                class="w-100 shadow-1-strong rounded mb-4"
                alt="Yosemite National Park"
            />
        </div>
    </div>
    <div class="container" style="margin:15px">
        <div class="col-xl-2 col-lg-2 col-md-3">
            <a style="font-size:25px;background-color:red" id="return" class="btn btn-primary">Regresar</a>
        </div>
    </div> 
<!-- Gallery -->
    <script src="js/personalizados/Galery/addUrlReturn.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            addUrlReturn();
        }        
    </script>
</asp:Content>
