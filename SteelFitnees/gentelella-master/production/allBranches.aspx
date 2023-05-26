<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allBranches.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.allBranches" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">       

    <title>Steel Fitness - Sucursales</title>

    <link href="frontend/css/styleIndex.css" rel="stylesheet" />
    <link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css">
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">   
    <!-- Inner -->
    <div class="row" style="margin-bottom:150px"></div>
    <div class="text-center"  >
        <h2  class="section-heading text-uppercase">Sucursales</h2>
        <h3 class="section-subheading text-muted">Visita nuestras sucursales</h3>
    </div>
    <div class="container" style="margin-bottom:10px">
        <div class="row" style="justify-content:center" id="team"></div>
        <div class="col-xl-2 col-lg-2 col-md-3">
            <a style="font-size:25px;position:fixed;bottom: 20px;left: 20px;" id="return" class="btn btn-primary">Regresar</a>
        </div>
    </div>
    <div class="modal fade" id="modalComments" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-body">
                   <h2>Comentarios de nuestros clientes</h2> 
                    <div id="containerComments"></div>
                </div>
            </div>
        </div>
    </div>
   
      <!-- Inner -->
    <!-- Carousel wrapper -->
    <script src="js/personalizados/allBranches/addUrlReturn.js"></script>
    <script src="js/personalizados/allBranches/msjOpeningBrancheCards.js"></script>
    <script src="js/personalizados/allBranches/requestCommentsByBranche.js"></script>
    <script src="js/personalizados/Index/requestBranches.js"></script>
    <script src="js/personalizados/Index/build/buildCardsBranches.js"></script>
    <script src="js/personalizados/utils/formant12HourTime.js"></script>
    <script src="js/personalizados/utils/returnOpeningStatus.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@10.15.5/dist/sweetalert2.all.min.js" integrity="sha256-92U7H+uBjYAJfmb+iNPi7DPoj795ZCTY4ZYmplsn/fQ=" crossorigin="anonymous"></script>
    <script type="text/javascript">
        window.onload = function () {            
            requestBranches();
            addUrlReturn();

            var myModal = new bootstrap.Modal(document.getElementById('modalComments'), {
                keyboard: false
            })
        }
    </script>
</asp:Content>

