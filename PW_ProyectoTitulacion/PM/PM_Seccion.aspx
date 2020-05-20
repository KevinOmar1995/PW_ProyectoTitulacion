<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_Seccion.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_Seccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" style="float:right" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
    <asp:LinkButton ID="SubmitBtn" runat="server" CssClass="btn btn-small btn-danger"  OnClick="SubmitBtn_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="10%">
   <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="100%" >
        <asp:GridView ID="GvrSeccion" CssClass="table table-condensed table-hover" OnSelectedIndexChanged="GvrSeccion_SelectedIndexChanged"  caption="Secciòn"   emptydatatext="No hay Registros." runat="server" AutoGenerateColumns="False" DataKeyNames="SecId" DataSourceID="sdsSeccion">

            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="SecId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="SecId" InsertVisible="False" ReadOnly="True" SortExpression="SecId" />
                <asp:BoundField DataField="SecNombre" HeaderText="Nombre" SortExpression="SecNombre" />
                <asp:BoundField DataField="SecDescripcion" HeaderText="Descripcion" SortExpression="SecDescripcion" />
                <asp:BoundField DataField="CodModulos" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodModulos" SortExpression="CodModulos" />
                <asp:BoundField DataField="CodProyecto" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodProyecto" SortExpression="CodProyecto" />
                <asp:CommandField ShowSelectButton="True"  ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            </Columns>

        </asp:GridView>
        <asp:SqlDataSource ID="sdsSeccion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT SecNombre, SecId, SecDescripcion, CodModulos, CodProyecto FROM OCKO_TblSeccion WHERE (CodModulos = @ModuloId) AND (CodProyecto = @ProyectoId)">

            <SelectParameters>
                <asp:SessionParameter Name="ModuloId" SessionField="ModuloId" />
                <asp:SessionParameter Name="ProyectoId" SessionField="ProyectoId" />
            </SelectParameters>

        </asp:SqlDataSource>
     </asp:Panel> 
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">CREAR SECCIÒN</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtNombreCreate" CssClass="form-control" placeholder="Nombre"  />
                    <br />
                    <asp:TextBox runat="server" ID="txtDescripcionCreate" CssClass="form-control" placeholder="Descripciòn"  />
                    <br />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Guardar" ></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>


 <%--   ////editar/////--%>
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="label">EDITAR MODULOS </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtNombreEdit" CssClass="form-control" placeholder="Nombre"  />
                    <br />
                    <asp:TextBox runat="server" ID="txtDescripcionEdit"  CssClass="form-control" placeholder="Descripciòn"  />
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
