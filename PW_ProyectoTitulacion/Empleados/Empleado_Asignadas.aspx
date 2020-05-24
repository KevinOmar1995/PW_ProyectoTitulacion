<%@ Page Title="" Language="C#" MasterPageFile="~/Empleado_PageMaster.Master" AutoEventWireup="true" CodeBehind="Empleado_Asignadas.aspx.cs" Inherits="PW_ProyectoTitulacion.Empleados.Empleado_Asignadas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" Visible="false">
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Asignar
        </button>
    </asp:Panel>
    <asp:Panel runat="server" ID="grvAsignacion" Style="float: left" Width="100%">
        <asp:GridView CssClass="table table-condensed table-hover" Caption="Modulos" EmptyDataText="No hay Registros." OnSelectedIndexChanged="gvrAsignacion_SelectedIndexChanged" ID="gvrAsignacion" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" DataKeyNames="AsiId" DataSourceID="sdsAsignacion" ForeColor="#333333" GridLines="None">

            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AsiId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="AsiId" InsertVisible="False" ReadOnly="True" SortExpression="AsiId" />
                <asp:BoundField DataField="AsiDescripcion" HeaderText="AsiDescripcion" SortExpression="AsiDescripcion" />
                <asp:BoundField DataField="SecNombre" HeaderText="SecNombre" SortExpression="SecNombre" />
                <asp:BoundField DataField="CodProceso" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodProceso" SortExpression="CodProceso" />
                <asp:BoundField DataField="ProNombre" HeaderText="Proceso" SortExpression="ProNombre" />
                <asp:BoundField DataField="ProDescripcion" HeaderText="Detalle Proceso" SortExpression="ProDescripcion" />
                <asp:BoundField DataField="CodSeccion" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodSeccion" SortExpression="CodSeccion" />
                <asp:BoundField DataField="CodEmpleado" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodEmpleado" SortExpression="CodEmpleado" />
                <asp:TemplateField ControlStyle-Font-Size="Small" HeaderText="Fecha Inicio">
                    <ItemTemplate>
                        <asp:Label ID="lblPrescriptionDate" runat="server" Text='<%# Bind("AsiFechaInicio", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ControlStyle-Font-Size="Small" HeaderText="Fecha Fin">
                    <ItemTemplate>
                        <asp:Label ID="lblPrescriptionDate" runat="server" Text='<%# Bind("AsiFechafin", "{0:dd/MM/yyyy}") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AsiEstado" HeaderText="AsiEstado" SortExpression="AsiEstado" />
                <asp:BoundField DataField="AsiAvanceFuncional" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="AsiAvanceFuncional" SortExpression="AsiAvanceFuncional" />

                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#3376D0" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#3376D0 " Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />

        </asp:GridView>
        <asp:SqlDataSource ID="sdsAsignacion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblAsignacion.AsiId, OCKO_TblAsignacion.AsiDescripcion, OCKO_TblAsignacion.CodProceso, OCKO_TblProceso.ProNombre, OCKO_TblAsignacion.CodSeccion, OCKO_TblSeccion.SecNombre, OCKO_TblAsignacion.CodEmpleado, OCKO_TblAsignacion.AsiFechaInicio, OCKO_TblAsignacion.AsiFechafin, OCKO_TblAsignacion.AsiEstado, OCKO_TblAsignacion.AsiAvanceFuncional, OCKO_TblProceso.ProDescripcion FROM OCKO_TblAsignacion INNER JOIN OCKO_TblProceso ON OCKO_TblAsignacion.CodProceso = OCKO_TblProceso.ProId INNER JOIN OCKO_TblSeccion ON OCKO_TblAsignacion.CodSeccion = OCKO_TblSeccion.SecId WHERE (OCKO_TblAsignacion.CodEmpleado = @EmpleadoId) AND (OCKO_TblAsignacion.AsiAvanceFuncional = @ProyectoIdT)">
            <SelectParameters>
                <asp:SessionParameter Name="EmpleadoId" SessionField="EmpId" />
                <asp:SessionParameter Name="ProyectoIdT" SessionField="ProyectoIdT" />
            </SelectParameters>
        </asp:SqlDataSource>
    </asp:Panel>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Tarea Estado</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:Label ID="Label4" runat="server" Text="">Seleccciona :                 </asp:Label>

                    <asp:DropDownList runat="server" ID="ddlEstados">
                        <asp:ListItem Text="Inicio" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Analisis" Value="2"></asp:ListItem>
                        <asp:ListItem Text="Proceso" Value="3"></asp:ListItem>
                        <asp:ListItem Text="Pruebas" Value="4"></asp:ListItem>
                        <asp:ListItem Text="Terminado" Value="5"></asp:ListItem>
                    </asp:DropDownList>
                    <br />

                    <asp:HiddenField runat="server" ID="hdId" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Cambiar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
