<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Calificaciones.aspx.cs" Inherits="Calificaciones.Frm_Calificaciones" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
         <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />
    <style>
        .selectedRow {
    background-color: lightgrey; 
}

    </style>
    <title>ABM Calificaciones</title>
</head>
<body>
    <form id="form1" runat="server">
           <div class="row mt-1">
<div class="col-6">
    <h3>Registro de Calificaciones</h3>
    </div>
        </div>
         <div class="row mt-1"> 
             <asp:Label ID="Label2" runat="server" Text="* Se recuerda que la nota mínima para aprobado es 4." ForeColor="#666666"></asp:Label>
             </div>
         <div class="row mt-1"> 
        <div class="col-3"> 

             <asp:DropDownList ID="ddlMateria"  Width="300" runat="server" DataSourceID="sqlDSMaterias" DataTextField="nombre" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
        </div>
              <div class="col-3"> 

      <asp:DropDownList ID="ddlAlumno" Width="300" runat="server" DataSourceID="sqlDSAlumnos" DataTextField="Estudiante" DataValueField="id" AutoPostBack="True"></asp:DropDownList>
 </div>
                <div class="col-2">  <asp:Label Width="100" ID="Label1" runat="server" Text="Calificación:"></asp:Label>
                    <asp:TextBox Width="60" ID="txtCalificacion" MaxLength="2"  type="number" runat="server" OnTextChanged="txtCalificacion_TextChanged" TextMode="Number" ></asp:TextBox>
                </div>
               <div class="col-1">  
                   <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" />

  </div>
                            <div class="col-1">  
                   <asp:Button ID="btnEditar" runat="server" Text="Editar" OnClick="btnEditar_Click"  />

  </div>

             <div class="col-1"> 
                  <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Frm_Principal.aspx">Volver</asp:HyperLink>

             </div>

         </div>
                  <div class="row mt-1"> 
              <h5 style="color:dimgray">Listado de Calificaciones</h5>
          </div>
  <div class="row mt-1"> 
        <div class="col-12">
                <asp:Label ID="lblIdCalificacion" runat="server" Text="0" Visible="False"></asp:Label>
      <asp:GridView ID="DVCalificaciones" Width="1000" AutoGenerateColumns="false" runat="server" OnRowDataBound="DVCalificaciones_RowDataBound" OnRowCommand="DVCalificaciones_RowCommand">
           
  <Columns>
           <asp:TemplateField HeaderText="Id Calificación">
         <ItemTemplate>
             <asp:Label ID="lblidCalificacion" runat="server" Text='<%#Eval("idCalificacion")%>'></asp:Label>
         </ItemTemplate>
     </asp:TemplateField>
            <asp:TemplateField HeaderText="Id Estudiante">
    <ItemTemplate>
        <asp:Label ID="lblidEstudiante" runat="server" Text='<%#Eval("idEstudiante")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                  <asp:TemplateField HeaderText="Id Materia">
    <ItemTemplate>
        <asp:Label ID="lblIdMateria" runat="server" Text='<%#Eval("idMateria")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                  <asp:TemplateField HeaderText="Materia">
    <ItemTemplate>
        <asp:Label ID="lblMateria" runat="server" Text='<%#Eval("Materia")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                      <asp:TemplateField HeaderText="Estudiante">
    <ItemTemplate>
        <asp:Label ID="lblEstudiante" runat="server" Text='<%#Eval("Estudiante")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                     <asp:TemplateField HeaderText="Nota">
    <ItemTemplate>
        <asp:Label ID="lblNota" runat="server" Text='<%#Eval("Nota")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
                           <asp:TemplateField HeaderText="Calificación">
    <ItemTemplate>
        <asp:Label ID="lblCalificacion" runat="server" Text='<%#Eval("Calificacion")%>'></asp:Label>
    </ItemTemplate>
</asp:TemplateField>
        <asp:TemplateField HeaderText="Acciones">
            <ItemTemplate>
                    <table>
        <tr>
            <td>
                      <div style="text-align: center">
           <asp:ImageButton AutoPostBack="True" title="Seleccionar Fila" ImageUrl="~/Images/seleccionar.png"  Width="25" ID="btnSeleccionar" runat="server" 
              CausesValidation="false" CommandName="seleccionar" CommandArgument='<%# Eval("idCalificacion") + "," + Eval("idEstudiante") + "," + Eval("idMateria") + "," + Eval("Nota") %>' />
       
      </div>
                </td>
            <td>
                                    <div style="text-align: center">
      <asp:ImageButton title="Eliminar Fila" ImageUrl="~/Images/borrar.png"  Width="25" ID="btnBorrar" runat="server" 
         CausesValidation="false" CommandName="borrar" CommandArgument='<%# Eval("idCalificacion") + "," + Eval("idEstudiante") + "," + Eval("idMateria") + "," + Eval("Estudiante") %>' />
 </div>
            </td>
            </tr>
                </table>
          

            </ItemTemplate>
    
        </asp:TemplateField>
        </Columns>
      </asp:GridView>
  </div>
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
       <%-- <script src="https://unpkg.com/sweetalert/dist/sweetalert.min.js"></script>--%>
           <asp:SqlDataSource ID="sqlDSMaterias" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" SelectCommand="SELECT [id], [nombre] FROM [Materias]"></asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlDSAlumnos" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" SelectCommand="SELECT [id], [apellido] + ' ' + [nombre] as Estudiante FROM [Estudiantes]"></asp:SqlDataSource>
           <asp:SqlDataSource ID="sqlDSCalificaciones" runat="server" ConnectionString="<%$ ConnectionStrings:conexion %>" DeleteCommand="DELETE FROM [Calificaciones] WHERE [id] = @id" InsertCommand="INSERT INTO [Calificaciones] ([idEstudiante], [idMateria], [int]) VALUES (@idEstudiante, @idMateria, @int)" SelectCommand="SELECT [idEstudiante], [idMateria], [int], [id] FROM [Calificaciones]" UpdateCommand="UPDATE [Calificaciones] SET [idEstudiante] = @idEstudiante, [idMateria] = @idMateria, [int] = @int WHERE [id] = @id">
               <DeleteParameters>
                   <asp:Parameter Name="id" Type="Int32" />
               </DeleteParameters>
               <InsertParameters>
                   <asp:ControlParameter ControlID="ddlAlumno" Name="idEstudiante" PropertyName="SelectedValue" Type="Int32" />
                   <asp:ControlParameter ControlID="ddlMateria" Name="idMateria" PropertyName="SelectedValue" Type="Int32" />
                   <asp:ControlParameter ControlID="txtCalificacion" Name="int" PropertyName="Text" Type="Int32" />
               </InsertParameters>
               <UpdateParameters>
                   <asp:Parameter Name="idEstudiante" Type="Int32" />
                   <asp:Parameter Name="idMateria" Type="Int32" />
                   <asp:Parameter Name="int" Type="Int32" />
                   <asp:Parameter Name="id" Type="Int32" />
               </UpdateParameters>
           </asp:SqlDataSource>
    </form>

                 </body>
</html>
