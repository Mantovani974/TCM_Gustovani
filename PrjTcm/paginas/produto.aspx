<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/masterGrids.master" AutoEventWireup="true" CodeBehind="produto.aspx.cs" Inherits="PrjTcm.paginas.produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tituloGrid" runat="server">
    Produtos
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="conteudoGrid" runat="server">
    <div class="area-grid">
            <asp:GridView ID="gvProdutos" runat="server"
                AutoGenerateColumns="true"
                ShowHeaderWhenEmpty="true"
                CssClass="tabela"
                HeaderStyle-CssClass="cabecalho"
                RowStyle-CssClass="linha"
                AlternatingRowStyle-CssClass="linhaAlt"
                AutoGenerateSelectButton="True"
                OnRowDataBound="gvProdutos_RowDataBound"
                OnSelectedIndexChanged="gvProdutos_SelectedIndexChanged">
            </asp:GridView>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="botoesGrid" runat="server">

    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btnAdd" OnClick="btnAdicionar_Click" />

    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btnEdit" OnClick="btnEditar_Click" />

    <asp:Button ID="btnRestaurar" runat="server" Text="Restaurar" CssClass="btnRestaurar" OnClick="btnRestaurar_Click" />

    <asp:Button ID="btnInativar" runat="server" Text="Inativar" CssClass="btnInativar" OnClick="btnInativar_Click" />
</asp:Content>
