<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalheUsuario.aspx.cs" Inherits="PrjTcm.paginas.detalheUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <link rel="stylesheet" href="../css/detalhe.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <div class="painel">
        <div class="titulo-painel"><h1>Dados Usuário</h1></div>
            
            <div class="campos-painel">
                <div class="coluna">
                    <div class="campo"><h2>Nome:</h2><asp:TextBox ID="txtNomeUsuario" runat="server" MaxLength="50"></asp:TextBox></div>
                    <div class="campo"><h2>Senha:</h2><asp:TextBox ID="txtSenhaUsuario" runat="server" MaxLength="10"></asp:TextBox></div>
                </div>
                <div class="coluna">

                </div>
                <div class="coluna">

                </div>
            </div>

            <div class="botoes-painel">
                <asp:Button ID="btnConfirmar" CssClass="confirmar" runat="server" Text="Confirmar" OnClick="btnConfirmar_Click" />
                <asp:Button ID="btnCancelar" CssClass="cancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" />
            </div>
    </div>
</main>

</asp:Content>
