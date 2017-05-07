<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InicioSesion.aspx.cs" Inherits="MCTuristic_Centro_Historico.GUI.InicioSesion" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Login</title>
    <link href="../Recursos/Login/css/style.css" rel="stylesheet" />
  <%--  [if lte IE 9]><link rel="stylesheet" href="assets/css/ie9.css" /><![endif]--%>

    <script src="../Recursos/dist/sweetalert.min.js"></script>
    <link href="../Recursos/dist/sweetalert.css" rel="stylesheet" />

<script type="text/javascript">
function validar(e) {
  tecla = (document.all) ? e.keyCode : e.which;
  if (tecla == 13) document.getElementById('txtContraseña').focus();
}
</script>
   <script>
    function button_click(objTextBox,objBtnID)
    {
        if(window.event.keyCode==13)
        {
           
        }
    }

    function ErrorLogin()
    {
        sweetAlert("Oops...", "Al parecer tu usuario y contraseña no coinciden vuelve a intentar", "error");
    }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
<link href='https://fonts.googleapis.com/css?family=Work+Sans:400,300,700' rel='stylesheet' type='text/css'/>
<div class="container">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <div class="profile">
    <button class="profile__avatar" id="toggleProfile">
     <img src="https://pbs.twimg.com/profile_images/554631714970955776/uzPxPPtr.jpeg" alt="Avatar" /> 
    </button>
    <div class="profile__form">
     <asp:Panel ID="Panel1" runat="server" DefaultButton="btnIngresar">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
         <ContentTemplate>
             <div class="field">
        <asp:TextBox ID="txtEmail" runat="server" class="input" required pattern=.*\S.*></asp:TextBox>
          <label for="fieldUser" class="label">Email</label>
        </div>
        <div class="field">
            <asp:TextBox   type="password" ID="txtContraseña" runat="server" class="input"  required pattern=.*\S.* ></asp:TextBox>
          <label for="fieldPassword" class="label">Contraseña</label>
        </div>
       
       </ContentTemplate>
      </asp:UpdatePanel>
    </asp:Panel>
        <div class="profile__footer">
            <asp:Button class="btn" ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
        </div>
         
    
     </div>
  </div>


</div>

     <asp:HyperLink  CssClass="btn fixed-action-btn btn btn--s"  NavigateUrl="~/GUI/PagPrincipal.aspx"  BackColor="#e91e63" ForeColor="White" Height="40px" Width="7%" ID="HyperLink1" runat="server" Font-Italic="False">Inicio</asp:HyperLink>
     <script src="../Recursos/Login/js/index.js"></script>
        
    </div>
    </form>
</body>
</html>
