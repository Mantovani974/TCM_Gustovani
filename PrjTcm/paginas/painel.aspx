<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/mestra.Master" AutoEventWireup="true" CodeBehind="painel.aspx.cs" Inherits="PrjTcm.paginas.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/painel.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <main>
        <div class="painel">
            <div class="jockey-one-regular"><h1>Painel Admin</h1></div>
                <div class="painelLinha">
                    <div class="celula">
                        <a href="cliente.aspx">
                        <img src="../imgs/painel/iconCliente.png" class="icone"/>
                        <h2>Clientes</h2>
                        </a>
                    </div>
                    <div class="celula">
                        <a href="produto.aspx">
                        <img src="../imgs/painel/iconProduto.png" class="icone"/>
                        <h2>Produtos</h2>
                        </a>
                    </div>
                    <div class="celula">
                        <a  href="representante.aspx">
                        <img src="../imgs/painel/iconRepresentante.png" class="icone"/>
                        <h2>Representantes</h2>
                        </a>
                    </div>
                </div>
                <div class="painelLinha">
                    <div class="celula">
                        <a href="pedido.aspx">
                        <img src="../imgs/painel/iconPedido.png" class="icone"/>
                        <h2>Pedidos</h2>
                        </a>
                    </div>
                    <div class="celula">
                        <a href="categoria.aspx">
                        <img src="../imgs/painel/iconCategoria.png" class="icone"/>
                        <h2>Categoria</h2>
                        </a>
                    </div>
                    <div class="celula">
                        <a  href="usuario.aspx">
                        <img src="../imgs/painel/iconUser.png" class="icone"/>
                        <h2>Usuário</h2>
                        </a>
                    </div>
                </div>
            <asp:Button ID="btnSair" runat="server" Text="Sair" />
            </div>
    </main>
</asp:Content>
