<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="RRHH_EmployeCreate.aspx.cs" Inherits="PW_ProyectoTitulacion.RRHH_EmploymentCreate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div class="hr hr-4"></div>
        <div class="row">
            <div class="col-xs-12 col-sm-4">
                <div class="widget-box">
                    <div class="widget-header">
                        <h4 class="widget-title">Text Area</h4>
                        <div class="widget-toolbar">
                            <a href="#" data-action="collapse">
                                <i class="ace-icon fa fa-chevron-up"></i>
                            </a>

                            <a href="#" data-action="close">
                                <i class="ace-icon fa fa-times"></i>
                            </a>
                        </div>
                    </div>

                    <div class="widget-body">
                        <div class="widget-main">
                            <div>
                                <label for="form-field-8">Default</label>

                                <textarea class="form-control" id="form-field-8" placeholder="Default Text"></textarea>
                            </div>

                            <hr />

                            <div>
                                <label for="form-field-9">With Character Limit</label>

                                <textarea class="form-control limited" id="form-field-9" maxlength="50"></textarea>
                            </div>

                            <hr />

                            <div>
                                <label for="form-field-11">Autosize</label>

                                <textarea id="form-field-11" class="autosize-transition form-control"></textarea>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.span -->
            <div class="col-xs-12 col-sm-4">
                <div class="widget-box">
                    <div class="widget-header">
                        <h4 class="widget-title">Masked Input</h4>

                        <span class="widget-toolbar">

                            <a href="#" data-action="reload">
                                <i class="ace-icon fa fa-refresh"></i>
                            </a>

                            <a href="#" data-action="collapse">
                                <i class="ace-icon fa fa-chevron-up"></i>
                            </a>

                            <a href="#" data-action="close">
                                <i class="ace-icon fa fa-times"></i>
                            </a>
                        </span>
                    </div>

                    <div class="widget-body">
                        <div class="widget-main">
                            <div>
                                <label for="form-field-mask-1">
                                    Date
																<small class="text-success">99/99/9999</small>
                                </label>

                                <div class="input-group">
                                    <input class="form-control input-mask-date" type="text" id="form-field-mask-1" />
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-default" type="button">
                                            <i class="ace-icon fa fa-calendar bigger-110"></i>
                                            Go!
                                        </button>
                                    </span>
                                </div>
                            </div>

                            <hr />
                            <div>
                                <label for="form-field-mask-2">
                                    Phone
																<small class="text-warning">(999) 999-9999</small>
                                </label>

                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="ace-icon fa fa-phone"></i>
                                    </span>

                                    <input class="form-control input-mask-phone" type="text" id="form-field-mask-2" />
                                </div>
                            </div>

                            <hr />
                            <div>
                                <label for="form-field-mask-3">
                                    Product Key
																<small class="text-error">a*-999-a999</small>
                                </label>

                                <div class="input-group">
                                    <input class="form-control input-mask-product" type="text" id="form-field-mask-3" />
                                    <span class="input-group-addon">
                                        <i class="ace-icon fa fa-key"></i>
                                    </span>
                                </div>
                            </div>

                            <hr />
                            <div>
                                <label for="form-field-mask-4">
                                    Eye Script
																<small class="text-info">~9.99 ~9.99 999</small>
                                </label>

                                <div>
                                    <input class="input-medium input-mask-eyescript" type="text" id="form-field-mask-4" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.span -->
            <div class="col-xs-12 col-sm-4">
                <div class="widget-box">
                    <div class="widget-header">
                        <h4 class="widget-title">Masked Input</h4>

                        <span class="widget-toolbar">

                            <a href="#" data-action="reload">
                                <i class="ace-icon fa fa-refresh"></i>
                            </a>

                            <a href="#" data-action="collapse">
                                <i class="ace-icon fa fa-chevron-up"></i>
                            </a>

                            <a href="#" data-action="close">
                                <i class="ace-icon fa fa-times"></i>
                            </a>
                        </span>
                    </div>

                    <div class="widget-body">
                        <div class="widget-main">
                            <div>
                                <label for="form-field-mask-1">
                                    Date
																<small class="text-success">99/99/9999</small>
                                </label>

                                <div class="input-group">
                                    <input class="form-control input-mask-date" type="text" id="form-field-mask-1" />
                                    <span class="input-group-btn">
                                        <button class="btn btn-sm btn-default" type="button">
                                            <i class="ace-icon fa fa-calendar bigger-110"></i>
                                            Go!
                                        </button>
                                    </span>
                                </div>
                            </div>

                            <hr />
                            <div>
                                <label for="form-field-mask-2">
                                    Phone
																<small class="text-warning">(999) 999-9999</small>
                                </label>

                                <div class="input-group">
                                    <span class="input-group-addon">
                                        <i class="ace-icon fa fa-phone"></i>
                                    </span>

                                    <input class="form-control input-mask-phone" type="text" id="form-field-mask-2" />
                                </div>
                            </div>

                            <hr />
                            <div>
                                <label for="form-field-mask-3">
                                    Product Key
																<small class="text-error">a*-999-a999</small>
                                </label>

                                <div class="input-group">
                                    <input class="form-control input-mask-product" type="text" id="form-field-mask-3" />
                                    <span class="input-group-addon">
                                        <i class="ace-icon fa fa-key"></i>
                                    </span>
                                </div>
                            </div>

                            <hr />
                            <div>
                                <label for="form-field-mask-4">
                                    Eye Script
									<small class="text-info">~9.99 ~9.99 999</small>
                                </label>

                                <div>
                                    <input class="input-medium input-mask-eyescript" type="text" id="form-field-mask-4" />
                                </div>
                            </div>
                            <hr />
                            <div>

                                <label for="form-field-mask-4">
                                    Habilitar Empleado
                                </label>
                                <div>
                                    <input name="switch-field-1" class="ace ace-switch ace-switch-6" type="checkbox" />
                                    <span class="lbl"></span>
                                </div>
                            </div>

                            <div>
                                <label for="form-field-mask-4">
                                    Fotografia
                                </label>
                                <div>
                                    <input type="file" id="id-input-file-2" />
                                </div>
                            </div>

                            <fieldset>
                                <label for="form-field-mask-4">
                                    CAMPOS
                                </label>
                                <div>
                                    <input type="text" />
                                </div>
                            </fieldset>
                        </div>
                    </div>
                </div>
            </div>
            <!-- /.span -->

        </div>
        <!-- /.row -->
        <div class="clearfix form-actions">
            <div class="col-md-offset-3 col-md-12">
                <button class="btn btn-info" type="button">
                    <i class="ace-icon fa fa-check bigger-110"></i>
                    Enviar
                </button>
				<button class="btn" type="reset">
                    <i class="ace-icon fa fa-undo bigger-110"></i>
                    Reiniciar
                </button>
            </div>
        </div>
        <div class="space-24"></div>
</asp:Content>
