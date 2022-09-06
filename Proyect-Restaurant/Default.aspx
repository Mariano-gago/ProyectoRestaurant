<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Proyect_Restaurant._Default" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <style>@import url('https://fonts.googleapis.com/css2?family=Kavoon&family=Lobster&family=Noto+Sans:wght@300;400;800&display=swap');</style>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Css/Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>
       
    <div class="container " >
        <section class="img-bg">
            <div class="card card-container">
                <img id="profile-img" class="profile-img-card" src="//ssl.gstatic.com/accounts/ui/avatar_2x.png" />
                <form class="form-signin" runat="server">
                    

                    <asp:TextBox ID="txtEmail" type="email" class="form-control" placeholder="Direccion de Email" runat="server" require></asp:TextBox>
                    <asp:TextBox ID="txtPassword" type="password" class="form-control" placeholder="Contraseña" runat="server" require></asp:TextBox>
                    <asp:Label ID="lblError" runat="server" Text="Mail o Contraseña incorrecta" Style="color:red; font-size:15px" Visible="false"></asp:Label>

                    <div id="remember" class="checkbox">
                        <label class="checkbox-label" style="color:white;">
                            <input type="checkbox" value="remember-me"/>Recuerdame
                        </label>
                    </div>
                    <asp:Button ID="btnIniciar" class="btn btn-lg btn-primary btn-block btn-signin" runat="server" Text="Iniciar Sesion" OnClick="btnIniciar_Click" />
                </form> 
                <a href="Sections/RecuperarCuenta/RecuperarCuenta.aspx" class="forgot-password">Olvidaste tu contraseña</a>             
            </div>
        </section>
    </div>        
</body>
</html>
