
 var mapcode;
 var diag;
 var geocoder;
 var map;
 var infoWindow;
 var marker;
 var marker2;
 var markerTmp;
      
        
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

     //marker2 = new google.maps.Marker({
     //    position: lnt,
     //    draggable: true,
     //    animation: google.maps.Animation.BOUNCE
     //});

     marker.setMap(map);
     //marker2.setMap(map);

     //google.maps.event.addListener(marker, 'click', function (event) {
     //    placeMarker(map, event.latLng);
     //});

     google.maps.event.addListener(map, 'click', function (event) {
         placeMarker(map, event.latLng);
     });

     

     function placeMarker(map, location) {
             var markerNew = new google.maps.Marker({
                 position: location,
                 map: map
             });

             markerTmp = markerNew.getPosition();



         var infowindow = new google.maps.InfoWindow({
             content: 'Latitude: ' + location.lat() +
             '<br>Longitude: ' + location.lng()
         });

         $('#txtLat').val(marker.getPosition().lat());
         $('#txtlon').val(marker.getPosition().lng());

         objConfigurarDS = {
             origin: marker.getPosition(),
             destination: markerNew.getPosition(),
             travelMode: google.maps.TravelMode.DRIVING
         }

         if (markerTmp != null) {
             ds.route(objConfigurarDS, fnrutear)
         }
         //infowindow.open(map, marker);
        
     }

     var objConfigDR = {
         map: map
     }

     //var objConfigurarDS = {
     //    origin: marker2.getPosition(),
     //    destination: marker.getPosition(),
     //    travelMode: google.maps.TravelMode.DRIVING 
     //}
     var objConfigurarDS;
    var ds = new google.maps.DirectionsService() //obtener coordenadas
    var dr = new google.maps.DirectionsRenderer(objConfigDR)//Traduce coordenadas a la ruta visible 

    //ds.route(objConfigurarDS, fnrutear)

    function fnrutear(resultados, status) {
        if (status == 'OK') {
            dr.setDirections(resultados);
        } else {
            alert('Error')
        }
    }

 }

           
 google.maps.event.addDomListener(window, 'load', initialize);


 //var geocoder;
 //var map;
 //var marker;


 //function initialize(){
 //    //MAP
 //    var latlng = new google.maps.LatLng(38.234509, 27.971330999999964);
 //    var options = {
 //        zoom: 13,
 //        center: latlng,
 //        mapTypeId: google.maps.MapTypeId.HYBRID,
 //        streetViewControl: false
     
     
 //    };
 

        
 //    map = new google.maps.Map(document.getElementById("map_canvas"), options);
        
 //    //GEOCODER
 //    geocoder = new google.maps.Geocoder();
        
 //    marker = new google.maps.Marker({
 //        map: map,
 //        draggable: true
 //    });
				
 //}


		
 //$(document).ready(function() { 
         
 //    initialize();
				  
 //    $(function() {
 //        $("#address").autocomplete({
 //            //This bit uses the geocoder to fetch address values
 //            source: function(request, response) {
 //                geocoder.geocode( {'address': request.term }, function(results, status) {
 //                    response($.map(results, function(item) {
 //                        return {
 //                            label:  item.formatted_address,
 //                            value: item.formatted_address,
 //                            latitude: item.geometry.location.lat(),
 //                            longitude: item.geometry.location.lng()
 //                        }
 //                    }));
 //                })
 //            },
 //            //This bit is executed upon selection of an address
 //            select: function(event, ui) {
 //                $("#latitude").val(ui.item.latitude);
 //                $("#longitude").val(ui.item.longitude);
 //                var location = new google.maps.LatLng(ui.item.latitude, ui.item.longitude);
 //                marker.setPosition(location);
 //                map.setCenter(location);
 //            }
 //        });
 //    });
	
 //    //Add listener to marker for reverse geocoding
 //    google.maps.event.addListener(marker, 'drag', function() {
 //        geocoder.geocode({'latLng': marker.getPosition()}, function(results, status) {
 //            if (status == google.maps.GeocoderStatus.OK) {
 //                if (results[0]) {
 //                    $('#address').val(results[0].formatted_address);
 //                    $('#latitude').val(marker.getPosition().lat());
 //                    $('#longitude').val(marker.getPosition().lng());
 //                }
 //            }
 //        });
 //    });
 

    
       
        



    