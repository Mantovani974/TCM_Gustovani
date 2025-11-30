using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalheRepresentante : System.Web.UI.Page
    {
        char mode;
        string idRepresentante;
        Funcoes f = new Funcoes();

        protected void Page_Load(object sender, EventArgs e)
        {
            idRepresentante = Request.QueryString["id"];
            if (idRepresentante != "0" && !string.IsNullOrEmpty(idRepresentante))
            {
                mode = 'E';
                if (!IsPostBack)
                {
                    CarregarRepresentante();
                }
            }
            else if (idRepresentante == "0")
            {
                mode = 'A'; // A de adicionar
            }
            else
            {
                Response.Redirect("cliente.aspx");
            }
        }

        protected void CarregarRepresentante()
        {
            MySqlParameter[] parametros = new MySqlParameter[]
            {
                new MySqlParameter("pId",idRepresentante)
            };
            string[] dados = f.ExecutarProcedureRetornarArray("sp_RetornarRepresentantePeloId", parametros);

            txtNomeRepresentante.Text = dados[0];
            txtDataNascRepresentante.Text = Convert.ToDateTime(dados[1]).ToString("yyyy-MM-dd");
            txtCpfRepresentante.Text = dados[2];
            txtComissaoRepresentante.Text = dados[3];
            txtEmailRepresentante.Text = dados[4];
            txtCelularRepresentante.Text = dados[5];
            txtLogradouroRepresentante.Text = dados[6];
            txtNumeroRepresentante.Text = dados[7];
            txtBairroRepresentante.Text = dados[8];
            txtCidadeRepresentante.Text = dados[9];
            txtUfRepresentante.Text = dados[10];
            txtCepRepresentante.Text = dados[11];
        }



        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            // Pega valores dos campos
            string nome = txtNomeRepresentante.Text?.Trim();
            DateTime dataNasc = DateTime.Parse(txtDataNascRepresentante.Text?.Trim());
            string cpf = txtCpfRepresentante.Text?.Trim();
            string comissao = txtComissaoRepresentante.Text?.Trim();
            string email = txtEmailRepresentante.Text?.Trim();
            string celular = txtCelularRepresentante.Text?.Trim();

            string logradouro = txtLogradouroRepresentante.Text?.Trim();
            string numero = txtNumeroRepresentante.Text?.Trim();
            string cidade = txtCidadeRepresentante.Text?.Trim();
            string bairro = txtBairroRepresentante.Text?.Trim();
            string uf = txtUfRepresentante.Text?.Trim();
            string cep = txtCepRepresentante.Text?.Trim();


            // Impedir strings vazias
            if (string.IsNullOrWhiteSpace(nome) ||
                dataNasc == DateTime.MinValue ||
                string.IsNullOrWhiteSpace(cpf) ||
                string.IsNullOrWhiteSpace(comissao) ||
                string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(celular) ||
                string.IsNullOrWhiteSpace(logradouro) ||
                string.IsNullOrWhiteSpace(numero) ||
                string.IsNullOrWhiteSpace(cidade) ||
                string.IsNullOrWhiteSpace(bairro) ||
                string.IsNullOrWhiteSpace(uf) ||
                string.IsNullOrWhiteSpace(cep))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg",
                    "alert('Há campos obrigatórios não preenchidos')", true);
                return;
            }

            //Msg resultado
            string msg = "erro";
            string script;
            if (mode == 'A') // Procedure para adicionar Representante
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pNome", nome),
                    new MySqlParameter("pDataNasc", dataNasc),
                    new MySqlParameter("pCpf", cpf),
                    new MySqlParameter("pComissao", comissao),
                    new MySqlParameter("pEmail", email),
                    new MySqlParameter("pCelular", celular),
                    new MySqlParameter("pLogradouro", logradouro),
                    new MySqlParameter("pNumero", numero),
                    new MySqlParameter("pCidade", cidade),
                    new MySqlParameter("pBairro", bairro),
                    new MySqlParameter("pUf", uf),
                    new MySqlParameter("pCep", cep)
                };
                msg = f.RetornoProcedureSimples("sp_InserirRepresentante", parametros);
            }

            else if (mode == 'E')
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pId", int.Parse(idRepresentante)),
                    new MySqlParameter("pNome", nome),
                    new MySqlParameter("pDataNasc", dataNasc),
                    new MySqlParameter("pCpf", cpf),
                    new MySqlParameter("pComissao", comissao),
                    new MySqlParameter("pEmail", email),
                    new MySqlParameter("pCelular", celular),
                    new MySqlParameter("pLogradouro", logradouro),
                    new MySqlParameter("pNumero", numero),
                    new MySqlParameter("pCidade", cidade),
                    new MySqlParameter("pBairro", bairro),
                    new MySqlParameter("pUf", uf),
                    new MySqlParameter("pCep", cep)
                };
                msg = f.RetornoProcedureSimples("sp_EditarRepresentante", parametros);
            }
            else
            {
                Response.Redirect("representante.aspx");
            }
            script = $"alert('{msg}'); window.location='representante.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("representante.aspx");
        }
    }
}