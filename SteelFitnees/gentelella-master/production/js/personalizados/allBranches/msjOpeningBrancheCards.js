
function buildOpeningBranches() {
     const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
     const today = new Date();
     const dayOfWeek = today.getDay();
     const todayName = daysOfWeek[dayOfWeek];

    request(buildMsjShedulesCards, 'Handlers/sucursalesController.aspx?meth=day&dayName=' + todayName,false);
}

function buildMsjShedulesCards(json) {
        json.forEach(item => {
        var divMsjOpening = document.getElementById("msjOpening" + item.idSucursal)
        if (divMsjOpening != undefined) {
            var scheduleOpen = formant12HoursTime(item.horaInicio);
            var scheduleClose = formant12HoursTime(item.horaCierre);
            document.getElementById("msjSheduleCards" + item.idSucursal).innerText = scheduleOpen + " - " + scheduleClose;
            openingStatusR(item.horaInicio, item.horaCierre, "msjOpening" + item.idSucursal);
        }
    })
}
setInterval(buildOpeningBranches, 60000)