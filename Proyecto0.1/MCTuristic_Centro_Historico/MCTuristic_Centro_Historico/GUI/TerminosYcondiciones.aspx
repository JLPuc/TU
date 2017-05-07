<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PaginaPrincipal.Master" AutoEventWireup="true" CodeBehind="TerminosYcondiciones.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.TerminosYcondiciones" %>
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



        </div>

</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="Contenido" runat="server">
    






    <div class="container" style="margin-top:120px">
           <h1><font><font>Términos y condiciones de uso</font></font></h1>
        <br />
        <br />
    <div class="row">
        <div class="col-lg-12">
<h2><b>A. INTRODUCCIÓN A NUESTROS SERVICIOS</b></h2>
<h4>Este Acuerdo gobierna su uso de los servicios de Master Coder ("Servicios") mediante los cuales puede comprar, obtener, licenciar, alquilar o subscribirse (cuando sea posible) a medios, aplicaciones y otros servicios. Nuestro Servicio es: MCTuristic (Master Code Turistic).  Nuestros Servicios están disponibles para su uso en su país de residencia. Para usar nuestros servicios, necesita hardware y software compatible (se recomienda tener la última versión y en algunos casos es necesario) y acceso a Internet (podrán aplicarse cargos). El rendimiento de nuestro servicio podrá verse afectado por estos factores.</h4>
    <br /><br />
    <h2><b>B. USO DE NUESTROS SERVICIOS</b></h2><br />
<h3><b>PAGOS, IMPUESTOS Y DEVOLUCIONES</b></h3>
<h4>Puede adquirir contenidos extras en nuestros servicios de forma gratuita o de pago, ambos referidos como "Transacción". Cada transacción es un contrato electrónico entre usted y Master Coder, y/o usted y la entidad que proporciona el contenido en nuestros servicios. Sin embargo, si usted es cliente de Master coder y compra una aplicación, Master Coder no será el comerciante oficial; esto significa que usted compra el contenido de la entidad que está registrada en nuestra empresa y este es licenciado por el proveedor de la empresa externa. Cuando realice su primera transacción, le pediremos que elija la frecuencia con la que debemos pedirle su contraseña en futuras transacciones.</h4>
<br />
<h3><b>PRIVACIDAD</b></h3>
<h4>El uso de sus servicios está sujeto a la política de privacidad de Master Coder</h4>

<h4>Tu privacidad es importante para Master Coder. Por esta razón se ha desarrollado una Política de Privacidad en la que se describe cómo se recopilan, utilizan, revelan, transfieren y almacenan tus datos. Dedica un momento a conocer las prácticas de privacidad.</h4>
            <br />
<h3><b>Recopilación y uso de los datos de carácter personal</b></h3>
<h4>Se considera información personal cualquier dato que pueda utilizarse para identificar a una persona en particular o ponerse en contacto con ella. <br /><br />
Es posible que tengas que proporcionar datos de carácter personal cuando contactes con Master Coder o con alguna de sus empresas afiliadas. Master Coder y sus empresas afiliadas podrán compartir los datos de carácter personal y utilizarlos de acuerdo con la presente Política de Privacidad. Asimismo, pueden combinarlos con otros datos para suministrar y mejorar productos, servicios, contenidos y anuncios publicitarios. No estás obligado a facilitar la información personal que te soliciten pero, si decides no proporcionarla, habrá muchas ocasiones en las que no podrás utilizar los productos ni servicios, o no recibirás respuestas a las preguntas que pudieras tener. <br /> <br />
A continuación se muestran algunos ejemplos de los tipos de información personal que Master Coder puede recopilar y los posibles usos que puede darle:
            <br />
    <br />  
