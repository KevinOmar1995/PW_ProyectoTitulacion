<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_Jefes.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_Jefes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" style="float:left" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
    <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger"  OnClick="SubmitBtn_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>

    <asp:GridView CssClass="table table-condensed table-hover" ID="grvJefes" runat="server" OnSelectedIndexChanged="grvJefes_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="EmpId" DataSourceID="sdsJefes">
        <Columns>
             <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpId"  HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="EmpId" InsertVisible="False" ReadOnly="True" SortExpression="EmpId" />
            <asp:BoundField DataField="EmpCedula" HeaderText="Cedula" SortExpression="EmpCedula" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombres" ReadOnly="True" SortExpression="Nombres" />
            <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" ReadOnly="True" SortExpression="Apellidos" />
            <asp:BoundField DataField="EmpEmail" HeaderText="Email" SortExpression="EmpEmail" />
            <asp:BoundField DataField="EmpDireccion" HeaderText="Direccion" SortExpression="EmpDireccion" />
            <asp:BoundField DataField="EmpTelefono" HeaderText="Telefono" SortExpression="EmpTelefono" />
            <asp:BoundField DataField="CodCargo" HeaderText="CodCargo" SortExpression="CodCargo" Visible="false" />
            <asp:BoundField DataField="CarNombre" HeaderText="Cargo" SortExpression="CarNombre" />
            <asp:CommandField ShowSelectButton="True"  ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
        </Columns>

    </asp:GridView>
    <asp:SqlDataSource ID="sdsJefes" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEmpleado.EmpId, OCKO_TblEmpleado.EmpCedula, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS Nombres, OCKO_TblEmpleado.EmpPrimerApellido + ' ' + OCKO_TblEmpleado.EmpSegundoApellidos AS Apellidos, OCKO_TblEmpleado.EmpEmail, OCKO_TblEmpleado.EmpDireccion, OCKO_TblEmpleado.EmpTelefono, OCKO_TblEmpleado.CodCargo, OCKO_TblCargo.CarNombre FROM OCKO_TblEmpleado INNER JOIN OCKO_TblCargo ON OCKO_TblEmpleado.CodCargo = OCKO_TblCargo.CarId WHERE (OCKO_TblEmpleado.EmpJefe = 'Y')"></asp:SqlDataSource>
    
 <%--   ////editar/////--%>
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="label">EDITAR CLIENTE</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    
                    <asp:TextBox runat="server" ID="txtCedula" Enabled="false" CssClass="form-control" placeholder="Cedula"/>
                    <asp:TextBox runat="server" ID="txtPrimerNombre" CssClass="form-control" placeholder="Primer Nombre"/>
                    <asp:TextBox runat="server" ID="txtSegundoNombre" CssClass="form-control" placeholder="Segundo Nombre"/>
                    <asp:TextBox runat="server" ID="txtPrimerApellido" CssClass="form-control" placeholder="Primer Apellido"/>
                    <asp:TextBox runat="server" ID="txtSegundoApellido" CssClass="form-control" placeholder="Segundo Apellido"/>
                    <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control" placeholder="Email"/>
                    <asp:TextBox runat="server" ID="txtDireccion" CssClass="form-control" placeholder="Direccion"/>
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" placeholder="Telefono"/>
                    <br />
                    <asp:HiddenField runat="server" ID="hdId"   />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnEditar_Click" ID="btnEditar" Text="Guardar" ></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
