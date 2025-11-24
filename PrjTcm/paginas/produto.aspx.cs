using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class produto : System.Web.UI.Page
    {
        Funcoes funcoes = new Funcoes();   
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
                CarregarProdutos();
        }

        private void CarregarProdutos()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarProdutos");
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            gvProdutos.DataSource = funcoes.exSQLParameters(cmd);
            gvProdutos.DataBind();
            btnEditar.Enabled = false;
            btnInativar.Enabled = false;
            btnRestaurar.Enabled = false;
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalheProduto.aspx?id=0");
        }

        protected void gvProdutos_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvProdutos, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvProdutos.Rows)
            {
                row.CssClass = row.RowIndex % 2 == 0 ? "linha" : "linhaAlt";
            }

            gvProdutos.SelectedRow.CssClass = "linha-selecionada";

            btnEditar.Enabled = true;
            btnInativar.Enabled = true;
            btnRestaurar.Enabled = true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = gvProdutos.SelectedRow.Cells[1].Text;
            Response.Redirect("detalheProduto.aspx?id=" + id);
        }

        protected void btnRestaurar_Click(object sender, EventArgs e)
        {
            string id = gvProdutos.SelectedRow.Cells[1].Text;
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",id)
            };
            string msg = funcoes.RetornoProcedureSimples("sp_AtivarProduto", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}');", true);
            CarregarProdutos();
        }

        protected void btnInativar_Click(object sender, EventArgs e)
        {
            string id = gvProdutos.SelectedRow.Cells[1].Text;
            MySqlParameter[] parametros = {
                new MySqlParameter("@pId", id)
            };
            string msg = funcoes.RetornoProcedureSimples("sp_InativarProduto", parametros);
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", $"alert('{msg}');", true);
            CarregarProdutos();
        }
    }
}