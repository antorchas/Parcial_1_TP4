<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Estudiantes.aspx.cs" Inherits="Calificaciones.Frm_Estudiantes" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
         <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />

    <title>ABM Estudiantes</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="row mt-1">
    <div class="col-6">
        <h3>Registro de Estudiantes</h3>
        </div>
            </div>
               <div class="row mt-1">
   <div class="col-4">
       <asp:TextBox ID="txtNombre" Width="350px" placeholder="Nombre del Estudiante" runat="server" MaxLength="50"></asp:TextBox>
       </div>
                   <div class="col-4">
    <asp:TextBox ID="txtApellido" Width="350px" placeholder="Apellido del Estudiante" runat="server" MaxLength="50"></asp:TextBox>
    </div>
                      <div class="col-4">
                          <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />
                          <asp:HyperLink ID="hlVolver" runat="server" NavigateUrl="~/Frm_Principal.aspx">Volver</asp:HyperLink>
       </div>
                 
           </div>
       <div class="row mt-1"> 

           <asp:Label ID="lblInfo" runat="server" Text=""></asp:Label>
       </div>
                    <div class="row mt-1"> 
                        <h5 style="color:dimgray">Listado de Estudiantes Registrados</h5>
                    </div>
            <div class="row mt-1"> 
                <asp:GridView ID="gvEstudiantes" Width="600px" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDSEstudiantes" OnRowDeleting="VerificarRelacion">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                        <asp:BoundField DataField="apellido" HeaderText="Apellido" SortExpression="apellido" />
                        <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
                        <asp:CommandField ButtonType="Button" ShowDeleteButton="True" ShowEditButton="True" />
                    </Columns>
                </asp:GridView>
           </div>
                 <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>
     <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
               <script>
           function Mensaje(title, msj, icon) {
               Swal.fire({
                   position: 'center',
                   icon: icon,
                   title: title,
                   text: msj,
                 
               })
           }

               </script>
        <asp:SqlDataSource ID="SqlDSEstudiantes" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" DeleteCommand="DELETE FROM [Estudiantes] WHERE [id] = @id" InsertCommand="INSERT INTO [Estudiantes] ([apellido], [nombre]) VALUES (@apellido, @nombre)" SelectCommand="SELECT [id], [apellido], [nombre] FROM [Estudiantes]" UpdateCommand="UPDATE [Estudiantes] SET [apellido] = @apellido, [nombre] = @nombre WHERE [id] = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:ControlParameter ControlID="txtApellido" Name="apellido" PropertyName="Text" Type="String" />
                <asp:ControlParameter ControlID="txtNombre" Name="nombre" PropertyName="Text" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="apellido" Type="String" />
                <asp:Parameter Name="nombre" Type="String" />
                <asp:Parameter Name="id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
                 </body>
</html>
