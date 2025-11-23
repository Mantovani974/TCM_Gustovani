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
            MySqlParameter[] parametros = new MySqlParameter[]
            {
                new MySqlParameter("pId",idCliente)
            };
            string[] dados = f.ExecutarProcedureRetornarArray("sp_RetornarClientePeloId",parametros);

            txtNomeCliente.Text = dados[0];
            txtCnpjCliente.Text = dados[1];
            txtEmailCliente.Text = dados[2];
            txtCelularCliente.Text = dados[3];
            txtLogradouroCliente.Text = dados[4];
            txtNumeroCliente.Text = dados[5];
            txtBairroCliente.Text = dados[6];
            txtCidadeCliente.Text = dados[7];
            txtUfCliente.Text = dados[8];
            txtCepCliente.Text = dados[9];

        }



        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            // Pega valores dos campos
            string nome = txtNomeCliente.Text?.Trim();
            string cnpj = txtCnpjCliente.Text?.Trim();
            string email = txtEmailCliente.Text?.Trim();
            string celular = txtCelularCliente.Text?.Trim();
            string logradouro = txtLogradouroCliente.Text?.Trim();
            string numero = txtNumeroCliente.Text?.Trim();
            string cidade = txtCidadeCliente.Text?.Trim();
            string bairro = txtBairroCliente.Text?.Trim();
            string uf = txtUfCliente.Text?.Trim();
            string cep = txtCepCliente.Text?.Trim();

            // Impedir strings vazias
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(cnpj) || string.IsNullOrWhiteSpace(email) ||  string.IsNullOrWhiteSpace(celular) || string.IsNullOrWhiteSpace(logradouro) || string.IsNullOrWhiteSpace(numero) || string.IsNullOrWhiteSpace(bairro) || string.IsNullOrWhiteSpace(uf) || string.IsNullOrWhiteSpace(cep))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Há campos obrigatorios não preenchidos')", true);
                return;
            }
            //Msg resultado
            string msg = "erro";
            string script;
            if (mode == 'A') // Procedure para adicionar cliente
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pCnpj",cnpj),
                    new MySqlParameter("pEmail",email),
                    new MySqlParameter("pCelular",celular),
                    new MySqlParameter("pLogradouro",logradouro),
                    new MySqlParameter("pNumero",numero),
                    new MySqlParameter("pCidade",cidade),
                    new MySqlParameter("pBairro",bairro),
                    new MySqlParameter("pUf",uf),
                    new MySqlParameter("pCep",cep)
                };
                msg = f.RetornoProcedureSimples("sp_InserirCliente", parametros);
            }

            else if (mode == 'E')
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pId",idCliente),
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pCnpj",cnpj),
                    new MySqlParameter("pEmail",email),
                    new MySqlParameter("pCelular",celular),
                    new MySqlParameter("pLogradouro",logradouro),
                    new MySqlParameter("pNumero",numero),
                    new MySqlParameter("pCidade",cidade),
                    new MySqlParameter("pBairro",bairro),
                    new MySqlParameter("pUf",uf),
                    new MySqlParameter("pCep",cep)
                };
                msg = f.RetornoProcedureSimples("sp_EditarCliente", parametros);
            }
            else
            {
                Response.Redirect("cliente.aspx");
            }
                script = $"alert('{msg}'); window.location='cliente.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("cliente.aspx");
        }

    }
}