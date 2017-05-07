<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/mpBase.Master" AutoEventWireup="true" CodeBehind="GestionServicios.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.GestionServicios" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.6.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTituloPagina" runat="server">
    Servicios
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
            <asp:LinkButton ID="lbtnNuevo" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnNuevo_Click"><i class="glyph-icon icon-plus-circle"></i> Nuevo</asp:LinkButton>
            <asp:Panel ID="pnlGestionServicios" runat="server">
                
    <asp:TextBox ID="txtIdEstablecimiento" runat="server" Visible="false"></asp:TextBox>
    <asp:TextBox ID="txtIdTipoServicio" runat="server" Visible="false"></asp:TextBox>
   
                
       <div class="row">
        <div class="col-lg-12">
            <div class="panel">
                <div class="panel-body">
                    <h3 class="text-center font-bold"><i class="glyph-icon icon-building"></i>Control de Servicios </h3>
                    <div class="divider"></div>
                    
                    <div class="divider"></div>
                    <div class="col-lg-6">
                        <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                        <asp:TextBox ID="txtNombreServicio" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        <br />
                        <h3><i class="glyph-icon icon-money"></i>Precio</h3>
                        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        <br />
                         <h3><i class="glyph-icon icon-list"></i>Oferta</h3>
                        <asp:TextBox ID="txtOferta" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        <br />
                         <h3><i class="glyph-icon icon-tags"></i>Descripción</h3>
                        <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control border-blue" TextMode="MultiLine"></asp:TextBox>
                   <br />
                          <h3><i class="glyph-icon icon-cutlery"></i>Tipo de servicio</h3>
                        <asp:DropDownList ID="ddlTipoServicio" runat="server" CssClass="form-control border-blue" OnSelectedIndexChanged="ddlTipoServicio_SelectedIndexChanged"  ></asp:DropDownList>
                    </div>
                    <div class="col-lg-6">
                       
                       <%--  <button class="btn btn-primary" data-toggle="modal" data-target="#Direccion" type="button">Agregar tipo de servicio</button>
                        <div class="modal fade bs-example-modal-lg" id="Direccion" tabindex="-1" role="dialog" aria-labelledby="myLargeModalLabel" aria-hidden="true">
                            <div class="modal-dialog modal-lg">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h3 class="modal-title"><b>Registrar tipo de servicio</b></h3>
                                    </div>
                                    <div class="modal-body">
                                        <div class="col-lg-6">
                                            <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                                            <asp:TextBox ID="txtNombreTipo" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-12">
                                            <div class="pull-right">
                                                <asp:Button ID="btnAceptar" CssClass="btn btn-primary" runat="server" Text="Aceptar" />
                                                <button type="button" class="btn btn-primary" data-dismiss="modal">Cancelar</button>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer no-border">
                                    </div>
                                </div>
                            </div>
                        </div>--%>
                        <br />

                             <asp:Image ID="imgServicios"  Width="300" Height="280" alt="" runat="server" ImageUrl="~/images1/cubiertos.png"/>
          
                             </center>
                            <br />
                            <asp:FileUpload ID="fuFoto" CssClass="btn-primary" runat="server" Visible="true" />
                            <br />
                            <asp:Button ID="btnSubir" runat="server" CssClass="btn btn-primary" Text="Subir foto" OnClick="btnSubir_Click" PostBackUrl="~/GUI/GestionServicios.aspx" />
                          


                       
                    </div>
                  
                    <div class="col-lg-12">
                        <div class="divider"></div>
                        
                        <asp:LinkButton ID="lbtnGuardar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnGuardar_Click"><i class="glyph-icon icon-save"></i> Guardar</asp:LinkButton>
                 
                        <div class="divider"></div>
                        <h3><i class="glyph-icon icon-table"></i>Tabla de datos</h3>
                        
                        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                            <ProgressTemplate>
                                                 <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                            </ProgressTemplate>
                                        </asp:UpdateProgress>
                        <dx:ASPxGridView ID="ASPxGridView1" runat="server" Theme="iOS" OnRowCommand="ASPxGridView1_RowCommand">
                            <Columns>
                             <dx:GridViewDataColumn FieldName="idServicio"  Visible="false" VisibleIndex="5" />
                             <dx:GridViewDataColumn FieldName="NombreServ" VisibleIndex="1" Caption="Servicio ofrece" />
                             <dx:GridViewDataColumn FieldName="OfertaServicio" Visible="true" VisibleIndex="3" />
                             <dx:GridViewDataColumn FieldName="PreciosServicio"  VisibleIndex="4" />
                              <dx:GridViewDataColumn FieldName="DescripServicio" Visible="true" VisibleIndex="5" Caption="Descripción servicio" />
                              <dx:GridViewDataColumn FieldName="Foto" Visible="false" VisibleIndex="6" />
                              <dx:GridViewDataColumn FieldName="Popularidad" Visible="False" VisibleIndex="7" />
                              <dx:GridViewDataColumn FieldName="idTipoServ" Visible="False" VisibleIndex="8" />
                                        <dx:GridViewDataColumn Caption="Selección">
                                            <DataItemTemplate>
                                                <asp:LinkButton ID="Lnk" runat="server" CommandArgument="Editar" Text="Editar"></asp:LinkButton>
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
        <asp:Panel ID="Editar" Visible="false" runat="server">
      <asp:TextBox ID="txtCodServicioEdit"  Visible="false" runat="server"></asp:TextBox>
      <asp:TextBox ID="txtIdTipoServicioEdit" runat="server" Visible="false"></asp:TextBox>
      <asp:TextBox ID="txtPopularidadEdit" runat="server" Visible="false"></asp:TextBox>
        <div class="row">
        <div class="col-lg-12">
            <div class="panel">
                <div class="panel-body">
                    <h3 class="text-center font-bold"><i class="glyph-icon icon-building"></i>Control de Servicios </h3>
                    <div class="divider"></div>
                    <div class="divider"></div>
                    <div class="col-lg-6">
                        <h3><i class="glyph-icon icon-tag"></i>Nombre</h3>
                        <asp:TextBox ID="txtNombreServEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        <br />
                        <h3><i class="glyph-icon icon-money"></i>Precio</h3>
                        <asp:TextBox ID="txtPrecioEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        <br />
                         <h3><i class="glyph-icon icon-list"></i>Oferta</h3>
                        <asp:TextBox ID="txtOfertaEdit" runat="server" CssClass="form-control border-blue"></asp:TextBox>
                        <br />
                         <h3><i class="glyph-icon icon-tags"></i>Descripción</h3>
                        <asp:TextBox ID="txtDescripcionEdit" runat="server" CssClass="form-control border-blue" TextMode="MultiLine"></asp:TextBox>
                   <br />
                          <h3><i class="glyph-icon icon-cutlery"></i>Tipo de servicio</h3>
                        <asp:DropDownList ID="drpTipoServicio" runat="server" CssClass="form-control border-blue" OnSelectedIndexChanged="drpTipoServicio_SelectedIndexChanged"  ></asp:DropDownList>
                    </div>
                    <div class="col-lg-6">
                        <br />
                  <asp:Image ID="FotoPre" runat="server" Width="450" Height="300" alt="" ></asp:Image>
                           
                             </center>
                            <br />
                    </div>
                  
                    <div class="col-lg-12">
                        <div class="divider"></div>
                        <asp:UpdateProgress ID="UpdateProgress2" runat="server">
                                            <ProgressTemplate>
                                                 <img alt="In progress..." src="../images1/iOS7Loader.gif" width="400" height="90" />
                                            </ProgressTemplate>
                         </asp:UpdateProgress>
                        <asp:LinkButton ID="lbtnModificar" runat="server" CssClass="btn btn-blue-alt" OnClick="lbtnModificar_Click"><i class="glyph-icon icon-edit"></i> Modificar</asp:LinkButton>
                        <asp:Label ID="lblModificar" runat="server" Font-Size="Medium" ForeColor="#009DC5"></asp:Label>
                        <asp:LinkButton ID="lbtnEliminar" runat="server" CssClass="btn btn-blue-alt pull-right" OnClick="lbtnEliminar_Click"><i class="glyph-icon icon-minus-square"></i> Eliminar</asp:LinkButton>
                        <div class="divider"></div>
                     
                        

                    </div>
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
