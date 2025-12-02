<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/masters/mestra.Master" AutoEventWireup="true" CodeBehind="detalheCategoria.aspx.cs" Inherits="PrjTcm.paginas.detalheCategoria" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../css/detalhe.css">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<main>
    <div class="painel">
        <div class="titulo-painel">Dados da Categoria:</div>

            <div class="campos-painel">
                <div class="coluna">
                    <div class="campo"><h2>Nome:</h2><asp:TextBox ID="txtNomeCategoria" runat="server"></asp:TextBox></div>
                    <div class="campo"><h2>Descrição:</h2><asp:TextBox ID="txtDescricaoCategoria" runat="server"></asp:TextBox></div>
                </div>
                <div class="coluna">

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
