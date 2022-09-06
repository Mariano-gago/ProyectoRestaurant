<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarCuentaFin.aspx.cs" Inherits="Proyect_Restaurant.Sections.RecuperarCuenta.RecuperarCuentaFin" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        @import url('https://fonts.googleapis.com/css2?family=Kavoon&family=Lobster&family=Noto+Sans:wght@300;400;800&display=swap');
    </style>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Css/Login.css" rel="stylesheet" />
    <title></title>
</head>
<body>

    <div class="container ">
        <section class="img-bg">
            <div class="card card-container">
                <h3 style="color:white;" >Recuperar Cuenta</h3>
                <form class="form-signin" runat="server">

                    <asp:Label ID="Password" runat="server" Text="Ingresa la nueva contraseña" Style="color: white; font-size: 15px"></asp:Label>
                    <asp:TextBox ID="PasswordText" type="password" class="form-control" placeholder="Ingresa tu contraseña" runat="server" ></asp:TextBox>
                    

                     <asp:Label ID="Password2" runat="server" Text="Ingrese nuevamente la contraseña" Style="color: white; font-size: 15px"></asp:Label>
                    <asp:TextBox ID="PasswordText2" type="password" class="form-control" placeholder="Ingresa nuevamente tu nueva contraseña" runat="server" ></asp:TextBox>

                    <asp:Label ID="ErrorPassword" runat="server" Text="Las contraseñas no son iguales"></asp:Label>
                    <asp:Button ID="CambiarContraseña" class="btn btn-lg btn-primary btn-block btn-signin" runat="server" Text="Cambiar Contraseña" OnClick="CambiarContraseña_Click" />
                </form>
                
            </div>
        </section>
    </div>
</body>
</html>
<script src="../../Scripts/jquery-3.4.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
