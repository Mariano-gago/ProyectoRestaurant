<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PostrePrueba.aspx.cs" Inherits="Proyect_Restaurant.Sections.PostrePrueba.PostrePrueba" %>




<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <link href="../../Css/Drinks.css" rel="stylesheet" />
    <link href="../../Css/Variables.css" rel="stylesheet" />
    <asp:HiddenField ID="token" runat="server" />
    <div class="container">
        <asp:Repeater ID="BebidasPostre" runat="server">
                <ItemTemplate>
                   
                    <div class="col-lg-4 col-md-4 box">
                        <img class="image-drink" src="#" />
                        <h3>Nombre postre</h3>
                        <p>Precio postre</p>
                        <div class="quantity">
                            <asp:Button ID="btn" runat="server" Text="-" />
                            <input class="input-qty" id="Idpostre3" type="text" value="" />
                            <asp:Button ID="BtnPostre3" runat="server" Text="+" />
                        </div>
                    </div>
                </ItemTemplate>

            </asp:Repeater>

    </div>



       


            <!--
            <asp:Repeater ID="Repeater1" runat="server">
                <ItemTemplate>
                   
                    <div class="col-lg-4 col-md-4 box">
                        <img class="image-drink" src="<%# Eval("Imagen") %>" />
                        <h3><%# Eval("NombreBebida") %></h3>
                        <p><%# Eval("PrecioBebida") %></p>
                        <div class="quantity">
                            <asp:Button ID="btn" runat="server" Text="-" />
                            <input class="input-qty" id="<%#Eval("IdBebida") %>" type="text" value="" />
                            <asp:Button ID="Button" runat="server" Text="+" />
                        </div>
                    </div>
                </ItemTemplate>

            </asp:Repeater>-->
            















            <!--
             <div class="col-lg-4 col-md-4 box">
                <img class="image-drink" src="../../Img/coca-zero.jpg" />
                <h3>Coca Cola  Zero</h3>
                <p>Precio: $100</p>
                 <div class="quantity">
                    <asp:Button ID="Button3" runat="server" Text="-" />
                    <input class="input-qty" id="Text2" type="text" />
                    <asp:Button ID="Button4" runat="server" Text="+" />
                </div>  
            </div>
            

            <div class="col-lg-4 col-md-4 box">
                <img class="image-drink" src="../../Img/fanta-orange.jpg" alt="Fanta"/>
                <h3>Fanta Naranja</h3>
                <p>Precio: $100</p>
                <div class="quantity">
                    <asp:Button ID="Button5" runat="server" Text="-" />
                    <input class="input-qty" id="Text3" type="text" />
                    <asp:Button ID="Button6" runat="server" Text="+" />
                </div>            
            </div>
            
             <div class="col-lg-4 col-md-4 box">
                 <div>
                     <img class="image-drink" src="../../Img/sprite1.jpg" alt="Sprite"/>                
                <h3>Sprite</h3>
                <p>Precio: $200</p>
                 </div>
                 
                 <div class="quantity">
                    <asp:Button ID="Button7" runat="server" Text="-" />
                    <input class="input-qty" id="Text4" type="text" />
                    <asp:Button ID="Button8" runat="server" Text="+" />
                </div>  
            </div>
       </div>
       <div class="row">
            <div class="col-lg-4 col-md-4 box">
                <img class="image-drink" src="../../Img/toro-pomelo.jpg" alt="Paso de los toros pomelo" />
                <h3>Toros Pomelo</h3>
                <p>Precio: $100</p>
                <div class="quantity">
                    <asp:Button ID="Button9" runat="server" Text="-" />
                    <input class="input-qty" id="Text5" type="text" />
                    <asp:Button ID="Button10" runat="server" Text="+" />
                </div>  
            </div>
           <asp:TextBox runat="server"></asp:TextBox>
        </div>-->
    
   
</asp:Content>