<b>Qué datos de carácter personal se recopilan</b><br />
    <br />
	Cuando creas un usuario de nuestra página MCTuristic te podrás poner en contacto con Master Coder o participas en una encuesta online, se pueden recopilar diferentes datos, como tu nombre, dirección postal, número de teléfono, dirección de correo electrónico, preferencias de contacto o algún otro dato menor que será tomado en cuenta.<br />
    <br />
	Cuando compartes contenido con tus amigos y familiares mediante productos Master Coder , envías ubicaciones, o invitas a terceros a participar en aplicaciones Master Coder, Master Coder puede recopilar la información que facilitas sobre esas personas, como su nombre, dirección postal, dirección de correo electrónico y número de teléfono. Master Coder utilizará dichos datos para completar tus pedidos, ofrecerte el producto o servicio que corresponda o para fines de lucha contra el fraude.<br />
    <br />
	En determinadas jurisdicciones, se te puede solicitar una identificación emitida por el gobierno en circunstancias muy concretas, como cuando configuras una cuenta de conexión inalámbrica y activas tu dispositivo, para ampliar un crédito comercial, para gestionar reservas o por imperativo legal.<br />
    <br />
    <br />
<b>Cómo se usa tu información personal</b><br />
    <br />
	Los datos de carácter personal que se recopilan permiten mantenerte informado acerca de los productos más recientes de Master Coder, las actualizaciones de software disponibles y los próximos eventos. Si no deseas formar parte de la lista de distribución, puedes darte de baja en cualquier momento actualizando tus preferencias.<br />
    <br />
	Los datos de carácter personal también ayudan a crear, desarrollar, gestionar, entregar y mejorar los productos, servicios, contenidos y anuncios publicitarios, además de evitar pérdidas y fraudes.<br />
    <br />
	Es posible que se usen tus datos de carácter personal, incluida la fecha de nacimiento, para verificar la identidad, colaborar en la identificación de usuarios y determinar los servicios apropiados. Por ejemplo, se puede usar la fecha de nacimiento para determinar la edad de los titulares de cuentas de Master Coder.<br />
    <br />
	Ocasionalmente es posible que se usen tus datos de carácter personal para enviarte notificaciones importantes, como comunicaciones acerca de lugares cercanos y modificaciones de las condiciones y políticas. Como esta información es fundamental para tu interacción con Master Coder, no puedes optar por rechazar la recepción de estas comunicaciones.<br />
    <br />
	También se pueden utilizar tus datos de carácter personal para fines internos, incluyendo auditorías, análisis de datos e investigaciones, con el fin de mejorar los productos, servicios y comunicaciones a clientes de Master Coder.</h4>            
    <br />
<h3><b>Protección de los datos de carácter personal</b></h3>
            <br />
<h4>Master Coder se toma muy en serio la seguridad de tus datos de carácter personal. Los servicios online de Master Coder, como MCTuristic protegen tus datos de carácter personal durante el tránsito mediante cifrado como, por ejemplo, Transport Layer Security (TLS). Cuando Master Coder almacena tus datos personales, se utilizan sistemas informáticos con acceso limitado alojados en instalaciones con medidas de seguridad físicas. Los datos de iCloud se almacenan de forma cifrada, incluso cuando se utiliza el almacenamiento de terceros.
Al utilizar determinados productos, servicios o aplicaciones de Master Coder o al publicar entradas en foros, salas de chat o redes sociales, el contenido y los datos de carácter personal que compartas serán visibles para otros usuarios, que podrán leerlos, recopilarlos o utilizarlos. En estos casos, tú eres el responsable de los datos de carácter personal que decides compartir o enviar. Por ejemplo, si escribes tu nombre y dirección de correo electrónico en un foro, dicha información será pública. Es recomendable tener cuidado al usar estas prestaciones.
Si tú, o cualquier persona de tu grupo que utilice en familia, inicias sesión en un dispositivo que pertenece a un tercero, cualquier información compartida en tu en familia (como calendarios, ubicaciones, fotos) podría descargarse a dicho dispositivo ajeno, divulgándose así la información que compartes.
</h4>
            <br />
     <h3><b>Servicios de localización</b></h3><br />
