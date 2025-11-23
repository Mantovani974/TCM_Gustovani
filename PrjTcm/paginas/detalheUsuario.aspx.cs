using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalheUsuario : System.Web.UI.Page
    {
        char mode;
        string idUsuario;
        Funcoes f = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {
            idUsuario = Request.QueryString["id"];
            if (idUsuario == "0")
            {
                mode = 'A';
            }
            else
            {
                mode = 'E';
                if (!IsPostBack)
                {
                    CarregarUsuario();
                }
            }
        }

        protected  void CarregarUsuario()
        {
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",idUsuario)
            };
            string[] dados = f.ExecutarProcedureRetornarArray(
                "sp_RetornarUsuarioPeloId",
                parametros
            );
            txtNomeUsuario.Text = dados[1];
            txtSenhaUsuario.Text = dados[2];
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("usuario.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Pega valores dos campos
            string nome = txtNomeUsuario.Text?.Trim();
            string senha = txtSenhaUsuario.Text?.Trim();

            // Msg resultado
            string msg = "erro";
            string script;

            // Impedir strings vazias
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(senha))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Há campos obrigatorios não preenchidos')", true);
                return;
            }


            if (mode == 'A') // Procedure para adicionar usuario
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pSenha",senha)
                };
                msg = f.RetornoProcedureSimples("sp_InserirUsuario",parametros);
                
            }
            else if(mode == 'E')
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("pId",idUsuario),
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pSenha",senha)
                };
                msg = f.RetornoProcedureSimples("sp_EditarUsuario", parametros);
            }
            else
            {
                Response.Redirect("usuario.aspx");
            }
            script = $"alert('{msg}'); window.location='usuario.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
        }
    }
}