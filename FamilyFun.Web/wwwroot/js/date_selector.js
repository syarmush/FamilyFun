(function ($) {

    $.fn.addDataSelector = function (config) {

        function dsDownDate() {
            var date = new Date($("#SelectedDate").val());
            date.setDate(date.getDate());
            var dd = date.getDate() >= 10 ? date.getDate() : "0" + date.getDate().toString();
            var mm = date.getMonth() >= 9 ? (date.getMonth() + 1).toString() : "0" + (date.getMonth() + 1).toString();
            $("#SelectedDate").val(date.getFullYear().toString() + "-" + mm + "-" + dd);
        }

        function dsUpDate() {
            var date = new Date($("#SelectedDate").val());
            date.setDate(date.getDate() + 2);
            var dd = date.getDate() >= 10 ? date.getDate() : "0" + date.getDate().toString();
            var mm = date.getMonth() >= 9 ? (date.getMonth() + 1).toString() : "0" + (date.getMonth() + 1).toString();
            $("#SelectedDate").val(date.getFullYear().toString() + "-" + mm + "-" + dd);
        }

        $(this).html(`
            <a class="glyphicon glyphicon-chevron-left" onclick="dsDownDate()" style="width:18%;display:inline-block;clear:left;text-align:right;"></a>
            <input class="form-control" type="date" data-val="true" data-val-required="The StartTime field is required."
                    id="dsSelectedDate" style="width:60%;display:inline-block;clear:left;">
            <a class="glyphicon glyphicon-chevron-right" onclick="dsUpDate()" style="width:18%;display:inline-block;clear:left;"></a>
        `);

        var now = new Date();
        var today = now.getFullYear() + '-' + (now.getMonth() + 1) + '-' + now.getDate();
        

        if (typeof config.onChange === 'function') {
            $("#dsSelectedDate").change(function () { config.onChange($(this).val()) });
        }

        if (typeof config.defaultDate !== 'undefined' && config.defaultDate) {
            $("#dsSelectedDate").val(config.defaultDate);
        }


        return this;
    };

}(jQuery));