using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalheUsuario : System.Web.UI.Page
    {
        static char mode = 'A';
        Funcoes f = new Funcoes();
        static int id = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Request.QueryString["id"]))
            {
                mode = 'N';
                return;
            }
            id = int.Parse(Request.QueryString["id"]);
            CarregarUsuario();
        }

        protected  void CarregarUsuario()
        {
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",id)
            };
            string[] dados = f.ExecutarProcedureRetornarArray(
                "sp_RetornarUsuarioPeloId",
                parametros
            );
            txtNomeUsuario.Text = dados[1];
            txtSenhaUsuario.Text = dados[2];
            mode = 'E';
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuario.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (mode == 'N')
            {
                string nome = txtNomeUsuario.Text?.Trim();

                // Evitar que senha venha com espaços acidentais
                string senha = txtSenhaUsuario.Text?.Trim();

                // Impedir strings vazias
                if (string.IsNullOrWhiteSpace(nome)  || string.IsNullOrWhiteSpace(senha))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Há campos obrigatorios não preenchidos')", true);
                    return;
                }
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pSenha",senha)
                };
                string msg = f.RetornoProcedureSimples("sp_InserirUsuario",parametros);
                ScriptManager.RegisterStartupScript(this,GetType(),"msg", $"alert('{msg}'); window.location='usuario.aspx';", true);
            }
            else if(mode == 'E')
            {
                string nome = txtNomeUsuario.Text?.Trim();
                // Evitar que senha venha com espaços acidentais
                string senha = txtSenhaUsuario.Text?.Trim();

                // Impedir strings vazias
                if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Há campos obrigatorios não preenchidos')", true);
                    return;
                }
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pId",id),
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pSenha",senha)
                };
                string msg = f.RetornoProcedureSimples("sp_EditarUsuario", parametros);
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}'); window.location='usuario.aspx';", true);
            }
            else
            {
                Response.Redirect("usuario.aspx");
            }
        }
    }
}