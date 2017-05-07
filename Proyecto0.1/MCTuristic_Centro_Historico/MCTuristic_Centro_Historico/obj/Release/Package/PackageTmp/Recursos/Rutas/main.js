//Useful links:
// http://code.google.com/apis/maps/documentation/javascript/reference.html#Marker
// http://code.google.com/apis/maps/documentation/javascript/services.html#Geocoding
// http://jqueryui.com/demos/autocomplete/#remote-with-cache
      
//var geocoder;
//var map;
//var marker;


var mapcode;
var diag;
function initialize() {
    mapcode = new google.maps.Geocoder();
    var lnt = new google.maps.LatLng(26.45, 82.85);
    var diagChoice = {
        zoom: 9,
        center: lnt,
        diagId: google.maps.MapTypeId.ROADMAP
    }
    diag = new google.maps.Map(document.getElementById('map_populate'), diagChoice);
}
function getmap() {
    var completeaddress = document.getElementById('txt_location').value;
    mapcode.geocode({ 'address': completeaddress }, function (results, status) {
        if (status == google.maps.GeocoderStatus.OK) {
            diag.setCenter(results[0].geometry.location);
            var hint = new google.maps.Marker({
                diag: diag,
                position: results[0].geometry.location
            });
        } else {
            alert('Location Not Tracked. ' + status);
        }
    });
}
google.maps.event.addDomListener(window, 'load', initialize);





/*function myMap() {
//MAP
    var latlng = new google.maps.LatLng(38.234509, 27.971330999999964);
  var options = {
      zoom: 13,
      center: latlng,
      mapTypeId: google.maps.MapTypeId.HYBRID,
      streetViewControl: false
     
     
  };
 

        
  map = new google.maps.Map(document.getElementById("map_populate"), options);
        
  //GEOCODER
  geocoder = new google.maps.Geocoder();
        
  marker = new google.maps.Marker({
    map: map,
    draggable: true
  });
				
}
		
$(document).ready(function() { 
         
  initialize();
				  
  $(function() {
    $("#address").autocomplete({      
      source: function(request, response) {
        geocoder.geocode( {'address': request.term }, function(results, status) {
          response($.map(results, function(item) {
            return {
              label:  item.formatted_address,
              value: item.formatted_address,
              latitude: item.geometry.location.lat(),
              longitude: item.geometry.location.lng()
            }
          }));
        })
      },
      //This bit is executed upon selection of an address
      select: function(event, ui) {
        $("#latitude").val(ui.item.latitude);
        $("#longitude").val(ui.item.longitude);
        var location = new google.maps.LatLng(ui.item.latitude, ui.item.longitude);
        marker.setPosition(location);
        map.setCenter(location);
      }
    });
  });
	
  //Add listener to marker for reverse geocoding
  google.maps.event.addListener(marker, 'drag', function() {
    geocoder.geocode({'latLng': marker.getPosition()}, function(results, status) {
      if (status == google.maps.GeocoderStatus.OK) {
        if (results[0]) {
          $('#address').val(results[0].formatted_address);
          $('#latitude').val(marker.getPosition().lat());
          $('#longitude').val(marker.getPosition().lng());
        }
      }
    });
  });
  
});*/