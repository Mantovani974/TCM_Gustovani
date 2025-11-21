<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/masterGrids.master" AutoEventWireup="true" CodeBehind="categoria.aspx.cs" Inherits="PrjTcm.paginas.categoria" %>


<asp:Content ID="Content1" ContentPlaceHolderID="tituloGrid" runat="server">
    Categorias
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="conteudoGrid" runat="server">

    <div class="grid-area-fixa">
        <asp:GridView ID="gvCategorias" runat="server"
            AutoGenerateColumns="true"
            ShowHeaderWhenEmpty="true"
            CssClass="tabela"
            HeaderStyle-CssClass="cabecalho"
            RowStyle-CssClass="linha"
            AlternatingRowStyle-CssClass="linhaAlt"
            AutoGenerateSelectButton="True"
            OnRowDataBound="gvCategorias_RowDataBound">
        </asp:GridView>
    </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="botoesGrid" runat="server">

    <asp:Button ID="btnAdd" CssClass="btnAdd" runat="server" Text="Adicionar" OnClick="btnAdd_Click1" />
    <asp:Button ID="btnEdit" CssClass="btnEdit" runat="server" Text="Editar" OnClick="btnEdit_Click1"/>
    <asp:Button ID="btnInativar" CssClass="btnInativar" runat="server" Text="Inativar" />
    <asp:Button ID="btnRestaurar" CssClass="btnRestaurar" runat="server" Text="Restaurar" />

</asp:Content>

