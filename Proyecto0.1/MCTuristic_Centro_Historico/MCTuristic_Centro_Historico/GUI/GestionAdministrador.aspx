<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/mpBase.Master" AutoEventWireup="true" CodeBehind="GestionAdministrador.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.GestionAdministrador" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTituloPagina" runat="server">
    Administrador
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
<asp:Content ID="Content3" ContentPlaceHolderID="cphBarraLat" runat="server">
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
<asp:Content ID="Content4" ContentPlaceHolderID="cphBody" runat="server">
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <asp:LinkButton CssClass="btn btn-blue-alt" Visible="false" ID="lblNuevo" runat="server" OnClick="lblNuevo_Click"><i class="glyph-icon icon-plus-circle"></i>Nuevo</asp:LinkButton>
            <asp:Panel ID="GestionNuevo" runat="server">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel">
                            <div class="panel-body">
                                <h3 class="text-center font-bold"><i class="glyph-icon icon-key"></i>Control de administradores </h3>
                                <div class="divider"></div>

                                <div class="divider"></div>
                                <div class="col-lg-6">
                                    <div class="form-group border-blue">
                                        <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-tags"></i>Apellidos</h3>
                                        <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-at"></i>Correo Electrónico</h3>
                                        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-language"></i>Dirección</h3>
                                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <button class="btn btn-primary" data-toggle="modal" data-target="#Direccion" type="button">Agregar dirección</button>
                                        <div class="modal fade bs-example-modal-lg" id="Direccion" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                                            <div class="modal-dialog modal-lg">
                                                <div class="modal-content">
                                                    <div class="modal-header">
                                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                                        <h3 class="modal-title"><b>Registrar dirección</b></h3>
                                                    </div>
                                                    <div class="modal-body">
                                                        <div class="col-lg-6">
                                                            <h3><i class="glyph-icon icon-road"></i>Calle</h3>
                                                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                                            <br />
                                                            <h3><i class="glyph-icon icon-tag"></i>Número</h3>
                                                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                                            <br />
                                                            <h3><i class="glyph-icon icon-flag"></i>Estado</h3>
                                                            <asp:TextBox ID="txtEstado" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <h3><i class="glyph-icon icon-arrows"></i>Cruzamiento</h3>
                                                            <asp:TextBox ID="txtCruzamiento" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                                            <br />
                                                            <h3><i class="glyph-icon icon-qrcode"></i>Código postal</h3>
                                                            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                                            <br />
                                                            <h3><i class="glyph-icon icon-tags"></i>Colonia</h3>
                                                            <asp:TextBox ID="txtColonia" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-12">
                                                            <br />
                                                            <h3><i class="glyph-icon icon-file-text"></i>Descripción</h3>
                                                            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control border-blue" TextMode="MultiLine"></asp:TextBox>
                                                            <br />
                                                            <div class="pull-right">
                                                                <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="modal-footer no-border">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group border-blue">
                                        <h3><i class="glyph-icon icon-terminal"></i>Contraseña</h3>
                                        <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-phone"></i>Teléfono celular</h3>
                                        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-calendar"></i>Fecha de nacimiento</h3>
                                        <div class="input-prepend input-group">
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFecha" Format="MM-dd-yyyy" />
                                            <asp:TextBox ID="txtFecha" CssClass="form-control border-blue" runat="server"></asp:TextBox>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnGuardar_Click1"><i class="glyph-icon icon-save"></i> Guardar</asp:LinkButton>
                                    <div class="divider"></div>

                                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                        <ProgressTemplate>
                                            <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>

                                    <dx:ASPxGridView ID="ASPxGridView1" runat="server" OnRowCommand="ASPxGridView1_RowCommand" Theme="iOS">
                                        <Columns>

                                            <dx:GridViewDataColumn FieldName="IdAdministrador" Visible="false" VisibleIndex="5" />
                                            <dx:GridViewDataColumn FieldName="Nombre" VisibleIndex="1" />
                                            <dx:GridViewDataColumn FieldName="Email" VisibleIndex="2" />
                                            <dx:GridViewDataColumn FieldName="TelefonoCelular" Visible="false" VisibleIndex="3" />
                                            <dx:GridViewDataColumn FieldName="FechaNacimiento" VisibleIndex="4" />
                                            <dx:GridViewDataColumn FieldName="idDireccion" Visible="false" VisibleIndex="5" />
                                            <dx:GridViewDataColumn FieldName="Calle" VisibleIndex="6" />
                                            <dx:GridViewDataColumn FieldName="Cruzamiento" Visible="false" VisibleIndex="7" />
                                            <dx:GridViewDataColumn FieldName="Numero" Visible="false" VisibleIndex="8" />
                                            <dx:GridViewDataColumn FieldName="Colonia" Visible="true" VisibleIndex="9" />
                                            <dx:GridViewDataColumn FieldName="Descripcion" Visible="false" VisibleIndex="10" />
                                            <dx:GridViewDataColumn FieldName="Estado" Visible="true" VisibleIndex="11" />
                                            <dx:GridViewDataColumn FieldName="CodPostal" Visible="false" VisibleIndex="12" />
                                            <dx:GridViewDataColumn FieldName="Apellidos" Visible="false" VisibleIndex="13" />

                                            <dx:GridViewDataColumn Caption="Edit">
                                                <DataItemTemplate>
                                                    <asp:LinkButton ID="Lnk" runat="server" CommandArgument="Editar" Text="Editar"></asp:LinkButton>
                                                </DataItemTemplate>
                                            </dx:GridViewDataColumn>
                                        </Columns>
                                    </dx:ASPxGridView>




                                    <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
                 <contenttemplate>
                  <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnGuardar_Click1"  ><i class="glyph-icon icon-save"></i> Guardar</asp:LinkButton>
   
                        <asp:LinkButton ID="lbtnModificar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnModificar_Click"><i class="glyph-icon icon-edit"></i> Modificar</asp:LinkButton>
                        <asp:LinkButton ID="lbtnEliminar" runat="server" CssClass="btn btn-blue-alt pull-right"><i class="glyph-icon icon-minus-square"></i> Eliminar</asp:LinkButton>
                        <div class="divider"></div>
                    
                   
                     <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="UpdatePanel1" DisplayAfter="0" DynamicLayout="false">
                                    <ProgressTemplate>
                                        <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>

                     <dx:ASPxGridView ID="ASPxGridView2" runat="server">
                         <Columns>

                                        <dx:GridViewDataColumn FieldName="Nombre" VisibleIndex="1" />
                                        <dx:GridViewDataColumn FieldName="Apellidos" VisibleIndex="2" />
                                        <dx:GridViewDataColumn FieldName="Email" VisibleIndex="3" />
                                        <dx:GridViewDataColumn FieldName="Cruzamiento" VisibleIndex="4" />
                                        <dx:GridViewDataColumn FieldName="TelefonoCelular" VisibleIndex="5" />
                                        <dx:GridViewDataColumn FieldName="Calle" VisibleIndex="6" />
                                        <dx:GridViewDataColumn FieldName="Colonia" VisibleIndex="7" />
                                        <dx:GridViewDataColumn FieldName="Estado" VisibleIndex="8" />
                                        <dx:GridViewDataButtonEditColumn Caption="Editar Columnas" Name="Editar" VisibleIndex="9">
                                        </dx:GridViewDataButtonEditColumn>
                                        <dx:GridViewDataColumn Caption="Edit">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="Lnk" runat="server" CommandArgument="Editar" Text="Editar"></asp:LinkButton>
                                            </DataItemTemplate>
                                        </dx:GridViewDataColumn>
                                    </Columns>

                     </dx:ASPxGridView>

                                
                             
                    </contenttemplate>
                        </asp:UpdatePanel>--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

            <asp:Panel ID="Editar" Visible="false" runat="server">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="panel">
                            <div class="panel-body">
                                <h3 class="text-center font-bold"><i class="glyph-icon icon-key"></i>Control de administradores </h3>
                                <div class="divider"></div>
                                <div class="divider"></div>
                                <div class="col-lg-6">
                                    <div class="form-group border-blue">
                                        <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                                        <asp:TextBox ID="txtNombreEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-tags"></i>Apellidos</h3>
                                        <asp:TextBox ID="txtApellidosEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-at"></i>Correo Electrónico</h3>
                                        <asp:TextBox ID="txtCorreoEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <div class="col-lg-12">
                                            <h3><i class="glyph-icon icon-road"></i>Calle</h3>
                                            <asp:TextBox ID="txtCalleEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                            <br />
                                            <h3><i class="glyph-icon icon-tag"></i>Número</h3>
                                            <asp:TextBox ID="txtNumeroCalleEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                            <br />
                                            <h3><i class="glyph-icon icon-flag"></i>Estado</h3>
                                            <asp:TextBox ID="txtEstadoEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <div class="form-group border-blue">

                                        <h3><i class="glyph-icon icon-phone"></i>Teléfono celular</h3>
                                        <asp:TextBox ID="txtTelefonoEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        <br />
                                        <h3><i class="glyph-icon icon-calendar"></i>Fecha de nacimiento</h3>
                                        <div class="input-prepend input-group">
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtFechaNEdit" Format="MM-dd-yyyy" />
                                            <asp:TextBox ID="txtFechaNEdit" CssClass="form-control border-blue" runat="server"></asp:TextBox>

                                        </div>

                                    </div>
                                </div>
                                <div class="col-lg-6">
                                    <h3><i class="glyph-icon icon-arrows"></i>Cruzamiento</h3>
                                    <asp:TextBox ID="txtCruzamientoEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                    <br />
                                    <h3><i class="glyph-icon icon-qrcode"></i>Código postal</h3>
                                    <asp:TextBox ID="txtCodigoPostalEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                    <br />
                                    <h3><i class="glyph-icon icon-tags"></i>Colonia</h3>
                                    <asp:TextBox ID="txtColoniaEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                    <div class="col-lg-12">
                                        <br />
                                        <h3><i class="glyph-icon icon-file-text"></i>Descripción</h3>
                                        <asp:TextBox ID="txtDescripcionEdit" runat="server" CssClass="form-control border-blue" TextMode="MultiLine"></asp:TextBox>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-lg-12">
                                    <div class="divider"></div>
                                    <asp:TextBox ID="txtIDAdmin" Visible="false" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                    <asp:TextBox ID="txtIdDireccion" Visible="false" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                    <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                        <ProgressTemplate>
                                            <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                        </ProgressTemplate>
                                    </asp:UpdateProgress>
                                    <asp:LinkButton ID="lbtnModificar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnModificar_Click1"><i class="glyph-icon icon-upload"></i> Modificar</asp:LinkButton>
                                    <asp:LinkButton ID="lBntEliminar" runat="server" CssClass="btn btn-blue-alt" OnClick="lBntEliminar_Click"><i class="glyph-icon icon-ban"></i> Eliminar</asp:LinkButton>
                                    <asp:Label ID="lblEstado" runat="server" Font-Size="12pt" ForeColor="#66BEE8"></asp:Label>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </asp:Panel>

        </ContentTemplate>
    </asp:UpdatePanel>






</asp:Content>

