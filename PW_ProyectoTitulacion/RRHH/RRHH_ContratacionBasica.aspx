<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_ContratacionBasica.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_ContratacionBasica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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

        function Mensaje(letra)
        {
            alert(letra)
        }
    </script>
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
        </ul>


        <div class="tab-content profile-edit-tab-content">
            <div id="edit-basic" class="tab-pane in active">
                <h4 class="header blue bolder smaller">General</h4>

                <div class="row">


                    <div class="col-xs-12 col-sm-8">
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-username">Cedula</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtCedula" enable="false" class="col-xs-12 col-sm-6"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <div class="space-4"></div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Primer Nombre</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtPrimerNombre" class="col-xs-12 col-sm-6"></asp:TextBox>

                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Segundo Nombre</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtSegundoNombre" class="col-xs-12 col-sm-6"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Primer Apellido</label>

                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtPrimerApellido" class="col-xs-12 col-sm-6"></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="space-4"></div>
                        <div class="space-4"></div>
                        <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-first">Segundo Apellido</label>
                            <div class="col-sm-8">
                                <asp:TextBox runat="server" ID="txtSegunfoApellido" class="col-xs-12 col-sm-6"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <div class="space-4"></div>
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-date">Fecha Nacimiento</label>
                    <div class="col-sm-9">
                        <div class="input-medium">
                            <div class="input-group">
                                <asp:TextBox ID="txtFechaNacimiento" class="col-xs-12 col-sm-20" placeholder="mm/dd/yyyy" TextMode="Date" runat="server"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
                <hr />
                <div class="space-4"></div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right">Genero</label>
                    <div class="col-sm-9">
                        <label class="inline">
                            <asp:RadioButton GroupName="gender" value="1" runat="server" class="lbl middle" ID="RadioMasculino"></asp:RadioButton>

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
                        <asp:DropDownList ID="ddlEmpresa" Width="145px" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <br />

                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-facebook">Aplicas Para :</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlCargoAplicar" OnSelectedIndexChanged="ddlCargoAplicar_SelectedIndexChanged" runat="server" Width="145px">
                            <asp:ListItem Value="Empleado">--Seleccionar--</asp:ListItem>
                            <asp:ListItem Value="Empleado">Empleado</asp:ListItem>
                            <asp:ListItem Value="Jefe">Jefe</asp:ListItem>
                            <asp:ListItem Value="Jefe">PM</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="space-4"></div>
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-facebook">Cargo a Ocupar:</label>
                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddlCargo" AutoPostBack="true" Width="145px" OnSelectedIndexChanged="ddlCargo_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="space-4"></div>
                <div class="form-group">
                    <asp:Label ID="lblJefeInmediato" runat="server" class="col-sm-3 control-label no-padding-right" Visible="false" Text="Jefe Inmediato"></asp:Label>

                    <div class="col-sm-9">
                        <asp:DropDownList ID="ddljefeInmediato" Visible="false" AutoPostBack="true" Width="145px" OnSelectedIndexChanged="ddljefeInmediato_SelectedIndexChanged" runat="server"></asp:DropDownList>
                    </div>
                </div>

                <div class="space-4"></div>
                <div class="space-10"></div>
                <div class="space-4"></div>
                <div class="space-10"></div>
                <div class="space-4"></div>
                <div class="space-4"></div>
                <div class="space-10"></div>
                <div class="space-4"></div>
                <div class="space-10"></div>
                <div class="space-4"></div>
                <div class="space-10"></div>
                <div class="space-10"></div>
            </div>

        </div>
    </div>

    <div class="clearfix form-actions">
        <div class="col-md-offset-3 col-md-9">

            <asp:Button Text="Guardar" class="btn btn-success" ID="Guardar" OnClick="Guardar_Click" runat="server" />
            <button class="btn" type="reset">
                <i class="ace-icon fa fa-undo bigger-110"></i>
                Reset
            </button>
        </div>
    </div>
</asp:Content>
