<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_Periodos.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_Periodos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"> 
    
   
    <!-- Boostrap DatePicket CSS -->
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/css/bootstrap-datepicker.css" type="text/css" />
    <!-- Boostrap DatePciker JS  -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/bootstrap-datepicker/1.6.4/js/bootstrap-datepicker.js" type="text/javascript"></script>

     <script type="text/javascript">
        function Evaluacion(letra,parametros)
        {
             
            if (confirm(letra))
            {
                window.location.href = window.location.href;
            }
            else
            {
                return false;
            }
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {
            var dp = $('#<%=dateFechaInicioCreate.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd.mm.yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });

        $(document).ready(function () {
            var dp = $('#<%=dateFechaFinCreate.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd.mm.yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
        $(document).ready(function () {
            var dp = $('#<%=dateFechaInicioEdit.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd.mm.yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });
           $(document).ready(function () {
            var dp = $('#<%=datefinEdit.ClientID%>');
            dp.datepicker({
                changeMonth: true,
                changeYear: true,
                format: "dd.mm.yyyy",
                language: "tr"
            }).on('changeDate', function (ev) {
                $(this).blur();
                $(this).datepicker('hide');
            });
        });

         
          
    </script>
      
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel runat="server" ID="pnlBotones" Style="float: right" Visible="false" Width="90%">
        <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar">
            <a class="fa fa-pencil"></a>
            Editar
        </button>
        <asp:LinkButton ID="BtnEliminar" runat="server" CssClass="btn btn-small btn-danger" OnClick="BtnEliminar_Click"><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" Style="float: left" Width="10%">
        <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="100%" ID="p">
        <asp:GridView ID="GridView1" CssClass="table table-condensed table-hover" caption="Periodos"   emptydatatext="No hay Registros." runat="server" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" AutoGenerateColumns="False" DataKeyNames="PerId" DataSourceID="SqlPeriodos" AllowPaging="True" AllowSorting="True" CellPadding="4" ForeColor="#333333" GridLines="None">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PerId" HeaderStyle-CssClass="hidden" HeaderText="PerId" ItemStyle-CssClass="hidden" ReadOnly="True" SortExpression="PerId">
                <HeaderStyle CssClass="hidden" />
                <ItemStyle CssClass="hidden" />
                </asp:BoundField>
                <asp:BoundField DataField="PerPeriodo" HeaderText="Nombre" SortExpression="PerPeriodo" />
                <asp:BoundField DataField="PerDescripcion" HeaderText="Descripción" SortExpression="PerDescripcion" />
                <asp:BoundField DataField="PerFechaInicio" DataFormatString="{0:d}"  HeaderText="Fecha Inicio" SortExpression="PerFechaInicio" />
                <asp:BoundField DataField="PerFechaFin"  DataFormatString="{0:d}" HeaderText="Fecha Fin" SortExpression="PerFechaFin" />
                <asp:BoundField DataField="PerEstado" HeaderStyle-CssClass="hidden" HeaderText="PerEstado" ItemStyle-CssClass="hidden" SortExpression="PerEstado">
                <HeaderStyle CssClass="hidden" />
                <ItemStyle CssClass="hidden" />
                </asp:BoundField>
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
        
        <asp:SqlDataSource ID="SqlPeriodos" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblPeriodo.* FROM OCKO_TblPeriodo"></asp:SqlDataSource>
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
                    <asp:TextBox runat="server" ID="txtnombreCreate" CssClass="form-control" placeholder="Nombre"  />
                    <br />
                    <asp:TextBox runat="server" ID="txtDescripcionCreate" CssClass="form-control" placeholder="Descripciòn"  />
                     <br />
                    <asp:TextBox runat="server" ID="dateFechaInicioCreate" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime" />
                    <br />
                     <br />
                    <asp:TextBox runat="server" ID="dateFechaFinCreate" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime"  />
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
                    <h5  class="modal-title" id="label">EDITAR </h5>
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
                    <asp:TextBox runat="server" ID="dateFechaInicioEdit" ClientIDMode="Static"  CssClass="form-control" placeholder="Fecha Inicio"  />
                    <br />
                     <br />
                    <asp:TextBox runat="server" ID="datefinEdit" ClientIDMode="Static" CssClass="form-control" placeholder="Fecha Fin"  />
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
