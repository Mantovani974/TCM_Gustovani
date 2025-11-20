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
                MySqlCommand cmd = new MySqlCommand("sp_ListarUsuarios");
                cmd.CommandType = CommandType.StoredProcedure;

                gvUsuarios.DataSource = funcoes.exSQLParameters(cmd);
                gvUsuarios.DataBind();
            }
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Response.Redirect("painel.aspx");
        }

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


    }
}