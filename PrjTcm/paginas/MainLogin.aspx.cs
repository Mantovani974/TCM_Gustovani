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
            try
            {
                MySqlCommand comando = new MySqlCommand();
                comando.CommandText =
                    "SELECT * FROM tblUsuario WHERE nome = @usuario AND senha = @senha";

                string usuario = txtNome.Text;
                string senha = txtSenha.Text;

                comando.Parameters.AddWithValue("@usuario", usuario);
                comando.Parameters.AddWithValue("@senha", senha);

                DataTable dt = f.exSQLParameters(comando);

                if (dt != null && dt.Rows.Count > 0)
                {
                    Session["usuario"] = dt.Rows[0]["nome"].ToString();
                    Response.Redirect("painel.aspx");
                }
                else
                {
                    lblMensagem.Text = "Usuário ou senha inválidos.";
                }
            }
            catch (Exception ex)
            {
                lblMensagem.Text = "Erro ao efetuar login: " + ex.Message;
            }
        }
    }
}