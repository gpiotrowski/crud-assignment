function displayMoney(value) {
    return value.formatMoney(2, ",", "") + " €";
}

function displayDays(value) {
    var form = (value != 1 ? "days" : "day");
    return value + " " + form;
}