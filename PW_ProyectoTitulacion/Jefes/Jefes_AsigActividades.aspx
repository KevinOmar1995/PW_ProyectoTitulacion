<%@ Page Title="" Language="C#" MasterPageFile="~/Jefes_PageMaster.Master" AutoEventWireup="true" CodeBehind="Jefes_AsigActividades.aspx.cs" Inherits="PW_ProyectoTitulacion.Jefes.Jefes_AsigActividades" %>
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
    <asp:Panel runat="server"  ID="grvAsignacion" style="float:left" Width="100%" >
         <asp:GridView runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="sdsAsigancion">
                                      
             <Columns>
                 
                 <asp:BoundField DataField="AsiDescripcion" HeaderText="AsiDescripcion" SortExpression="AsiDescripcion" />
                 <asp:BoundField DataField="AsiFechaInicio" HeaderText="AsiFechaInicio" SortExpression="AsiFechaInicio" />
                 <asp:BoundField DataField="AsiFechafin" HeaderText="AsiFechafin" SortExpression="AsiFechafin" />
                 <asp:BoundField DataField="CodProceso" HeaderText="CodProceso" SortExpression="CodProceso" />
                 <asp:BoundField DataField="ProNombre" HeaderText="ProNombre" SortExpression="ProNombre" />
                 <asp:BoundField DataField="CodSeccion" HeaderText="CodSeccion" SortExpression="CodSeccion" />
                 <asp:BoundField DataField="SecNombre" HeaderText="SecNombre" SortExpression="SecNombre" />
                 <asp:BoundField DataField="AsiAvanceTecnico" HeaderText="AsiAvanceTecnico" SortExpression="AsiAvanceTecnico" />
                 <asp:BoundField DataField="AsiAvanceFuncional" HeaderText="AsiAvanceFuncional" SortExpression="AsiAvanceFuncional" />
                 <asp:BoundField DataField="CodJefe" HeaderText="CodJefe" SortExpression="CodJefe" />
                  <asp:CommandField ShowSelectButton="True"  ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
             </Columns>
                                      
         </asp:GridView>

	</asp:Panel>
    <asp:SqlDataSource ID="sdsAsigancion" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblAsignacion.AsiDescripcion, OCKO_TblAsignacion.AsiFechaInicio, OCKO_TblAsignacion.AsiFechafin, OCKO_TblAsignacion.CodProceso, OCKO_TblProceso.ProNombre, OCKO_TblAsignacion.CodSeccion, OCKO_TblSeccion.SecNombre, OCKO_TblAsignacion.AsiAvanceTecnico, OCKO_TblAsignacion.AsiAvanceFuncional, OCKO_TblAsignacion.CodJefe FROM OCKO_TblAsignacion INNER JOIN OCKO_TblProceso ON OCKO_TblAsignacion.CodProceso = OCKO_TblProceso.ProId INNER JOIN OCKO_TblSeccion ON OCKO_TblAsignacion.CodSeccion = OCKO_TblSeccion.SecId WHERE (OCKO_TblAsignacion.AsiAvanceFuncional = @ProyectoId) AND (OCKO_TblAsignacion.CodJefe = @JefeId)">
        <SelectParameters>
            <asp:SessionParameter Name="ProyectoId" SessionField="ProyectoId" />
            <asp:SessionParameter Name="JefeId" SessionField="JefeId" />
        </SelectParameters>
    </asp:SqlDataSource>
</asp:Content>
