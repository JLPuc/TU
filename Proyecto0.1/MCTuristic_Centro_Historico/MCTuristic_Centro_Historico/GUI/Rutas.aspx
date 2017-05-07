<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rutas.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.Rutas" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
</head>
<body>
    <form id="form1" runat="server">
        <div id='map_canvas' style="width: 900px; height: 600px;"> </div>
        <label>Latitud</label><br />
        <asp:TextBox ID="txtLat" runat="server"></asp:TextBox><br />
        <br />
        <ul id="list">
        </ul>
        <label>Longitud</label><br />
        <asp:TextBox ID="txtlon" runat="server"></asp:TextBox>
        <script type="text/javascript">
            window.onload = function () {
                var markers = '<%=Posiciones()%>'
        var mapOptions = {
            center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
            zoom: 8,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var infoWindow = new google.maps.InfoWindow();
        var map = new google.maps.Map(document.getElementById("map_canvas"), mapOptions);
        for (i = 0; i < markers.length; i++) {
            var data = markers[i]
            var myLatlng = new google.maps.LatLng(data.lat, data.lng);
            var marker = new google.maps.Marker({
                position: myLatlng,
                map: map,
                title: data.title
            });
            (function (marker, data) {
                google.maps.event.addListener(marker, "click", function (e) {
                    infoWindow.setContent(data.description);
                    infoWindow.open(map, marker);
                });
            })(marker, data);
        }
    }
        </script>
        
        <%--<script src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBGe3RossrWxAzZFzm4tQMZGcGyJVhhdig&libraries=places"></script>--%>
        <script src="http://maps.google.com/maps?file=api&amp;v=2&amp;sensor=true&amp;key=ABQIAAAA3e9bpW5mHEGS7LVaB4R-3BQx6TWrfC8bNfnC-vtzzHJYkwhD6xTwJS9V3UI-UBnyi98SwuzCxumFSw" type="text/javascript"></script>
        <script src="../Recursos/Rutas/jquery-1.4.2.min.js"></script>
        <script src="../Recursos/Rutas/jquery-ui-1.8.1.custom.min.js"></script>
        
        <%--<script src="../Recursos/Rutas/iniciomap.js"></script>--%>

    </form>
</body>
</html>
