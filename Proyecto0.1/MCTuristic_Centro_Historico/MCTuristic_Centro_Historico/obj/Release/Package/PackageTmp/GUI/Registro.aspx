<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.Registro" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Gurdar() {
            var actionData = " { 'nombre': '" + $("#<%=txtNombre.ClientID%>")[0].value + "' , 'apellido': '" + $("#<%=txtApellidos.ClientID%>")[0].value + "' , 'email': '" + $("#<%=txtDireccionCorreo.ClientID%>")[0].value + "' , 'contraseña': '" + $("#<%=txtContraseña.ClientID%>")[0].value + "' , 'numero': '" + $("#<%=txtTelefono.ClientID%>")[0].value + "'}  ";
            $.ajax({
                type: "POST",
                url: "Registro.aspx/Guardar",
                data: actionData,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: OnSuccess,
                failure: function (response) {
                    alert(response.d);
                }
            });
        }
        function OnSuccess(response) {
            alert("Respuesta " + response.d);
        }
    </script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Principal" runat="server">
    <div class="wrapper inner">
        <header id="header">
            <div class="container">
                <div class="row">
                    <div class="col-lg-3 col-md-3">
                        <logo class="logo"><a href="PagPrincipal.aspx" ><img src="../Recursos/images/inner-logo.png" alt="Logo" title="Relax Spa Palace"/></a></logo>
                    </div>
                    <div class="col-lg-9 col-md-9">
                        <div class="home-menu">
                            <div class="navbar mm">
                                <div>
                                 <br />

                                    <nav class="navbar navbar-default" role="navigation">
                                        <div class="navbar-header">
                                            <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#navbar-collapse-1"><span class="sr-only">Toggle navigation</span> <span class="icon-bar"></span><span class="icon-bar"></span><span class="icon-bar"></span></button>
                                        </div>
                                        <div id="navbar-collapse-1" class="collapse navbar-collapse pull-right">
                                            <ul class="nav navbar-nav">
                                                <li><a href="PagPrincipal.aspx">Inicio</a></li>
                                                <li class="dropdown">
                                                    <a href="#" data-toggle="dropdown" class="dropdown-toggle">Servicios<b class="caret"></b></a>
                                                    <ul class="dropdown-menu">
                                                        <li>
                                                            <div class="mm-content">
                                                                <div class="row">
                                                                    <ul class="col-sm-4 list-unstyled">
                                                                        <li>
                                                                            <p><strong>Empresa</strong></p>
                                                                        </li>
                                                                        <li><a href="QuieneSomo.aspx">Misión</a></li>
                                                                        <li><a href="QuieneSomo.aspx">Visión</a></li>
                                                                        <li><a href="QuieneSomo.aspx">Valores </a></li>
                                                                        <li><a href="QuieneSomo.aspx">¿Quiénes somos?</a></li>
                                                                      <li><a href="Suscripciones.aspx" >Suscripciones</a></li>
                                                                    </ul>
                                                                    <%-- <ul class="col-sm-4 list-unstyled">
                                                                        <li>
                                                                            <p><strong>Section Title</strong></p>
                                                                        </li>
                                                                        <li><a href="#">Body Massage</a></li>
                                                                        <li><a href="#">Spa Treatments</a></li>
                                                                        <li><a href="#">Body Massage</a></li>
                                                                        <li><a href="#">Special Facial</a></li>
                                                                        <li><a href="#">Manicure</a></li>
                                                                        <li><a href="#">Pedicure</a></li>
                                                                    </ul>
                                                                    <ul class="col-sm-4 list-unstyled">
                                                                        <li>
                                                                            <p><strong>Section Title</strong></p>
                                                                        </li>
                                                                        <li><a href="#">Body Massage</a></li>
                                                                        <li><a href="#">Spa Treatments</a></li>
                                                                        <li><a href="#">Body Massage</a></li>
                                                                        <li><a href="#">Special Facial</a></li>
                                                                        <li><a href="#">Manicure</a></li>
                                                                        <li><a href="#">Pedicure</a></li>
                                                                    </ul>--%>
                                                                </div>
                                                            </div>
                                                        </li>
                                                    </ul>
                                                </li>

                                                <li class="dropdown">
                                                    <asp:HyperLink ID="HyperLink1" data-toggle="dropdown" class="dropdown-toggle" Visible="false" NavigateUrl="~/GUI/Principal.aspx" runat="server">Blog</asp:HyperLink>
                                                    <%--                                                    <a href="Principal.aspx"  data-toggle="dropdown" class="dropdown-toggle"> Blog<b class="caret"></b></a>--%>

                                                    <ul role="menu" class="dropdown-menu">
                                                        <li><a tabindex="-1" href="Principal.aspx">Página principal </a></li>
                                                        <li>
                                                            <asp:Button TabIndex="-1" ID="btnCerrarSecion" runat="server" Text=" Cerrar sesión" />
                                                        </li>
                                                    </ul>
                                                </li>
                                                                                             <li>
                                                <a href="VistaProducto.aspx">Productos<b></b></a>
                                            </li>
                                                <%-- <li class="dropdown">
                                                    <a href="#" data-toggle="dropdown" class="dropdown-toggle">Gallery<b class="caret"></b></a>
                                                    <ul role="menu" class="dropdown-menu">
                                                        <li><a tabindex="-1" href="galletry01.html">Double Column </a></li>
                                                        <li><a tabindex="-1" href="galletry02.html">Three Column</a></li>
                                                        <li><a tabindex="-1" href="galletry03.html">Four Column</a></li>
                                                        <li><a tabindex="-1" href="galletry04.html">Masonry Style</a></li>
                                                    </ul>
                                                </li>--%>
                                                <li>
                                                    <a href="Contactanos.aspx">Contactanos<b></b></a>
                                                </li>
                                                <li>
                                                    <a href="TerminosYcondiciones.aspx">Términos y condiciones<b></b></a>
                                                </li>
                                            </ul>
                                        </div>
                                    </nav>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </header>
        <div class="gap"></div>
        <section class="signup">
            <div class="container">
                <div class="row">
                    <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                        <div class="register">
                            <h2><font><font>Crea una cuenta</font></font></h2>
                            <asp:Label ID="Label1" ForeColor="Red" Font-Size="Medium" runat="server" Text="Los campos marcados con * son datos obligatorios"></asp:Label>

                            <form method="post" action="#">
                                
                                <ul class="row">
                                    <li class="col-lg-6">
                                        <label><font><font>Nombre  <asp:Label ID="Label3" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtNombre" type="text" placeholder="Nombre" runat="server" required pattern=".*\S.*"></asp:TextBox>

                                    </li>
                                    <li class="col-lg-6">
                                        <label><font><font>Apellido  <asp:Label ID="Label4" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtApellidos" type="text" placeholder="Apellidos" runat="server" required pattern=".*\S.*"></asp:TextBox>

                                    </li>
                                </ul>
                                <ul class="row">
                                    <li class="col-lg-6">
                                        <label><font><font>Dirección de correo electrónico  <asp:Label ID="Label5" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtDireccionCorreo" type="text" placeholder="Dirección de correo electrónico" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                  <li class="col-lg-6">
                                       <label><font><font>Número de Teléfono <asp:Label ID="Label2" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtTelefono"  placeholder="9991565264" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                   </li>


                                </ul>
                                
                                <ul class="row">
                                    <li class="col-lg-6">
                                        <label><font><font>Calle  <asp:Label ID="Label8" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtCalle" type="text" placeholder="Calle" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                    <li class="col-lg-6">
                                        <label><font><font>Número  <asp:Label ID="Label9" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtNumeroCalle" type="text" placeholder="Número" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <label><font><font>Cruzamientos  <asp:Label ID="Label10" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtCruzamiento" type="text" placeholder="Cruzamientos" required pattern=".*\S.*" runat="server"></asp:TextBox>

                                    </li>
                                </ul>
                                <ul class="row">
                                    <li class="col-lg-3">
                                        <label><font><font>Descripción  <asp:Label ID="Label11" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtDescripción" type="text" placeholder="Descripción" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                    <li class="col-lg-3">
                                        <label><font><font>Colonia  <asp:Label ID="Label12" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtColonia" type="text" placeholder="Colonia" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                    <li class="col-lg-3">
                                        <label><font><font>Código postal  <asp:Label ID="Label13" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtCodigoPostal" type="text" placeholder="Código posta" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                    <li class="col-lg-3">
                                        <label><font><font>Estado <asp:Label ID="Label14" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtEstado" type="text" placeholder="Estado" runat="server" required pattern=".*\S.*"></asp:TextBox>
                                    </li>
                                </ul>
                                <ul>
                                    <li>
                                        <font>
                                            <font>
                                            <input id="Button1" type="button" class="btn btn-info boton1" onclick="myFuncion();" value="CREAR CUENTA" />
                                            </font>
                                         </font>
                                    </li>
                                </ul>
                        </div>
                    </div>
                    w
                    <!--Se encarga de llamar al modal Panel-->
                    <script>
                        function myFuncion()
                        {
                            $("#mostrarmodal").modal("show");
                        }
                        function FotoSubida()
                        {
                            swal("Buen trabajo!", "La imagen se subió correctamente continúe con el registro", "success")
                        }
                        function confirmaciónDecuentaSubida()
                        {
                            swal({
                                title: "Registro Completado!",
                                text: "Al equipo de MasterCoder está agradecido con tu contribución, Selecciona un tipo Suscripción",
                                imageUrl: "../Recursos/images/Logon-PNG.png"
                            });
                        }
                      
                    </script>

                     <script>
                       
                         
                         
                    </script>
                                    

                                <!--Panel para aceptar terminos y condiciones de uso-->
                    <div class="modal fade" id="mostrarmodal" tabindex="-1" role="dialog" aria-labelledby="basicModal" aria-hidden="true">

                        <div class="modal-dialog">
                            <div class="modal-content">
                                <div class="modal-header">
                                   
                              
                                </div>
                                <div class="modal-body">
                                   <br />
                                    <br />
                                   
                                    <h1>Términos y condiciones de uso</h1>
                                      <h4>Ingrese la contraseña</h4>
                                     <label><font><font>Contraseña  <asp:Label ID="Label6" ForeColor="Red"  runat="server" Text="*"></asp:Label></font></font></label>
                                        <asp:TextBox ID="txtContraseña" type="Password" placeholder="******" runat="server" BorderStyle="Double" CssClass="text" Height="39px"  Width="199px"></asp:TextBox>
                                    <br />
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtContraseña" ControlToValidate="txtConfirmarContraseña" ErrorMessage="Las contraseñas que usted ingreso no coinciden." Font-Size="Medium" ForeColor="#FF0066"></asp:CompareValidator>
                                                                  
                                        <label>Confirmar contraseña  <asp:Label ID="Label7" ForeColor="Red"  runat="server" Text="*"></asp:Label></label>
                                        <asp:TextBox ID="txtConfirmarContraseña" type="Password" placeholder="******" runat="server" BorderStyle="Double" CssClass="text" Height="39px" Width="199px" ></asp:TextBox>
                                     <br />
                                    <br />

                                    <span> <asp:CheckBox ID="chkTerminos" runat="server" />Acepto los<a target="_blank" href="TerminosYcondiciones.aspx">Términos y condiciones </a> de MCturistic By <a href="https://www.facebook.com/Master-Coder-580293505350746/">MasterCoder</a></span>  
                                </div>
                                <div class="modal-footer">
                                     <asp:Button ID="btnAgregar" class="btn btn-info boton1" runat="server" Text="Registrarse" OnClick="btnAgregar_Click"></asp:Button>
                                     <input id="Button1" type="button"  data-dismiss="modal" class="btn btn-info boton1"  value="Cancelar" />
                              
                                </div>
                            </div>
                        </div>
                    </div>



                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                        <div class="login">
                            <h3><font><font>Agrega una foto</font></font></h3>
                            <form method="post" action="#">
                                <ul>
                                    <li>
                                        <label><font><font><h3><i class="glyph-icon icon-image"></i>Foto  <asp:Label ID="Label16" ForeColor="Red"  runat="server" Text="*"></asp:Label></h3></font></font></label>
                                        <asp:Image ID="imgFoto1" runat="server" Width="450" Height="300" alt="" />
                                        <asp:FileUpload ID="fuFoto1" runat="server" accept=" image/jpeg, image/png" />
                                        <asp:Button ID="btnVer" class="img-responsive" runat="server" Text="Visualizar imagen" CssClass="btn btn-purple" OnClick="btnVer_Click" />
                                        <br />
                                        <%-- <script type="text/javascript">
          function showimagepreview(input) {

              if (input.files && input.files[0]) {
                  var reader = new FileReader();
                  reader.onload = function (e) {

                      $('#imagend').attr('src', e.target.result);
                      document.getElementsById("imagend")[0].setAttribute("src", e.target.result);
                  }
                  reader.readAsDataURL(input.files[0]);
              }
          }

             </script>--%>

                                    </li>
                                    <li>
                                        <br />
                                         <br />
                                        <br />
                                        <label><font>Fecha de Nacimiento  <asp:Label ID="Label15" ForeColor="Red"  runat="server" Text="*"></asp:Label><font></font></font></label>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="Calender" Format="MM/dd/yyyy" />
                                        <asp:TextBox ID="Calender" runat="server" placeholder="Mes/Día/Año Ejemplo: 05/27/1990 " required pattern=".*\S.*"></asp:TextBox>
                                    </li>

                                </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
    <div class="gap"></div>

</asp:Content>

<asp:Content ID="Content5" ContentPlaceHolderID="scrip" runat="server">
</asp:Content>
