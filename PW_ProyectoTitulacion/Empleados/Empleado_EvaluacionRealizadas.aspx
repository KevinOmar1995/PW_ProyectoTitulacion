<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado_PageMaster.Master" AutoEventWireup="true" CodeBehind="Empleado_EvaluacionRealizadas.aspx.cs" Inherits="PW_ProyectoTitulacion.Empleados.Empleado_EvaluacionRealizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:GridView ID="gvrEvaluacionRealizadas" CssClass="table table-condensed table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="evaId,TipId" DataSourceID="sqlEvaluacionRealizadas">
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="evaId" HeaderText="evaId" ReadOnly="True" SortExpression="evaId"  Visible="false"/>
            <asp:BoundField DataField="CodEmpleado" HeaderText="CodEmpleado" SortExpression="CodEmpleado" Visible="false" />
            <asp:BoundField DataField="TipId" HeaderText="TipId" InsertVisible="False" ReadOnly="True" SortExpression="TipId" Visible="false" />
            <asp:BoundField DataField="TipEvaluacion" HeaderText="Evaluaciones" SortExpression="TipEvaluacion" />
            <asp:BoundField DataField="evaResultado" HeaderText="evaResultado" SortExpression="evaResultado" Visible="false" />
            <asp:TemplateField>
                <ItemTemplate>
                    <span class="label label-sm label-success">Completado</span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>


    </asp:GridView>
    <asp:SqlDataSource ID="sqlEvaluacionRealizadas" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEvaluacionEmpleado.evaId, OCKO_TblEvaluacionEmpleado.CodEmpleado, OCKO_TblTipoEvaluacion.TipId, OCKO_TblTipoEvaluacion.TipEvaluacion, OCKO_TblEvaluacionEmpleado.evaResultado FROM OCKO_TblEvaluacionEmpleado INNER JOIN OCKO_TblTipoEvaluacion ON OCKO_TblEvaluacionEmpleado.codTipoEvaluacion = OCKO_TblTipoEvaluacion.TipId WHERE (OCKO_TblEvaluacionEmpleado.CodEmpleado = @empleado) AND (OCKO_TblEvaluacionEmpleado.evaResultado &gt; 0)">
        <SelectParameters>
            <asp:SessionParameter Name="empleado" SessionField="IdEmpleado" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