<h4>Para prestar servicios de localización en relación con productos de Master Coder, tanto nosotros como nuestros socios podrán recopilar, utilizar y compartir datos precisos sobre localizaciones, incluyendo la localización geográfica en tiempo real de tu ordenador o dispositivo. Si están disponibles, los servicios de localización pueden usar tecnología GPS, Bluetooth y tu dirección IP, junto con localizaciones de puntos de acceso Wi-Fi procedentes de la recopilación masiva y de torres de telefonía móvil, además de otras tecnologías, para determinar la ubicación aproximada de tus dispositivos. Salvo que des tu consentimiento, estos datos de localización se recogen de manera anónima de tal forma que no puedan utilizarse para identificarte personalmente, y son utilizados por Master Coder y sus socios para suministrar y mejorar sus productos y servicios de localización. Por ejemplo, tu dispositivo puede compartir su ubicación geográfica con proveedores de aplicaciones si aceptas participar en sus servicios de localización.
</h4><br />
<h3><b>REGLAS DE USO DE SERVICIOS Y CONTENIDOS</b></h3>
            <br />
<h4>Su uso de los servicios y contenidos deberá cumplir con las reglas establecidas en esta sección ("Reglas de uso"). Cualquier otro uso de los servicios y contenidos será un incumplimiento sustancial de este Acuerdo. Master Coder podrá supervisar su uso de los servicios y contenidos para garantizar que cumple estas reglas de uso.

<br />
    <br />
    <b>Todos los Servicios</b><br />
- Puede usar los Servicios y Contenidos solo para fines personales y no comerciales (excepto por lo establecido en la sección Contenidos mas adelante).
- La entrega de contenidos de Master Coder no le transfiere ningún derecho de uso promocional y no constituirá la concesión o renuncia de los derechos de los propietarios de copyright.
- No podrá alterar o evitar ninguna tecnología de seguridad incluida con los Servicios.
- Podrá acceder a nuestros Servicios usando solamente el software establecidos y no podrá modificar o usar versiones modificadas de dicho software.
    <br />
    <br /><b>SUSCRIPCIONES</b><br />
Los servicios y ciertas aplicaciones podrían permitirle adquirir acceso a contenidos o servicios por suscripción ("Suscripciones de pago"). Las suscripciones de pago se renuevan automáticamente hasta que se cancelen en la sección gestionar suscripciones de los ajustes de su cuenta. Le notificaremos si el precio de una suscripción de pago aumenta y, si es necesario, le pediremos su consentimiento para continuar. Se le cobrará durante las 24 horas antes al inicio del último periodo de suscripción de pago. Algunas suscripciones de pago pueden ofrecen un periodo de evaluación gratuita antes de cobrar su método de pago. Si decide darse de baja de una suscripción de pago antes de que empecemos a cobrar en su método de pago, cancele la suscripción antes de que acabe la evaluación gratuita.
MANTENIMIENTO Y SOPORTE DE MASTER CODER
Master Coder es responsable de proporcionar mantenimiento y soporte solo para Aplicaciones de nuestra fabricación o según la ley lo requiera. 
<br /><br /><b>TERMINACIÓN Y SUSPENSIÓN DE LOS SERVICIOS</b><br />
Si usted no cumple, o Master Coder sospecha que no ha cumplido, alguna de las disposiciones de este Acuerdo, nosotros, podremos, sin aviso alguno:
<br />(i)	terminar este Acuerdo y/o cancelar su usuario registrado, y usted será responsable por la cantidad completa debida en su usuario hasta, e incluida, la fecha de terminación;
<br />(ii)	y/o terminar su licencia al software; 
<br />(iii)	y/o  descartar su acceso a los Servicios.
Master Coder se reserva el derecho de modificar, suspender o interrumpir los servicios (o cualquier parte o contenido de los mismos) en cualquier momento, con o sin aviso, y también no seremos responsables con respecto a usted o terceros en caso de ejercitar dichos derechos.
</h4>
        </div>
    </div>
    </div>
    <div class="gap"></div>
</asp:Content>
<asp:Content ID="Content5" ContentPlaceHolderID="scrip" runat="server">
</asp:Content>
