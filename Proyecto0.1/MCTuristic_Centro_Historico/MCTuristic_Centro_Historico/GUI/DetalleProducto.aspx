<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.DetalleProducto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="Principal" runat="server">
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


                                                <li class="dropdown">
                                                    <a href="VistaProducto.aspx" data-toggle="dropdown" class="dropdown-toggle">Productos<b class="caret"></b></a>
                                                    <ul role="menu" class="dropdown-menu">
                                                        <li><a tabindex="-1" href="VistaProducto.aspx">Lista Productos </a></li>
                                                        <%--      <li><a tabindex="-1" href="DetalleProducto.aspx"> Product Details</a></li>
                                                        <li><a tabindex="-1" href="cart.html"> Cart </a></li>
                                                        <li><a tabindex="-1" href="checkout.html"> Check Out</a></li>
                                                        <li><a tabindex="-1" href="register.html"> Login</a></li>
                                                        <li><a tabindex="-1" href="register.html"> Register</a></li>--%>
                                                    </ul>
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
                                                    <a href="Contactanos1.aspx">Contactanos<b></b></a>
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


        <section class="inner-titlebg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <h1>Detalle Productos</h1>
                    </div>
                    <div class="">
                        <div class="col-lg-9 col-md-9">
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <ul class="bcrumb pull-right">
                                <li><a href="VistaProducto.aspx">Top Tep Servicios</a></li>
                                &gt;
                                <li><a href="#">Detalle Producto</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>

        <div class="gap"></div>
        <asp:DataList ID="DLDetallProducto" runat="server">
            <ItemTemplate>
                 <section class="pro-details">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12">
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="bx-wrapper" style="max-width: 100%;">
                                    <div class="bx-viewport" style="width: 100%; overflow: hidden; position: relative; height: 500px;">
                                        <ul class="pro-slider" style="width: 715%; position: relative; transition-duration: 0s; transform: translate3d(-720px, 0px, 0px);">
                                            <li style="float: left; list-style: none; position: relative; width: 720px;" class="bx-clone">
                                              
                                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                              
                                            <asp:Image class="img-responsive image-gallery" width="550px" height="418px" ID="Image2"  runat="server" 
                                            ImageUrl='<%#"GetImagen.aspx?id=" + Eval("idServicio") %>' alt=""  />
                                        </ul>
                                    </div>
                                   
                                </div>
                             
                            </div>

                            <div class="col-lg-6">
                                <div class="prod-top"><strong class="title"> <asp:Label ID="lbl" runat="server" Text='<%# Eval("NombreServ") %>' ForeColor="#3399FF"></asp:Label> </strong> <strong class="sub-title">   <asp:Label ID="Label1" runat="server" Text='<%# Eval("NomEstable") %>'></asp:Label>  </strong> <strong class="ptag">Precio: </strong> 
                                    <span class="price"> $<asp:Label ID="lblPrecio" runat="server" Text='<%# Eval("PreciosServicio") %>'></asp:Label> </span> </div>
                                <div class="prod-details">
                                    <p>Detalles Establecimiento </p>
                                    <br>
                                    <ul class="flist">
                                         <p>Detalles Servicio </p>
                                        <li>Teléfono:   <asp:Label ID="Label2" runat="server" Text='<%# Eval("Telefono") %>' ForeColor="#3399FF"></asp:Label></li>
                                        <li>Página Facebook:   <asp:Label ID="Label3" runat="server" Text='<%# Eval("PagFacebook") %>' ForeColor="#3399FF"></asp:Label> </li>
                                        <li><asp:Label ID="Label4" runat="server" Text='<%# Eval("DescripServicio") %>' ForeColor="#3399FF"></asp:Label> </li>
                                    </ul>
                                </div>
                                <div class="prod-info">
                                    <ul>
                                        <li><strong>Servicio:</strong> Servicios</li>
                                        <li><strong>Código producto:  </strong><asp:Label ID="Label5" runat="server" Text='<%# Eval("idServicio") %>' ForeColor="#3399FF"> </asp:Label></li>
                                        <li><strong>Número:</strong>  20</li>
                                      
                                    </ul>
                                </div>
                              
                                <div class="prod-buy">
                                    <ul>
                                        <li>Precio Producto :</li>
                                        <li>
                                            <div class="buttons_added">
                                                <input type="button" class="minus" value="-">
                                                <input type="number" maxlength="12" class="input-text qty text" title="Qty" size="4" value="1" max="" min="" step="1" name="cart[ccb0989662211f61edae2e26d58ea92f][qty]">
                                                <input type="button" class="plus" value="+">
                                            </div>
                                        </li>
                                        <li>
                                            <button class="buyit">Información</button>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                        </div>
                        <div class=" gap-30"></div>

                    </div>

                </div>
            </div>
        </section>
            </ItemTemplate>
           
        </asp:DataList>
        
    </div>
</asp:Content>
