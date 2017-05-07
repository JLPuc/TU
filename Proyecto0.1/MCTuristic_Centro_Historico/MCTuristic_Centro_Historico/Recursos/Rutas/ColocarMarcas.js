function initialize() {
    mapcode = new google.maps.Geocoder();
    var lnt = new google.maps.LatLng(20.9673702, -89.59258569999997);
    var latlng = new google.maps.LatLng(20.97332102266464, -89.59116949364011);

    var diagChoice = {
        zoom: 9,
        center: lnt,
        diagId: google.maps.MapTypeId.HIBRID
    }
    map = new google.maps.Map(document.getElementById('map_canvas'), diagChoice);

    marker = new google.maps.Marker({
        position: latlng,
        draggable: true,
        animation: google.maps.Animation.BOUNCE
    });
}

function getMarkersWS(map) {
    $.ajax({
        type: "POST",
        url: "Rutas.aspx/Posiciones",
        data: "{}",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            var panaderias = response.d;
            $.each(panaderias, function (index, pan) {
                var point = new GLatLng(pan.lng, pan.lat);
                var htmlVentana = "<br> Sitio:" + pan.nombre + "</b><br><i>Precio:" + pan.precio + "</i><br>Direccion:" + pan.direccion;
                var marker = createMarker(point, htmlVentana);
                map.addOverlay(marker);
                $("<li />").html(pan.nombre + "  " + pan.direccion + " <b>" + pan.precio + "</b>").click(function () {
                    marker.openInfoWindowHtml(htmlVentana);
                }).appendTo("#list");

            });

        },

        failure: function (msg) {
            alert(msg);
        }

    }); //fin llamada ajax
} //fin funcion getMarkersWS