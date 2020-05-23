<%@ Page Title="" Language="C#" MasterPageFile="~/Jefes_PageMaster.Master" AutoEventWireup="true" CodeBehind="Jefes_AsigActividades.aspx.cs" Inherits="PW_ProyectoTitulacion.Jefes.Jefes_AsigActividades" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Panel runat="server" ID="pnlBotones" style="float:right" Visible="false" Width="90%" >
        <button type="button" class="btn btn-success" data-toggle="modal" data-target="#exampleModal">
            <a class="fa fa-plus"></a>
            Asignar
        </button>
    </asp:Panel>
    <asp:Panel runat="server" ID="grvAsignacion" Style="float: left" Width="100%">
        <asp:GridView runat="server" ID="gvrTareas" CssClass="table table-condensed table-hover" Caption="Tareas Desrrollo" OnSelectedIndexChanged="gvrTareas_SelectedIndexChanged" EmptyDataText="No hay Registros." AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="sdsAsigancion" DataKeyNames="AsiId">

            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AsiId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="AsiId" InsertVisible="False" ReadOnly="True" SortExpression="AsiId" />
                <asp:BoundField DataField="AsiDescripcion" HeaderText="Descripción" SortExpression="AsiDescripcion" />
                <asp:BoundField DataField="AsiFechaInicio" HeaderText="Fecha Incio" SortExpression="AsiFechaInicio" />
                <asp:BoundField DataField="AsiFechafin" HeaderText="Fecha Fin" SortExpression="AsiFechafin" />
                <asp:BoundField DataField="CodProceso" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodProceso" SortExpression="CodProceso" />
                <asp:BoundField DataField="ProNombre" HeaderText="Proceso" SortExpression="ProNombre" />
                <asp:BoundField DataField="CodSeccion" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodSeccion" SortExpression="CodSeccion" />
                <asp:BoundField DataField="SecNombre" HeaderText="Sección" SortExpression="SecNombre" />
                <asp:BoundField DataField="AsiAvanceTecnico" HeaderText="Avance" SortExpression="AsiAvanceTecnico" />
                <asp:BoundField DataField="AsiAvanceFuncional" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="AsiAvanceFuncional" SortExpression="AsiAvanceFuncional" />
                <asp:BoundField DataField="CodJefe" HeaderText="CodJefe" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" SortExpression="CodJefe" />
                <asp:BoundField DataField="AsiEstado" HeaderText="AsiEstado" SortExpression="AsiEstado" />
                <asp:CommandField ShowSelectButton="True"  ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            
            </Columns>
        </asp:GridView>

    </asp:Panel>
    <asp:SqlDataSource ID="sdsAsigancion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblAsignacion.AsiDescripcion, OCKO_TblAsignacion.AsiFechaInicio, OCKO_TblAsignacion.AsiFechafin, OCKO_TblAsignacion.CodProceso, OCKO_TblProceso.ProNombre, OCKO_TblAsignacion.CodSeccion, OCKO_TblSeccion.SecNombre, OCKO_TblAsignacion.AsiAvanceTecnico, OCKO_TblAsignacion.AsiAvanceFuncional, OCKO_TblAsignacion.CodJefe, OCKO_TblAsignacion.AsiId, OCKO_TblAsignacion.AsiFechaAsignacion, OCKO_TblAsignacion.AsiEstado FROM OCKO_TblAsignacion INNER JOIN OCKO_TblProceso ON OCKO_TblAsignacion.CodProceso = OCKO_TblProceso.ProId INNER JOIN OCKO_TblSeccion ON OCKO_TblAsignacion.CodSeccion = OCKO_TblSeccion.SecId WHERE (OCKO_TblAsignacion.AsiAvanceFuncional = @ProyectoId) AND (OCKO_TblAsignacion.CodJefe = @JefeId)">
        <SelectParameters>
            <asp:SessionParameter Name="ProyectoId" SessionField="ProyectoId" />
            <asp:SessionParameter Name="JefeId" SessionField="IdJefe" />
        </SelectParameters>
    </asp:SqlDataSource>

    <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">Asignar Desarrollador</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                   <asp:Label ID="Label4" runat="server" Text="">Seleccciona :                 </asp:Label>
                    <center>
                                <asp:DropDownList ID="ddlPersonal"  runat="server" ></asp:DropDownList>
                                    <br />
                    </center>
                       <asp:HiddenField runat="server" ID="hdId"   />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnGuardar_Click" ID="btnGuardar" Text="Asignar" ></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
