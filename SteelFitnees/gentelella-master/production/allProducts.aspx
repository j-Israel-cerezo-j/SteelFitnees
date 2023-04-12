﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="allProducts.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.allProducts" MasterPageFile="~/gentelella-master/production/principal.Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <meta charset="utf-8"/>
    <meta http-equiv="x-ua-compatible" content="ie=edge"/>    
    <meta name="description" content=""/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <link rel="manifest" href="site.webmanifest"/>
	<!-- CSS here -->    
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
    <link rel="stylesheet" href="templates/fitnessclub-master/assets/css/style.css"/>
	<link href="frontend/css/styleIndex.css" rel="stylesheet" />
    <link href="bootstrap-5.0.2-dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/personalizados/slider.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row" style="margin-bottom:100px"></div>
    <section class="home-blog-area " style="z-index:1 !important">
        <div class="container">
            <div class="row justify-content-center">
                <div class="col-lg-6 col-md-6 col-sm-12 mt-3" >
                    <form id="formOnkeyup">	
                        <input type="hidden" id="catalogo" name="catalogo" value="productsByBrancheAndCharacteres" />
                        <div class="input-group " > 
	    		            <div class="form-outline" style="width: 100%;">
	    		            	<svg style=" position: absolute;width: 20px; height: 20px; left: 12px; top: 50%; transform: translateY(-50%);" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
	    		            		<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
	    		            	</svg>
	    		                <input class="form-control" list="datalistOptionsSerch" id="exampleDataList" placeholder="Busca un producto por su nombre,sucursal,precio y/o descripción" style="border-radius:10px; width: 100%;padding:10px; padding-left:45px;" onkeyup="onkeyupSearchh()" name="onkeyupCoincidencias">
	    		                <datalist id="datalistOptionsSerch"></datalist>
	    		            </div>
	    		        </div>
                    </form>
                </div>
            </div>
            <div class="row mt-4">
                <div class="col-lg-2">
                    <div class="wrapper">
                        <div class="price-input">
                            <div class="field">
                                <span>Min</span>
                                <input type="number" id="min" min="1" class="input-min" onkeyup="onMin()"  value="1">
                            </div>
                            <div class="separator">-</div>
                            <div class="field">
                                <span>Max</span>
                                <input type="number" id="max" min="1" class="input-max" onkeyup="onMax()" value="1000">
                            </div>
                        </div>
                        <div class="slider">
                            <div class="progress"></div>
                        </div>
                        <div class="range-input">
                            <input type="range" class="range-min" min="0" onmouseup="onMin()" max="10000" value="2500" step="100">
                            <input type="range" class="range-max" min="0" onmouseup="onMax()" max="10000" value="7500" step="100">
                        </div>
                    </div>
                </div>
                <div class="col-lg-10">
                    <div class="row" style="justify-content: center;margin-top:50px;" id="containerCardsProducts"></div>
                </div>
            </div>            
            <div class="col-xl-2 col-lg-2 col-md-3">
                <a style="font-size:25px" href="index.aspx" class="btn btn-primary">Regresar</a>
            </div>
        </div>
    </section>
    <script src="js/personalizados/slider/slider.js"></script>
    <script src="js/personalizados/allProducts/requestProductBySearchQueyString.js"></script>
    <script src="js/personalizados/allProducts/OnkeyupSearch.js"></script>
    <script src="js/personalizados/allProducts/requestAllProducts.js"></script>
    <script src="js/personalizados/allProducts/build/productsCards.js"></script>
    <script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script type="text/javascript">
        window.onload = function () {            
            var characters = " <%=getCharacters %> "
            console.log(characters)
            if (characters == " ") {
                requestAllProducts()
            } else {
                requestProductBySearchQueyString(characters);
            }                           
        }
    </script>

</asp:Content>