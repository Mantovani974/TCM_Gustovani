using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PrjTcm.paginas
{
    public partial class TestarBanco : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnComando1_Click(object sender, EventArgs e)
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

            gvTeste.DataSource = Funcoes.Consultar("SELECT * FROM tblUsuario");
            gvTeste.DataBind();
        }

        protected void btnComando2_Click(object sender, EventArgs e)
        {
            string codigoSql = @"";

            Funcoes.Executar(codigoSql);
        }
    }
}
