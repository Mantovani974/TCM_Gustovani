using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas.masters
{
    public partial class masterGrids : System.Web.UI.MasterPage
    {
        public int idSelecionado
        {
            get { return (int)(Session["IdSelecionado"] ?? 0); }
            set { Session["IdSelecionado"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AcaoAdicionar_Click(object sender, EventArgs e)
        {
            if (idSelecionado > 0)
            {
                string destino = ((Button)sender).CommandArgument;
                Response.Redirect(destino + idSelecionado);
            }
        }

        protected void AcaoEditar_Click(object sender, EventArgs e)
        {
            string  destino = ((Button)sender).CommandArgument;
            
        }
    }
}