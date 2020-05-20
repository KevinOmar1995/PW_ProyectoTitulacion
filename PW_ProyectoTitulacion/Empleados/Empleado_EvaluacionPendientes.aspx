<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado_PageMaster.Master" AutoEventWireup="true" CodeBehind="Empleado_EvaluacionPendientes.aspx.cs" Inherits="PW_ProyectoTitulacion.Empleados.Empleado_Evaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    
    </div> 
    <asp:GridView ID="gvrEvaluaciones" runat="server" CssClass="table table-condensed table-hover" AutoGenerateColumns="False" DataKeyNames="EvaId,TipId" DataSourceID="sqlEvaluacion">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EvaId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"  HeaderText="EvaId" ReadOnly="True" SortExpression="EvaId" InsertVisible="False" />
            <asp:BoundField DataField="CodEmpleado" HeaderText="CodEmpleado" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"  SortExpression="CodEmpleado" />
            <asp:BoundField DataField="TipId" HeaderText="TipId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"  InsertVisible="False" ReadOnly="True" SortExpression="TipId"/>
            <asp:BoundField DataField="TipEvaluacion" HeaderText="Tipo Evaluación" SortExpression="TipEvaluacion" />
            <asp:BoundField DataField="EvaResultado" HeaderText="Resultado" SortExpression="EvaResultado" />
            <asp:TemplateField>
                <ItemTemplate>
                    <span class="label label-sm label-info arrowed arrowed-righ">Asignado</span>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:SqlDataSource ID="sqlEvaluacion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEvaluacionEmpleado.EvaId, OCKO_TblEvaluacionEmpleado.CodEmpleado, OCKO_TblTipoEvaluacion.TipId, OCKO_TblTipoEvaluacion.TipEvaluacion, OCKO_TblEvaluacionEmpleado.EvaResultado FROM OCKO_TblEvaluacionEmpleado INNER JOIN OCKO_TblTipoEvaluacion ON OCKO_TblEvaluacionEmpleado.CodTipoEvaluacion = OCKO_TblTipoEvaluacion.TipId WHERE (OCKO_TblEvaluacionEmpleado.CodEmpleado = @empleado) AND (OCKO_TblEvaluacionEmpleado.EvaResultado = 0)">
        <SelectParameters>
            <asp:SessionParameter Name="empleado" SessionField="IdEmpleado" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
