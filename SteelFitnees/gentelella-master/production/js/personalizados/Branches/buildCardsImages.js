function buildCardsImage(json) {
    document.getElementById("containerImages").innerHTML = ""
    document.getElementById("containerImages").innerHTML = `<h2 id="msjImages">Tus imagenes recuperadas se han cargado automaticamente</h2>`
    for (var i = 0; i < json.length; i++) {
        let html =
            `	<div class="col-lg-2 col-md-2 col-sm-6 form-group justify-content-center" style="margin-top:15px">
				    <div class="card reflejo " style="width: 7.5rem;text-align:center;flex-direction:inherit">
				    	<img id="image${i}" alt="Cargar fotografía por favor." src="${json[i].path}" height="100" width="120" />
				    	<div class="card-body">
				    	    <div id="msjImagenCargadaAutomatica${i}"></div>
				    	</div>
				    </div>
				</div>`      

        document.getElementById("containerImages").innerHTML += html;        
    }
    addDataImag(json);
}

function addDataImag(json) {
    for (var i = 0; i < json.length; i++) {
        var inputImage = document.getElementById("image"+i);
        inputImage.setAttribute('data-image-uploadAut' + i, json[i].path);
    }
}