<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/masterGrids.master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="PrjTcm.paginas.usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="tituloGrid" runat="server">
    Usuários
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="conteudoGrid" runat="server">

        <div class="grid-area-fixa">
            <asp:GridView ID="gvUsuarios" runat="server"
                AutoGenerateColumns="true"
                ShowHeaderWhenEmpty="true"
                CssClass="tabela"
                HeaderStyle-CssClass="cabecalho"
                RowStyle-CssClass="linha"
                AlternatingRowStyle-CssClass="linhaAlt"
                AutoGenerateSelectButton="True"
                OnRowDataBound="gvUsuarios_RowDataBound"
                OnSelectedIndexChanged="gvUsuarios_SelectedIndexChanged">
            </asp:GridView>
        </div>

</asp:Content>


<asp:Content ID="Content3" ContentPlaceHolderID="botoesGrid" runat="server">

    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar" CssClass="btnAdd" OnClick="btnAdicionar_Click" />

    <asp:Button ID="btnEditar" runat="server" Text="Editar" CssClass="btnEdit" OnClick="btnEditar_Click" />

    <asp:Button ID="btnRestaurar" runat="server" Text="Restaurar" CssClass="btnRestaurar" OnClick="btnRestaurar_Click" />

    <asp:Button ID="btnInativar" runat="server" Text="Inativar" CssClass="btnInativar" OnClick="btnInativar_Click" />
</asp:Content>
