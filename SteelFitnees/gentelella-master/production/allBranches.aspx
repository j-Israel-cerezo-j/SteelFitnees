<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allBranches.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.allBranches" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-EVSTQN3/azprG1Anm3QDgpJLIm9Nao0Yz1ztcQTwFspd3yD65VohhpuuCOmLASjC" crossorigin="anonymous">
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.0.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-MrcW6ZMFYlzcLA8Nl+NtUVF0sA7MsXsP1UyJoMp4YLEuNSfAP+JcXn/tWtIaxVXM" crossorigin="anonymous"></script>
    <script src="../vendors/jquery/dist/jquery.min.js"></script>
    <link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <!-- Carousel wrapper -->
    <div id="carouselMultiItemExample" class="carousel slide carousel-dark text-center" data-mdb-ride="carousel"> 
      <!-- Inner -->
        <div class="text-center mt-5"  >
            <h2  class="section-heading text-uppercase">Sucursales</h2>
            <h3 class="section-subheading text-muted">Visita nuestras sucursales</h3>
        </div>
        <div class="container">
            <div class="row mt-5" style="justify-content:center" id="team"></div>   
        </div>        
      <!-- Inner -->
    </div>
    <!-- Carousel wrapper -->
    <script src="js/personalizados/Index/requestBranches.js"></script>
    <script src="js/personalizados/Index/build/buildCardsBranches.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>

    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.all.min.js" integrity="sha256-92U7H+uBjYAJfmb+iNPi7DPoj795ZCTY4ZYmplsn/fQ=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        window.onload = function () {
            requestBranches();
        }
    </script>
</asp:Content>

