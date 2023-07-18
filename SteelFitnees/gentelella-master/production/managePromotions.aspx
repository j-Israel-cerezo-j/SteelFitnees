<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="managePromotions.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.managePromotions" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Gestionar promociones</title>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
    <link href="css/personalizados/efectsLoading.css" rel="stylesheet" />
    <script src="js/personalizados/utils/loading.js"></script>
</asp:content> 

<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="x_panel">
		<div class="x_content">
			<br>
			<p style="font-size: 18px;">
				Todas tus promociones seran vizualizadas en la página de inicio esten o no asignadas a una sucursal.
				De forma opcional podras asignar la promoción a una sucursal para que se mostrada en la
				página de detalles de la sucursal.
			</p>
			<form id="form1" class="row g-3 needs-validation" enctype="multipart/form-data" novalidate>
				<div class="form-group col-lg-3 col-md-3 col-sm-3 col-xsm-12">
					<button style="font-size:18px;z-index:2;border-radius:30px;position:fixed;bottom: 20px;left: 250px;padding-top:10px;padding-bottom:10px;" type="button" onclick="cleanFilter()" class="btn btn-secondary">Limpiar filtro</button>
				</div>
				<div class="col-lg-3 col-md-3 col-sm-3 col-xsm-12">
					<button style="font-size:18px;z-index:2;border-radius:30px;position:fixed;bottom: 20px;right: 20px;padding-top:10px;padding-bottom:10px" type="button" class="btn btnSuccesss reflejo" id="add" onclick="addPr()">
						<svg xmlns="http://www.w3.org/2000/svg" width="23" height="23" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
							<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
						</svg>
						Guardar todo
					</button>
				</div>
				<div class="card" style="padding-bottom:20px;padding-top:30px">
					<ul class="nav nav-tabs">
						<li id="promoExisting" class="nav-item">
							<a id="promoExistingA"  class="nav-link active" data-toggle="tab" href="#home">Promociones existentes</a>
						</li>
						<li id="promosUpload" class="nav-item">
							<a id="promosUploadA" class="nav-link"  data-toggle="tab" href="#menu1">Promociones a subir</a>
						</li>
					</ul>
					<div class="tab-content">
						<div id="home" class="tab-pane fade in active">
							<div class="row" style="margin-top:15px">
								<div class="col-lg-4 col-md-4 col-sm-6 col-xsm-12 mt-3 justify-content-center">
									<div class="input-group" > 
										<div class="form-outline" style="width: 100%;">
											<svg style=" position: absolute;width: 20px; height: 20px; left: 12px; top: 50%; transform: translateY(-50%);" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
	    										<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
	    									</svg>
										    <input class="form-control" list="datalistOptionsSerch" id="inputSearch" placeholder="Buscar por nombre de promoción..." style="border-radius:10px; width: 100%;padding-left: 40px;padding-right: 15px;" onkeyup="searchPromotions()">
										    <datalist id="datalistOptionsSerch"></datalist>
										</div>
									</div>
								</div>
								<div class="form-group col-lg-4 col-md-6 col-sm-6 col-xsm-12">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-filter-left" viewBox="0 0 16 16">
										<path d="M2 10.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z"/>
									</svg>
									<label id="msjFilter" class="control-label">Filtrar por sucursales</label>
									<select style="border-radius:6px" class="form-control" id="filter">
										<option value="-1">Seleccione una opción</option>
									</select>				
								</div>
								<div class="form-group col-lg-4 col-md-6 col-sm-6 col-xsm-12">
									<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-filter-left" viewBox="0 0 16 16">
										<path d="M2 10.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z"/>
									</svg>
									<label class="control-label">Filtrar por visibilidad</label>
									<select style="border-radius:6px" class="form-control" id="filterVisivility" onchange="requestPromotionsByFilterBranchAndVisibilityOrNone()">
										<option value="-1">Seleccione una opción</option>
										<option value="1">Promociones visibles</option>
										<option value="0">Promociones no visibles</option>
									</select>				
								</div>
							</div>
							<div class="row mt-2">
								<div class="col-lg-3 col-md-3 col-sm-3 col-xsm-12">
									<h4 style="font-size:18px;margin-top:15px" id="stateFilter">Sin filtro seleccionado</h4>
								</div>
								<div class="form-group col-lg-3 col-md-3 col-sm-3 col-xsm-12 mt-3 justify-content-center">
									<div class="form-check form-switch" style="margin-left: 40px;">
										<input class="form-check-input" type="checkbox" id="selectorVisible" onchange="fullVisiblesOnload()" style="font-size: 25px;">
										<label class="form-check-label" for="flexSwitchCheckChecked">Todas visibles</label>
									</div>
								</div>
								<div class="form-group col-lg-3 col-md-3 col-sm-3 col-xsm-12 mt-3">
									<div class="form-check">
										<input style="padding:10px" class="form-check-input" type="checkbox" id="checkSelector" onchange="fullSelecteds()">
										<label style="margin-left: 10px;" class="form-check-label">
											Selecionar todas las promociones
										</label>
									</div>
								</div>
								<div class="col-lg-3 col-md-3 col-sm-3 col-xsm-12 form-group" >
									<div class="form-group">
										<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deletePromotion(event)">
											<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
												<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
											</svg>
											Eliminar
										</button>
									</div>
								</div>
							</div>
							<hr />
							<div class="row">
								<div class="row">
									<div class="col-lg-3 col-md-3 col-sm-3 col-xsm-12">
										<h4 style="font-size:18px;margin-top:15px" id="lengthPromotions"></h4>
									</div>
								</div>
								<div id="containerImages" class="mt-3 row justify-content-center"></div>
							</div>
						</div>
						<div id="menu1" class="tab-pane fade">
							<div class="row mt-2">
								<div class="col-lg-6 col-md-6 col-sm-6 col-xsm-12">
									<h2 id="labelMsjAction">Cargar nueva promoción por favor...</h2>
								</div>
								<div class="col-lg-6 col-md-6 col-sm-6 col-xsm-12">
									<span style="font-size:16px;">
										Recuerda que puedes cambiar el nombre de cada promoción.
									</span>
								</div>
							</div>
							<div class="row mt-5">
								<div class="col-lg-4 col-md-6 col-sm-12 form-group">
									<div class="col-md-10 col-sm-10 col-xs-10" id="containerFilePhotograph">
										<input multiple style="border-radius:6px" accept="image/jpeg,image/png,image/jfif"  class="form-control"  type="file" id="formFile" onchange="MostraIma(this)">
									</div>
								</div>
								<div class="col-lg-3 col-md-3 col-sm-3 col-xsm-12 form-group">
									<div class="form-check form-switch" style="margin-left: 40px;">
										<input class="form-check-input" type="checkbox" id="selectorVisibleUpload" onchange="fullVisiblesUpload()" style="font-size: 25px;">
										<label style="margin-top:10px" class="form-check-label" for="flexSwitchCheckChecked">Todas visibles</label>
									</div>
								</div>
								<div class="col-2 col-xsm-12">
									<svg onclick="removeFullPromosUpload()" style="cursor:pointer;" xmlns="http://www.w3.org/2000/svg" width="35" height="35" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
										<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"/>
									</svg>
									<label class="form-label">Quitar todo</label>
								</div>
								<div class="col-3 col-xsm-12">
									<h4 style="font-size:18px" id="lengthPromotionsRecentUpload"></h4>
								</div>
							</div>
							<hr />
							<div id="containerImagesUpload" class="mt-2 row justify-content-center"></div>
						</div>
					</div>
				</div>
			</form>
		</div>
		<figure class="loader" style="display:none">
			<div class="dot white"></div>
			<div class="dot"></div>
			<div class="dot"></div>
			<div class="dot"></div>
			<div class="dot"></div>
		</figure>
	</div>
    <script src="js/personalizados/Promotions/searchPromotions.js"></script>
    <script src="js/personalizados/Promotions/img.js"></script>
    <script src="js/personalizados/Promotions/add.js"></script>
    <script src="js/personalizados/Promotions/requestBranches.js"></script>
    <script src="js/personalizados/Promotions/imgOnloadAfterPost.js"></script>
    <script src="js/personalizados/Promotions/requestPromotionsOnload.js"></script>
    <script src="js/personalizados/Promotions/delete.js"></script>
    <script src="js/personalizados/Promotions/requestPromotions.js"></script>
    <script src="js/personalizados/Promotions/checksPromotions.js"></script>
	<script src="js/personalizados/Promotions/cleanFilter.js"></script>

    <script src="js/personalizados/utils/HttpClient/POST/Post.js"></script>
    <script src="js/personalizados/utils/HttpClient/DELETE/Delete.js"></script>
	<script src="js/personalizados/utils/Ajax/request.js"></script>
    
    <script src="js/personalizados/utils/styleBoxShadow.js"></script>
    <script src="js/personalizados/utils/Ajax/requestTables.js"></script>
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/validatorForm.js"></script>
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>
    <script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
	<script type="text/javascript">
		window.onload = function () {
			requestBranchesSlcFilter();
			requestPromotionsOnload();
			requestHmtlOptions();
        }


    </script>
</asp:content> 