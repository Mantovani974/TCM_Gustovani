using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class itemPedido : System.Web.UI.Page
    {
        Funcoes funcoes = new Funcoes();
        string idPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            idPedido = Request.QueryString["id"];
            if (!IsPostBack)
            {
                PreencherListBox();
            }
        }
        protected void PreencherListBox()
        {
            if (lbProdutos.Items.Count > 0)
            {
                return;
            }
            string[] dadosProd = funcoes.RetornoStringDados("sp_ListBoxProdutos");
            for (int i = 0; i < dadosProd.Length; i += 2)
            {
                ListItem item = new ListItem(dadosProd[i + 1], dadosProd[i]);
                lbProdutos.Items.Add(item);
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("detalhePedido.aspx?idPedido=" + idPedido);
        }
        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            string idProduto = lbProdutos.SelectedValue;
            string quantidade = txtQuantidadeItem.Text;
            string desconto = txtDescontoItem.Text;
            if (string.IsNullOrWhiteSpace(idProduto) || string.IsNullOrWhiteSpace(quantidade) || string.IsNullOrWhiteSpace(desconto))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Por favor, preencha todos os campos.');", true);
                return;
            }
            if( !int.TryParse(quantidade, out _))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg", "alert('Quantidade deve ser um número inteiro.');", true);
                return;
            }
            if (!double.TryParse(desconto, out double valorDesconto) || valorDesconto < 0 || valorDesconto > 100)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg",
                    "alert('Desconto deve ser um número entre 0 e 100.');", true);
                return;
            }
            string  msg =  "erro";
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pIdPed",idPedido),
                new MySqlParameter("pIdProd",idProduto),
                new MySqlParameter("pQtd",quantidade),
                new MySqlParameter("pDesconto",desconto)
            };
            msg = funcoes.RetornoProcedureSimples("sp_InserirItemPedido", parametros);
            Response.Redirect("detalhePedido.aspx?id=" + idPedido);
        }
    }
}