function buildSchedule(json) {
    document.getElementById("nav-tab").innerHTML = ""
    document.getElementById("nav-tabContent").innerHTML = ""
    
    var ban = false;
    var htmlDays = "";
    var htmlHours= "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;

            var scheduleOpen = formant12HoursTime(json[i].horaInicio);
            var scheduleClose = formant12HoursTime(json[i].horaCierre);

            htmlDays += 
                `<a class="nav-item nav-link" id="nav-home-tab${json[i].dia.toUpperCase()}" data-toggle="tab" href="#nav-home${json[i].idHorario}" role="tab" aria-controls="nav-home" aria-selected="true">${json[i].dia}</a>`
            htmlHours +=
                `<div class="tab-pane fade mt-4" id="nav-home${json[i].idHorario}" role = "tabpanel" aria - labelledby="nav-home-tab" >
                    <div class="row">
                        <div class="col-lg-12 col-lg-12 col-md-6 col-lg-12">
                            <div class="tab-wrapper" style="justify-content: center;">
                                <!-- single -->
                                <div class="single-box" style="justify-content: center;">
                                    <div class="note card text-dark bg-light mb-3" style="width:80%">
                                        <div style="background: #ff1313;color:white;font-size: 32px;text-align: center;" class="card-header">${json[i].dia}</div>
                                        <div style="background: #dcdcdc;height:170px;" class="card-body">
                                            <h5 style="color:black;font-size: 30px;text-align: center;padding-top:10px;" class="card-title">${scheduleOpen}</h5>
                                            <h5 style="color:black;font-size: 30px;text-align: center;" class="card-title"> - </h5>
                                            <h5 style="color:black;font-size: 30px;text-align: center;" class="card-title"> ${scheduleClose}</h5>
                                        </div>
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
        buildScheduleToday();
    } else {
        document.getElementById("nav-tab").innerHTML = `<h1>Sin horarios por el momento</h1>`
    }
}

function buildScheduleToday() {
    const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
    const today = new Date();
    const dayOfWeek = today.getDay();
    const todayName = daysOfWeek[dayOfWeek];

    if (document.getElementById("nav-home-tab" + todayName) != undefined) {
        const enlace = document.getElementById("nav-home-tab" + todayName);
        enlace.click();
    }
}