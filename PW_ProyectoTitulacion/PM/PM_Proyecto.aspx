<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_Proyecto.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_Proyecto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlBotones" Style="float: left" Visible="false" Width="90%">
        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar">
            <a class="fa fa-pencil"></a>
            Editar
        </button>
        <asp:LinkButton ID="Eliminar" runat="server" CssClass="btn btn-small btn-danger" OnClick="Eliminar_Click"><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Crear
        </button>
    </asp:Panel>

    <asp:Panel runat="server" style="float:left" Width="100%" ID="panel">
        <asp:GridView CssClass="table table-condensed table-hover" caption="Proyectos"   emptydatatext="No hay Registros."  ID="grvProyecto" OnSelectedIndexChanged="grvProyecto_SelectedIndexChanged" runat="server" AutoGenerateColumns="False" DataKeyNames="ProId" DataSourceID="sdsProyectos">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ProId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="ProId" InsertVisible="False" ReadOnly="True" SortExpression="ProId" />
                <asp:BoundField DataField="ProNombre" HeaderText="Nombre" SortExpression="ProNombre" />
                <asp:BoundField DataField="ProDescripcion" HeaderText="Descripcion" SortExpression="ProDescripcion" />
                <asp:BoundField DataField="ProFechaIncio" HeaderText="Fecha Inicio" SortExpression="ProFechaIncio" />
                <asp:BoundField DataField="ProFechaFinal" HeaderText="Fecha Entrega " SortExpression="ProFechaFinal" />
                <asp:BoundField DataField="ProAvance" HeaderText="Avance" SortExpression="ProAvance" />
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="sdsProyectos" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblProyecto.* FROM OCKO_TblProyecto"></asp:SqlDataSource>
     </asp:Panel> 
        <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="exampleModalLabel">Registro Proyecto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtProyectoCreate" CssClass="form-control" placeholder="Proyecto" />
                    <br />
                    <asp:TextBox runat="server" ID="txtDescripcionCreate" CssClass="form-control" placeholder="Descripciòn" />
                    <br />
                    Fecha Inicio      :
                    <center>
                    <asp:TextBox ID="txtFechaInicioCreate" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime" placeholder="Fecha Inicio" TextMode="Date" runat="server"></asp:TextBox>
                        </center>
                    <br />
                    <br />
                    Fecha Entrega      :    
                    <center>
                    <asp:TextBox ID="txtfechaFinCreate" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime"  placeholder="Fecha Entrega" TextMode="Date" runat="server"></asp:TextBox>
                        </center>
                    <br />
                    <br />
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
                    <h5 class="modal-title" id="label">Editar Proyecto</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtproyectoEdit" CssClass="form-control" placeholder="Proyecto" />
                    <br />
                    <asp:TextBox runat="server" ID="txtDescripcionEdit" CssClass="form-control" placeholder="Descripciòn" />
                    <br />
                    Fecha Inicio      :
                    <center>
                    <asp:TextBox ID="txtFechaInicioEdit" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime" placeholder="Fecha Inicio" TextMode="Date" runat="server"></asp:TextBox>
                        </center>
                    <br />
                    <br />
                    Fecha Entrega      :    
                    <center>
                    <asp:TextBox ID="txtFechafinalEdit" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime"  placeholder="Fecha Entrega" TextMode="Date" runat="server"></asp:TextBox>
                        </center>
                    <br />
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
