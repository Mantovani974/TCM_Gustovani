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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalheCategoria.aspx");
        }

        private void CarregarCategorias()
        {
            MySqlCommand cmd = new MySqlCommand("sp_ListarCategorias");
            cmd.CommandType = CommandType.StoredProcedure;

            Funcoes f = new Funcoes();
            gvCategorias.DataSource = f.exSQLParameters(cmd);
            gvCategorias.DataBind();
        }
    }
}