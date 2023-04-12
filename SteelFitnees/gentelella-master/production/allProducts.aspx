<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allProducts.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.allProducts" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>    
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="manifest" href="site.webmanifest"/>
    <link rel="shortcut icon" type="templates/fitnessclub-master/image/x-icon" href="templates/fitnessclub-master/assets/img/favicon.ico"/>
	<!-- CSS here -->
	<link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
	<link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="home-blog-area " style="z-index:1 !important">
            <div class="container">
                <div class="row justify-content-center">
                    <div class="col-lg-6 col-md-6 col-sm-12" >
                        <form id="formOnkeyup">	
                            <input type="hidden" id="catalogo" name="catalogo" value="productsByBrancheAndCharacteres" />
                            <div class="input-group" > 
					            <div class="form-outline" style="width: 100%;">
					            	<svg style=" position: absolute;width: 20px; height: 20px; left: 12px; top: 50%; transform: translateY(-50%);" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
	    			            		<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
	    			            	</svg>
					                <input class="form-control" list="datalistOptionsSerch" id="exampleDataList" placeholder="Busca algún producto en alguna sucursal..." style="border-radius:10px; width: 100%;padding-left: 40px;padding-right: 15px;" onkeyup="onkeyupSearchh()" name="onkeyupCoincidencias">
					                <datalist id="datalistOptionsSerch"></datalist>
					            </div>
					        </div>
                        </form>
                    </div>                    
                </div>
                <div class="row" style="justify-content: center;margin-top:50px;" id="containerCardsProducts">
                </div>
                <div class="col-xl-2 col-lg-2 col-md-3">
                    <a href="index.aspx" class="btn wantToWork-btn f-right">Regresar</a>
                </div>
            </div>
        </section>
    <script src="js/personalizados/allProducts/OnkeyupSearch.js"></script>
    <script src="js/personalizados/allProducts/requestAllProducts.js"></script>
    <script src="js/personalizados/allProducts/build/productsCards.js"></script>
    <script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            requestAllProducts()
        }
    </script>

</asp:Content>