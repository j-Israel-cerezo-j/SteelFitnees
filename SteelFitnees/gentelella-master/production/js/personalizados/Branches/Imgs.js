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
			`	<div id="divImage${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}" class="col-lg-2 col-md-2 col-sm-6 form-group justify-content-center" style="margin-top:15px">
							<button style="text-align:center;color:whith" type="button" class="_42ft _2d4g _t7b" id="" onclick="remremoveImag(${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate},'${fileName}')">X</button>
							<div class=" " style="width: 7.5rem;text-align:center;flex-direction:inherit">
								<img class="reflejo" id="image${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}" alt="Cargar fotografía por favor." src="" height="120" width="120" />
								<div class="card-body">
								    <div id="msjImagenCargadaAutomatica${indexImgUpdate == 0 ? indexImgAddCards : indexImgUpdate}"></div>
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
	document.getElementById("divImage" + i).innerHTML = ""
	if (fileName != undefined) {
		arrayFiles=arrayFiles.filter(item => item.name != fileName);
	}
}

function addBr() {
	document.getElementById("formFile").value = "";
	var formData = new FormData(document.getElementById("form1"));
	for (var i = 0; i < arrayFiles.length; i++) {
		formData.append("file" + i, arrayFiles[i]);
	}
	addB(formData);
}

function updateBr() {
	document.getElementById("formFile").value = "";
	var formData = new FormData(document.getElementById("form1"));
	for (var i = 0; i < arrayFiles.length; i++) {
		formData.append("file" + i, arrayFiles[i]);
	}
	update(formData);
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