<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_IniciarProyecto.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_IniciarProyecto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


                <h4 class="header blue bolder smaller">Datos Generales</h4>

                <div class="row">
                    <div class="col-xs-12 col-sm-8">
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-username">Proyecto :</label>
                          
                            <div class="col-sm-8">
                                <label class="col-sm-4 control-label no-padding-right" for="form-field-username"><%=ProyectoName %></label>
                            </div>
                               
                        </div>
 
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Arquitecto Software :</label>

                            <div class="col-sm-8">
                                <label class="col-sm-4 control-label no-padding-left" for="form-field-username"><%=ArquitectoSoftware %></label>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Arquitecta Financiera :</label>

                            <div class="col-sm-8">
                                <label class="col-sm-4 control-label no-padding-left" for="form-field-username"><%=ArquitectaFinanciera %></label>
                           
                            </div>
                        </div>
                    </div>
                    </div>
    

    <br />
    <asp:Panel runat="server" ID="pnlBotones" style="float:right" Visible="false" Width="90%" >
    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar"><a class="fa fa-pencil"></a>
       Editar
    </button>
    <asp:LinkButton ID="Eliminar" runat="server" CssClass="btn btn-small btn-danger"  OnClick="Eliminar_Click" ><i class="fa fa-trash"></i>&nbsp;Eliminar</asp:LinkButton>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="10%">
   <button type="button" class="btn btn-success"  data-toggle="modal" data-target="#exampleModal"><a class="fa fa-plus"></a>
        Crear
    </button>
    </asp:Panel>
    <asp:Panel runat="server" style="float:left" Width="100%" >
        <asp:GridView ID="gvrAsignacion" runat="server"  CssClass="table table-condensed table-hover" OnSelectedIndexChanged="gvrAsignacion_SelectedIndexChanged" caption="Actividades del Proyecto"   emptydatatext="No hay Registros." AutoGenerateColumns="False" ShowFooter="True" DataKeyNames="AsiId" DataSourceID="sdsActividad">
            <Columns>
                  <asp:TemplateField>
                    <ItemTemplate>
                        <%#Container.DataItemIndex +1 %>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="AsiId" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden"  HeaderText="AsiId" InsertVisible="False" ReadOnly="True" SortExpression="AsiId" />
                <asp:BoundField DataField="AsiDescripcion" HeaderText="Descripcion" SortExpression="AsiDescripcion" />
                <asp:BoundField DataField="AsiFechaInicio" HeaderText="Fecha Inicio" SortExpression="AsiFechaInicio" />
                <asp:BoundField DataField="AsiFechafin" HeaderText="Fecha Fin" SortExpression="AsiFechafin" />
                <asp:BoundField DataField="ModNombre" HeaderText="Modulo" SortExpression="ModNombre" />
                <asp:BoundField DataField="SecNombre" HeaderText="Sección" SortExpression="SecNombre" />
                <asp:BoundField DataField="CodProyecto" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" HeaderText="CodProyecto" SortExpression="CodProyecto" />
                <asp:CommandField ShowSelectButton="True"  ControlStyle-CssClass="btn btn-blue" ButtonType="Button" ShowHeader="True" HeaderText=""></asp:CommandField>
            </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:SqlDataSource ID="sdsActividad" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="SELECT OCKO_TblAsignacion.AsiId, OCKO_TblAsignacion.AsiDescripcion, OCKO_TblAsignacion.AsiFechaInicio, OCKO_TblAsignacion.AsiFechafin, OCKO_TblModulos.ModNombre, OCKO_TblSeccion.SecNombre, OCKO_TblSeccion.CodProyecto FROM OCKO_TblAsignacion INNER JOIN OCKO_TblSeccion ON OCKO_TblAsignacion.CodSeccion = OCKO_TblSeccion.SecId INNER JOIN OCKO_TblModulos ON OCKO_TblSeccion.CodModulos = OCKO_TblModulos.ModId WHERE (OCKO_TblSeccion.CodProyecto = @ProyectoIdAsignacion)">
        <SelectParameters>
            <asp:SessionParameter Name="ProyectoIdAsignacion" SessionField="ProyectoIdAsignacion" />
        </SelectParameters>
    </asp:SqlDataSource>
     <div class="modal fade" id="exampleModal" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5  class="modal-title" id="exampleModalLabel">CREAR ACTIVIDAD</h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <br />
                        <asp:TextBox runat="server" ID="txtDescripcionCreate" CssClass="form-control" placeholder="Descripciòn"  />
                    <br />
                    
                        <asp:Label ID="Label2" runat="server" Text="">Fecha Inicio :                 </asp:Label>
                    <center>
                        <asp:TextBox runat="server" ID="dateFechaInicioCreate" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime" />
                    </center>
                    <br />
                     <br />
                    
                        <asp:Label ID="Label1" runat="server" Text="">Fecha Fin :               </asp:Label>
                    <center>
                        <asp:TextBox runat="server" ID="dateFechaFinCreate" ClientIDMode="Static"  CssClass="m-wrap span12 date form_datetime"  />
                    </center>
                    <br />
                        <asp:Label ID="Label3" runat="server" Text="">Seleccionar Sección :                 </asp:Label>
                    <center>
                                <asp:DropDownList ID="ddlSeccion"  runat="server" ></asp:DropDownList>
                                    <br />
                    </center>
                    
                                <asp:Label ID="Label4" runat="server" Text="">Selecccionar Proceso :                 </asp:Label>
                    <center>
                                <asp:DropDownList ID="ddlProceso"  runat="server" ></asp:DropDownList>
                                    <br />
                    </center>

                    
                    <asp:Label ID="Label5" runat="server" Text="">Intervienen :                 </asp:Label>
                              <br />
                            <asp:Label ID="Label6" runat="server" Text="">Funcional :                 </asp:Label>
                            <asp:CheckBox ID="cbxFuncional" runat="server"></asp:CheckBox>
                        <asp:Label ID="Label7" runat="server" Text="">Desarrollo :                 </asp:Label>
                            <asp:CheckBox ID="cbxtecnico" runat="server"></asp:CheckBox>
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
                    <h5  class="modal-title" id="label">EDITAR MODULOS </h5>
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
