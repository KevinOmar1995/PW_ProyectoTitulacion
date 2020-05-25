<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_TipoEvaluacion.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_TipoEvaluacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function EvaluacionInicio(letra) {
            
            /*if (confirm(letra)) {
                window.location.href = "RRHH_TipoEvaluacion.aspx";
            }
            else {
                return false;
            }        */
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:panel runat="server" id="pnlBotones" style="float: right" visible="false" width="90%">
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
    <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger"  OnClick="SubmitBtn_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:panel>
    <asp:panel runat="server" style="float: left" width="10%">
   <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:panel>
    <asp:panel runat="server" style="float: left" width="100%">
    <asp:GridView  ID="gvrTipoEvaluacion" CssClass="table table-condensed table-hover" Width="100%" caption="Tipo de Evaluaciòn"   emptydatatext="No hay Registros." SelectedRowStyle-Font-Bold="true" OnSelectedIndexChanged="gvrTipoEvaluacion_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" DataKeyNames="TipId" DataSourceID="sdsTipoEvaluacion" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
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
        <EditRowStyle BackColor="#7C6F57" />
        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="#E3EAEB" />
        <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        <SortedAscendingCellStyle BackColor="#F8FAFA" />
        <SortedAscendingHeaderStyle BackColor="#246B61" />
        <SortedDescendingCellStyle BackColor="#D4DFE1" />
        <SortedDescendingHeaderStyle BackColor="#15524A" />
    </asp:GridView>
    </asp:panel>
    <asp:sqldatasource id="sdsTipoEvaluacion" runat="server" connectionstring="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" selectcommand="SELECT TipEvaluacion, TipDescripcion, TipId FROM OCKO_TblTipoEvaluacion">

    </asp:sqldatasource>
    <%--   ////modales/////--%>
    <%--   ////Crear/////--%>
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Crear Evaluaciòn</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:textbox runat="server" id="txtEvaluacionCreate" required="required" title="Evaluacion " cssclass="form-control" placeholder="Evaluacion" />
                    <br />
                    <asp:textbox runat="server" id="txtEvaDescripcionCreate" required="required" title="Descripciòn Required" cssclass="form-control" placeholder="Descripcion" />

                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:linkbutton runat="server" cssclass="btn btn-success" onclick="btnGuardar_Click" id="btnGuardar" text="Guardar"></asp:linkbutton>
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
                    <asp:textbox runat="server" id="txtEvaluacionEditar" cssclass="form-control" placeholder="Evaluacion" />
                    <br />
                    <asp:textbox runat="server" id="txtEvaDescripcionEditar" cssclass="form-control" placeholder="Descripcion" />
                    <br />
                    <asp:hiddenfield runat="server" id="hdId" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:linkbutton runat="server" cssclass="btn btn-success" onclick="btnEditar_Click" id="btnEditar" text="Guardar"></asp:linkbutton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
