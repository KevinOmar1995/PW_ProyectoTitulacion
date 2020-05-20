<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_EvaluacionesPendientes.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_EvaluacionesPendientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table table-condensed table-hover" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TipId" DataSourceID="sqlEvaluaciones">
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpCedula" HeaderText="Cedula" SortExpression="EmpCedula" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" ReadOnly="True" SortExpression="Nombres" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellido" ReadOnly="True" SortExpression="Apellido" />
            <asp:BoundField DataField="evaResultado" HeaderText="Resultado" visible="false" SortExpression="evaResultado" />
            <asp:BoundField DataField="TipId" HeaderText="TipId" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="TipId" />
        </Columns>

    </asp:GridView>


    <asp:SqlDataSource ID="sqlEvaluaciones" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEmpleado.EmpCedula, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS Nombres, OCKO_TblEmpleado.EmpPrimerApellido + ' ' + OCKO_TblEmpleado.EmpSegundoApellidos AS Apellido, OCKO_TblEvaluacionEmpleado.evaResultado, OCKO_TblTipoEvaluacion.TipId FROM OCKO_TblEmpleado INNER JOIN OCKO_TblEvaluacionEmpleado ON OCKO_TblEmpleado.EmpId = OCKO_TblEvaluacionEmpleado.CodEmpleado INNER JOIN OCKO_TblTipoEvaluacion ON OCKO_TblEvaluacionEmpleado.codTipoEvaluacion = OCKO_TblTipoEvaluacion.TipId WHERE (OCKO_TblEvaluacionEmpleado.evaResultado = 0) AND (OCKO_TblTipoEvaluacion.TipId = @TipoEvaluacion)">
        <SelectParameters>
            <asp:SessionParameter Name="TipoEvaluacion" SessionField="TipoEvaluacion" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
