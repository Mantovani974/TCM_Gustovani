using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class cliente : System.Web.UI.Page
    {
        Funcoes Funcoes = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {
            gvClientes.DataSource = Funcoes.retornarTabela("tblCliente");
            gvClientes.DataBind();
        }
    }
}