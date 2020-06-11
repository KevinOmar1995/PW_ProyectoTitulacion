<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_CategoriaPreguntas.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_CategoriaPreguntas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <asp:Panel runat="server" ID="pnlBotones" style="float:right" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
    <asp:LinkButton ID="BtnEliminar" runat="server" CssClass="btn btn-small btn-danger"  OnClick="BtnEliminar_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="10%">
   <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
   <asp:Panel runat="server" style="float:left" Width="100%" ID="p">
       <asp:GridView CssClass="table table-condensed table-hover" ID="GridView1" runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="CatId,GruId" DataSourceID="SqlCaterogoria" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
           <AlternatingRowStyle BackColor="White" />
           <Columns>
               <asp:TemplateField>
                   <ItemTemplate>
                       <%#Container.DataItemIndex +1 %>
                   </ItemTemplate>
               </asp:TemplateField>
               <asp:BoundField DataField="CatId" HeaderStyle-CssClass="hidden" HeaderText="CatId" ItemStyle-CssClass="hidden" ReadOnly="True" SortExpression="CatId">
               <HeaderStyle CssClass="hidden" />
               <ItemStyle CssClass="hidden" />
               </asp:BoundField>
               <asp:BoundField DataField="CatNombre" HeaderStyle-CssClass="hidden" HeaderText="CatNombre" ItemStyle-CssClass="hidden" SortExpression="CatNombre">
               <HeaderStyle CssClass="hidden" />
               <ItemStyle CssClass="hidden" />
               </asp:BoundField>
               <asp:BoundField DataField="CatDescripcion" HeaderText="Categoria" SortExpression="CatDescripcion" />
               <asp:BoundField DataField="GruId" HeaderStyle-CssClass="hidden" HeaderText="GruId" ItemStyle-CssClass="hidden" SortExpression="GruId">
               <HeaderStyle CssClass="hidden" />
               <ItemStyle CssClass="hidden" />
               </asp:BoundField>
               <asp:BoundField DataField="GruNombre" HeaderText="Grupo" SortExpression="GruNombre" />
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
       <asp:SqlDataSource ID="SqlCaterogoria" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblCategoriaPregunta.CatNombre, OCKO_TblCategoriaPregunta.CatDescripcion, OCKO_TblCategoriaPregunta.CatId, OCKO_TblGrupoConceptos.GruId, OCKO_TblGrupoConceptos.GruNombre FROM OCKO_TblCategoriaPregunta INNER JOIN OCKO_TblGrupoConceptos ON OCKO_TblCategoriaPregunta.CodGrupoConceptos = OCKO_TblGrupoConceptos.GruId"></asp:SqlDataSource>
   </asp:Panel>


      <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">Crear Categoria</h5>
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
                    <asp:Label ID="lblModalBody" runat="server" Text="">Elegir una Grupo Concepto</asp:Label>
                    <asp:DropDownList ID="dllGrupoConcepto"  runat="server" OnSelectedIndexChanged="dllGrupoConcepto_SelectedIndexChanged"></asp:DropDownList>
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
                    <h5  class="modal-title" id="label">EDITAR </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    
                    <asp:TextBox runat="server" ID="txtCategoriaEdit" CssClass="form-control" placeholder="Cargo"/>
                     <br />
                    <asp:TextBox runat="server" ID="txtDescripcionEdit"  CssClass="form-control" placeholder="Cargo"/>
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="">Grupo Concepto</asp:Label>
                    <asp:DropDownList ID="dllGrupoConceptoEdit"  runat="server" CssClass="form-control" OnSelectedIndexChanged="dllGrupoConcepto_SelectedIndexChanged"></asp:DropDownList>
               
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
