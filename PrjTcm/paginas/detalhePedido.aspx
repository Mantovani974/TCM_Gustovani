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
                    <div class="campo"><h2>Data Prevista Para Entrega:</h2></div>
                </div>
            </div>
        </div>
    </main>
</asp:Content>
