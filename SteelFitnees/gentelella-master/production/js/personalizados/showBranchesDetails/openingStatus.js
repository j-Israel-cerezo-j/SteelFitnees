const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];

function openingStatus() {    
    const today = new Date();
    const dayOfWeek = today.getDay();
    const todayName = daysOfWeek[dayOfWeek];

    if (document.getElementById("nav-home-tab" + todayName) != undefined) {

        const divTab = document.getElementById("nav-home-tab" + todayName);
        const scheduleOpen = divTab.dataset.open;
        const scheduleClose = divTab.dataset.close;
        openingStatusR(scheduleOpen, scheduleClose,"msjOpeningStatus");
     
    } else {
        document.getElementById("msjOpeningStatus").innerText = "Cerrado"
        document.getElementById("msjOpeningStatus").style.color = "red";
    }
}
setInterval(openingStatus, 60000)