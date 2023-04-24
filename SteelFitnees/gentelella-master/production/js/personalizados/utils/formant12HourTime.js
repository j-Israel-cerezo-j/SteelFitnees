function formant12HoursTime(time24) {
    var hour = time24.split(":")[0];
    var minuts = time24.split(":")[1];
    return hour >= 12 ? hour - 12 + ":" + minuts + " PM" : hour + ":" + minuts + " AM"
}