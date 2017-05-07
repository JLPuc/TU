<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="QuieneSomo.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.QuieneSomo" %>
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





        <section class="about about2">
<div class="container">
 
<div class="row">
<div class="col-lg-6 col-md-6">
<ul class="about-slider">
 
<li>   <img src="../Recursos/Imagenes/slider01.jpeg" /></li>
<li>   <img src="../Recursos/Imagenes/slider02.jpg" /></li>
<li>   <img src="../Recursos/Imagenes/slider03.jpg" /></li>
</ul></div>
<div class="col-lg-6 col-md-6 about-2">
<h2>Nuestra blanca Mérida</h2>
<p>Mérida, capital de Yucatán cuenta con una vasta infraestructura para convertirse en el centro de distribución de turismo cultural más importante de la península de Yucatán: con más de 5 mil 919 habitaciones en hoteles de todas sus categorías, recintos de congresos y exposiciones, más de 300 restaurantes de todo tipo de modalidad y una extensa oferta de atracciones culturales y turísticas, es el punto principal para recorrer los caminos del Mayab.</p>
<br />
<p>Te ofrece varias opciones de cultura, historia, diversión y su deliciosa gastronomía, por lo que te recomendamos comenzar tu visita en el Centro Histórico de la Ciudad, en donde se puede apreciar gran variedad de edificios coloniales, museos, galerías, teatros, cafés al aire libre, bares, ropa típica, parques, hoteles, restaurantes con comida típica nacional e internacional.</p>
<br />
<p>El Centro Histórico es un lugar ideal para llevar a cabo todos los días diferentes actividades de esparcimiento y diversión nocturna.</p>
</div>
</div>
 
<div class="gap-30"></div>
 
<div class="row">
<div class="col-lg-12 col-md-12 full-tabs">
 
<ul class="nav nav-tabs">
<li><a href="#tab1" data-toggle="tab">¿MCTuristic?</a></li>
<li><a href="#tab2" data-toggle="tab">Misión</a></li>
<li><a href="#tab3" data-toggle="tab">Visión</a></li>
<li><a href="#tab4" data-toggle="tab">Valores</a></li>
</ul>
 
<div class="tab-content">
<div class="tab-pane active" id="tab1">
<h4>MCTuristic nace de una problemática simple al darse cuenta que los turistas y gente de la región de Yucatán no conoce la mayoría de los puntos más importantes del Centro histórico, perdiéndose gran parte de la cultura que tenemos en nuestro estado.
El Equipo de Master Coder se comprometió a buscar una solución y llegamos en la conclusión en una aplicación móvil que tenga los beneficios de poder hacer recorrido en el centro de Mérida y poder conocer parte de la historia de los sitios que se podrán visualizar en la aplicación.
</h4>
<ul class="flist">
    <h3>Beneficios.  </h3>
<li> Rutas específicas de los sitios más visitados.</li>
<li> Conocer los eventos próximos, fechas y horarios. </li>
<li> Descuentos en establecimientos registrados.</li>
<li> Hoteles y servicios a un buen precio, más cerca de ti.</li>
</ul>
</div>
<div class="tab-pane" id="tab2">
<h4> Nuestra Misión, es representar y promover las riquezas naturales y culturales que ofrece el estado de Yucatán, Mérida es el mejor punto de partida, pues está perfectamente conectada con la costa y Pueblos Mágicos, así como con sus muchas zonas arqueológicas que cuentan una historia, contribuyendo a la conservación del patrimonio natural y cultural del país integrando a las comunidades locales al desarrollo de las actividades para los turistas.
</h4>

</div>
<div class="tab-pane" id="tab3">
<h4>El Turismo es un sector productivo de primer orden, que contribuye al desarrollo social y económico de Yucatán, mediante la generación de actividades. Nuestra visión general, es posicionar al sector de turismo de historia como un segmento consolidado y reconocido dentro de las actividades turísticas del país.</h4>
</div>
<div class="tab-pane" id="tab4">
<h4>Valoramos a las personas y a nuestros turistas en México , tenemos prioridad en el cuidado de los derechos de los empleados, sus familias, buscamos los mejores beneficios de los clientes y aseguramos el valor del de la cultura en nuestro México, estructurando Actividades que no produzcan ninguna clase de incomodidad a las personas, buscamos principalmente una conciencia ecológica y cultural, usando la tecnología para el beneficio de la sociedad.</h4>
</div>
</div>
</div>
</div>
 
<div class="gap-30"></div>
<div class="prograss-round">
<div class="row">
<div class="col-lg-12 col-md-12">
<h2 class="main-title">Panel Opiniones</h2>
</div>
</div>

