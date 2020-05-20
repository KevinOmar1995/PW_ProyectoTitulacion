<%@ Page Title="" Language="C#" MasterPageFile="~/Jefes_PageMaster.Master" AutoEventWireup="true" CodeBehind="Jefes_InicioEvaluacion.aspx.cs" Inherits="PW_ProyectoTitulacion.Jefes.Jefes_InicioEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function Evaluacion(letra)
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
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    


    <div class="container">
        <div class="panel panel-primary"> 
            <div class="panel-heading">
                <asp:scriptmanager runat="server"></asp:scriptmanager>
                        <h2 class="panel-title"><%if (Session["Categoria"].ToString() == "1") { %> DESEMPEÑO <%} if (Session["Categoria"].ToString() == "2") { %> FACTOR HUMANO - ACTITUD <%} if (Session["Categoria"].ToString() == "3") { %> HABILIDADES <%}%></h2>
            </div>
            <div class="panel-body">
                 <div class="col-md-11">
                    <p class="alert alert-info"><b>Completa la Evaluaciòn</b></p>
                     <div class="table">
                         <asp:listview ID="listaPreguntas" runat="server" DataSourceID="sdsPreguntas" DataKeyNames="PreId">
                              <LayoutTemplate>
                                     <LayoutTemplate>
                                        <span id="itemPlaceHolder" runat="server"></span>
                                    </LayoutTemplate>
                              </LayoutTemplate>
                              <ItemTemplate>
                                  <div>
                                      <strong><asp:Label Id="lblPregunta" runat="server" Text='<%# Eval("PrePregunta") %>'></asp:Label>  </strong>
                                                <asp:Label Id="lblIdPregunta" runat="server" HeaderStyle-CssClass="hidden" Text='<%# Eval("PreId") %>'></asp:Label>
                                  </div>
                                  <asp:ListView ID="listaRespuesta" DataKeyNames="" runat="server" DataSourceID="sdsRespuestas">
                                      <LayoutTemplate>
                                          <span id="itemPlaceHolder" runat="server"></span>
                                      </LayoutTemplate>
                                      <ItemTemplate>
                                          <input type="radio" required="required"   id='<%# Eval("resRespuesta") %>' name='<%# Eval("PreId") %>'  value='<%# Eval("ResId") %>'/> &nbsp; <%# Eval("resRespuesta") %>
                                      </ItemTemplate>
                                  </asp:ListView>
                                
                                  <asp:SqlDataSource ID="sdsRespuestas" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="select ResId,OCKO_TblRespuestas.resRespuesta,OCKO_TblPreguntas.PreId
from OCKO_TblTipoEvaluacion INNER JOIN OCKO_TblPreguntas ON OCKO_TblTipoEvaluacion.TipId= OCKO_TblPreguntas.CodTipoEvaluacion
inner Join OCKO_TblRespuestas on OCKO_TblPreguntas.PreId = OCKO_TblRespuestas.CodPregunta
inner join OCKO_TblCategoriaPregunta on OCKO_TblCategoriaPregunta.CatId = OCKO_TblPreguntas.CodCategoria 
where (OCKO_TblCategoriaPregunta.CatId = @Categoria and OCKO_TblTipoEvaluacion.TipId = @evaluacion and OCKO_TblPreguntas.PreId =@pregunta)">
                             <SelectParameters>
                                 <asp:SessionParameter Name="categoria" SessionField="Categoria" />
                                 <asp:SessionParameter Name="evaluacion" SessionField="NoEvaluacion" />
                                 <asp:ControlParameter ControlID="lblIdPregunta" Name="pregunta" PropertyName="Text" />
                             </SelectParameters>
                         </asp:SqlDataSource>
                              </ItemTemplate>
                         </asp:listview>
                         <br />
                           <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                         <asp:sqldatasource ID="sdsPreguntas" runat="server" ConnectionString="<%$ ConnectionStrings:OCKO_EvaluacionPersonal %>" SelectCommand="select OCKO_TblPreguntas.PreId ,OCKO_TblPreguntas.PrePregunta
from OCKO_TblTipoEvaluacion 
INNER JOIN OCKO_TblPreguntas ON OCKO_TblTipoEvaluacion.TipId= OCKO_TblPreguntas.CodTipoEvaluacion
INNER JOIN OCKO_TblCategoriaPregunta on OCKO_TblCategoriaPregunta.CatId = OCKO_TblPreguntas.CodCategoria
where (OCKO_TblCategoriaPregunta.CatId = @categoria and OCKO_TblTipoEvaluacion.TipId = @evaluacion)">
                             <SelectParameters>
                                 <asp:SessionParameter Name="categoria" SessionField="Categoria" />
                                 <asp:SessionParameter Name="evaluacion" SessionField="NoEvaluacion" />
                             </SelectParameters>
                         </asp:sqldatasource>
                         
                     </div>
                 </div>
            </div>
        </div>
    </div>
</asp:Content>
