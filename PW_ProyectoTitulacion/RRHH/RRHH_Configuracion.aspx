<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_Configuracion.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH.RRHH_Configuracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    <div class="tabbable">
        <ul class="nav nav-tabs padding-16">
            <li class="active">
                <a data-toggle="tab" href="#edit-basic">
                    <i class="green ace-icon fa fa-pencil-square-o bigger-125"></i>
                    Parametro Evaluaciones
                </a>
            </li>

        </ul>

        <div class="tab-content profile-edit-tab-content">
            <div id="edit-basic" class="tab-pane in active">
                <h4 class="header blue bolder smaller">Evaluaciones</h4>

                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-date">Fecha Inicio</label>

                    <div class="col-sm-9">
                        <div class="input-medium">
                            <div class="input-group">
                                <input class="input-medium date-picker" id="form-field-date" type="text" data-date-format="dd-mm-yyyy" placeholder="dd-mm-yyyy" />
                                <span class="input-group-addon">
                                    <i class="ace-icon fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
               <div class="space-10"></div>
                <hr />
                <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-date">Fecha fin</label>

                    <div class="col-sm-9">
                        <div class="input-medium">
                            <div class="input-group">
                                <input class="input-medium date-picker" id="form-field-date" type="text" data-date-format="dd-mm-yyyy" placeholder="dd-mm-yyyy" />
                                <span class="input-group-addon">
                                    <i class="ace-icon fa fa-calendar"></i>
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
                 <div class="form-group">
                            <label class="col-sm-4 control-label no-padding-right" for="form-field-username">Mensaje </label>

                                <asp:TextBox runat="server" ID="txtCedula" enable="false" class="col-xs-12 col-sm-12"></asp:TextBox>
                            
                        </div>
                <hr />
                <div class="space-4"></div>
                

                <br />
                <div class="space"></div>
                <h4 class="header blue bolder smaller">Autoevaluación</h4>

                  <div class="form-group">
                    <label class="col-sm-3 control-label no-padding-right" for="form-field-website">Numero Dias</label>

                    <div class="col-sm-9">
                        <span class="input-icon input-icon-right">
                            <asp:TextBox runat="server" ID="TextBox1" class="col-xs-12 col-sm-12"></asp:TextBox>
                            
                        </span>
                    </div>
                </div>
               <div class="space-10"></div>
            </div>
            
        </div>
    </div>

    <div class="clearfix form-actions">
        <div class="col-md-offset-3 col-md-9">
            <button class="btn btn-info" type="button">
                <i class="ace-icon fa fa-check bigger-110"></i>
                Save
            </button>

            &nbsp; &nbsp;
														<button class="btn" type="reset">
                                                            <i class="ace-icon fa fa-undo bigger-110"></i>
                                                            Reset
                                                        </button>
        </div>
    </div>
</asp:Content>
