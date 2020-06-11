<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_ParametrosCalificacion.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_ParametrosCalificacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView CssClass="table table-condensed table-hover" caption="Parametros de Calificación"   emptydatatext="No hay Registros." ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="parID" DataSourceID="SqlItemsCalificacion">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:BoundField DataField="parNombre" HeaderText="Nombre" SortExpression="parNombre" />
            <asp:BoundField DataField="parPuntaje" HeaderText="Puntaje" SortExpression="parPuntaje" />
            <asp:BoundField DataField="parID" HeaderText="parID" visible="false" InsertVisible="False" ReadOnly="True" SortExpression="parID" />
        </Columns>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlItemsCalificacion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT parNombre, parPuntaje, parID FROM OCKO_TblParametroItems"></asp:SqlDataSource>
</asp:Content>
