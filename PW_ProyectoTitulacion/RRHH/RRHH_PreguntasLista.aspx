<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_PreguntasLista.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_PreguntasLista" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Evaluacion(letra, parametros) {

            if (confirm(letra)) {
                window.location.href = window.location.href;
            }
            else {
                return false;
            }
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:Panel runat="server" ID="pnlBotonEditar" Style="float: left" Visible="false" Width="90%">
        <button type="button" id="btnEditar" class="btn btn-dark" data-toggle="modal" data-target="#editar">
            <a class="fa fa-pencil"></a>
            Editar
        </button>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlBotonEliminar" Style="float: left" Visible="false" Width="90%">
        <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger" OnClick="SubmitBtn_Click"><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlBotonCrear" Visible="false" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Crear
        </button>
    </asp:Panel>

    <asp:GridView CssClass="table table-condensed table-hover" ID="grvPreguntas" OnSelectedIndexChanged="grvPreguntas_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" DataKeyNames="PreId,CatId" DataSourceID="SqlDataSource1">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <%#Container.DataItemIndex +1 %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="PreId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="PreId" InsertVisible="False" ReadOnly="True" SortExpression="PreId" />
            <asp:BoundField DataField="PrePregunta" HeaderText="Pregunta" SortExpression="PrePregunta" />
            <asp:BoundField DataField="CodTipoEvaluacion"  HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodTipoEvaluacion" SortExpression="CodTipoEvaluacion" />
            <asp:BoundField DataField="CatId" HeaderText="CatId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" InsertVisible="False" ReadOnly="True" SortExpression="CatId" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblPreguntas.PreId, OCKO_TblPreguntas.PrePregunta, OCKO_TblPreguntas.CodTipoEvaluacion, OCKO_TblCategoriaPregunta.CatId FROM OCKO_TblPreguntas INNER JOIN OCKO_TblCategoriaPregunta ON OCKO_TblPreguntas.CodCategoria = OCKO_TblCategoriaPregunta.CatId WHERE (OCKO_TblPreguntas.CodTipoEvaluacion = @evaluacion) AND (OCKO_TblCategoriaPregunta.CatId = @CategoriaId)">
        <SelectParameters>
            <asp:SessionParameter Name="evaluacion" SessionField="EvaluacionList" />
            <asp:SessionParameter DefaultValue="" Name="CategoriaId" SessionField="CategoriaId" />
        </SelectParameters>
    </asp:SqlDataSource>

    <%--   ////Crear/////--%>
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
                    <asp:TextBox runat="server" ID="txtPreguntaC" CssClass="form-control" placeholder="Pregunta" />
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
                    <h5 class="modal-title" id="label">EDITAR PREGUNTA</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:TextBox runat="server" ID="txtPreguntaEditar" CssClass="form-control" placeholder="Pregunta" />
                    <br />
                    <asp:HiddenField runat="server" ID="hdId" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="LinkButton1_Click" ID="LinkButton1" Text="Guardar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
