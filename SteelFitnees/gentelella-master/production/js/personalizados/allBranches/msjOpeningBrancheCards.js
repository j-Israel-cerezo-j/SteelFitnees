var dateCurrent = new Date();
const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
const today = new Date();
const dayOfWeek = today.getDay();
const todayName = daysOfWeek[dayOfWeek];

function buildOpeningBranches(scheduleOpen, scheduleClose, day) {
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
    } else {
        document.getElementById("noOpenTodayMsj").innerText = "Diculpa,pero hoy " + todayName + " nuestra sucursal no tiene servicios, te invitamos a ver los horarios de la sucursal abajo."
    }
}