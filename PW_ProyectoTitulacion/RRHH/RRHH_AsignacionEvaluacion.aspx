<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_AsignacionEvaluacion.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_AsignacionEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
     <p class="alert alert-info"><b>Asignación por Empleado</b></p>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Panel runat="server" Height="50px">
                <asp:Table ID="Table1" runat="server" Width="390px">
                     <asp:TableRow>
                         <asp:TableCell >
                                Evaluaciones :
                                <asp:DropDownList ID="ddlEvaluaciones" runat="server"></asp:DropDownList>
                         </asp:TableCell>
                         <asp:TableCell>
                                        Cedula :
                                <asp:TextBox ID="TxtCedula" runat="server"></asp:TextBox>
                         </asp:TableCell>
                     </asp:TableRow>
                </asp:Table>
            </asp:Panel>
            
            <br>
            
            
            <asp:Label ID="lblMensajevisto" ForeColor="Green" runat="server" Text=""></asp:Label>
            <asp:Label ID="LblMensajeMalo" ForeColor="red" runat="server" Text=""></asp:Label>
            <asp:GridView CssClass="table table-condensed table-hover"  caption="Empleado"   emptydatatext="No hay Registros." OnSelectedIndexChanged="gvrEmpelados_SelectedIndexChanged" ID="gvrEmpelados" runat="server" AutoGenerateColumns="False" DataKeyNames="EmpId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%#Container.DataItemIndex +1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EmpId"  HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="EmpId" InsertVisible="False" ReadOnly="True" SortExpression="EmpId" />
                    <asp:BoundField DataField="EmpCedula" HeaderText="Cedula" SortExpression="EmpCedula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombres" ReadOnly="True" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellido" HeaderText="Apellidos" ReadOnly="True" SortExpression="Apellido" />
                    <asp:BoundField DataField="EmpEmail" HeaderText="Email" SortExpression="EmpEmail" />
                    <asp:BoundField DataField="EmpDireccion" HeaderText="Direccion" SortExpression="EmpDireccion" />
                    <asp:BoundField DataField="EmpTelefono" HeaderText="Telefono" SortExpression="EmpTelefono" />
                    <asp:BoundField DataField="CarNombre" HeaderText="Cargo" SortExpression="CarNombre" />
                    <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEmpleado.EmpId, OCKO_TblEmpleado.EmpCedula, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS Nombre, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS Apellido, OCKO_TblEmpleado.EmpEmail, OCKO_TblEmpleado.EmpDireccion, OCKO_TblEmpleado.EmpTelefono, OCKO_TblCargo.CarNombre FROM OCKO_TblEmpleado INNER JOIN OCKO_TblCargo ON OCKO_TblEmpleado.CodCargo = OCKO_TblCargo.CarId WHERE (OCKO_TblEmpleado.EmpCedula = @cedula)">
                <SelectParameters>
                    <asp:ControlParameter ControlID="TxtCedula" Name="cedula" PropertyName="Text" />
                </SelectParameters>
            </asp:SqlDataSource>

        </ContentTemplate>
    </asp:UpdatePanel>




</asp:Content>
