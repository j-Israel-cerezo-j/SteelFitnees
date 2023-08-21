<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="manageGalery.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.manageGalery" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>


<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar galeria</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
    <link href="css/personalizados/x.css" rel="stylesheet" />
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="x_panel">
		<div class="x_content">
			<h2 id="labelMsjAction">Agregar fotos a la galeria</h2>
			<br>
			<form id="form1" class="row g-3 needs-validation" enctype="multipart/form-data" novalidate>
				<div class="row">
					<div class="col-lg-6 col-md-6 col-sm-12 form-group" style="margin-top:15px">
						<label style="margin-left:10px;margin-bottom:10px" class="control-label row">Cargar imagenes por favor...</label>
                        <div class="col-md-10 col-sm-10 col-xs-10" id="containerFilePhotograph">
							<input multiple style="border-radius:6px" accept="image/jpeg,image/png,image/jfif"  class="form-control"  type="file" id="formFile" onchange="MostraIma(this)">
                        </div>
					</div>	
				</div>
				<div class="card">
					<div id="containerImages" class="mt-5 row justify-content-center"></div>
				</div>
				<div class="row  justify-content-center" style="margin-top:30px" >
					<div class="col-md-6 col-sm-6">
						<div class="form-group row">
							<div class="col-md-6 col-sm-6" id="ctrl-principal">								
								<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deleteBranches(event)">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
										<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
									</svg>
									Eliminar
								</button>
								<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addGalery()">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
										<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
									</svg>
									Agregar
								</button>
							</div>
							<div class="col-lg-4 col-md-4 col-sm-9">
								<button style="padding:10px" class="btn btn-secondary reflejo" type="button" onclick="resertB()">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
									  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2v1z"/>
									  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466z"/>
									</svg>
									Limpiar
								</button>
							</div> 
						</div>
					</div>
				</div>
			</form>
			<div style="margin-top:30px;" class="x_title"></div>
			<h2>Fotos existentes<small></small></h2>
		</div>
	</div>
    
    <script src="js/personalizados/GaleryAdmin/AddImg.js"></script>
    <script src="js/personalizados/GaleryAdmin/buildGaleryOnload.js"></script>
    <script src="js/personalizados/GaleryAdmin/buildImgPostBack.js"></script>

    <script src="js/personalizados/utils/HttpClient/POST/Post.js"></script>
    <script src="js/personalizados/utils/HttpClient/GET/GET.js"></script>

    <script src="js/personalizados/utils/styleBoxShadow.js"></script>
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>

	<script type="text/javascript">
		window.onload = function () {
			requestGalery();
		}
    </script>
</asp:content> 