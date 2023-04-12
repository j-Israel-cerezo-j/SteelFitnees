<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="addProductsToBranches.aspx.cs" Inherits="SteelFitnees.gentelella_master.production.addProductsToBranches" MasterPageFile="~/gentelella-master/production/adminMaster.Master" %>

<asp:content id="Content2" ContentPlaceHolderID="head" runat="server">
	<title>Agregar productos a sucursales</title>
	<script src="../vendors/validator/multifield.js"></script>
    <script src="../vendors/validator/validator.js"></script>
    <link href="css/personalizados/buttons.css" rel="stylesheet" />
    <link href="css/personalizados/reflejos.css" rel="stylesheet" />
</asp:content> 
<asp:content id="Content1" ContentPlaceHolderID="bodyContent" runat="server">
    <div class="x_panel">					
		<div class="x_content">
			<h2 id="labelMsjAction">Agrega productos a sucursales</h2>
			<br>
			<form id="form1" class="row g-3 needs-validation" novalidate>
				<div class="row mt-4">
					<div class="form-group col-lg-6 col-md-6 col-sm-12 ">
						<label class="control-label">Sucursales</label>
						<select style="border-radius:6px" class="form-control" id="branches" required="required" name="branches" onchange="onkeyupNoSelectInSlc('branches')">
							 <option selected value="">Seleccione una</option>
						</select>
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Seleccione una opción correcta en sucursales
						</div>
					</div>
					<div class="form-group col-lg-6 col-md-6 col-sm-12 ">
						<label class="control-label">Productos</label>
						<select style="border-radius:6px" class="form-control" id="products" required="required" name="products" onchange="onkeyupNoSelectInSlc('products')">
							 <option selected value="">Seleccione una</option>
						</select>
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Seleccione una opción correcta en dias
						</div>
					</div>
				</div>
				<div class="row mt-5" style="margin-top:20px">
					<div class="form-group col-lg-6 col-md-6 col-sm-12 col-xsm-12">
						<label class="control-label">Cantidad de productos en la sucursal</label>
						<input id="cantidad" class="form-control" name="cantidad" type="number" min="0" required value="0" onkeyup="onkeyupInputEmtyy('cantidad')">
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>
						<div class="invalid-feedback">
							Seleccione una opción correcta en dias
						</div>
					</div>
					<div class="item form-group col-lg-6 col-md-6 col-sm-12 col-xsm-12">
						<label class="control-label">Precio por producto ($)</label>
						<input id="precio" class="form-control" name="precio" type="number" min="0.0" value="0.0" step="any"  required onkeyup="onkeyupInputEmtyy('precio')">
						<div class="valid-feedback">
							¡ Buen trabajo!
						</div>	
					</div>
				</div>	
				<br />
				<div class="form-group row mt-5" style="margin-top:20px">
					<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-principal">								
						<button class="btn btnDeletes reflejo" id="delete" type="button" onclick="deletePB(event)">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
								<path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z"></path>                                    
							</svg>
							Eliminar
						</button>
						<button type="button" class="btn btnSuccesss reflejo" id="add" onclick="addP()">
							<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-plus-circle-fill" viewBox="0 0 16 16">
								<path d="M16 8A8 8 0 1 1 0 8a8 8 0 0 1 16 0zM8.5 4.5a.5.5 0 0 0-1 0v3h-3a.5.5 0 0 0 0 1h3v3a.5.5 0 0 0 1 0v-3h3a.5.5 0 0 0 0-1h-3v-3z"/>
							</svg>
							Agregar
						</button>
					</div>
					<div class="col-md-9 col-sm-9 offset-md-3" id="ctrl-update" style="display: none">
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
				</div>
				<input type="hidden" id="catalogo"  name="catalogo" value="productBranche" />
			</form>					
		</div>
		<%-- Tabla Inicio--%>
		<div class="clearfix"></div>
		<div class="clearfix x_title"></div>
		<h2>Productos en sucursales<small></small></h2>
		<div class="row">
			<div class="form-group col-lg-3 col-md-6 col-sm-12 ">
				<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-filter-left" viewBox="0 0 16 16">
					<path d="M2 10.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z"/>
				</svg>
				<label class="control-label">Tipos de filtro...</label>
				<select style="border-radius:6px" class="form-control" id="filter"   onchange="requestBuildFilter()">
					<option selected value="">Tipos de filtro</option>
					<option value="fullRecords">Todos los registros</option>
					<option value="productsBranchByBranche">Sucursales</option>
					<option value="productsBranchByProduct">Productos</option>
				</select>				
			</div>
			<div class="form-group col-lg-3 col-md-6 col-sm-12 ">
				<svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-filter-left" viewBox="0 0 16 16">
					<path d="M2 10.5a.5.5 0 0 1 .5-.5h3a.5.5 0 0 1 0 1h-3a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h7a.5.5 0 0 1 0 1h-7a.5.5 0 0 1-.5-.5zm0-3a.5.5 0 0 1 .5-.5h11a.5.5 0 0 1 0 1h-11a.5.5 0 0 1-.5-.5z"/>
				</svg>
				<label id="filterByLbl" class="control-label">Filtrar por...</label>
				<select style="border-radius:6px" class="form-control" id="filterTableBy" onchange="requestBuildTableFilterBy()">
					 <option selected value="">Selecciona un tipo de filtro</option>
				</select>				
			</div>
			<div class="col-lg-6 col-md-6 col-sm-6"  style="margin-top:19px;justify-content:right">
				<form id="formOnkeyup">												
					<div class="input-group" > 
					    <div class="form-outline" style="width: 100%;">
							<svg style=" position: absolute;width: 20px; height: 20px; left: 12px; top: 50%; transform: translateY(-50%);" xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-search" viewBox="0 0 16 16">
	    						<path d="M11.742 10.344a6.5 6.5 0 1 0-1.397 1.398h-.001c.03.04.062.078.098.115l3.85 3.85a1 1 0 0 0 1.415-1.414l-3.85-3.85a1.007 1.007 0 0 0-.115-.1zM12 6.5a5.5 5.5 0 1 1-11 0 5.5 5.5 0 0 1 11 0z"></path>
	    					</svg>
					        <input class="form-control" list="datalistOptionsSerch" id="exampleDataList" placeholder="Buscar..." style="border-radius:10px; width: 100%;padding-left: 40px;padding-right: 15px;" onkeyup="onkeyupSearchh()" name="onkeyupCoincidencias">
					        <datalist id="datalistOptionsSerch"></datalist>
					    </div>
					</div>
				</form>
			</div>
		</div>	
		<div class="mt-4" id="containerTableProductBranches"></div>
		<%-- Tabla Final--%>
	</div>
	<script src="js/personalizados/addProductsToBranches/add.js"></script>
	<script src="js/personalizados/addProductsToBranches/requestBranches.js"></script>
	<script src="js/personalizados/addProductsToBranches/requestProducts.js"></script>
	<script src="js/personalizados/addProductsToBranches/build/slc/buildProductsSlc.js"></script>
	<script src="js/personalizados/addProductsToBranches/build/slc/buildBranchesSlc.js"></script>
	<script src="js/personalizados/addProductsToBranches/build/table/buildTable.js"></script>
	<script src="js/personalizados/addProductsToBranches/buildTableOnload.js"></script>
	<script src="js/personalizados/addProductsToBranches/delete.js"></script>
	<script src="js/personalizados/addProductsToBranches/recoverData.js"></script>
	<script src="js/personalizados/addProductsToBranches/update.js"></script>
    <script src="js/personalizados/addProductsToBranches/build/slc/buildFilterSlc.js"></script>
    <script src="js/personalizados/addProductsToBranches/requestBuildFilter.js"></script>
    <script src="js/personalizados/addProductsToBranches/requestBuildTableFilterBy.js"></script>
    <script src="js/personalizados/addProductsToBranches/OnkeyupSearch.js"></script>

	<script src="js/personalizados/FacadeCatalogosRecoverData/switchCatalogosRecoverData.js"></script>

    <script src="js/personalizados/Ajax/recoverData.js"></script>
    <script src="js/personalizados/Ajax/submitAjaxCatalogos.js"></script>  
  
	<script src="js/personalizados/utils/Ajax/onkeyupSearchCatalogos.js"></script>
    <script src="js/personalizados/utils/Ajax/requestTables.js"></script>
    <script src="js/personalizados/utils/Ajax/request.js"></script>

	<script src="js/personalizados/utils/onkeyupInputEmpty.js"></script>
	<script src="js/personalizados/utils/onkeyupNoSelectInSlc.js"></script>
    <script src="js/personalizados/utils/defaultBtnsDisplay.js"></script>
    <script src="js/personalizados/utils/currentDate.js"></script>
	<script src="js/personalizados/utils/switchTableOnkeyup.js"></script>    

	<script type="text/javascript">
		window.onload = function () {
			requestBranches();
			requestProducts();
            buildTableOnload();		
            $('#tbl-roles input[type=checkbox]').iCheck({
                checkboxClass: 'icheckbox_flat-green',
                handle: 'checkbox'
            });
			var checkAll = document.getElementById('check-all');
			if (checkAll != undefined) {
                checkAll.nextElementSibling.setAttribute('onclick', 'toggleSelectAll()');
			}
		}       
    </script>
</asp:content> 