<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_InicioEvaluacion.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_InicioEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="assets/js/jquery.js"></script>
    <script src="assets/js/jquery.dropdownPlain.js"></script>
    <link href="css/bootstrap1.css" rel="stylesheet" />
    <script type="text/javascript">
        function show(obj) {
            var gvrEvaluaciones = document.getElementById(obj);
            var imageID = document.getElementById('imagen' + obj);
            if (gvrEvaluaciones.style.display == "none") {
                gvrEvaluaciones.style.display = "inline";
                imageID.src = "./assets/css/images/arriba.png";
            }
            else {
                gvrEvaluaciones.style.display = "none";
                imageID.src = "./assets/css/images/abajo.png";
            }
        }
        function EvaluacionInicio(letra)
        { 
            
            if (confirm("Desea Realizar la evaluación de este Empleado"))
            {
                
                $('#myModal').modal('show');
                     document.getElementById('<%= hd1.ClientID %>').value = letra ;  
                
                //window.location.href = "Jefes_InicioEvaluacion.aspx?" + letra;  
            }
            
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text="">Selecccionar Periodo</asp:Label></h4>
                        </div>
                         <div class="modal-body">
                            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                             <asp:HiddenField runat="server" ID="hd1"   />
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="lblModalBody" runat="server" Text="">Elegir Periodo</asp:Label>
                            <asp:DropDownList ID="dllPeriodos" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="dllPeriodos_SelectedIndexChanged"></asp:DropDownList>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                            <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnEditar_Click" ID="btnEditar" Text="Comenzar"></asp:LinkButton>
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <asp:GridView ID="gvrCalificaciones"  runat="server" AutoGenerateColumns="False" DataKeyNames="EmpId" DataSourceID="sdsJefes" GridLines="None" CssClass="table table-condensed table-hover" OnRowDataBound="gvrCalificaciones_RowDataBound">                         
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <a href='javascript:show("empleado_<%# Eval("EmpId") %>");'>
                        <img id='imagenEmpleado_<%# Eval("EmpId") %>' alt="Mostrar u Ocultar" src="../assets/css/images/abajo.png" width="18px" height="18px" />
                         </a>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="EmpId" HeaderText="EmpId" InsertVisible="False" Visible="false" ReadOnly="True" SortExpression="EmpId" />
            <asp:BoundField DataField="Nombres" HeaderText="Nombre" ReadOnly="True" SortExpression="Nombres" />
            <asp:BoundField DataField="EmpCedula" HeaderText="Cedula" SortExpression="EmpCedula" />
            <asp:BoundField DataField="CarNombre" HeaderText="Cargo" SortExpression="CarNombre" />
            <asp:BoundField DataField="EmpJefe" HeaderText="EmpJefe" Visible="false" SortExpression="EmpJefe" />
            <asp:BoundField DataField="EmpJefeId" HeaderText="EmpJefeId" Visible="false" SortExpression="EmpJefeId" />
            <asp:TemplateField>
                <ItemTemplate>
                    <tr>
                        <td colspan="100">
                            <div id='empleado_<%# Eval("EmpId") %>' style="display: none;">
                              
                                <asp:GridView CssClass="table table-condensed table-hover" OnRowCommand="gvrEvaluaciones_RowCommand" OnRowDataBound="gvrEvaluaciones_RowDataBound" SelectedRowStyle-Font-Bold="true"   OnSelectedIndexChanged="gvrEvaluaciones_SelectedIndexChanged" ID="gvrEvaluaciones" DataKeyNames="CodEmpleado" runat="server" AutoGenerateColumns="False" >
                                    <Columns>
                                        <asp:BoundField DataField="TipEvaluacion" SortExpression="TipEvaluacion" />
                                        <asp:BoundField DataField="CodEmpleado" Visible="false" SortExpression="CodEmpleado" />
                                        <asp:BoundField DataField="TipId" Visible="false"  SortExpression="TipId" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                    <a href='javascript:EvaluacionInicio("evaluacion=<%# Eval("TipId") %>&empleado=<%# Eval("CodEmpleado") %> ");'>
                                                <img id='imagenEmpleado_<%# Eval("TipId") %>' alt="Mostrar u Ocultar" src="../assets/css/images/INICIO.png" width="50px" height="50px" />
                                         </a>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView> 
                            </div>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:SqlDataSource ID="sdsJefes" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblEmpleado.EmpId, OCKO_TblEmpleado.EmpPrimerNombre + ' ' + OCKO_TblEmpleado.EmpPrimerApellido 
AS Nombres, OCKO_TblEmpleado.EmpCedula, OCKO_TblEmpleado.EmpJefe, OCKO_TblEmpleado.EmpJefeId,OCKO_TblCargo.CarNombre
 FROM OCKO_TblCargo INNER JOIN OCKO_TblEmpleado ON OCKO_TblCargo.CarId = OCKO_TblEmpleado.CodCargo 
 WHERE (OCKO_TblEmpleado.EmpJefeId = @IdJefe)">
        <SelectParameters>
            <asp:SessionParameter Name="IdJefe" SessionField="JefeIdEva" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="sdsEvaluaciones" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" 
                SelectCommand="SELECT	TipId	,TipEvaluacion,CodEmpleado 
FROM			OCKO_TblEvaluacionEmpleado INNER JOIN
                OCKO_TblTipoEvaluacion ON OCKO_TblEvaluacionEmpleado.codTipoEvaluacion = OCKO_TblTipoEvaluacion.TipId
				and OCKO_TblEvaluacionEmpleado.evaResultado = 0 "></asp:SqlDataSource>

    


</asp:Content>
