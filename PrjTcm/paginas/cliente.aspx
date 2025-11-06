<%@ Page Title="" Language="C#" MasterPageFile="~/paginas/mestra.Master" AutoEventWireup="true" CodeBehind="cliente.aspx.cs" Inherits="PrjTcm.paginas.cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <main>
        <asp:GridView ID="gvCliente" runat="server" 
            AutoGenerateColumns="true"
            ShowHeaderWhenEmpty="true"
            CssClass="tabela"
            HeaderStyle-CssClass="cabecalho"
            RowStyle-CssClass="linha"
            AlternatingRowStyle-CssClass="linhaAlt">
        </asp:GridView>

    </main>

</asp:Content>
