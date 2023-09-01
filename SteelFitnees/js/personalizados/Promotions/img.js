﻿var arrayFiles = []
var promotionsOnload=[]
var indexImgUpdate = 0;
var indexImgUpdate2 = 0;
var indexImgAddCards = 0;
var htmlChecksBranches = "";
var fecha = new Date();

function getPrmotionsOnload() {
	promotionsOnload = returnPromotionsOnload();
}

async function requestHmtlOptions() {
	htmlChecksBranches = await requestBranchesChecks();
}

function MostraIma(input) {		
	var opcionesFormato = { month: 'long' };
	var nombreMes = fecha.toLocaleString('es-ES', opcionesFormato);	
	var actionUpdateData = document.getElementById("containerImages");
	var imageUploadAut = actionUpdateData.getAttribute("data-action-uploadAut");

	if (imageUploadAut != null) {
		if (indexImgUpdate == 0) {
			indexImgUpdate = parseInt(actionUpdateData.getAttribute("data-indexImage-update"));
		}
	}

	for (var i = 0; i < input.files.length; i++) {
		var fileName = input.files[i].name;
		var valueIndex = indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate
		var idBranches = "branches" + valueIndex
		var idCheckVizualize = "checkVizualize" + valueIndex
		var idInputPromoName = "promotionName" + valueIndex
		var numeroAleatorio = Math.floor(Math.random() * 1000) + 1;

		let html2 =
			`	<div id="divImage${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}" class="col-lg-3 col-md-3 col-sm-6 form-group justify-content-center" style="margin-top:54px">
					<div class="row mb-3">
						<label style="margin-bottom:10px" class="control-label">Nombre de la promoción</label>
						<div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
							<input style="border-radius:6px" type="text" class="form-control" value="Promo ${nombreMes.toUpperCase()} ${numeroAleatorio}" id="${idInputPromoName}" placeholder="Nombre de la promoción" onkeyup="onkeyupInputEmtyy('${idInputPromoName}')">
						</div>
					</div>
					<div style="width: 7.5rem;text-align:center;flex-direction:inherit">
						<img style="border-radius:20px;z-index:1" class="reflejo" id="image${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}" alt="Cargar fotografía por favor." src="" height="220" width="200" />
						<svg onclick="remremoveImag(${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate},'${fileName}')" style="cursor: pointer;z-index: 2;position: absolute;margin-left: 20px;margin-top: -123px;" width="45px" height="45px" viewBox="0 0 54 54" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:sketch="http://www.bohemiancoding.com/sketch/ns">
							<title>Quitar promoción</title>
							<defs></defs>
							<g id="Page-1" stroke="none" stroke-width="1" fill="none" fill-rule="evenodd" sketch:type="MSPage">
							    <g id="Check-+-Oval-2" sketch:type="MSLayerGroup" stroke="#747474" stroke-opacity="0.198794158" fill="#FFFFFF" fill-opacity="0.816519475">
							        <path d="M32.6568542,29 L38.3106978,23.3461564 C39.8771021,21.7797521 39.8758057,19.2483887 38.3137085,
							            17.6862915 C36.7547899,16.1273729 34.2176035,16.1255422 32.6538436,17.6893022 L27,
							            23.3431458 L21.3461564,17.6893022 C19.7823965,16.1255422 17.2452101,16.1273729 15.6862915,17.6862915 C14.1241943,
							            19.2483887 14.1228979,21.7797521 15.6893022,23.3461564 L21.3431458,29 L15.6893022,34.6538436 C14.1228979,
							            36.2202479 14.1241943,38.7516113 15.6862915,40.3137085 C17.2452101,41.8726271 19.7823965,41.8744578 21.3461564,
							            40.3106978 L27,34.6568542 L32.6538436,40.3106978 C34.2176035,41.8744578 36.7547899,41.8726271 38.3137085,
							            40.3137085 C39.8758057,38.7516113 39.8771021,36.2202479 38.3106978,34.6538436 L32.6568542,29 Z M27,
							            53 C41.3594035,53 53,41.3594035 53,27 C53,12.6405965 41.3594035,1 27,1 C12.6405965,1 1,12.6405965 1,
							            27 C1,41.3594035 12.6405965,53 27,53 Z" id="Oval-2" sketch:type="MSShapeGroup">
							        </path>
							    </g>
							</g>
						</svg>
					</div>
					<div class="card-body">
						<div class="form-check form-switch" style="margin-left: 40px;">
							<input class="form-check-input checkBoxVUP" type="checkbox" id="${idCheckVizualize}" value="null" style="font-size: 25px;    ">
							<label class="form-check-label" for="flexSwitchCheckChecked">Visible al usuario</label>
						</div>
						<div class="form-check mt-4" style="margin-left: 10px;">
							<input class="form-check-input checkBoxABP" type="checkbox" id="checkAllBranch${idBranches}" onchange="allBranchesCheks(${idBranches})">
							<label style="margin-left: 10px;" class="form-check-label">
							    Todas las sucursales
							</label>
						</div>
						<hr />
						<div class="mt-4" id="${idBranches}">
							${htmlChecksBranches}
						</div>
						<div class="mt-4" style="margin-left: 20px;">
							<div id="msjImagenCargadaAutomatica${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}"></div>
						</div>
					</div>
				</div> `

		var htmlContainerImg = document.getElementById("containerImagesUpload").innerHTML;
		document.getElementById("containerImagesUpload").innerHTML = html2+ htmlContainerImg;

		var promotion = { id: null, img: input.files[i], idChecksBranchs: idBranches, idCheck: idCheckVizualize, idInputNamePromotion: idInputPromoName }
		arrayFiles.push(promotion);

		var image = new FileReader();
		addImageProcess(image, i, input, indexImgAddCards, indexImgUpdate)
		indexImgAddCards++
		if (indexImgUpdate != 0) {
			indexImgUpdate++;
		}
	}

	buildMsjPromotionsUpload();
}
function addImageProcess(image, i, input, indexImgAddCards2, indexImgUpdate2) {
	return new Promise((resolve, reject) => {
		image.onload = function (e) {
			var newIndex = indexImgUpdate2 == 0 ? indexImgAddCards2 : indexImgUpdate2;
			document.getElementById("image" + newIndex).setAttribute("src", e.target.result);
		}
		image.readAsDataURL(input.files[i]);
	})
}

