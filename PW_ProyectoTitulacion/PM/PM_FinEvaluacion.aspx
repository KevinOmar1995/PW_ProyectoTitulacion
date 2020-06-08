<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_FinEvaluacion.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_FinEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="btn btn-danger btn-lg" style="display:none">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
        
    </div>
  <div class="panel panel-success">
  <div class="panel-heading">
    <h3 class="panel-title">Felicitaciones</h3>
  </div>
  <div class="panel-body">
    <p>Has Terminado la Evaluación!</p>
  </div>
</div>
</asp:Content>
