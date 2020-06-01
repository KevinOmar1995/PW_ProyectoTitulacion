<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_GrupoConcepto.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_GrupoConcepto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <asp:Panel runat="server" ID="pnlBotones" Style="float: right" Visible="false" Width="90%">
        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar">
            <a class="fa fa-pencil"></a>
            Editar
        </button>
        </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
     <asp:Panel runat="server" style="float:left" Width="100%" ID="p">
        <asp:GridView CssClass="table table-condensed table-hover" ID="GridView1" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="GruId" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="GruId" HeaderStyle-CssClass="hidden" HeaderText="GruId" ItemStyle-CssClass="hidden" SortExpression="GruId">
                <HeaderStyle CssClass="hidden" />
                <ItemStyle CssClass="hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="GruNombre" HeaderText="GruNombre" SortExpression="GruNombre" />
                <asp:BoundField DataField="GruMinimo" HeaderText="Minimo %" ReadOnly="true" SortExpression="Minimo %" />
                <asp:BoundField DataField="GruPeso" HeaderText="Porcetaje Optimo %" SortExpression="Porcentaje" />
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

            
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
        ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" 
        SelectCommand="SELECT OCKO_TblGrupoConceptos.* FROM OCKO_TblGrupoConceptos" >                   
    </asp:SqlDataSource>
       
    
    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">Editar Grupo Conceptos</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtnombreCreate" CssClass="form-control" placeholder="Nombre Grupo"  />
                    <br />
                    <asp:TextBox runat="server" ID="txtMinimo" CssClass="form-control" placeholder="Minimo"  />
                     <br />
                    <asp:TextBox runat="server" ID="txtPorcentaje" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime" /> %
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
                    <h5  class="modal-title" id="label">Editar Grupo Conceptos </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtNombreEdit" CssClass="form-control" placeholder="Nombre Grupo"  />
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
