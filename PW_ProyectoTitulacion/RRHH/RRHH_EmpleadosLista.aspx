<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_EmpleadosLista.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH_EmployeeList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(window).on('load', function () {
            $('#myModal').modal('show');
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="">Elegir Cargo</asp:Label>
                            <asp:DropDownList ID="dllCargo" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dllCargo_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>

    <br />
    <div style="width:100%;"> 
    <asp:UpdatePanel runat="server" Style="float: left" Width="100%" ID="panel">
        <ContentTemplate>
            <asp:GridView CssClass="table table-condensed table-hover" Width="100%" ID="GrvCliente" runat="server" OnSelectedIndexChanged="GrvCliente_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="EmpId,CarId" DataSourceID="SqlDataSource1">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%#Container.DataItemIndex +1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="EmpId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="EmpId" InsertVisible="False" ReadOnly="True" SortExpression="EmpId" />
                    <asp:BoundField DataField="EmpCedula" HeaderText="Cedula" SortExpression="EmpCedula" />
                    <asp:BoundField DataField="NOMBRES" HeaderText="Nombres" ReadOnly="True" SortExpression="NOMBRES" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" ReadOnly="True" SortExpression="Apellidos" />
                    <asp:BoundField DataField="EmpEmail" HeaderText="Email" SortExpression="EmpEmail" />
                    <asp:BoundField DataField="EmpDireccion" HeaderText="Direccion" SortExpression="EmpDireccion" />
                    <asp:BoundField DataField="EmpTelefono" HeaderText="Telefono" SortExpression="EmpTelefono" />
                    <asp:BoundField DataField="CarNombre" HeaderText="Cargo" SortExpression="CarNombre" />
                    <asp:BoundField DataField="EmpJefe" HeaderText="EmpJefe" Visible="false" SortExpression="EmpJefe" />
                    <asp:BoundField DataField="CarId" HeaderText="CarId" Visible="false" InsertVisible="False" ReadOnly="True" SortExpression="CarId" />
                </Columns>

            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEmpleado.EmpId, OCKO_TblEmpleado.EmpCedula, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS NOMBRES, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpSegundoNombre AS Apellidos, OCKO_TblEmpleado.EmpEmail, OCKO_TblEmpleado.EmpDireccion, OCKO_TblEmpleado.EmpTelefono, OCKO_TblCargo.CarNombre, OCKO_TblEmpleado.EmpJefe, OCKO_TblCargo.CarId FROM OCKO_TblCargo INNER JOIN OCKO_TblEmpleado ON OCKO_TblCargo.CarId = OCKO_TblEmpleado.CodCargo WHERE (OCKO_TblEmpleado.EmpJefe = N'N') AND (OCKO_TblCargo.CarId = @CarId)">
        <SelectParameters>
            <asp:SessionParameter Name="CarId" SessionField="CardId" />
        </SelectParameters>
    </asp:SqlDataSource>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">CREAR PREGUNTA</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtCargo" CssClass="form-control" placeholder="Cargo" />
                    <br />
                    <asp:DropDownList runat="server" ID="txtPersona" CssClass="form-control" placeholder="Cargo" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Guardar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


    <%--   ////editar/////--%>
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="label">EDITAR CLIENTE</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:TextBox runat="server" ID="txetCargo" CssClass="form-control" placeholder="Cargo" />
                    <br />
                    <asp:HiddenField runat="server" ID="hdId" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnEditar_Click" ID="btnEditar" Text="Guardar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


</asp:Content>
