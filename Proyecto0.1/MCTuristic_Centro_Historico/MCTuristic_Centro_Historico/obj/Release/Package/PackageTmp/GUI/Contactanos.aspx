<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.Contactanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="title" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
    <script src="../Recursos/js/push.min.js"></script>
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
                                <div> <br />
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

                                                    <asp:HyperLink ID="HyperLink2" data-toggle="dropdown" class="dropdown-toggle" Visible="false" NavigateUrl="~/GUI/Principal.aspx" runat="server">Blog</asp:HyperLink>
                                                    <%--                                                    <a href="Principal.aspx"  data-toggle="dropdown" class="dropdown-toggle"> Blog<b class="caret"></b></a>--%>
                                                   
                                                    <ul role="menu" class="dropdown-menu">
                                                        <li><a tabindex="-1" href="Principal.aspx">Página principal </a></li>
                                                        <li>
                                                            <asp:Button TabIndex="-1" ID="Button1" runat="server" Text=" Cerrar sesión" />
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



        </div>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
    
     <section class="inner-titlebg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <h1>
                            <font>
                            <font class="">Contáctenos</font></font>
                        </h1>
                    </div>
                    <div>
                        <div class="col-lg-9 col-md-9">
                        </div>
                        <div class="col-lg-3 col-md-3">
                            <ul class="bcrumb pull-right">
                                <li>
                                    <a href="PagPrincipal.aspx">
                                        <font>
                                    <font>Inicio</font>
                                    </font></a></li>
                                <font>
                                <font>
                                &gt;
                                </font></font>
                                <li><a href="Contactanos.aspx"><font>
                               <font> contactanos</font></font></a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </section>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblMensaje" runat="server" ForeColor="#58B1C3"></asp:Label>
                <section class="signup">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-9 col-md-9 col-sm-12 col-xs-12">
                                <div class="contact">
                                    <p class="contact-sub">
                                        <font>
                                         <font>Mandanos tus dudas, nosotros nos pondremos en contacto.</font>
                                        </font>
                                    </p>
                                    <ul class="row">
                                        <li class="col-lg-6">
                                            <label class="first"><font><font>Nombre *</font></font></label>
                                            <asp:TextBox ID="txtNombre" class="required" type="text" placeholder="Nombre" runat="server" required pattern=.*\S.*></asp:TextBox>

                                        </li>
                                        <li class="col-lg-6">
                                            <label class="first"><font><font>Apellidos *</font></font></label>
                                            <asp:TextBox ID="txtApellidos" class="required" type="text" placeholder="Apellidos" runat="server" required pattern=.*\S.*></asp:TextBox>
                                        </li>
                                    </ul>
                                    <ul class="row">
                                        <li class="col-lg-6">
                                            <label><font><font>Correo Electrónico *</font></font></label>
                                            <asp:TextBox ID="txtEmail" class="required" type="text" placeholder="Email" runat="server" required pattern=.*\S.*></asp:TextBox>

                                        </li>
                                        <li class="col-lg-6">
                                            <label><font><font>Asunto *</font></font></label>
                                            <asp:TextBox ID="txtAsunto" class="required" placeHolder="Asunto" type="text" runat="server" required pattern=.*\S.*></asp:TextBox>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li>
                                            <label><font><font>Mensaje</font></font></label>
                                            <asp:TextBox ID="txtContenido" class="required" CssClass="table-responsive" type="text" placeholder="Contenido" runat="server"  TextMode="MultiLine" required pattern=.*\S.*></asp:TextBox>
                                        </li>
                                    </ul>
                                    <ul>
                                        <li>
                                            <font>
                            <font>
                                 <asp:Button runat="server" id="Buton" Text="Enviar" OnClick="Unnamed1_Click"></asp:Button>
                            </font>
                             </font>
                                        </li>
                                    </ul>
                                </div>
                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12">
                                <div class="contact-details">
                                    <h2><font><font>Datos de contacto</font></font></h2>
                                    <p>
                                        <font><font>Somos un grupo de programadores que estan desarrollando esta página para 
                                                        poder facilitar la manere de visitar el centro Historico de nuestra cidud Mérida,Yucatán.
                                        </font><font>Altualmente estududiamos en la universidad la carrera de Tecnologías de la información </font><font>
                                    </p>
                                    <hr>
                                    <address>
                                        <ul>
                                            <li><strong class="title"><i class="fa fa-home"></i><font><font>Universidad Tecnológica Metropolitana</font></font></strong></li>
                                            <li><strong class="title"><i class="fa fa-phone"></i><font><font> (999) 1565262</font></font></strong></li>
                                            <li><strong class="title"><i class="fa fa-mobile"></i><font><font> (00) 1234 4567 89</font></font></strong></li>
                                            <li><strong class="title"><i class="fa fa-envelope"></i><a href="mailto:info@relaxspapalace.com"><font><font>info@relaxspapalace.com</font></font></a></strong></li>
                                        </ul>
                                        <address>
                                        </address>
                                        <hr>
                                            <div class="social">
                                                <a href="#" title="Facebook"><i class="fa fa-facebook-square"></i></a><a href="#" title="Linkedin"><i class="fa fa-linkedin-square"></i></a><a href="#" title="gplus"><i class="fa fa-google-plus-square"></i></a><a href="#" title="Gorjeo"><i class="fa fa-twitter-square"></i></a><a href="#" title="Pinterest"><i class="fa fa-pinterest-square"></i></a><a href="#" title="Instagram"><i class="fa fa-instagram"></i></a><a href="#" title="Flickr"><i class="fa fa-flickr"></i></a>
                                            </div>
                                        </hr>
                                        <address>
                                        </address>
                                    </address>
                                </div>
                            </div>
                        </div>
                    </div>
                </section>
                </font></font>
            </ContentTemplate>
        </asp:UpdatePanel>
        <div class="gap"></div>
</asp:Content>
