﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PM_PageMaster.Master" AutoEventWireup="true" CodeBehind="PM_Inicio.aspx.cs" Inherits="PW_ProyectoTitulacion.PM.PM_Inicio" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
      .img-container {
        text-align: center;
        display: block;
      }
    </style>
    <link href="../assets/css/main.css" rel="stylesheet" />
    <link href="../assets/css/MoneAdmin.css" rel="stylesheet" />
    <link href="../assets/plugins/Font-Awesome/css/font-awesome.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
                    <div class="col-lg-12">
                        <div style="text-align: center;">
                           
                            <a class="quick-btn" href="#">
                                <i class="icon-check icon-2x"></i>
                                <span> Products</span>
                                <span class="label label-danger">2</span>
                            </a>

                            <a class="quick-btn" href="#">
                                <i class="icon-envelope icon-2x"></i>
                                <span>Messages</span>
                                <span class="label label-success">456</span>
                            </a>
                            <a class="quick-btn" href="#">
                                <i class="icon-signal icon-2x"></i>
                                <span>Profit</span>
                                <span class="label label-warning">+25</span>
                            </a>
                            <a class="quick-btn" href="#">
                                <i class="icon-external-link icon-2x"></i>
                                <span>value</span>
                                <span class="label btn-metis-2">3.14159265</span>
                            </a>
                            <a class="quick-btn" href="#">
                                <i class="icon-lemon icon-2x"></i>
                                <span>tasks</span>
                                <span class="label btn-metis-4">107</span>
                            </a>
                            <a class="quick-btn" href="#">
                                <i class="icon-bolt icon-2x"></i>
                                <span>Tickets</span>
                                <span class="label label-default">20</span>
                            </a>
                        </div>
                    </div>
                </div>

        <span class="img-container"> <!-- Inline parent element -->
            <img src="../assets/css/images/OKSstem.png" class="img-thumbnail" />
        </span>
</asp:Content>
