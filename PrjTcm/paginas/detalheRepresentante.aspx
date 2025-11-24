<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalheRepresentante.aspx.cs" Inherits="PrjTcm.paginas.detalheRepresentante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/detalhe.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <div class="painel">
        <div class="titulo-painel"><h1>Representantes</h1></div>

            <div class="campos-painel">
                <div class="coluna">
                    <div class="campo"><h2>Nome:</h2><asp:TextBox ID="txtNomeRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Data de Nascimento:</h2><asp:TextBox ID="txtDataNascRepresentante" runat="server" TextMode="Date" /></div>
                    <div class="campo"><h2>CPF:</h2><asp:TextBox ID="txtCpfRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Comissão:</h2><asp:TextBox ID="txtComissaoRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Email:</h2><asp:TextBox ID="txtEmailRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Celular:</h2><asp:TextBox ID="txtCelularRepresentante" runat="server"></asp:TextBox></div>
                </div>
                <div class="coluna">
                    <div class="campo"><h2>Logradouro:</h2><asp:TextBox ID="txtLogradouroRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Número:</h2><asp:TextBox ID="txtNumeroRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Cidade:</h2><asp:TextBox ID="txtCidadeRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Bairro:</h2><asp:TextBox ID="txtBairroRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>UF:</h2><asp:TextBox ID="txtUfRepresentante" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>CEP:</h2><asp:TextBox ID="txtCepRepresentante" runat="server"></asp:TextBox></div>
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
