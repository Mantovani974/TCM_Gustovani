<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/mestra.Master" AutoEventWireup="true" CodeBehind="painel.aspx.cs" Inherits="PrjTcm.paginas.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/painel.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

    <main>
        <div class="painel">
        <div class="titulo-painel"><h1>Painel Admin</h1></div>
            <div class="tabela">
                <div class="celula">
                    <div class="icone" onclick="window.location.href='cliente.aspx'" style="cursor:pointer;">
                        <img src="../imgs/painel/iconCliente.png" alt="icone de cliente" draggable="false">
                        <h1>Clientes</h1>
                    </div>
                </div>
                <div class="celula">
                    <div class="icone" onclick="window.location.href='produto.aspx'" style="cursor:pointer;">
                        <img src="../imgs/painel/iconProduto.png" alt="icone de produto" draggable="false">
                        <h1>Produtos</h1>
                    </div>
                </div>
                <div class="celula">
                    <div class="icone" onclick="window.location.href='representante.aspx'" style="cursor:pointer;">
                        <img src="../imgs/painel/iconRepresentante.png" alt="icone de representante" draggable="false">
                        <h1>Representantes</h1>
                    </div>
                </div>
                <div class="celula">
                    <div class="icone" onclick="window.location.href='pedido.aspx'" style="cursor:pointer;">
                        <img src="../imgs/painel/iconPedido.png" alt="icone de pedido" draggable="false">
                        <h1>Pedidos</h1>
                    </div>
                </div>
                <div class="celula">
                    <div class="icone" onclick="window.location.href='categoria.aspx'" style="cursor:pointer;">
                        <img src="../imgs/painel/iconCategoria.png" alt="icone de categoria" draggable="false">
                        <h1>Categorias </h1>
                    </div>
                </div>
                <div class="celula">
                    <div class="icone" onclick="window.location.href='usuario.aspx'" style="cursor:pointer;">
                        <img src="../imgs/painel/iconUser.png" alt="icone de usuário" draggable="false">
                        <h1>Usuário</h1>
                    </div>
                </div>
            </div>
            <div class="rodape-painel"><button>Sair</button></div>
        </div>
    </main>


</asp:Content>