</div>
</div>
</section>

    
        <section class="quote-bg">
            <div class="container">
                <div class="row">
                    <div class="col-lg-12">
                        <ul class="quote-slider">
                            <li><i class="fa fa-quote-left"></i>
                                <p>La ciudad de Mérida Yucatán, México es una hermosa ciudad colonial, rebosante de cultura, segura y llena de gente amable y servicial. Te invitamos a conocer más sobre nuestra ciudad, ya sea que vengas de un lugar lejano o seas un habitante de la misma, siempre podrás descubrir increíbles historias, lugares y gente que no te imaginabas.</p>
                                <img src="../images1/Luis.jpg" alt="" />
                                <h4>José Luis Puc Chan </h4>
                           <%-- </li>
                            <li><i class="fa fa-quote-left"></i>
                                <p>It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </p>
                                <img src="images/buser1.jpg" alt="">
                                <h4>José Salazar Fuigueroa</h4>
                            </li>
                            <li><i class="fa fa-quote-left"></i>
                                <p>It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </p>
                                <img src="images/buser1.jpg" alt="">
                                <h4>Diosemir Nah May</h4>
                            </li>
                            <li><i class="fa fa-quote-left"></i>
                                <p>It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </p>
                                <img src="images/buser1.jpg" alt="">
                                <h4>Yair Roberto Gamboa</h4>
                            </li>
                            <li><i class="fa fa-quote-left"></i>
                                <p>It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. </p>
                                <img src="images/buser1.jpg" alt="">
                                <h4>Aaron Peñna Martin</h4>
                            </li>--%>
                        </ul>
                    </div>
                </div>
            </div>
        </section>


        <div class="gap"></div>


 
<div class="gap-30"></div>
<div class="prograss-round">
<div class="row">
<div class="col-lg-12 col-md-12">
<h2 class="main-title">Página Oficial Facebook</h2>
</div>
</div>
<div class="row">
<div class="col-lg-3 col-md-3 col-sm-6 cp_load fadeInUp">
<div id="prog1" data-dimension="300" data-text="75%" data-info="Massage" data-width="20" data-fontsize="70" data-percent="75" data-fgcolor="#58b1c3" data-bgcolor="#fff" data-fill="#e1e1e1">
</div>
</div>
<div class="col-lg-3 col-md-3 col-sm-6 cp_load fadeInUp">
<div id="prog2" data-dimension="300" data-text="84%" data-info="Facial" data-width="20" data-fontsize="70" data-percent="84" data-fgcolor="#58b1c3" data-bgcolor="#fff" data-fill="#e1e1e1"></div>
</div>
<div class="col-lg-3 col-md-3 col-sm-6 cp_load fadeInUp">
<div id="prog3" data-dimension="300" data-text="66%" data-info="Waxing" data-width="20" data-fontsize="70" data-percent="66" data-fgcolor="#58b1c3" data-bgcolor="#fff" data-fill="#e1e1e1"></div>
</div>

</div>
</div>
</div>

        <section class="blog bdetails">
            <div class="container">
                <div class="row">

                    <div class="col-lg-9 col-md-9">

                    

                        <div class="blog-comments">
                            <div>
                                <h2> Comentario</h2>
                                <ul class="comments-list">
                                 <div class="fb-comments" data-href="https://www.facebook.com/Master-Coder-580293505350746/" data-width="850" data-numposts="5"></div>
                                </ul>
                            </div>
                            <div class="hr1"></div>
                        </div>


                        


                    </div>

                    <div class="col-lg-3 col-md-3 sidebar">

                        <div class="gap-25"></div>

                   <iframe src="https://www.facebook.com/plugins/page.php?href=https%3A%2F%2Fwww.facebook.com%2FMaster-Coder-580293505350746%2F&tabs=timeline&width=400&height=400&small_header=false&adapt_container_width=false&hide_cover=false&show_facepile=true&appId" width="300" height="400" style="border:none;overflow:hidden" scrolling="no" frameborder="0" allowTransparency="true"></iframe>

                       


                        <div class="gap"></div>
                    </div>
                    </div>
                </div>
        </section>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
    <div id="fb-root"></div>
<script>(function(d, s, id) {
  var js, fjs = d.getElementsByTagName(s)[0];
  if (d.getElementById(id)) return;
  js = d.createElement(s); js.id = id;
  js.src = "//connect.facebook.net/es_LA/sdk.js#xfbml=1&version=v2.8";
  fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));</script>
</asp:Content>

