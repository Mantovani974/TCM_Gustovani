<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalheCliente.aspx.cs" Inherits="PrjTcm.paginas.detalheCliente" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/detalhe.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <div class="painel">
        <div class="titulo-painel">Detalhes Cliente</div>

            <div class="campos-painel">
                <div class="coluna">
                    <div class="campo"><h2>Nome:</h2><asp:TextBox ID="txtNomeCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>CNPJ:</h2><asp:TextBox ID="txtCnpjCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Celular:</h2><asp:TextBox ID="txtCelularCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Email:</h2><asp:TextBox ID="txtEmailCliente" runat="server"></asp:TextBox></div>
                </div>
                <div class="coluna">
                    <div class="campo"><h2>Logradouro:</h2><asp:TextBox ID="txtLogradouroCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Número:</h2><asp:TextBox ID="txtNumeroCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Cidade:</h2><asp:TextBox ID="txtCidadeCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Bairro:</h2><asp:TextBox ID="txtBairroCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>UF:</h2><asp:TextBox ID="txtUfCliente" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>CEP:</h2><asp:TextBox ID="txtCepCliente" runat="server"></asp:TextBox></div>
                </div>
                <div class="coluna">

                </div>
            </div>

            <div class="botoes-painel">
                <asp:Button ID="btnCofirmar" CssClass="confirmar" runat="server" Text="Confirmar" OnClick="btnCofirmar_Click" />
                <asp:Button ID="btnCancelar" CssClass="cancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
    </div>
</main>

</asp:Content>
