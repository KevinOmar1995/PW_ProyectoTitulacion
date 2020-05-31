<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_Perfil.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="tabbable">
        <ul class="nav nav-tabs padding-16">
            <li class="active">
                <a data-toggle="tab" href="#edit-basic">
                    <i class="green ace-icon fa fa-pencil-square-o bigger-125"></i>
                    Información Basica
                </a>
            </li>


            <li>
                <a data-toggle="tab" href="#edit-password">
                    <i class="blue ace-icon fa fa-key bigger-125"></i>
                    Ingreso
                </a>
            </li>
        </ul>

        <div class="tab-content profile-edit-tab-content">
            <div id="edit-basic" class="tab-pane in active">
                <h4 class="header blue bolder smaller">General</h4>

                <div class="row">


                    <div class="col-xs-12 col-sm-8">
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-username">Cedula</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtCedula" enable="false" class="col-xs-12 col-sm-12"></asp:TextBox>
                            </div>
                        </div>

                        <div class="space-4"></div>
                        <hr />
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Nombres</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtPrimerNombre" class="col-xs-12 col-sm-6"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtSegundoNombre" class="col-xs-12 col-sm-6"></asp:TextBox>

                            </div>
                        </div>
                        <br />
                        <hr />
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Apellidos</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtPrimerApellido" class="col-xs-12 col-sm-6"></asp:TextBox>
                                <asp:TextBox runat="server" ID="txtSegunfoApellido" class="col-xs-12 col-sm-6"></asp:TextBox>

                            </div>
                        </div>
                        <hr />
                    </div>
                </div>

                <hr />


                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right">Fecha Nacimiento :</label>

                    <div class="col-sm-9">
                        <label class="inline">
                            <asp:TextBox ID="txtFechaNacimiento" class="lbl middle" runat="server"></asp:TextBox>
                        </label>

                        &nbsp; &nbsp; &nbsp;
						<label class="inline">
                            <asp:ImageButton ID="ImageButton1" class="lbl middle" runat="server" Height="31px" ImageUrl="~/assets/images/gallery/calentar.png" Width="35px" OnClick="ImageButton1_Click" />
                        </label>
                        <asp:Calendar ID="calendarFechaNacimiento" runat="server" BackColor="White" BorderColor="White" BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" Height="190px" NextPrevFormat="FullMonth" Width="350px" OnDayRender="calendarFechaNacimiento_DayRender" OnSelectionChanged="calendarFechaNacimiento_SelectionChanged">
                            <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                            <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" VerticalAlign="Bottom" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                            <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                            <TodayDayStyle BackColor="#CCCCCC" />
                        </asp:Calendar>
                    </div>
                </div>
                <hr />
                <div class="space-4"></div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right">Genero</label>

                    <div class="col-sm-9">
                        <label class="inline">
                            <asp:RadioButton GroupName="gender" value="1" runat="server" class="lbl middle" ID="radioMasculino"></asp:RadioButton>

                            <span class="lbl middle">Masculino</span>
                        </label>

                        &nbsp; &nbsp; &nbsp;
						<label class="inline">
                            <asp:RadioButton GroupName="gender" value="2" runat="server" class="lbl middle" ID="radioFemenino"></asp:RadioButton>

                            <span class="lbl middle">Femenino</span>
                        </label>
                    </div>
                </div>

                <div class="space-4"></div>


                <br />
                <div class="space"></div>
                <h4 class="header blue bolder smaller">Contacto</h4>

                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-email">Email</label>

                    <div class="col-sm-8">
                        <span class="input-icon input-icon-right">
                            <asp:TextBox runat="server" ID="txtEmail" class="col-xs-12 col-sm-12"></asp:TextBox>

                            <i class="ace-icon fa fa-envelope"></i>
                        </span>
                    </div>
                </div>

                <div class="space-4"></div>

                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-website">Dirección</label>

                    <div class="col-sm-9">
                        <span class="input-icon input-icon-right">
                            <asp:TextBox runat="server" ID="txtDireccion" class="col-xs-12 col-sm-12"></asp:TextBox>
                            <i class="ace-icon fa fa-home"></i>
                        </span>
                    </div>
                </div>

                <div class="space-4"></div>

                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-phone">Phone</label>

                    <div class="col-sm-9">
                        <span class="input-icon input-icon-right">
                            <asp:TextBox runat="server" ID="txttelefono" class="col-xs-12 col-sm-12"></asp:TextBox>
                            <i class="ace-icon fa fa-phone fa-flip-horizontal"></i>
                        </span>
                    </div>
                </div>

                <div class="space"></div>
                <h4 class="header blue bolder smaller">Empresa</h4>

                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-facebook">Perteneces a :</label>
                    <div class="col-sm-9">
                        <span class="input-icon">
                            <asp:TextBox runat="server" ID="txtEmpresa" class="col-xs-12 col-sm-12"></asp:TextBox>


                            <i class="ace-icon fa fa-building blue"></i>
                        </span>
                    </div>
                </div>

                <div class="space-4"></div>
                <div class="space-10"></div>
            </div>



            <div id="edit-password" class="tab-pane bigger-110">
                <div id="edit-basic" class="tab-pane in active">
                    <h4 class="header blue bolder smaller">Usuario</h4>

                    <div class="row">


                        <div class="col-xs-12 col-sm-8">
                            <div class="form-group">
                                <label class="col-sm-4 control-label no-padding-right" for="form-field-username"></label>

                                <div class="col-sm-8">
                                    <asp:TextBox runat="server" ID="txtUsuario" enable="false" class="col-xs-12 col-sm-12"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>

                    <hr>

                    <div class="row">
                        <div class="col-xs-12 col-sm-8">
                            <div class="form-group">
                                <label class="col-sm-4 control-label no-padding-right" for="form-field-username"></label>
                                <div class="col-sm-8">
                                    <button type="button" class="btn btn-dark" data-toggle="modal" data-target="#editar">
                                        <a class="fa fa-pencil"></a>
                                        Cambiar Contraseña
                                    </button>
                                </div>
                            </div>
                            <div class="space-10"></div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="clearfix form-actions">
        <div class="col-md-offset-3 col-md-9">
            <asp:Button ID="Guardar" class="btn btn-info" runat="server" Text="Guardar" OnClick="Guardar_Click" />

        </div>
    </div>


    <%--   ////editar/////--%>
    <div class="modal fade" id="editar" tabindex="-1" role="dialog" aria-labelledby="exampleModalLabel" aria-hidden="true">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title" id="label">Cambiar Contraseña </h5>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">

                    <asp:TextBox runat="server" ID="txtContraseñaNueva" CssClass="form-control check-seguridad" placeholder="NUeva Contraseña" />
                    <br />
                    <asp:TextBox runat="server" ID="txtConfirmarContraseña" CssClass="form-control" placeholder="Confirmar Contraseña" />
                    <asp:HiddenField runat="server" ID="hdId" />
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary" data-dismiss="modal">Close</button>
                    <asp:LinkButton runat="server" CssClass="btn btn-success" OnClick="btnCambiarContraseña_Click" ID="btnCambiarContraseña" Text="Guardar"></asp:LinkButton>
                </div>
            </div>
        </div>
    </div>
    <script>
        $('.check-seguridad').strength({
            templates: {
                toggle: ‘< span class= "input-group-addon" > <span class="glyphicon glyphicon-eye-open {toggleClass}"></span></span>’
        }
        });

    </script>
</asp:Content>
