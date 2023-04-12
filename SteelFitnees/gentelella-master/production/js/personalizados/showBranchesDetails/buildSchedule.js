function buildSchedule(json) {    
    document.getElementById("nav-tab").innerHTML = ""
    document.getElementById("nav-tabContent").innerHTML = ""
    
    var ban = false;
    var htmlDays = "";
    var htmlHours= "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;
            htmlDays += 
                `<a class="nav-item nav-link" id="nav-home-tab" data-toggle="tab" href="#nav-home${json[i].idHorario}" role="tab" aria-controls="nav-home" aria-selected="true">${json[i].dia}</a>`
            htmlHours +=
                `<div class="tab-pane fade" id = "nav-home${json[i].idHorario}" role = "tabpanel" aria - labelledby="nav-home-tab" >
                    <div class="row">
                        <div class="col-12">
                            <div class="tab-wrapper" style="justify-content: center;">
                                <!-- single -->
                                <div class="single-box"  style="width:25%">
                                    <div class="single-caption text-center">
                                        <div class="caption">
                                            <span style="font-size:26px">${json[i].horaInicio} - ${json[i].horaCierre}</span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div >`
        }
    }
    if (ban) {
        document.getElementById("nav-tab").innerHTML = htmlDays
        document.getElementById("nav-tabContent").innerHTML = htmlHours

    } else {
        document.getElementById("nav-tab").innerHTML = `<h1>Sin horarios por el momento</h1>`
    }
}