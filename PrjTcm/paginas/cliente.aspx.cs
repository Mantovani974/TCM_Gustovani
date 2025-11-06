using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string codigoSql = @"
            SELECT 
                cli.id_cliente AS 'Código',
                cli.nome AS 'Nome do Cliente',
                cli.dataNasc AS 'Data de Nascimento',
                cli.cnpj AS 'CNPJ',
                cli.email AS 'E-mail',
                cli.celular AS 'Celular',
                cli.ativo AS 'Ativo',
                e.logradouro AS 'Logradouro',
                e.numero AS 'Número',
                e.bairro AS 'Bairro',
                e.cidade AS 'Cidade',
                e.uf AS 'UF',
                e.cep AS 'CEP'
            FROM tblCliente AS cli
            INNER JOIN tblEndereco AS e ON e.id_endereco = cli.id_endereco";

            gvCliente.DataSource = Funcoes.Consultar("SELECT * FROM tblUsuario");
            gvCliente.DataBind();
        } 
    }
}