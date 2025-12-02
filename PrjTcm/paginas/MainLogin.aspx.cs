using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class MainLogin : System.Web.UI.Page
    {
        Funcoes f = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEntrar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            string senha = txtSenha.Text;
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Há campos obrigatorios não preenchidos')", true);
                return;
            }
            MySqlParameter[] parametros = {
                new MySqlParameter("p_usuario",txtNome.Text) ,
                new MySqlParameter("p_senha",txtSenha.Text)
            };
            string msg = f.RetornoProcedureSimples("sp_validar_login", parametros);
            if (msg == "1")
            {
                Session["usuario"] = txtNome.Text;
                Response.Redirect("painel.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Login  ou Senha errados')", true);
            }

        }
    }
}