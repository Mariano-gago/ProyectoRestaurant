<%@ Page Title="Entradas" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="AdministrarEntradas.aspx.cs" Inherits="Proyect_Restaurant.AdministrarEntradas" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <link href="../../Content/Entradas.css" rel="stylesheet" />
    <asp:HiddenField ID="idEntrada" runat="server" />   
    <asp:HiddenField ID="idBebida" runat="server" />
    <asp:HiddenField ID="token" runat="server" />

    <div class="panel panel-default" style="margin-top:50px 0;">
        <div class="panel-heading">Usuarios</div>
        <div class="panel-body">
            <a id="btnNuevoEntrada" class="btn btn-primary" >Nuevo Entrada</a>
            <table id="tableEntradas" class="table table-striped table-bordered" style="width:100%" cellspancing="0">               
                <thead>
            
            </table>
        </div>
     </div>



   
    
    
        <!-- Modal Entradas Guardar Editar-->
        <div class="modal fade" id="EntradasModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Alta / Edicion Entradas</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="Nombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="NombreEntradaText" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <asp:Label ID="Precio" runat="server" Text="Precio"></asp:Label>
                        <asp:TextBox ID="PrecioNumber" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="Imagen" runat="server" Text="Imagen"></asp:Label>
                        <asp:TextBox ID="ImagenEntrada" class="form-control" runat="server"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-check">
                        <asp:Label ID="Active" runat="server" Text="Active" class="form-check-label"></asp:Label>
                        <asp:CheckBox ID="ActivoEntradaCheck" runat="server" class="form-check-input" />
                    </div> 
                </div>                    
              </div>
              
              <div class="modal-footer">
                 
                 <asp:Button ID="btnGuardar" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                 <asp:Button ID="btnEditar" class="btn btn-warning" runat="server" Text="Editar" OnClick="btnEditar_Click" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                
              </div>
            </div>
          </div>
           
        </div>
    
    <!-- Modal Eliminar Entradas-->
        <div class="modal fade" id="eliminarEntradasModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalEliminar">Eliminar Entradas</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <h3> Esta seguro que desea eliminar el Entrada?</h3>
              <div class="modal-footer">
                  
                <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                  
              </div>
            </div>
          </div>          
        </div>
       </div>    
    
    <script src="../../Scripts/Entradas/Entradas.js"></script>
</asp:Content>

