<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_EvaluacionesRealizadas.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_EvaluacionesRealizadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table table-condensed table-hover" caption="Evaluaciones Realizadas"   emptydatatext="No hay Registros." ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="TipId" DataSourceID="sqlEvaluacionesP" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpCedula" HeaderText="Cedula" SortExpression="EmpCedula" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" ReadOnly="True" SortExpression="Nombres" />
            <asp:BoundField DataField="Apellido" HeaderText="Apellidos" ReadOnly="True" SortExpression="Apellido" />
            <asp:BoundField DataField="evaResultado" HeaderText="evaResultado" Visible="false"  SortExpression="evaResultado" />
            <asp:BoundField DataField="TipId" HeaderText="TipId" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="TipId" />
        </Columns>

        <EditRowStyle BackColor="#2461BF" />
        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#EFF3FB" />
        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F5F7FB" />
        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
        <SortedDescendingCellStyle BackColor="#E9EBEF" />
        <SortedDescendingHeaderStyle BackColor="#4870BE" />

    </asp:GridView>

    <asp:SqlDataSource ID="sqlEvaluacionesP" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEmpleado.EmpCedula, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS Nombres, OCKO_TblEmpleado.EmpPrimerApellido + ' ' + OCKO_TblEmpleado.EmpSegundoApellidos AS Apellido, OCKO_TblEvaluacionEmpleado.evaResultado, OCKO_TblTipoEvaluacion.TipId FROM OCKO_TblEmpleado INNER JOIN OCKO_TblEvaluacionEmpleado ON OCKO_TblEmpleado.EmpId = OCKO_TblEvaluacionEmpleado.CodEmpleado INNER JOIN OCKO_TblTipoEvaluacion ON OCKO_TblEvaluacionEmpleado.codTipoEvaluacion = OCKO_TblTipoEvaluacion.TipId WHERE (OCKO_TblEvaluacionEmpleado.evaResultado &gt; 0) AND (OCKO_TblTipoEvaluacion.TipId = @TipoEvaluacion)">
        <SelectParameters>
            <asp:SessionParameter Name="TipoEvaluacion" SessionField="TipoEvaluacion" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
