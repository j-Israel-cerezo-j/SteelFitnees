
function buildOpeningBranches() {
     const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
     const today = new Date();
     const dayOfWeek = today.getDay();
     const todayName = daysOfWeek[dayOfWeek];

    request((json) => {
        json.forEach(item => {
            var divMsjOpening = document.getElementById("msjOpening" + item.idSucursal)
            if (divMsjOpening != undefined) {
                var scheduleOpen = formant12HoursTime(item.horaInicio);
                var scheduleClose = formant12HoursTime(item.horaCierre);
                document.getElementById("msjSheduleCards" + item.idSucursal).innerText = scheduleOpen + " - " + scheduleClose;
                openingStatusR(item.horaInicio, item.horaCierre, "msjOpening" + item.idSucursal);
            }
        })
    }, 'Handlers/sucursalesController.aspx?meth=day&dayName=' + todayName, false);
}
setInterval(buildOpeningBranches, 60000)