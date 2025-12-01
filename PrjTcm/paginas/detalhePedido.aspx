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
                <asp:Panel ID="pItens" runat="server">
                    <h1>Itens  do  Pedidos</h1>
                    <br />
                </asp:Panel>
            </div>
        </div>
    </main>
</asp:Content>
