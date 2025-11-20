<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/masterGrids.master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="PrjTcm.paginas.usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tituloGrid" runat="server">
    Usuários
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudoGrid" runat="server">
            <asp:GridView ID="gvUsuarios" runat="server" 
               AutoGenerateColumns="true"
                ShowHeaderWhenEmpty="true"
                CssClass="tabela"
                HeaderStyle-CssClass="cabecalho"
                RowStyle-CssClass="linha"
                AlternatingRowStyle-CssClass="linhaAlt">
                <Columns>
                    <asp:ButtonField Text="Selecionar"  CommandName="selecionar"/>
                </Columns>
            </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="botoesGrid" runat="server">
    <button type="button" class="btnAdd" onclick="window.location='clienteAdd.aspx'">
        Adicionar
    </button>

    <button type="button"  class="btnEdit" onclick="window.location='clienteEdit.aspx?id=1'">
        Editar
    </button>

    <button type="button" class="btnInativar" onclick="window.location='clienteInativar.aspx'">
        Inativar
    </button>

    <button type="button"  class="btnRestaurar" onclick="window.location='clienteRestaura.aspx'">
        Restaurar
    </button>
</asp:Content>