function remremoveImag(i, fileName) {
	document.getElementById("divImage" + i).remove();
	if (fileName != undefined) {
		arrayFiles = arrayFiles.filter(item => item.img.name != fileName);
	}
	buildMsjPromotionsUpload();
}

function addPr() {
	loadingBlock('.loader');
	addPromotion(addFilesToFormData());
}

function addFilesToFormData() {
	getPrmotionsOnload();
	document.getElementById("formFile").value = "";
	var formData = new FormData(document.getElementById("form1"));

	var datas=[]		
	var index = 0
	arrayFiles.forEach(promotion => {
		var idsBranches=[]
		var checkVizualizeSelected=""
		var valueNamePromotion = "";
		if (document.getElementById(promotion.idChecksBranchs) != undefined) {
			var divBranchChecks = document.getElementById(promotion.idChecksBranchs)
			var checksBoxBranchs = divBranchChecks.querySelectorAll('input[type="checkbox"]')			
			var checksBranches = Array.from(checksBoxBranchs);
			var checksSelectedBranchs = checksBranches.filter(check => { return check.checked });
			idsBranches = checksSelectedBranchs.map(check => check.value);
		}		
		if (document.getElementById(promotion.idCheck) != undefined) {
			var checked=document.getElementById(promotion.idCheck);
			checkVizualizeSelected = checked.checked
		}
		if (document.getElementById(promotion.idInputNamePromotion) != undefined) {
			valueNamePromotion = document.getElementById(promotion.idInputNamePromotion).value;
		}
		index++;

		var data = {
			id: promotion.id,
			branches: idsBranches,
			check: checkVizualizeSelected,
			promotionName: valueNamePromotion,
			img: promotion.img
		}
		datas.push(data)
	})

	promotionsOnload.forEach(prom => {
		var idsBranchesOnload = []
		var checkVizualizeSelected2 = ""
		if (document.getElementById(prom.idDivBranch) != undefined) {

			var divBranchChecks = document.getElementById(prom.idDivBranch)
			var checksBoxBranchsOnload = divBranchChecks.querySelectorAll('input[type="checkbox"]')
			var checksBranchesOnload = Array.from(checksBoxBranchsOnload);
			var checksSelectedBranchsOnload = checksBranchesOnload.filter(check => { return check.checked });
			idsBranchesOnload = checksSelectedBranchsOnload.map(check => check.value);

		}
		if (document.getElementById(prom.idCheck) != undefined) {
			var checked2 = document.getElementById(prom.idCheck);
			checkVizualizeSelected2 = checked2.checked
		}
		var data = {
			id: prom.id,
			branches: idsBranchesOnload,
			check: checkVizualizeSelected2,
			img: null
		}
		datas.push(data)
	})

	datas.forEach((object, indexx) => {
		formData.append(`img${indexx}`, object.img);
	});
	arrayFiles = [];
	promotionsOnload = [];
	formData.append("data", JSON.stringify(datas));
	return formData
}


function resetArrayFiles() {
	arrayFiles = [];
}

function buildMsjPromotionsUpload() {
	var newlyUploadedImg = arrayFiles.length;
	document.getElementById("lengthPromotionsRecentUpload").innerText = "Recien subidas: (" + newlyUploadedImg + ")";
}

function removeFullPromosUpload() {
	document.getElementById("formFile").value = "";
	arrayFiles = [];
	document.getElementById("containerImagesUpload").innerHTML = "";
	buildMsjPromotionsUpload();
}
