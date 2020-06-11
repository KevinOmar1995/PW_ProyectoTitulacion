<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_TipoEvaluacion.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_TipoEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function validaCampos() {

            var nombre = $("#txtEvaluacionCreate").val();
            var edad = $("#edad").val();
            var direccion = $("#direccion").val();
            //validamos campos
            if ($.trim(nombre) == "") {
                toastr.error("No ha ingresado Nombre", "Aviso!");
                return false;
            }
            if ($.trim(edad) == "") {
                toastr.error("No ha ingresado Edad", "Aviso!");
                return false;
            }

            if (edad < 0) {
                toastr.error("Mínimo permitido 0", "Aviso!");
                return false;
            }
            if ($.trim(direccion) == "") {
                toastr.error("No ha ingresado Dirección", "Aviso!");
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" Style="float: right" Visible="false" Width="90%">
        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar">
            <a class="fa fa-pencil"></a>
            Editar
        </button>
        <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger" OnClick="SubmitBtn_Click"><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Crear
        </button>
    </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="100%">
        <asp:GridView ID="gvrTipoEvaluacion" CssClass="table table-condensed table-hover" Width="100%" Caption="Tipo de Evaluaciòn" EmptyDataText="No hay Registros." SelectedRowStyle-Font-Bold="true" OnSelectedIndexChanged="gvrTipoEvaluacion_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" DataKeyNames="TipId" DataSourceID="sdsTipoEvaluacion" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="TipId" HeaderStyle-CssClass="hidden" HeaderText="TipId" InsertVisible="False" ItemStyle-CssClass="hidden" ReadOnly="True" SortExpression="TipId">
                    <HeaderStyle CssClass="hidden" />
                    <ItemStyle CssClass="hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="TipEvaluacion" HeaderText="Tipo Evaluación" SortExpression="TipEvaluacion" />
                <asp:BoundField DataField="TipDescripcion" HeaderText="Descripción" SortExpression="TipDescripcion" />
                <asp:CommandField ButtonType="Button" ControlStyle-CssClass="btn btn-blue" HeaderText="" ShowHeader="True" ShowSelectButton="True">
                    <ControlStyle CssClass="btn btn-blue" />
                </asp:CommandField>
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
    </asp:Panel>
    <asp:SqlDataSource ID="sdsTipoEvaluacion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT TipEvaluacion, TipDescripcion, TipId FROM OCKO_TblTipoEvaluacion"></asp:SqlDataSource>
    <%--   ////modales/////--%>
    <%--   ////Crear/////--%>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Crear Evaluación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtEvaluacionCreate" required title="Evaluacion " CssClass="form-control" placeholder="Evaluacion" />
                    <br />
                    <asp:TextBox runat="server" ID="txtEvaDescripcionCreate" required="required" title="Descripciòn Required" CssClass="form-control" placeholder="Descripcion" />

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
                    <h5 class="modal-title" id="label">Editar Evaluación</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <asp:TextBox runat="server" ID="txtEvaluacionEditar" CssClass="form-control" placeholder="Evaluacion" />
                    <br />
                    <asp:TextBox runat="server" ID="txtEvaDescripcionEditar" CssClass="form-control" placeholder="Descripcion" />
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
