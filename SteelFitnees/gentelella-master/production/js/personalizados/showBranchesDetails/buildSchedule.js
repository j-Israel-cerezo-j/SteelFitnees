function buildSchedule(json) {
    document.getElementById("nav-tab").innerHTML = ""
    document.getElementById("nav-tabContent").innerHTML = ""
    
    var ban = false;
    var htmlDays = "";
    if (json != undefined) {
        for (var i = 0; i < json.length; i++) {
            ban = true;

            var scheduleOpen = formant12HoursTime(json[i].horaInicio);
            var scheduleClose = formant12HoursTime(json[i].horaCierre);

            htmlDays += 
                    `
                    <div class="col-lg-2 col-md-2 col-sm-6 col-xsm-6" style="text-align: center;">
                        <a style="margin-bottom: 0px;width: 100%;" class="ynav-item nav-link card-header" id="nav-home-tab${json[i].dia.toUpperCase()}" data-toggle="tab" href="#nav-home${json[i].idHorario}" onclick="buildSchedulea('nav-home-tab${json[i].dia.toUpperCase()}','div${json[i].dia.toUpperCase()}','${json[i].dia.toUpperCase()}')" role="tab" aria-controls="nav-home" aria-selected="true">${json[i].dia}</a>
                        <div id="div${json[i].dia.toUpperCase()}">
                            <div style="background: #dcdcdc;" class="tab-pane fade" id="nav-home${json[i].idHorario}" role="tabpanel" aria-labelledby="nav-home-tab" >
                                <div class="col-lg-6 col-md-6 col-sm-6 col-xsm-6" style="width: 100%;">
                                    <div class="tab-wrapper" style="justify-content: center;">
                                        <!-- single -->
                                        <div class="mt-4 mb-4" style="justify-content: center;">
                                            <div class="row"><h5 style="color:black;font-size: 25px;text-align: center;">${scheduleOpen}</h5></div>
                                            <div class="row"><h5 style="color:black;font-size: 25px;text-align: center;"> - </h5></div>
                                            <div class="row"><h5 style="color:black;font-size: 25px;text-align: center;">${scheduleClose}</h5></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                `
        }
    }
    if (ban) {
        document.getElementById("nav-tab").innerHTML = htmlDays
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

        enlace.style.background = "#ff1313"
        enlace.style.color = "white"
        enlace.classList.add("note")
        enlace.click();
    }
}

function buildSchedulea(idDaySelect, idScheduleSelect, day) {
    styleDisplayNoneDivSchedules();
    removeSylesAndClassSchedule()
    

    const enlace = document.getElementById(idDaySelect);
    enlace.style.background = "#ff1313"
    enlace.style.color = "white"
    enlace.classList.add("note")
    const divIdScheduleSelect = document.getElementById(idScheduleSelect);
    divIdScheduleSelect.style.display = "block"

    enlace.click();
}

function styleDotSchedule(id,textAling) {
    const enlace = document.getElementById(id);
    enlace.innerText="."
    enlace.style.color = "black";
    enlace.style.fontSize = "70px";
    enlace.style.textAlign = textAling;
    enlace.style.position = "absolute";

}

function styleDisplayNoneDivSchedules() {
    const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
    daysOfWeek.forEach(elem => {
        if (document.getElementById("div" + elem) != undefined) {
            var enlace = document.getElementById("div" + elem);
            enlace.style.display = "none";
        }
    });
}

function removeStyleDotSchedule(id) {
    const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
    daysOfWeek.forEach(elem => {
        if (document.getElementById(id + elem) != undefined) {
            var enlace = document.getElementById(id + elem);
            enlace.style.color = "";
            enlace.style.fontSize = "";
            enlace.style.textAlign = ""
            enlace.innerText = ""
        }
    });
}

function removeSylesAndClassSchedule() {
    const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
    daysOfWeek.forEach(elem => {
        if (document.getElementById("nav-home-tab" + elem) != undefined) {
            var enlace = document.getElementById("nav-home-tab" + elem);
            enlace.style.background = "#f7fdff";
            enlace.style.color = "#2c234d";
            enlace.classList.remove("note")
        }        
    });  
}