<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Maps.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.Maps" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <link href="../Recursos/css/site.css" rel="stylesheet" media="screen"/>
    <script src="../Recursos/js/jquery-1.7.1.min.js"></script>
    <script src="../Recursos/js/jquery-ui.min.js"></script>

  
    <script type="text/javascript" src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAUowcGNgwl55nrflrtISUfZbw59yL5KzY&amp;libraries=adsense&amp;sensor=true&amp;language=es"></script>
     <link href="../Recursos/agileui.com/demo/monarch/assets-minified/admin-all-demo.css" rel="stylesheet" />
   <%--Llave nueva mapa AIzaSyAUowcGNgwl55nrflrtISUfZbw59yL5KzY--%>

   <%-- AIzaSyBRxC6Y4f-j6nECyHWigtBATtJyXyha-XU--%>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
      <asp:Button ID="btnMaps" runat="server" Text="Seleccionar Ubicación" CssClass="btn btn-primary" OnClick="btnMaps_Click" />
      
           </ContentTemplate>
        </asp:UpdatePanel>
        <div  class="demo column width4 first">
              <div id="map_canvas" style="width: 1360px; height:610px; position: relative; overflow: hidden;" ></div>
        </div>
        <asp:TextBox ID="TextLat" Visible="true" runat="server" OnTextChanged="TextLat_TextChanged"></asp:TextBox> 
     <asp:TextBox ID="txtLong" Visible="true" runat="server"></asp:TextBox>
    
     <script type='text/javascript'>
     var map = null;
     var infoWindow = null;
 
     function openInfoWindow(marker) {
     var markerLatLng = marker.getPosition();
     infoWindow.setContent([
        '<strong>Agregue el marcador donde se hubique su establecimiento</strong><br/>',
        '<br/>Arrástrame para buscar la posición.'
     ].join(''));

        document.getElementById("txtLong").value = markerLatLng.lng();
        document.getElementById("TextLat").value = markerLatLng.lat();
    infoWindow.open(map, marker);
}
 
     function initialize() {
         var Longitud = document.getElementById("txtLong").value;
         var Latitud = document.getElementById("TextLat").value
         var myLatlng = new google.maps.LatLng(Latitud, Longitud);
    var myOptions = {
      zoom: 17,
      center: myLatlng,
      mapTypeId: google.maps.MapTypeId.ROADMAP
    }
 
    map = new google.maps.Map($("#map_canvas").get(0), myOptions);
 
    infoWindow = new google.maps.InfoWindow();
 
    var marker = new google.maps.Marker({
        position: myLatlng,
        draggable: true,
        map: map
    });
        google.maps.event.addListener(marker, 'dragend', function(){ openInfoWindow(marker); });
	google.maps.event.addListener(marker, 'click', function(){ openInfoWindow(marker); });
}
 
$(document).ready(function() {
    initialize();
    gmaps_ads();
});
           </script>
    </div>
    </form>
</body>
</html>
