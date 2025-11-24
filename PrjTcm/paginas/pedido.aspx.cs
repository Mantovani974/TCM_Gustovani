using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class pedido : System.Web.UI.Page
    {
        Funcoes funcoes = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void CarregarPedidos()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarPedidos");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            gvPedidos.DataSource = funcoes.exSQLParameters(cmd);
            gvPedidos.DataBind();
            btnEditar.Enabled = false;
            btnInativar.Enabled = false;
            btnRestaurar.Enabled = false;
        }

        protected void gvPedidos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvPedidos, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvPedidos.Rows)
            {
                row.CssClass = row.RowIndex % 2 == 0 ? "linha" : "linhaAlt";
            }

            gvPedidos.SelectedRow.CssClass = "linha-selecionada";

            btnEditar.Enabled = true;
            btnInativar.Enabled = true;
            btnRestaurar.Enabled = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = gvPedidos.SelectedRow.Cells[1].Text;
            Response.Redirect("detalheProduto.aspx?id=" + id);
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            string id = gvPedidos.SelectedRow.Cells[1].Text;
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",id)
            };
            string msg = funcoes.RetornoProcedureSimples("sp_AtivarProduto", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}');", true);
            CarregarPedidos();
        }

        protected void btnInativar_Click(object sender, EventArgs e)
        {
            string id = gvPedidos.SelectedRow.Cells[1].Text;
            MySqlParameter[] parametros = {
                new MySqlParameter("@pId", id)
            };
            string msg = funcoes.RetornoProcedureSimples("sp_InativarProduto", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}');", true);
            CarregarPedidos();
        }
    }
}