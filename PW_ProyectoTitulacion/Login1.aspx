<%@ Page Title="" Language="C#" MasterPageFile="~/Login.Master" AutoEventWireup="true" CodeBehind="Login1.aspx.cs" Inherits="PW_ProyectoTitulacion.Login1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="sweetalert2.min.js"></script>
    <script src="assets/js/SweetAlert.js"></script>
    <!-- Optional: include a polyfill for ES6 Promises for IE11 -->
    <script src="https://cdn.jsdelivr.net/npm/promise-polyfill"></script>
    <script>

        function alertme() {
            Swal.fire(
                'Good job!',
                'You clicked the button!',
                'success'
            )
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="phBody" runat="server">



    <asp:Login ID="Login" runat="server" FailureText="Credenciales Incorrectas" OnAuthenticate="Login1_Authenticate" OnLoggedIn="Login1_LoggedIn">
        <LayoutTemplate>

            <label class="block clearfix">
                <span class="block input-icon input-icon-right">
                    <asp:Label ID="UserNameLabel" Visible="false" runat="server" Text="Usuario" CssClass="control-label" AssociatedControlID="Username"></asp:Label>
                    <asp:TextBox ID="UserName" runat="server" placeholder="Usuario" CssClass="form-control" Width="288px"></asp:TextBox>
                    <i class="ace-icon fa fa-user"></i>
                </span>
            </label>

            <label class="block clearfix">
                <span class="block input-icon input-icon-right">
                    <asp:Label ID="PasswordLabel" Visible="false" runat="server" Text="Contraseña" CssClass="control-label" AssociatedControlID="Password"></asp:Label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" placeholder="Contraseña" CssClass="form-control" Width="288px"></asp:TextBox>
                    <i class="ace-icon fa fa-lock"></i>
                </span>
            </label>

            <div class="space"></div>
            <div class="clearfix">
                <span class="width-100 btn btn-sm btn-primary">
                    <i class="ace-icon fa fa-key"></i>
                    <asp:Button ID="LogginButton" runat="server" Text="Iniciar" class="width-95 btn btn-sm btn-primary" CommandName="Login" />
                </span>
            </div>
        </LayoutTemplate>
    </asp:Login>



</asp:Content>
