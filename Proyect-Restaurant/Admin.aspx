<%@ Page Title="My Restaurant" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="Proyect_Restaurant.Admin" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   

    <link href="Css/Variables.css" rel="stylesheet" />
    <link href="Css/Default.css" rel="stylesheet" />
    <link href="Css/Admin.css" rel="stylesheet" />
    <div class="container">
        <div class="row">

            <div class="col-lg-3">
              
             <a href="Empleados" class="box col-lg-3 col-md-3">  
               
                 <img class="icons" src="Img/UserIcon.png" />
                <h2 class="title">Empleados</h2>    
             </a>
            </div>

            <div class="col-lg-3">
                <a class="box col-lg-3 col-md-3" href="Sections/Entradas/AdministrarEntradas.aspx">
                    <img class="icons" src="Img/entradas.jpg" />
                    <h2 class="title">Entradas</h2>    
                </a>
            </div>

            <div class="col-lg-3">
                <a class="box col-lg-3 col-md-3" href="*">
                    <img class="icons" src="Img/platoPrincipal.png" />
                    <h2 class="title">Principal</h2>    
                </a>
            </div>

            <div class="col-lg-3">
                <a class="box col-lg-3 col-md-3" href="*">
                    <img class="icons" src="Img/postre.png" />
                    <h2 class="title">Postre</h2>    
                </a>
            </div>
       </div>
        <div class="row">
            <div class="col-lg-3">
                <a class="box col-lg-3 col-md-3" href="Sections/Bebidas/AdministrarBebidas">
                    <img class="icons" src="Img/bebidas.png" />
                    <h2 class="title">Bebidas</h2>
                        
                </a>
            </div>
        </div>
        
    </div>
    
</asp:Content>