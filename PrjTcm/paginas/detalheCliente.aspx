<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalheCliente.aspx.cs" Inherits="PrjTcm.paginas.masters.detalhePedido" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../../css/detalhe.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <div class="painel">
        <div class="titulo-painel"><h1>Clientes</h1></div>

            <div class="campos-painel">
                <div class="coluna">
                    <div class="campo"><h2>Nome:</h2><asp:TextBox ID="txtNomeCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>CNPJ:</h2><asp:TextBox ID="txtCnpjCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Celular:</h2><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Email:</h2><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></div>
                </div>
                <div class="coluna">
                    <div class="campo"><h2>Logradouro:</h2><asp:TextBox ID="TextBox4" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Número:</h2><asp:TextBox ID="TextBox5" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Cidade:</h2><asp:TextBox ID="TextBox6" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Bairro:</h2><asp:TextBox ID="TextBox7" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>UF:</h2><asp:TextBox ID="TextBox8" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>CEP:</h2><asp:TextBox ID="TextBox9" runat="server"></asp:TextBox></div>
                </div>
                <div class="coluna">

                </div>
            </div>

            <div class="botoes-painel">
                <asp:Button ID="Button1" CssClass="confirmar" runat="server" Text="Confirmar" />
                <asp:Button ID="Button2" CssClass="cancelar" runat="server" Text="Cancelar" />
            </div>
    </div>
</main>
    
</asp:Content>
