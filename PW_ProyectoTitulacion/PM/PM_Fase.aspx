﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_Fase.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_Fase" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" style="float:left" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
    <asp:LinkButton ID="Eliminar" runat="server" CssClass="btn btn-small btn-danger"  OnClick="Eliminar_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
        <asp:Panel runat="server" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Crear
        </button>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="100%" ID="panel">
        <asp:GridView ID="grvFase"  caption="Fases del Proyecto"   emptydatatext="No hay Registros."  OnSelectedIndexChanged="grvFase_SelectedIndexChanged"  CssClass="table table-condensed table-hover" runat="server" AutoGenerateColumns="False" DataKeyNames="FasId" DataSourceID="sdsFase">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="FasId"  HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"  HeaderText="FasId" InsertVisible="False" ReadOnly="True" SortExpression="FasId" />
                <asp:BoundField DataField="FasNombre" HeaderText="Nombre" SortExpression="FasNombre" />
                <asp:BoundField DataField="FasDescripcion" HeaderText="Descripciòn" SortExpression="FasDescripcion" />
                <asp:CommandField ShowSelectButton="True" ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="sdsFase" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT FasId, FasNombre, FasDescripcion FROM OCKO_TblFase">
    </asp:SqlDataSource>
    </asp:Panel> 
     <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">CREAR FASE</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                    <asp:TextBox runat="server" ID="txtnombreCreate" CssClass="form-control" placeholder="Nombre"  />
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
                    <h5  class="modal-title" id="label">EDITAR FASE </h5>
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
