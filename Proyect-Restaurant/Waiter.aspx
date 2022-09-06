<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Waiter.aspx.cs" Inherits="Proyect_Restaurant.Waiter" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">


    <link href="Css/Variables.css" rel="stylesheet" />
    <link href="Css/Default.css" rel="stylesheet" />
    <div class="container">
        <div class="row">
            <div class="col-lg-3">
                
                <a href="Sections/NuevaOrden/NuevaOrden.aspx" class="box col-lg-3 col-md-3">
                    <h2 class="title">Nuevo Pedido</h2>
                </a>
            </div>
            <div class="col-lg-3">
                <a href="*" class="box col-lg-3 col-md-3">
                    <h2 class="title">Pedidos</h2>
                </a>
            </div>

        </div>

    </div>


</asp:Content>
