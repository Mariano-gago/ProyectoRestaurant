<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NuevaOrden.aspx.cs" Inherits="Proyect_Restaurant.Sections.NuevaOrden.NuevaOrden" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Css/Variables.css" rel="stylesheet" />
    <link href="../../Content/NuevaOrden.css" rel="stylesheet" />
    <asp:HiddenField ID="token" runat="server" />

    <div class="container">
        <div class="row">
            <div>
                <label>Mesa:</label>
                <input class="inputMesa" id="mesa" type="text" class="form-control" />
            </div>
        </div>
        <div class="btn-productos">
            <button type="button" id="btnBebidas" class="btn btn-primary">Bebidas</button>
            <button type="button" id="btnEntradas" class="btn btn-primary" value="Entradas">Entradas</button>
            <button type="button" id="btnPlato" class="btn btn-primary" value="Plato Principal">Plato Principal</button>
            <button type="button" id="btnGuarniciones" class="btn btn-primary" value="Guarniciones">Guarniciones</button>
            <button type="button" id="btnPostres" class="btn btn-primary" value="Postres">Postres</button>
        </div>
        <section id="productos">
            <div class="contenido">
            </div>
        </section>

    </div>
    <section id="pedido">
        <div class="contenido row">
        </div>
    </section>





    <script src="../../Scripts/NuevaOrden/NuevaOrden.js"></script>

</asp:Content>
