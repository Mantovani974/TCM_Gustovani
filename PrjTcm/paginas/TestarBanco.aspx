<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestarBanco.aspx.cs" Inherits="PrjTcm.paginas.TestarBanco" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style>
        .tabela {
            width: 80%;
            margin: 20px auto;
            border-collapse: collapse;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
            font-family: Arial, sans-serif;
            border-radius: 10px;
            overflow: hidden;
        }

        .cabecalho {
            background-color: royalblue;
            color: white;
            font-weight: bold;
            text-align: left;
            padding: 10px;
        }

        .linha {
            background-color: #f8f8f8;  
            transition: background 0.2s;
        }

        .linhaAlt {
            background-color: #e9f1ff;
        }

        .linha:hover {
            background-color: #d6e4ff;
        }

        .tabela td, .tabela th {
            padding: 10px;
            border-bottom: 1px solid #ddd;
        }

    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:GridView ID="gvTeste" runat="server" 
                AutoGenerateColumns="true"
                ShowHeaderWhenEmpty="true"
                CssClass="tabela"
                HeaderStyle-CssClass="cabecalho"
                RowStyle-CssClass="linha"
                AlternatingRowStyle-CssClass="linhaAlt">
            </asp:GridView>


            <asp:Button ID="btnComando1" runat="server" Text="CONSULTAR" OnClick="btnComando1_Click"/><br />
            <asp:Button ID="btnComando2" runat="server" Text="INCLUIR/ATUALIZAR/DELETAR" OnClick="btnComando2_Click"/><br />

            <asp:TextBox ID="txtNome" runat="server" type="text"></asp:TextBox><br />
            <asp:TextBox ID="txtSenha" runat="server" type="password"></asp:TextBox>

        </div>
    </form>

    <script>
    </script>
</body>
</html>
