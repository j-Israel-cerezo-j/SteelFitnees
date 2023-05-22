
var dateCurrent = new Date();
const daysOfWeek = ['DOMINGO', 'LUNES', 'MARTES', 'MIÉRCOLES', 'JUEVES', 'VIERNES', 'SÁBADO'];
const today = new Date();
const dayOfWeek = today.getDay();
const todayName = daysOfWeek[dayOfWeek];

function openingStatusR(scheduleOpen, scheduleClose,idMsj) {

    const minuteMilliseconds20 = 20 * 60 * 1000;
    var yearCurrent = dateCurrent.getFullYear();
    var monthCurrent = dateCurrent.getMonth() + 1; // Los monthCurrentes van de 0 a 11, por lo que se suma 1
    var dayCurrent = dateCurrent.getDate();

    const newMonthCurrent = monthCurrent < 10 ? "0" + monthCurrent : monthCurrent
    const newDayCurrent = dayCurrent < 10 ? "0" + dayCurrent : dayCurrent

    const currentDate = yearCurrent + "-" + newMonthCurrent + "-" + newDayCurrent
    const objDateScheduleOpen = new Date(currentDate + " " + scheduleOpen);
    const objDateScheduleClose = new Date(currentDate + " " + scheduleClose);

    const timeAlmostClose = objDateScheduleClose.getTime() - minuteMilliseconds20;    
    if ((today.getTime() >= timeAlmostClose) && (today.getTime() < objDateScheduleClose.getTime())) {
        document.getElementById(idMsj).innerText = "Cierra pronto"
        document.getElementById(idMsj).style.color = "orangered";
    } else if ((today.getTime() < objDateScheduleClose.getTime()) && (today.getTime() >= objDateScheduleOpen.getTime())) {
        document.getElementById(idMsj).innerText = "Abierto";
        document.getElementById(idMsj).style.color = "green";    
    }
    else {
        document.getElementById(idMsj).innerText = "Cerrado"
        document.getElementById(idMsj).style.color = "red";      
    }
}
