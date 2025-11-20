using PrjTcm.paginas.masters;
using System;
using System.Collections.Generic;
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
            gvUsuarios.DataSource = funcoes.retornarTabela("tblUsuario");
            gvUsuarios.DataBind();
        }
        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "selecionar")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int id = Convert.ToInt32(gvUsuarios.DataKeys[index].Value);

                // envia para o Master
                ((masterGrids)this.Master).idSelecionado = id;

                // destaca a linha visualmente
                gvUsuarios.SelectedIndex = index;
            }
        }
        protected void gvUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gvUsuarios.Rows)
                row.CssClass = "";

            gvUsuarios.SelectedRow.CssClass = "linha-selecionada";
        }

    }
}