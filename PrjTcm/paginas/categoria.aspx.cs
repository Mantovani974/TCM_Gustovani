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
    public partial class categoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                CarregarCategorias();
        }

        private void CarregarCategorias()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarCategorias");
            cmd.CommandType = CommandType.StoredProcedure;

            Funcoes f = new Funcoes();
            gvCategorias.DataSource = f.exSQLParameters(cmd);
            gvCategorias.DataBind();
        }

        protected void btnAdd_Click1(object sender, EventArgs e)
        {
            Response.Redirect("detalheCategoria.aspx");
        }

        protected void gvCategorias_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Attributes["style"] = "cursor:pointer";
                e.Row.Attributes["onclick"] = Page.ClientScript.GetPostBackClientHyperlink(gvCategorias, "Select$" + e.Row.RowIndex);
            }
        }



        protected void btnEdit_Click1(object sender, EventArgs e)
        {
            string id = gvCategorias.SelectedRow.Cells[1].Text;
            Response.Redirect("detalheCategoria.aspx?id=" + id);

        }
    }
}