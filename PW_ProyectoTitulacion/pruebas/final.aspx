<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="final.aspx.cs" Inherits="PW_ProyectoTitulacion.pruebas.final" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <div class="btn btn-danger btn-lg" style="display:none">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Timer ID="Clock" runat="server" Interval="1000" ontick="Clock_Tick">
                </asp:Timer>
                <strong><asp:Label ID="Reloj" runat="server" Text=""></asp:Label></strong><br />
            </ContentTemplate>
    </asp:UpdatePanel>
    </div>
  <div class="panel panel-success">
  <div class="panel-heading">
    <h3 class="panel-title">Felicitaciones</h3>
  </div>
  <div class="panel-body">
    <p>Has Terminado tus examenes!</p>
  </div>
</div>

</asp:Content>
