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
        protected void Page_Load(object sender, EventArgs e)
        {
            CarregarUsuario();
        }

        protected  void CarregarUsuario()
        {
            string id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(id))
            {
                mode = 'N';
                return;
            }
            string[] dados = f.ExecutarProcedureRetornarArray(
                "sp_RetornarUsuarioPeloId",
                new MySqlParameter("@pId", int.Parse(id))
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
            if(mode == 'N')
            {
                Response.Redirect("painel.aspx");
            }else if(mode == 'E')
            {
                /*Procedure para  editar usuario*/
            }
            else
            {
                Response.Redirect("usuario.aspx");
            }
        }
    }
}