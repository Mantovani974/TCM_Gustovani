using MySql.Data.MySqlClient;
using PrjTcm.paginas.masters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class usuario : System.Web.UI.Page
    {
        Funcoes funcoes = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CarregarUsuarios();
            }
        }

        private void CarregarUsuarios()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarUsuarios");
            cmd.CommandType = CommandType.StoredProcedure;

            Funcoes f = new Funcoes();
            gvUsuarios.DataSource = f.exSQLParameters(cmd);
            gvUsuarios.DataBind();
            btnEditar.Enabled = false;
            btnInativar.Enabled = false;
            btnRastaurar.Enabled = false;
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalheUsuario.aspx");
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvUsuarios, "Select$" + e.Row.RowIndex);
            }
        }
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnEditar.Enabled = true;
            btnInativar.Enabled= true;
            btnRastaurar.Enabled= true;
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            string id = gvUsuarios.SelectedRow.Cells[1].Text;
            Response.Redirect("detalheUsuario.aspx?id=" + id);
        }

        protected void btnRastaurar_Click(object sender, EventArgs e)
        {

        }

        protected void btnInativar_Click(object sender, EventArgs e)
        {
            string id = gvUsuarios.SelectedRow.Cells[1].Text;
            MySqlCommand cmd = new MySqlCommand("CALL sp_InativarUsuario(" + id + ")");
            funcoes.exSQLParameters(cmd);
        }
    }
}