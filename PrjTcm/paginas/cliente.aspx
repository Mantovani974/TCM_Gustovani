<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/masterGrids.master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="PrjTcm.paginas.cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tituloGrid" runat="server">
    Clientes
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="conteudoGrid" runat="server">
            <asp:GridView ID="gvClientes" runat="server" 
                AutoGenerateColumns="true"
                ShowHeaderWhenEmpty="true"
                CssClass="tabela"
                HeaderStyle-CssClass="cabecalho"
                RowStyle-CssClass="linha"
                AlternatingRowStyle-CssClass="linhaAlt">
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
