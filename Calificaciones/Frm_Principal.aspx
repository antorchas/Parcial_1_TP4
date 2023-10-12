<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Frm_Principal.aspx.cs" Inherits="Calificaciones.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
     <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-T3c6CoIi6uLrA9TneNEoa7RxnatzjcDSCmG1MXxSR1GAsXEV/Dwwykc2MPK8M2HN" crossorigin="anonymous" />

    <title>Menú Principal</title>
</head>
<body>

  
    <form id="form1" runat="server">
        <div>
            <h2>Menú Principal</h2>
        </div>
        <div>
               <asp:HyperLink ID="hlMaterias" runat="server" NavigateUrl="~/Frm_Materias.aspx">ABM Materias</asp:HyperLink>
            <br />
                <asp:HyperLink ID="hlAlumnos" runat="server" NavigateUrl="~/Frm_Estudiantes.aspx">ABM ALumnos</asp:HyperLink>
             <br />
                <asp:HyperLink ID="hlCalificaciones" runat="server" NavigateUrl="~/Frm_Calificaciones.aspx">ABM Calificaciones</asp:HyperLink>
        </div>
    </form>
             <script src="https://code.jquery.com/jquery-3.6.0.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.2/dist/js/bootstrap.bundle.min.js" integrity="sha384-C6RzsynM9kWDrMNeT87bh95OGNyZPhcTNXj1NW7RuBCsyN/o0jlpcV8Qyq46cDfL" crossorigin="anonymous"></script>

</body>
</html>
