<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalheProduto.aspx.cs" Inherits="PrjTcm.paginas.detalheProduto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/detalhe.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div  class="painel">
        <div class="titulo-painel">Dados Produto</div>

        <div class="campos-painel">
            <div class="coluna">
                <div class="campo"><h2>Descrição:</h2><asp:TextBox ID="txtDescricaoProduto" runat="server" MaxLength="100"></asp:TextBox></div>
                <div class="campo"><h2>Preço:</h2><asp:TextBox ID="txtPrecoProduto" runat="server" MaxLength="10"></asp:TextBox></div>
                <div class="campo"><h2>Categoria:</h2><asp:ListBox ID="lbCategorias" runat="server"></asp:ListBox></div>
            </div>
            <div class="coluna">
                <div class="campo"><h2>Código  de Barras:</h2><asp:TextBox ID="txtCodigoBProduto" runat="server" MaxLength="11"></asp:TextBox></div>
                <div class="campo"><h2>Quantidade  em Estoque:</h2><asp:TextBox ID="txtQtdeProduto" runat="server" MaxLength="11"></asp:TextBox></div>
                <div class="campo"><h2>Imagem:</h2><asp:TextBox ID="txtImagemProduto" runat="server" MaxLength="200"></asp:TextBox></div>
            </div>
        </div>

        <div  class="botoes-painel">
            <asp:Button ID="btnConfirmar" CssClass="confirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
            <asp:Button ID="btnCancelar" CssClass="cancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
        </div>
        </div>
    </main>
</asp:Content>
