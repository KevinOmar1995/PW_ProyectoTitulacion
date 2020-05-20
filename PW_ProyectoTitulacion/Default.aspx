<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PW_ProyectoTitulacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/jquery.dropdownPlain.js"></script>
    <link href="css/bootstrap1.css" rel="stylesheet" />
    <script type="text/javascript">
        function show(obj) {
            var GvCalificacion = document.getElementById(obj);
            var imageID = document.getElementById('imagen' + obj);
            if (GvCalificacion.style.display == "none") {
                GvCalificacion.style.display = "inline";
                imageID.src = "./assets/css/images/arriba.png";
            }
            else {
                GvCalificacion.style.display = "none";
                imageID.src = "./assets/css/images/abajo.png";
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phBody" runat="server">

    <asp:GridView ID="GvCalificaciones" runat="server" AutoGenerateColumns="False" DataKeyNames="idAlumno" DataSourceID="sdsAlumnos" GridLines="None" CssClass="table table-striped" OnRowDataBound="GvCalificaciones_RowDataBound">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='javascript:show("alumno_<%# Eval("idAlumno")%>");'>
                        <img id='imagenalumno_<%# Eval("idAlumno") %>' alt="clic para mostrar u ocultar" src="assets/css/images/abajo.png" width="18px" height="18px" />
                    </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="idAlumno" HeaderText="idAlumno" InsertVisible="False" ReadOnly="True" SortExpression="idAlumno" Visible="false" />
            <asp:BoundField DataField="nombre" HeaderText="Nombre" SortExpression="nombre" />
            <asp:BoundField DataField="grado" HeaderText="Grado" SortExpression="grado" />
            <asp:BoundField DataField="grupo" HeaderText="Grupo" SortExpression="grupo" />
            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan='200%'>
                            <div id='alumno_<%# Eval("idAlumno") %>' style="display: none;">
                                <asp:GridView ID="gvCalificacion" runat="server" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:BoundField DataField="nombre" SortExpression="nombre" />
                                        <asp:BoundField DataField="resultado" SortExpression="resultado" />
                                        <asp:BoundField DataField="IdAlumno" HeaderText="IdAlumno" SortExpression="IdAlumno" Visible="false" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </td>
                    </tr>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sdsAlumnos" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenTest %>" SelectCommand="Select idAlumno,nombre,grado,grupo from Alumnos where idMaestro = @maestro">
        <SelectParameters>
            <asp:SessionParameter Name="maestro" SessionField="IdMaestro" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsCalificacion" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenTest %>" SelectCommand="Select nombre,resultado,IdAlumno from Examenes left join ExamenAlumno on Examenes.idExamen = ExamenAlumno.idExamen"></asp:SqlDataSource>
</asp:Content>
