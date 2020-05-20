<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado_PageMaster.Master" AutoEventWireup="true" CodeBehind="Empleado_EvaluacionAsignadas.aspx.cs" Inherits="PW_ProyectoTitulacion.Empleados.Empleado_EvaluacionAsignadas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        function EvaluacionInicio(letra)
        {
             
            if (confirm(letra))
            {
                window.location.href="Empleado_InicioEvaluacion.aspx";
            }
            else
            {
                return false;
            }
        }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" style="float:left" Visible="false" Width="90%" >
    <button type="button" class="btn btn-success" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Iniciar
    </button>
    </asp:Panel>
    <br />
     <br />
    <asp:gridview ID="grvEvaluacion" CssClass="table table-condensed table-hover" Width="100%" OnSelectedIndexChanged="grvEvaluacion_SelectedIndexChanged" runat="server" DataSourceID="sdsEvaluaciones" AutoGenerateColumns="False" DataKeyNames="TipId" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="TipId"  HeaderText="TipId"  HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" InsertVisible="false" ReadOnly="True" SortExpression="TipId" />
            <asp:BoundField DataField="TipEvaluacion" HeaderText="Tipo Evaluación" SortExpression="TipEvaluacion" />
            <asp:BoundField DataField="CodEmpleado" HeaderText="CodEmpleado" Visible="false" SortExpression="CodEmpleado" />
            <asp:CommandField ShowSelectButton="True"  ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField></Columns>
    </asp:gridview>
    <asp:sqldatasource Id="sdsEvaluaciones" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblTipoEvaluacion.TipId, OCKO_TblTipoEvaluacion.TipEvaluacion, OCKO_TblEvaluacionEmpleado.CodEmpleado FROM OCKO_TblEvaluacionEmpleado INNER JOIN OCKO_TblTipoEvaluacion ON OCKO_TblEvaluacionEmpleado.CodTipoEvaluacion = OCKO_TblTipoEvaluacion.TipId WHERE (OCKO_TblEvaluacionEmpleado.CodEmpleado = @empleado) AND (OCKO_TblEvaluacionEmpleado.EvaResultado = 0) AND (OCKO_TblTipoEvaluacion.TipId = 1)">
        <SelectParameters>
            <asp:SessionParameter Name="empleado" SessionField="IdEmpleado" />
        </SelectParameters>
    </asp:sqldatasource>
</asp:Content>
