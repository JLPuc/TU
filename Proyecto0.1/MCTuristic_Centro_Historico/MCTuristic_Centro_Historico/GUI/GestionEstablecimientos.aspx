<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/mpBase.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="GestionEstablecimientos.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.GestionEstablecimientos" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTituloPagina" runat="server">
    Gestion de establecimientos
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphSesion" runat="server">
    <asp:PlaceHolder ID="phSesion" runat="server" Visible="true">
        <a href="#" title="My Account" class="user-profile clearfix" data-toggle="dropdown">
            <asp:Image ID="imgUsuario" runat="server" Width="28" ImageUrl="../Recursos/agileui.com/demo/monarch/assets/image-resources/gravatar.jpg" />
            <asp:Label ID="lblUsuario" runat="server" role="span" Text="André Salazar"></asp:Label>
            <i class="glyph-icon icon-angle-down"></i>
        </a>

        <div class="dropdown-menu float-left">
            <div class="box-sm">
                <div class="login-box clearfix">
                    <div class="user-img">
                        <asp:LinkButton ID="lbtnCambiarFoto" CssClass="change-img" runat="server">Cambiar foto</asp:LinkButton>
                        <asp:Image ID="imgMiniaturaUsuario" runat="server" ImageUrl="../Recursos/agileui.com/demo/monarch/assets/image-resources/gravatar.jpg" />
                    </div>
                    <div class="user-info">
                        <span>
                            <asp:Label ID="lblNombreUsuario" runat="server" Text="André Salazar"></asp:Label>
                        </span>
                        <br />
                        <a href="GestionUsuariosGUI.aspx">
                            <span>Editar perfil</span></a>
                    </div>
                </div>
                <%--<div class="divider"></div>
                                <ul class="reset-ul mrg5B">
                                    <li>
                                        <a href="#">
                                            <i class="glyph-icon float-right icon-caret-right"></i>
                                            View account details
                                
                                        </a>
                                    </li>
                                </ul>--%>
                <div class="pad5A button-pane button-pane-alt text-center">
                    <a href="PagPrincipal.aspx" class="btn display-block font-normal btn-danger">
                        <i class="glyph-icon icon-power-off"><span>Cerrar Sesión</span></i></a>
                </div>
            </div>
        </div>
    </asp:PlaceHolder>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cphBody" runat="server">
 
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
          <asp:LinkButton ID="lblNuevo" runat="server" CssClass="btn btn-blue-alt" OnClick="LinkButton1_Click" ><i class="glyph-icon icon-plus-circle"></i> Nuevo</asp:LinkButton>
            <asp:Panel ID="pnlGestionEstablecimientos" runat="server">
                <div class="row">
        <div class="col-lg-12">
            <div class="panel">
                <div class="panel-body">
                    <h3 class="text-center font-bold"><i class="glyph-icon icon-building"></i>Control de establecimientos </h3>
                    <div class="divider"></div>
                    <div class="divider"></div>
                    <div class="col-lg-6">
                        <div class="form-group border-blue">
                               <asp:Button ID="btnMaps" runat="server" Text="Seleccionar Ubicación" CssClass="btn btn-primary" OnClick="btnMaps_Click" />
                                <asp:Label ID="lblMapsEstatus" runat="server" Font-Size="Medium" ForeColor="#009DC5"></asp:Label>
                            <br />
                            <asp:TextBox ID="txtIdEstablecimiento" runat="server" Visible="false"></asp:TextBox>
                            <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-phone"></i>Teléfono</h3>
                            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-facebook-square"></i>Facebook</h3>
                            <asp:TextBox ID="txtFacebook" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-sign-in"></i>Hora de apertura</h3>
                            <asp:TextBox ID="txtAbrir" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-sign-out"></i>Hora de cierre</h3>
                            <asp:TextBox ID="txtCerrar" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group border-blue">
                            <h3><i class="glyph-icon icon-tag"></i>Foto</h3>
                            <center>
                                <asp:Image ID="imgEstablecimiento"  Width="300" Height="220" alt="" runat="server" ImageUrl="~/Recursos/images/Establecimiento.png"/>
                           
                             </center>
                            <br />
                            <asp:FileUpload ID="fuFoto" CssClass="btn-primary" runat="server" Visible="true" />
                            <br />
                            <asp:Button ID="btnSubir" runat="server" CssClass="btn btn-primary" Text="Subir foto" OnClick="btnSubir_Click" PostBackUrl="~/GUI/GestionEstablecimientos.aspx" />
                            <br />
                            <br />
                            </div>
                    </div>
                  
                    <div class="col-lg-12 form-group">
                    </div>
     
                    <div class="col-lg-12 form-group">
                        <div class="divider"></div>
                        <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnGuardar_Click"><i class="glyph-icon icon-save"></i> Guardar</asp:LinkButton>
                       <%-- <asp:LinkButton ID="lbtnModificar" runat="server" CssClass="btn btn-blue-alt"><i class="glyph-icon icon-edit"></i> Modificar</asp:LinkButton>
                        <asp:LinkButton ID="lbtnEliminar" runat="server" CssClass="btn btn-blue-alt pull-right"><i class="glyph-icon icon-minus-square"></i> Eliminar</asp:LinkButton>--%>
                        <div class="divider"></div>
                        <h3><i class="glyph-icon icon-table"></i>Tabla de datos</h3>
               
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                 <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>


                                        <dx:ASPxGridView ID="ASPxGridView1" runat="server"  Theme="iOS" OnRowCommand="ASPxGridView1_RowCommand">
                                            <Columns>
                             
                                        <dx:GridViewDataColumn FieldName="Código" Visible="false" VisibleIndex="5" />
                                                <dx:GridViewDataColumn FieldName="Nombre" VisibleIndex="1" />
                                                 <dx:GridViewDataColumn FieldName="Teléfono" Visible="true" VisibleIndex="3" />
                                                 <dx:GridViewDataColumn FieldName="HoraInicio"  VisibleIndex="4" />
                                                 <dx:GridViewDataColumn FieldName="HoraCierre" Visible="true" VisibleIndex="5" />
                                                 <dx:GridViewDataColumn FieldName="PagFacebook" VisibleIndex="6" Caption="Facebook" />
                                                 <dx:GridViewDataColumn FieldName="Propietario" Visible="False" VisibleIndex="7" />
                                                 <dx:GridViewDataColumn FieldName="Latitud" Visible="false" VisibleIndex="8" />
                                                 <dx:GridViewDataColumn FieldName="Longitud" Visible="false" VisibleIndex="9" />
                                                 <dx:GridViewDataColumn FieldName="Foto" Visible="false" VisibleIndex="10" />
                                                 <dx:GridViewDataColumn FieldName="IdUsuario"  Visible="false" VisibleIndex="11" />
                   
                                        <dx:GridViewDataColumn Caption="Selección">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="Lnk" runat="server" CommandArgument="Editar" Text="Editar"></asp:LinkButton>
                                             <asp:LinkButton ID="lkServicios" runat="server" CommandArgument="Servicios" Text="Servicios"></asp:LinkButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                    </Columns>
                                        </dx:ASPxGridView>
                    </div>
          
                </div>
            </div>
        </div>
    </div>
            </asp:Panel>
            <asp:Panel ID="Editar" runat="server">
                <div class="row">
        <div class="col-lg-12">
            <div class="panel">
                <div class="panel-body">
                    <h3 class="text-center font-bold"><i class="glyph-icon icon-building"></i>Control de establecimientos </h3>
                    <div class="divider"></div>
                    <div class="divider"></div>
                    <div class="col-lg-6">
                        <div class="form-group border-blue">
                               <asp:Button ID="mapaEdit" runat="server" Text="Seleccionar Ubicación" CssClass="btn btn-primary" OnClick="mapaEdit_Click" />
                    <asp:Label ID="Label1" runat="server" Font-Size="Medium" ForeColor="#009DC5"></asp:Label>
                            <br />
                            <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                            <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                            <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-phone"></i>Teléfono</h3>
                            <asp:TextBox ID="txtTelefonoEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-facebook-square"></i>Facebook</h3>
                            <asp:TextBox ID="txtFacebookEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-sign-in"></i>Hora de apertura</h3>
                            <asp:TextBox ID="txtHoraAbriEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                            <br />
                            <h3><i class="glyph-icon icon-sign-out"></i>Hora de cierre</h3>
                            <asp:TextBox ID="txtHoraCierreEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="form-group border-blue">
                            <h3><i class="glyph-icon icon-tag"></i>Foto</h3>
                            <center>
                               
                                  <asp:Image ID="FotoPre" runat="server" Width="450" Height="300" alt=""></asp:Image>
                             </center>
                        </div>
                    </div>
                    <asp:TextBox ID="txtIDuserEdit"  Visible="false" runat="server"></asp:TextBox>

                        
                    <div class="col-lg-12 form-group">
                         <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                            <ProgressTemplate>
                                                 <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                            </ProgressTemplate>
                         </asp:UpdateProgress>
                         <asp:LinkButton ID="lbtnModificar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnModificar_Click"><i class="glyph-icon icon-edit"></i> Modificar</asp:LinkButton>
                        <asp:Label ID="lblModificar" runat="server" Font-Size="Medium" ForeColor="#009DC5"></asp:Label>
                        <asp:LinkButton ID="lbtnEliminar" runat="server" CssClass="btn btn-blue-alt pull-right" OnClick="lbtnEliminar_Click"><i class="glyph-icon icon-minus-square"></i> Eliminar</asp:LinkButton>
          
                </div>
            </div>
        </div>
    </div>
            </asp:Panel>
      </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cphBarraLat" runat="server">
    <div id="page-sidebar">
        <div class="scroll-sidebar">
            <ul id="sidebar-menu">
                <li class="header"><span>Módulos</span></li>
                <asp:PlaceHolder ID="phAdmin" runat="server" Visible="true">
                    <li>
                        <a href="../GUI/GestionUsuariosGUI.aspx" title="Usuarios">
                            <i class="glyph-icon icon-users"></i>
                            <span>Usuarios</span>
                        </a>
                    </li>
                    <li>
                        <a href="../GUI/GestionSitios.aspx" title="Sitios">
                            <i class="glyph-icon icon-university"></i>
                            <span>Sitios</span>
                        </a>
                    </li>
                    <li>
                        <a href="../GUI/GestionEstablecimientos.aspx" title="Establecimientos">
                            <i class="glyph-icon icon-building"></i>
                            <span>Establecimientos</span>
                        </a>
                    </li>
                    <li>
                        <a href="../GUI/GestionAdministrador.aspx" title="Administradores">
                            <i class="glyph-icon icon-key"></i>
                            <span>Administradores</span>
                        </a>
                    </li>
                </asp:PlaceHolder>

                <asp:PlaceHolder ID="phUsuario" runat="server" Visible="false">

                    <li>
                        <a href="../GUI/GestionUsuariosGUI.aspx" title="Perfil">
                            <i class="glyph-icon icon-users"></i>
                            <span>Perfil</span>
                        </a>
                    </li>
                    <li>
                        <a href="../GUI/GestionEstablecimientos.aspx" title="Establecimientos">
                            <i class="glyph-icon icon-building"></i>
                            <span>Establecimientos</span>
                        </a>
                    </li>
                    <li>
                        <a href="../GUI/GestionEventosUsuarios.aspx" title="Eventos">
                            <i class="glyph-icon icon-flag"></i>
                            <span>Eventos</span>
                        </a>
                    </li>
                    <%--<li>
                        <a href="Rutas.aspx" title="Rutas">
                            <i class="glyph-icon icon-road"></i>
                            <span>Rutas</span>
                        </a>
                    </li>--%>
                </asp:PlaceHolder>
            </ul>
        </div>
    </div>
</asp:Content>
