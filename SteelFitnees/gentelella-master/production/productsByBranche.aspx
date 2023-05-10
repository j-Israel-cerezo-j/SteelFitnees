<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="productsByBranche.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.productsByBranche" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 	
	<link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css">    
    <link href="frontend/css/styleIndex.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-bottom:100px"></div>
    <section class="home-blog-area " style="z-index:1 !important">
            <div class="container">                
                <!-- Section Tittle -->
                <div class="row justify-content-center">
                    <div class="section-tittle text-center">
                        <span style="font-size:40px">Productos de la sucursal</span>
                    </div>
                </div>
                <div class="row justify-content-center">
                    <div class="col-lg-6 col-md-6 col-sm-12">
                        <div class="section-tittle text-center mb-100">
                             <select class="form-select form-select-lg mb-3" id="branches" onchange="buildProductsByBranche()">
                            </select>
                        </div>
                    </div>
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
                <div class="row justify-content-center">
                     <div class="col-lg-6 col-md-6 col-sm-12">
                        <div class="section-tittle text-center mb-50">                             
                            <h3 id="nameBranche"></h3>
                        </div>
                    </div>
                </div>
                <div class="row" style="justify-content: center;" id="containerCardsProducts">
                    <h2 style="text-align:center">Selecciona una sucursal por favor</h2>
                </div>
                <div class="col-xl-2 col-lg-2 col-md-3">
                    <a style="font-size:25px;position:fixed;bottom: 20px;left: 20px;background-color:red" id="return" class="btn btn-primary ">Regresar</a>
                </div>
            </div>
        </section>
    <script src="js/personalizados/productByBranches/addUrlReturn.js"></script>
    <script src="js/personalizados/productByBranches/OnkeyupSearch.js"></script>
    <script src="js/personalizados/productByBranches/requestBranches.js"></script>    
    <script src="js/personalizados/productByBranches/requestProductByBranche.js"></script>
    <script src="js/personalizados/productByBranches/build/buildCardsProducts.js"></script>    
    <script src="js/personalizados/productByBranches/build/slc/buildBranchesSlc.js"></script>

    <script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script type="text/javascript">
        window.onload = function () {
            requestBranches()
            addUrlReturn();
        }
    </script>

</asp:Content>