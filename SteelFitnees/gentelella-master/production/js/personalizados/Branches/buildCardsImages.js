function buildCardsImage(json) {
    document.getElementById("containerImages").innerHTML = ""
    document.getElementById("containerImages").innerHTML = `<h2 id="msjImages">Tus imagenes recuperadas se han cargado automaticamente</h2>`
    for (var i = 0; i < json.length; i++) {
        let html =
            `	<div id="divImage${i}" class="col-lg-2 col-md-2 col-sm-6 form-group justify-content-center" style="margin-top:15px">                                    
				    <div class="" style="width: 7.5rem;text-align:center;flex-direction:inherit">
				    	<img style="border-radius:30px;z-index:1" class="reflejo" id="image${i}" alt="Cargar fotografía por favor." src="${json[i].path}" height="130" width="130" />
                        <svg onclick="remremoveImag(${i})" style="cursor: pointer;z-index: 2;position: absolute;margin-left: -23px;margin-top: -90px;" width="50px" height="50px" viewBox="0 0 54 54" version="1.1" xmlns="http://www.w3.org/2000/svg" xmlns:xlink="http://www.w3.org/1999/xlink" xmlns:sketch="http://www.bohemiancoding.com/sketch/ns">      
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
				    	<div class="card-body">
				    	    <div id="msjImagenCargadaAutomatica${i}"></div>
                            <div><p>Nombre de imagen: ${json[i].Nombre}</p></div>
				    	</div>
				    </div>
				</div>`      

        document.getElementById("containerImages").innerHTML += html;
    }
    var containerImg = document.getElementById("containerImages");
    containerImg = containerImg.setAttribute("data-indexImage-update", json.length)
    addDataImag(json);
}

function addDataImag(json) {
    for (var i = 0; i < json.length; i++) {
        var inputImage = document.getElementById("image"+i);
        inputImage.setAttribute('data-image-uploadAut', json[i].path);
    }
}

//Poner las imagenes de los productos en tamaño normal,
/*poner los limpiadores cuando dibije la tabla, por que sognifica que salio exitoso */
