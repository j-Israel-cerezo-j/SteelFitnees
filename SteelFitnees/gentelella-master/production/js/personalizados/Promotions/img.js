var arrayFiles = []
var indexImgUpdate = 0;
var indexImgUpdate2 = 0;
var indexImgAddCards = 0;

function MostraIma(input) {
	var actionUpdateData = document.getElementById("containerImages");
	var imageUploadAut = actionUpdateData.getAttribute("data-action-uploadAut");

	if (imageUploadAut != null) {
		if (indexImgUpdate == 0) {
			indexImgUpdate = parseInt(actionUpdateData.getAttribute("data-indexImage-update"))
		}
	}
	for (var i = 0; i < input.files.length; i++) {
		var fileName = input.files[i].name;
		let html =
			`	<div id="divImage${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}" class="col-lg-3 col-md-3 col-sm-6 form-group justify-content-center" style="margin-top:15px">
					<div style="width: 7.5rem;text-align:center;flex-direction:inherit">
						<img style="border-radius:20px;z-index:1" class="reflejo" id="image${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}" alt="Cargar fotografía por favor." src="" height="200" width="200" />
						<svg onclick="remremoveImag(${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate},'${fileName}')" style="cursor: pointer;z-index: 2;position: absolute;margin-left: 46px;margin-top: -140px;" width="45px" height="45px" viewBox="0 0 54 54" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:sketch="http://www.bohemiancoding.com/sketch/ns">
							<title>Quitar imagen</title>
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
							<input class="form-check-input" type="checkbox" id="flexSwitchCheckChecked" style="font-size: 25px;    ">
							<label class="form-check-label" for="flexSwitchCheckChecked">Mostrar al usuario</label>
						</div>
						<div class="mt-3">
							<select class="form-select" aria-label=".form-select" style="border-radius:10px">
								<option selected>Selecciona una sucursal(opcional)</option>
								<option value="1">One</option>
								<option value="2">Two</option>
								<option value="3">Three</option>
							</select>
						</div>
						<div class="mt-4" style="margin-left: 20px;">
							<div id="msjImagenCargadaAutomatica${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}"></div>
							<div><p>Nombre de imagen: ${fileName}</p></div>
						</div>
					</div>
				</div> `
		document.getElementById("containerImages").innerHTML += html;
		arrayFiles.push(input.files[i]);
		var image = new FileReader();
		addImageProcess(image, i, input, indexImgAddCards, indexImgUpdate)
		indexImgAddCards++
		if (indexImgUpdate != 0) {
			indexImgUpdate++;
		}
	}
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
		arrayFiles = arrayFiles.filter(item => item.name != fileName);
	}
}

function addBr() {
	addB(addFilesToFormData());
}
function addFilesToFormData() {
	document.getElementById("formFile").value = "";
	var formData = new FormData(document.getElementById("form1"));
	var index = 0
	arrayFiles.forEach(file => {
		formData.append("file" + index++, file);
	})
	return formData
}
function updateBr() {
	update(addFilesToFormData());
}

function recoverDataB(event) {
	arrayFiles = [];
	recoverDataa(event);
}
function cancelB() {
	arrayFiles = [];
	indexImgUpdate = 0;
	indexImgUpdate2 = 0;
	indexImgAddCards = 0;
	cancelUpdate();
}
function resertB() {
	arrayFiles = [];
	indexImgUpdate = 0;
	indexImgUpdate2 = 0;
	indexImgAddCards = 0;
	btnReset();
}

function resetArrayFiles() {
	arrayFiles = [];
}