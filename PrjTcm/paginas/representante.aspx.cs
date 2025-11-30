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
    public partial class representante : System.Web.UI.Page
    {
        Funcoes funcoes = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarRepresentantes();
        }

        private void CarregarRepresentantes()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarRepresentantes");
            cmd.CommandType = CommandType.StoredProcedure;
            gvRepresentantes.DataSource = funcoes.exSQLParameters(cmd);
            gvRepresentantes.DataBind();
            btnEditar.Enabled = false;
            btnInativar.Enabled = false;
            btnRestaurar.Enabled = false;
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalheRepresentante.aspx?id=0");
        }

        // pega o valor do id da linha clicada
        protected void gvRepresentantes_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvRepresentantes, "Select$" + e.Row.RowIndex);
            }
        }

        protected void gvRepresentantes_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvRepresentantes.Rows)
            {
                // remove classe de selecionada das outras linhas
                row.CssClass = row.RowIndex % 2 == 0 ? "linha" : "linhaAlt";
            }

            // adiciona a classe de linha selecionada
            gvRepresentantes.SelectedRow.CssClass = "linha-selecionada";

            btnEditar.Enabled = true;
            btnInativar.Enabled = true;
            btnRestaurar.Enabled = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = gvRepresentantes.SelectedRow.Cells[1].Text;
            Response.Redirect("detalheRepresentante.aspx?id=" + id);

        }

        protected void btnInativar_Click(object sender, EventArgs e)
        {
            string id = gvRepresentantes.SelectedRow.Cells[1].Text;
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",id)
            };
            string msg = funcoes.RetornoProcedureSimples("sp_InativarRepresentante", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}');", true);
            CarregarRepresentantes();
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            string id = gvRepresentantes.SelectedRow.Cells[1].Text;
            MySqlParameter[] parametros = {
                new MySqlParameter("@pId", id)
            };
            string msg = funcoes.RetornoProcedureSimples("sp_AtivarRepresentante", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}');", true);
            CarregarRepresentantes();
        }
    }
}