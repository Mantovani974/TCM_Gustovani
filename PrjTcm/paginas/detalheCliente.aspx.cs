using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalheCliente : System.Web.UI.Page
    {
        char mode;
        string idCliente;
        Funcoes f = new Funcoes();

        protected void Page_Load(object sender, EventArgs e)
        {
            idCliente = Request.QueryString["id"];
            if (idCliente == "0")
            {
                mode = 'A'; // A de adicionar
            }
            else
            {
                mode = 'E'; // E de editar
                if (!IsPostBack) // só faz na primeira vez que carrega ao inves de sempre que clica
                {
                    CarregarCliente();
                }
            }
        }

        protected void CarregarCliente()
        {
            string[] dados = f.ExecutarProcedureRetornarArray(
                "sp_RetornarClientePeloId",
                new MySqlParameter("@pId", int.Parse(idCliente))
            );

            txtNomeCliente.Text = dados[1];
            txtCnpjCliente.Text = dados[2];
            txtEmailCliente.Text = dados[3];
            txtCelularCliente.Text = dados[4];
            txtLogradouroCliente.Text = dados[7];
            txtNumeroCliente.Text = dados[8];
            txtBairroCliente.Text = dados[9];
            txtCidadeCliente.Text = dados[10];
            txtUfCliente.Text = dados[11];
            txtCepCliente.Text = dados[12];

        }



        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            if (mode == 'A') // Procedure para adicionar cliente
            {
                // Pega valores dos campos
                string nome = txtNomeCliente.Text.Trim();
                string cnpj = txtCnpjCliente.Text.Trim();
                string email = txtEmailCliente.Text.Trim();
                string celular = txtCelularCliente.Text.Trim();
                string logradouro = txtLogradouroCliente.Text.Trim();
                int numero = int.Parse(txtNumeroCliente.Text.Trim());
                string cidade = txtCidadeCliente.Text.Trim();
                string bairro = txtBairroCliente.Text.Trim();
                string uf = txtUfCliente.Text.Trim();
                string cep = txtCepCliente.Text.Trim();

                string resultado = f.RetornoProcedureSimples(
                    "sp_InserirCliente",
                    new MySqlParameter("@pNome", nome),
                    new MySqlParameter("@pCnpj", cnpj),
                    new MySqlParameter("@pEmail", email),
                    new MySqlParameter("@pCelular", celular),
                    new MySqlParameter("@pLogradouro", logradouro),
                    new MySqlParameter("@pNumero", numero),
                    new MySqlParameter("@pCidade", cidade),
                    new MySqlParameter("@pBairro", bairro),
                    new MySqlParameter("@pUf", uf),
                    new MySqlParameter("@pCep", cep)
                );

                string script = $"alert('{resultado}'); window.location='cliente.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
            }

            else if (mode == 'E')
            {
                // Pega valores dos campos
                int id = int.Parse(idCliente);
                string nome = txtNomeCliente.Text.Trim();
                string cnpj = txtCnpjCliente.Text.Trim();
                string email = txtEmailCliente.Text.Trim();
                string celular = txtCelularCliente.Text.Trim();
                string logradouro = txtLogradouroCliente.Text.Trim();
                int numero = int.Parse(txtNumeroCliente.Text.Trim());
                string cidade = txtCidadeCliente.Text.Trim();
                string bairro = txtBairroCliente.Text.Trim();
                string uf = txtUfCliente.Text.Trim();
                string cep = txtCepCliente.Text.Trim();

                string resultado = f.RetornoProcedureSimples(
                    "sp_EditarCliente",
                    new MySqlParameter("@pId", id),
                    new MySqlParameter("@pNome", nome),
                    new MySqlParameter("@pCnpj", cnpj),
                    new MySqlParameter("@pEmail", email),
                    new MySqlParameter("@pCelular", celular),
                    new MySqlParameter("@pLogradouro", logradouro),
                    new MySqlParameter("@pNumero", numero),
                    new MySqlParameter("@pCidade", cidade),
                    new MySqlParameter("@pBairro", bairro),
                    new MySqlParameter("@pUf", uf),
                    new MySqlParameter("@pCep", cep)
                );

                string script = $"alert('{resultado}'); window.location='cliente.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cliente.aspx");
        }

    }
}