<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalhePedido.aspx.cs" Inherits="PrjTcm.paginas.detalhePedido" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/detalhe.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <main>
        <div class="painel">
            <div class="titulo-painel"><h1>Dados Pedido</h1></div>

            <div class="campos-painel">
                <div class="coluna">
                    <div class="campo"><h2>Cliente:</h2><asp:ListBox ID="lbClientes" runat="server"></asp:ListBox></div>
                    <div class="campo"><h2>Representante:</h2><asp:ListBox ID="lbRepresentantes" runat="server"></asp:ListBox></div>
                    <div class="campo">
                        <h2>Status:</h2>
                        <asp:ListBox ID="lbStatusPedido" runat="server">
                            <asp:ListItem>Pendente</asp:ListItem>
                            <asp:ListItem>Concluido</asp:ListItem>
                        </asp:ListBox>
                    </div>
                </div>
                <div class="coluna">
                    <div class="campo"><h2>Data Entrega:</h2><asp:TextBox ID="txtDataPedido" runat="server" TextMode="Date" ></asp:TextBox></div>
                    <div class="campo"><h2>Frete:</h2><asp:TextBox ID="txtFretePedido" runat="server" MaxLength="20"></asp:TextBox></div>
                </div>
            </div>
            <div class="areaItens">
                                    <h1>Itens  do  Pedidos</h1>
                <asp:Panel ID="pItens" runat="server">
                </asp:Panel>
                <asp:Button ID="btnAdicionarItem" runat="server" Text="Adicionar Novo Item" OnClick="btnAdicionarItem_Click" />
            </div>
            <div>
                <div class="botoes-painel">
                    <asp:Button ID="btnCofirmar" CssClass="confirmar" runat="server" Text="Confirmar" OnClick="btnCofirmar_Click" />
                    <asp:Button ID="btnCancelar" CssClass="cancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
                </div>
            </div>
        </div>
    </main>
</asp:Content>
