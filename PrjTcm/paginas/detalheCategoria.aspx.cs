using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalheCategoria : System.Web.UI.Page
    {
        char mode;
        string idCategoria;
        Funcoes f = new Funcoes();

        protected void Page_Load(object sender, EventArgs e)
        {
            idCategoria = Request.QueryString["id"];
            if (idCategoria == "0")
            {
                mode = 'A'; // A de adicionar
            }
            else
            {
                mode = 'E'; // E de editar
                if (!IsPostBack) // só faz na primeira vez que carrega ao inves de sempre que clica
                {
                    CarregarCategoria();
                }
            }
        }

        protected void CarregarCategoria()
        {
            string[] dados = f.ExecutarProcedureRetornarArray(
                "sp_RetornarCategoriaPeloId",
                new MySqlParameter("@pId", int.Parse(idCategoria))
            );

            txtNomeCategoria.Text = dados[1];
            txtDescricaoCategoria.Text = dados[2];
        }
    


        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            // Pega valores dos campos
            string nome = txtNomeCategoria.Text?.Trim();
            string descricao = txtDescricaoCategoria.Text?.Trim();

            // Impedir strings vazias
            if (string.IsNullOrWhiteSpace(nome) || string.IsNullOrWhiteSpace(descricao))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Há campos obrigatorios não preenchidos')", true);
                return;
            }


            if (mode == 'A') // Procedure para adicionar categoria
            {
                MySqlParameter[] parametros = new MySqlParameter[]
                {
                    new MySqlParameter("@pNome",nome),
                    new MySqlParameter("@pDescricao",descricao)
                };

                string msg = f.RetornoProcedureSimples("sp_InserirCategoria", parametros);
                string script = $"alert('{msg}'); window.location='categoria.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
            }
            else if (mode == 'E')
            {
                MySqlParameter[] parameters = new MySqlParameter[]
                {
                    new MySqlParameter("pId",idCategoria),
                    new MySqlParameter("pNome",nome),
                    new MySqlParameter("pDescricao", descricao)
                };
                string resultado = f.RetornoProcedureSimples("sp_EditarCategoria",parameters);
                string script = $"alert('{resultado}'); window.location='categoria.aspx';";
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("categoria.aspx");
        }

    }
}