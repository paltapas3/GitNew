const uri = 'api/Users';
let todos = null;

$(document).ready(function () {
    getData();
});

function getData() {
    $.ajax({
        type: 'GET',
        dataType: "json",
        url: uri,

        success: function (data) {

            $.each(data, function (key, item) {
                $( '<td>' + item.name + '</td>' +
                    '</tr>').appendTo($('#todos'));
            });

            todos = data;
        }
    });

    error : error = function () {
        $("#msg").html("Error while calling the Web API!");
    };
}





