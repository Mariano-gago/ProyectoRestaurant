<%@ Page Title="Empleados" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Empleados.aspx.cs" Inherits="Proyect_Restaurant.Emplados" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:HiddenField ID="idEmpleado" runat="server" />
    <asp:HiddenField ID="idBebida" runat="server" />
    <asp:HiddenField ID="token" runat="server" />

    <div class="panel panel-default" style="margin-top:50px 0;">
        <div class="panel-heading">Usuarios</div>
        <div class="panel-body">
            <a id="btnNuevoEmpleado" class="btn btn-primary" >Nuevo Empleado</a>
            <table id="tableEmpleados" class="table table-striped table-bordered" style="width:100%" cellspancing="0">               
                <thead>
            
            </table>
        </div>
     </div>



   
    
    
        <!-- Modal Empleados Guardar Editar-->
        <div class="modal fade" id="empleadosModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabel">Alta / Edicion Empleados</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="Nombre" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="NombreText" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-6 form-group">
                        <asp:Label ID="Apellido" runat="server" Text="Apellido"></asp:Label>
                        <asp:TextBox ID="ApellidoText" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                  <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="Telefono" runat="server" Text="Telefono"></asp:Label>
                        <asp:TextBox ID="TelefonoText" type="number" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-6 form-group">
                        <asp:Label ID="Mail" runat="server" Text="Mail"></asp:Label>
                        <asp:TextBox ID="MailText" type="email" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                  <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="Password" runat="server" Text="Pasword"></asp:Label>
                        <asp:TextBox ID="PasswordText"  class="form-control" runat="server"></asp:TextBox>
                    </div>
                      <div class="col-md- form-group">
                        <asp:Label ID="Rol" runat="server" Text="Roles"></asp:Label>
                        <asp:DropDownList ID="RolDrop" class="form-control" runat="server">
                        </asp:DropDownList>
                    </div>                    
                </div>

                  <div class="row">
                      <div class="col-md-6 form-group">
                        <asp:Label ID="Active" runat="server" Text="Active" class="form-check-label"></asp:Label>
                        <asp:CheckBox ID="ActivoCheck" runat="server" class="form-check-input" />
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

    <!-- Modal Eliminar Empleados-->
        <div class="modal fade" id="eliminarEmpleadosModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalEliminar">Eliminar Empleados</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <h3> Esta seguro que desea eliminar el Empleado?</h3>
              <div class="modal-footer">
                  
                <asp:Button ID="btnEliminar" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                  
              </div>
            </div>
          </div>          
        </div>
       </div>
    



     <!-- Modal Bebidas Guardar Editar-->
        <div class="modal fade" id="bebidasModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalLabelBebidas">Alta / Edicion Bebidias</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="NombreBebida" runat="server" Text="Nombre"></asp:Label>
                        <asp:TextBox ID="NombreBebidaText" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-6 form-group">
                        <asp:Label ID="PrecioBebida" runat="server" Text="Precio"></asp:Label>
                        <asp:TextBox ID="PrecioBebidaText" type="number" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>

                  <div class="row">
                    <div class="col-md-6 form-group">
                        <asp:Label ID="StockBebida" runat="server" Text="Stock"></asp:Label>
                        <asp:TextBox ID="StockBebidaText" type="number" class="form-control" runat="server"></asp:TextBox>
                    </div>

                    <div class="col-md-6 form-group">
                        <asp:Label ID="ImagenBebida" runat="server" Text="Imagen"></asp:Label>
                        <asp:TextBox ID="ImagenBebidaText" type="file" class="form-control" runat="server"></asp:TextBox>
                    </div>
                </div>
              </div>
              <div class="modal-footer">
                 
                 <asp:Button ID="btnGuardarBebida" class="btn btn-primary" runat="server" Text="Guardar" OnClick="btnGuardarBebida_Click" />
                 <asp:Button ID="btnEditarBebida" class="btn btn-secondary" runat="server" Text="Editar" OnClick="btnEditarBebida_Click" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                
              </div>
            </div>
          </div>
            
        </div>

    <!-- Modal Eliminar Bebidas-->
        <div class="modal fade" id="eliminarBebidasModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
          <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <h5 class="modal-title" id="exampleModalEliminarBebidas">Eliminar Bebidas</h5>
                <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                  <span aria-hidden="true">&times;</span>
                </button>
              </div>
              <div class="modal-body">
                <h3> Esta seguro que desea eliminar la Bebida?</h3>
              <div class="modal-footer">
                  
               <asp:Button ID="btnEliminarBebida" class="btn btn-danger" runat="server" Text="Eliminar" OnClick="btnEliminarBebida_Click" />
                <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                  
              </div>
            </div>
          </div>          
        </div>
       </div>
   
    
    
    
    <script src="Scripts/Empleados/Empleados.js"></script>
    <script src="Scripts/Bebidas/BebidasAdmin.js"></script>
</asp:Content>

