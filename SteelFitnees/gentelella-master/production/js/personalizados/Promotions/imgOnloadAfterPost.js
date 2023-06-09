
var arrayPromotions = [];
function returnPromotionsOnload() {
	return arrayPromotions;
}

async function buildPromotionsOnloadAferPost(json) {
	document.getElementById("containerImages").innerHTML = ""
	console.log("json2", json)
	var htmlOptionsSlcBranches2 = await requestBranches();
	var i = 0;
	 json.forEach(async item => {
		 var idBrancheSlc = "branches" + i
		 var idCheckVizualize = "checkVizualize" + i
		 var fileName = item.fileNane;
		 let html =
			 `	<div id="divImage${i}" class="col-lg-3 col-md-3 col-sm-6 form-group justify-content-center" style="margin-top:15px">
					<div style="width: 7.5rem;text-align:center;flex-direction:inherit">
						<img style="border-radius:20px;z-index:1" src="${item.img}" class="reflejo" id="image${i}" alt="Cargar fotografía por favor." src="" height="220" width="200" />
					</div>
					<div class="card-body">
						<div class="form-check form-switch" style="margin-left: 40px;">
							<input class="form-check-input" type="checkbox" id="${idCheckVizualize}" value="null" style="font-size: 25px;    ">
							<label class="form-check-label" for="flexSwitchCheckChecked">Mostrar al usuario</label>
						</div>
						<div class="mt-4">
							<select class="form-select" id="${idBrancheSlc}" aria-label=".form-select" style="border-radius:10px">
								${htmlOptionsSlcBranches2}
							</select>
						</div>
						<div class="mt-4" style="margin-left: 20px;">
							<div id="msjImagenCargadaAutomatica${i}"></div>
						</div>
					</div>
				</div> `
		 i++;
		 document.getElementById("containerImages").innerHTML += html;
		 var idBranche = await requestValueBrancheByPromotion(item.id);
		 if (idBranche != 0) {
			 document.getElementById(idBrancheSlc).value = idBranche;
		 }
		 if (document.getElementById(idCheckVizualize) != undefined) {
			 document.getElementById(idCheckVizualize).checked = item.checkk == "True" ? true : false
		 }
		 var newValueIdBranche = idBranche == 0 ? -1 : idBranche
		 var promotion = { id: item.id, idSlcBranch: idBrancheSlc, idBranchV: newValueIdBranche, idCheck: idCheckVizualize, isCheck: item.checkk == "True" ? true : false }
		 arrayPromotions.push(promotion);
	 });
	var containerImg = document.getElementById("containerImages");
	containerImg.setAttribute("data-indexImage-update", json.length)
	containerImg.setAttribute("data-action-uploadAut", true)
	addDataImag(json);

	console.log("arrayPromotions", arrayPromotions)
}

function addDataImag(json) {
	for (var i = 0; i < json.length; i++) {
		var inputImage = document.getElementById("image" + i);
		inputImage.setAttribute('data-image-uploadAut', json[i].img);
	}
}

function requestValueBrancheByPromotion(id) {
	return new Promise((resolve,reject) => {
		request(resp => {
			resolve(resp)
        }, 'Handlers/promotionsController.aspx?meth=brancheByPromotion&id='+id,false)
	});
}