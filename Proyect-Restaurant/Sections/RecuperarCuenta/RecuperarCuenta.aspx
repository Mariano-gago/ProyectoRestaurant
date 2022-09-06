<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecuperarCuenta.aspx.cs" Inherits="Proyect_Restaurant.Sections.RecuperarCuenta.RecuperarCuenta" %>



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

                    <asp:Label ID="Email" runat="server" Text="Ingresa tu Mail" Style="color: white; font-size: 15px"></asp:Label>
                    <asp:TextBox ID="EmailText" type="email" class="form-control" placeholder="Direccion de Email" runat="server" ></asp:TextBox>
                    <asp:Button ID="Button2" class="btn btn-lg btn-primary btn-block btn-signin" runat="server" Text="Enviar" OnClick="Button2_Click"/>

                     <asp:Label ID="Codigo" runat="server" Text="Ingresa el codigo enviado a tu mail" Style="color: white; font-size: 15px"></asp:Label>
                    <asp:TextBox ID="CodigoText" type="text" class="form-control" placeholder="Codigo" runat="server" ></asp:TextBox>

                    <asp:Button ID="BtnRecuperar" class="btn btn-lg btn-primary btn-block btn-signin" runat="server" Text="Recuperar" OnClick="RecuperarCuenta_Click" />
                </form>

            </div>
        </section>
    </div>
</body>
</html>
<script src="../../Scripts/jquery-3.4.1.min.js"></script>
<script src="../../Scripts/bootstrap.min.js"></script>
