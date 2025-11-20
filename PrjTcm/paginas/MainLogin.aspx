<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainLogin.aspx.cs" Inherits="PrjTcm.paginas.MainLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link  rel="stylesheet" type="text/css" href="../css/login.css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Inter:ital,opsz,wght@0,14..32,100..900;1,14..32,100..900&display=swap" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">
        <div class="painel">
            <h1>Login</h1>
            <asp:Label ID="lblMensagem" runat="server" Text=""></asp:Label>
            <div class="painel-section">
                <h2>Nome:</h2>
                <asp:TextBox ID="txtNome" runat="server"></asp:TextBox>
            </div>
            <div class="painel-section">
                <h2>Senha:</h2>
                <asp:TextBox ID="txtSenha" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnEntrar" runat="server" Text="Entrar" CssClass="painel-btn" OnClick="btnEntrar_Click" />
        </div>
    </form>
</body>
</html>
