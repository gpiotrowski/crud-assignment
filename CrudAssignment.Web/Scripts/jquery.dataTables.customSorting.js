// Sorting by days column (1 day, 2 days etc.)
(function () {
    
    // Change this list to the valid characters you want
    // Init the regex just once for speed - it is "closure locked"
    var re = new RegExp("[0123456789]+ days?");

    jQuery.fn.dataTableExt.aTypes.unshift(
        function (data) {
             if (typeof data !== 'string' || !re.test(data)) {
                 return null;
             }
             return 'day-displayer';
        }
    );

}());

jQuery.extend(jQuery.fn.dataTableExt.oSort, {
    "day-displayer-asc": function (a, b) {
        a = parseInt(a.split(" ")[0]);
        b = parseInt(b.split(" ")[0]);
        return ((a < b) ? -1 : ((a > b) ? 1 : 0));
    },

    "day-displayer-desc": function (a, b) {
        a = parseInt(a.split(" ")[0]);
        b = parseInt(b.split(" ")[0]);
        return ((a < b) ? 1 : ((a > b) ? -1 : 0));
    }
});