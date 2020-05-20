<%@ Page Title="" Language="C#" MasterPageFile="~/RRHH_PageMaster.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PW_ProyectoTitulacion.pruebas.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="panel panel-primary">
            <div class="panel-heading">
                <h2 class="panel-title">
                    <% if (Session["NoExamen"].ToString() == "1")
                        {
                    %>
                        Matematicas
                    <%      
                        }
                        if (Session["NoExamen"].ToString() == "2")
                        {
                    %>
                        Fisica
                    <%      
                        }
                        if (Session["NoExamen"].ToString() == "3")
                        {
                    %>
                        Quimica
                    <%      
                        }

                    %>
                </h2>
            </div>
            <div class="panel-body">
                <div class="col-md-1">
                    <div class="btn btn-danger btn-lg">
                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Timer ID="Reloj" runat="server" Interval="1000" OnTick="Reloj_Tick"></asp:Timer>
                                <strong>
                                    <asp:Label ID="lblReloj" runat="server" Text=""></asp:Label>
                                </strong>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </div>
                </div>
                <div class="col-md-11">
                    <p class="alert alert-info"><b>Elige una Respuesta</b></p>
                    <div class="table ">
                        <asp:ListView ID="listaPreguntas" runat="server" DataSourceID="sdsPreguntas" DataKeyNames="idPregunta">
                            <LayoutTemplate>
                                <span id="itemplaceholder" runat="server"></span>
                            </LayoutTemplate>
                            <ItemTemplate>
                                <div>
                                    <strong>
                                        <asp:Label ID="lnlPregunta" runat="server" Text='<%# Eval("Pregunta") %>'></asp:Label>
                                    </strong>
                                    <asp:Label ID="lblIdPregunta" runat="server" Text='<%# Eval("idPregunta") %>' Visible="false"></asp:Label>
                                </div>
                                <asp:ListView ID="listaRespuestas" DataKeyNames="idRespuesta" DataSourceID="sdsRespuestas" runat="server">
                                    <LayoutTemplate>
                                        <span id="itemPlaceHolder" runat="server"></span>
                                    </LayoutTemplate>
                                    <ItemTemplate>
                                        <input type="radio" id='<%# Eval("respuesta") %>' name='<%# Eval("idRespuesta") %>' value='<%# Eval("idRespuesta") %>' />&nbsp; <%# Eval("respuesta") %>
                                    </ItemTemplate>
                                </asp:ListView>
                                <asp:SqlDataSource ID="sdsRespuestas" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenTest %>" SelectCommand="Select idRespuesta,Respuestas.respuesta,Preguntas.idPregunta
from Examenes inner join Preguntas on Examenes.idExamen = Preguntas.idExamen
inner join Respuestas on Preguntas.idPregunta = Respuestas.idPregunta
where Examenes.idExamen =@examen and Preguntas.idPregunta = @pregunta">
                                    <SelectParameters>
                                        <asp:SessionParameter Name="examen" SessionField="NoExamen" />
                                        <asp:ControlParameter ControlID="lblIdPregunta" Name="pregunta" PropertyName="Text" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </ItemTemplate>
                        </asp:ListView>
                        <br />
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        <asp:SqlDataSource ID="sdsPreguntas" runat="server" ConnectionString="<%$ ConnectionStrings:ExamenTest %>" SelectCommand="select top 5 Preguntas.idPregunta,Preguntas.pregunta
From Examenes Inner Join Preguntas on Examenes.idExamen = Preguntas.idExamen
where (Examenes.idExamen=@examen) ;">
                            <SelectParameters>
                                <asp:SessionParameter Name="examen" SessionField="NoExamen" />
                            </SelectParameters>
                        </asp:SqlDataSource>
                    </div>


                </div>
            </div>

        </div>
    </div>
</asp:Content>
