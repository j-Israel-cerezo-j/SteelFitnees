<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="aboutUsAdmin.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.aboutUs" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar misión,visión y valores</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="x_panel">
		<div class="x_content">
			<h1 id="labelMsjAction">Sobre nosotros</h1>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>
				<div class="row mt-4" style="justify-content:center">
					<label class="form-label"><b>Misión:</b></label>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xsm-12 form-group" style="padding-right: 0px;padding-left:10px;">
						<textarea style="border-radius:6px" class="form-control" rows="6" required="required" name="mision" id="mision" placeholder="Redacte la misión aqui por favor"  onkeyup="onkeyupInputEmtyy('mision')"></textarea>						
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Favor de redactar la misión por favor
						</div>
					</div>
				</div>
				<div class="row mt-4" style="justify-content:center">
					<label class="form-label"><b>Visión:</b></label>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xsm-12 form-group" style="padding-right: 0px;padding-left:10px;">
						<textarea style="border-radius:6px" class="form-control" rows="6" required="required" name="vision" id="vision" placeholder="Redacte la visión aqui por favor"  onkeyup="onkeyupInputEmtyy('vision')"></textarea>						
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Favor de redactar la visión por favor.
						</div>
					</div>
				</div>
				<div class="row mt-4" style="justify-content:center">
					<label class="form-label"><b>Valores:</b></label>
					<div class="col-lg-12 col-md-12 col-sm-12 col-xsm-12 form-group" style="padding-right: 0px;padding-left:10px;">
						<textarea style="border-radius:6px" class="form-control" rows="8" required="required" name="valores" id="valores" placeholder="Redacte los valores aqui por favor"  onkeyup="onkeyupInputEmtyy('valores')"></textarea>						
						<div class="valid-feedback">
								¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Favor de redactar los valores por favor.
						</div>
					</div>
				</div>
				<div class="form-group row mt-5" style="margin-top:20px">
					<div class="col-md-6 col-sm-6 offset-md-3" id="ctrl-principal">								
						<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deleteAb(event)">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
								<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
							</svg>
							Eliminar
						</button>
						<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addAboutUs()">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
								<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
							</svg>
							Agregar
						</button>
					</div>
					<div class="col-md-6 col-sm-6 offset-md-3" id="ctrl-update" style="display: none">
						<button type="button" class="btn btn-primary reflejo" id="save"  onclick="update()" >
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-save-fill" viewBox="0 0 16 16">
								<path d="M8.5 1.5A1.5 1.5 0 0 1 10 0h4a2 2 0 0 1 2 2v12a2 2 0 0 1-2 2H2a2 2 0 0 1-2-2V2a2 2 0 0 1 2-2h6c-.314.418-.5.937-.5 1.5v7.793L4.854 6.646a.5.5 0 1 0-.708.708l3.5 3.5a.5.5 0 0 0 .708 0l3.5-3.5a.5.5 0 0 0-.708-.708L8.5 9.293V1.5z"/>
							</svg>
							Guardar
						</button>
						<button type="button" class="btn btn-danger reflejo" id="cancel" onclick="cancelUpdate()">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-x-octagon-fill" viewBox="0 0 16 16">
								<path d="M11.46.146A.5.5 0 0 0 11.107 0H4.893a.5.5 0 0 0-.353.146L.146 4.54A.5.5 0 0 0 0 4.893v6.214a.5.5 0 0 0 .146.353l4.394 4.394a.5.5 0 0 0 .353.146h6.214a.5.5 0 0 0 .353-.146l4.394-4.394a.5.5 0 0 0 .146-.353V4.893a.5.5 0 0 0-.146-.353L11.46.146zm-6.106 4.5L8 7.293l2.646-2.647a.5.5 0 0 1 .708.708L8.707 8l2.647 2.646a.5.5 0 0 1-.708.708L8 8.707l-2.646 2.647a.5.5 0 0 1-.708-.708L7.293 8 4.646 5.354a.5.5 0 1 1 .708-.708z"/>
							</svg>
							Cancelar
						</button>
					</div>
					<div class="col-lg-4 col-md-4 col-sm-9">
						<button style="padding:10px" class="btn btn-secondary reflejo" type="reset">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-arrow-counterclockwise" viewBox="0 0 16 16">
							  <path fill-rule="evenodd" d="M8 3a5 5 0 1 1-4.546 2.914.5.5 0 0 0-.908-.417A6 6 0 1 0 8 2v1z"/>
							  <path d="M8 4.466V.534a.25.25 0 0 0-.41-.192L5.23 2.308a.25.25 0 0 0 0 .384l2.36 1.966A.25.25 0 0 0 8 4.466z"/>
							</svg>
							Limpiar
						</button>
					</div>
				</div>
				<input type="hidden" id="catalogo" name="catalogo" value="aboutUsAdmin" />						
			</form>
			<%-- Tabla Inicio--%>
			<div class="clearfix"></div>
			<div style="margin-top:60px" id="containerTableAboutUs"></div>			
			<%-- Tabla Final--%>			
		</div>
	</div>
    <script src="js/personalizados/aboutUsAdmin/add.js"></script>
    <script src="js/personalizados/aboutUsAdmin/update.js"></script>
    <script src="js/personalizados/aboutUsAdmin/delete.js"></script>    
	<script src="js/personalizados/aboutUsAdmin/recoverData.js"></script>
	<script src="js/personalizados/aboutUsAdmin/build/buildTable.js"></script>
	<script src="js/personalizados/aboutUsAdmin/buildTableRequestOnload.js"></script>    

    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>
    <script src="js/personalizados/Ajax/recoverData.js"></script>

    <script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

    <script src="js/personalizados/utils/styleBoxShadow.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>
    <script src="js/personalizados/utils/Ajax/requestTables.js"></script>
	<script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
    <script src="js/personalizados/utils/buildMsjValidOrInvalid.js"></script>
    <script src="js/personalizados/utils/onkeyupNoSelectInSlc.js"></script>
	<script src="js/personalizados/utils/hideshow.js"></script>

	<script type="text/javascript">
		window.onload = function () {
			buildTableOnload();
		}
    </script>

</asp:content> 