<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="itemPedido.aspx.cs" Inherits="PrjTcm.paginas.itemPedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/detalhe.css">   
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
            <div class="painel">
                <div class="titulo-painel"><h1>Item do Pedido</h1></div>
                <div class="campos-painel">
                    <div class="coluna">
                        <div class="campo">
                            <h2>Produto:</h2>
                            <asp:ListBox ID="lbProdutos" runat="server"></asp:ListBox>
                        </div>
                        <div class="campo">
                            <h2>Quantidade:</h2>
                            <asp:TextBox ID="txtQuantidadeItem" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="coluna">
                        <div class="campo">
                            <h2>Desconto:</h2>
                            <asp:TextBox ID="txtDescontoItem" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                    <div class="botoes-painel">
                        <asp:Button ID="btnCofirmar" CssClass="confirmar" runat="server" Text="Confirmar" OnClick="btnCofirmar_Click" />
                        <asp:Button ID="btnCancelar" CssClass="cancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                    </div>
                </div>
    </main>
</asp:Content>
