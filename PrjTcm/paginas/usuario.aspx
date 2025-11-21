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
                AlternatingRowStyle-CssClass="linhaAlt"
                OnRowDataBound="gvUsuarios_RowDataBound"
                OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged"
                >
            </asp:GridView>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="botoesGrid" runat="server">

    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btnAdd" OnClick="btnAdicionar_Click" />

    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btnEdit" />

    <asp:Button ID="btnRastaurar" runat="server" Text="Restaurar" CssClass="btnRestaurar" />

    <asp:Button ID="btnInativar" runat="server" Text="Inativar" CssClass="btnInativar" />
</asp:Content>
