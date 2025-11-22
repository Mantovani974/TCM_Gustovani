using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalheCategoria : System.Web.UI.Page
    {
        private static string id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Request.QueryString["id"];
            if (id == "0")
            {
                return;
            }
            Response.Write("ID resgatado: " + id);
            carregarDadosCategoria();
        }

        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            MySqlCommand cmd = new MySqlCommand("sp_InserirCategoria");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pNome", txtNomeCategoria.Text);
            cmd.Parameters.AddWithValue("@pDescricao", txtDescricaoCategoria.Text);

            Funcoes f = new Funcoes();
            DataTable dt = f.exSQLParameters(cmd);

            // pega o retorno da procedure
            string retorno = dt.Rows[0]["Resultado"].ToString();

            if (retorno == "EXISTE")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Categoria ja existente!');", true);
                return; // não redireciona
            }

            // se chegou aqui, tudo certo → inserir OK
            Response.Redirect("categoria.aspx");
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoria.aspx");
        }

        protected void carregarDadosCategoria()
        {
            MySqlCommand cmd = new MySqlCommand("sp_RetornarCategoriaPeloId");
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@pId", id);

            Funcoes f = new Funcoes();
            DataTable dt = f.exSQLParameters(cmd);

            if (dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                string[] dados = row.ItemArray
                    .Select(c => c.ToString())
                    .ToArray();

                txtNomeCategoria.Text = dados[1];
                txtDescricaoCategoria.Text = dados[2];
                    
            }


        }
    }
}