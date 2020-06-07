<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_RptEvaluacionEmpleado.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_RptEvaluacionEmpleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <script type="text/javascript">
      google.charts.load('current', {'packages':['corechart']});
      google.charts.setOnLoadCallback(drawChart);

      function drawChart() {

        var data = google.visualization.arrayToDataTable(<%=ObtenerDatos()%>);

          var options = {
              title: 'Evaluaciones Desempeño ',
              backgroundColor:{ fill:"white"}  ,
              is3D: true,
              legend: { position: "labeled" },
              tooltip: {showColorCode:true}
        };

        var chart = new google.visualization.PieChart(document.getElementById('piechart'));

        chart.draw(data, options);
      }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

              <div id="piechart" style="width: 900px; height: 600px; position:center;"></div>
           
</asp:Content>
