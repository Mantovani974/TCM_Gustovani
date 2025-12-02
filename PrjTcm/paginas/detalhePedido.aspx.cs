using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PrjTcm.paginas
{
    public partial class detalhePedido : System.Web.UI.Page
    {
        Funcoes funcoes = new Funcoes();
        char mode;
        string idPedido;
        protected void Page_Load(object sender, EventArgs e)
        {
            bool  novo =  Request.QueryString["novo"] == "1";
            if (novo) 
                mode = 'A';
            else
            {
                mode = 'E';
            }
                idPedido = Request.QueryString["id"];
            PreencherListBox();
            CarregarItensPedido();
            if (idPedido != "0" && !string.IsNullOrEmpty(idPedido))
            {
                if (!IsPostBack)
                {
                    CarregarDetalhesPedido();
                }
            }
            else if (idPedido == "0")
            {
                mode = 'A';
            }
            else
            {
                Response.Redirect("pedido.aspx");
            }
        }
        protected  void  PreencherListBox()
        {
            if(lbClientes.Items.Count > 0  || lbRepresentantes.Items.Count > 0)
            {
                return;
            }
            string[] dadosCli = funcoes.RetornoStringDados("sp_ListBoxClientes");
            for (int i = 0; i < dadosCli.Length; i += 2)
            {
                ListItem item = new ListItem(dadosCli[i + 1], dadosCli[i]);
                lbClientes.Items.Add(item);
            }
            string[] dadosRep = funcoes.RetornoStringDados("sp_ListBoxRepresentantes");
            for (int i = 0; i < dadosRep.Length; i += 2)
            {
                ListItem item = new ListItem(dadosRep[i + 1], dadosRep[i]);
                lbRepresentantes.Items.Add(item);
            }
        }
        protected void CarregarDetalhesPedido()
        {
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",idPedido)
            };
            string[] dados = funcoes.ExecutarProcedureRetornarArray(
                "sp_RetornarPedidoPeloId",
                parametros
            );
            lbClientes.SelectedValue = dados[0];
            lbRepresentantes.SelectedValue = dados[1];
            txtDataPedido.Text = Convert.ToDateTime(dados[2]).ToString("yyyy-MM-dd");
            txtFretePedido.Text = dados[3];
            if (dados[4] == "PENDENTE")
            {
                lbStatusPedido.SelectedIndex = 0;
            }
            else if (dados[4] == "CONCLUIDO")
            {
                lbStatusPedido.SelectedIndex = 1;
            }
        }

        protected  void  CarregarItensPedido()
        {
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",idPedido)
            };
            string[][] dados = funcoes.RetornoMatrizDados("sp_ListarDetalhesDeUmPedido", parametros);
            foreach (var item in dados)
            {
                double precoProduto = double.Parse(funcoes.RetornoProcedureSimples("sp_PrecoProduto", new MySqlParameter("pId", item[3])));
                double desconto = double.Parse(item[2]);
                double total = (double.Parse(item[1]) * precoProduto);
                Panel Carditem = new Panel();
                Carditem.CssClass = "card-item-pedido";
                Button btnRemover = new Button();
                btnRemover.Text = "X";
                btnRemover.CssClass = "btn-remover-item";
                btnRemover.CommandArgument = item[3];
                btnRemover.Click += BtnRemover_Click;
                Label lblNomeProduto = new Label();
                lblNomeProduto.Text = "Produto: " + item[0];
                Label lblQuantidade = new Label();
                lblQuantidade.Text = "Quantidade: " + item[1];
                Label lblDesconto = new Label();
                lblDesconto.Text = "Desconto: " + desconto*100 + "%";
                Label  lblPrecoTotal  =  new Label();
                lblPrecoTotal.Text = "Preço  Total: R$"+total;
                Carditem.Controls.Add(new LiteralControl("<br/>"));
                Carditem.Controls.Add(lblNomeProduto);
                Carditem.Controls.Add(lblQuantidade);
                Carditem.Controls.Add(lblDesconto);
                Carditem.Controls.Add(lblPrecoTotal);
                Carditem.Controls.Add(btnRemover);
                pItens.Controls.Add(Carditem);
            }

        }

        protected void BtnRemover_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string idProduto = btn.CommandArgument;

            // Chamar procedure para remover item do pedido
            funcoes.RetornoProcedureSimples(
                "sp_RemoverItemPedido",
                new MySqlParameter("pIdPedido", idPedido),
                new MySqlParameter("pIdProduto", idProduto)
            );

            // Recarregar os itens
            pItens.Controls.Clear();
            CarregarItensPedido();
        }

        protected void btnAdicionarItem_Click(object sender, EventArgs e)
        {
            Response.Redirect("itemPedido.aspx?id=" + idPedido);
        }

        protected void btnCofirmar_Click(object sender, EventArgs e)
        {
            //Pega valores dos campos
            string cliente = lbClientes.SelectedValue;
            string representante = lbRepresentantes.SelectedValue;
            string status = lbStatusPedido.SelectedValue;
            DateTime dataEnt = DateTime.Parse(txtDataPedido.Text?.Trim());
            string frete = txtFretePedido.Text?.Trim();

            //Validação
            if (string.IsNullOrWhiteSpace(cliente) ||
                string.IsNullOrWhiteSpace(representante) ||
                string.IsNullOrWhiteSpace(status) ||
                string.IsNullOrWhiteSpace(frete))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "msg",
                    "alert('Há campos obrigatórios não preenchidos');", true);
                return;
            }

            //Converter status
            status = (status == "1") ? "PENDENTE" : "CONCLUIDO";

            string msg = "";

            //Se estiver editando
            if (mode == 'E')
            {
                MySqlParameter[] parametros = new MySqlParameter[] {
            new MySqlParameter("pIdPed", idPedido),
            new MySqlParameter("pIdCli", int.Parse(cliente)),
            new MySqlParameter("pIdRep", int.Parse(representante)),
            new MySqlParameter("pStatusPed", status),
            new MySqlParameter("pDataEnt", dataEnt),
            new MySqlParameter("pFrete", frete)
        };

                // ❗ AQUI ESTAVA FALTANDO
                msg = funcoes.RetornoProcedureSimples("sp_EditarPedido", parametros);
            }

            //Mensagem + redirect
            string script =
                $"alert('{msg}'); window.location='pedido.aspx';";

            ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
        }


        protected void btnCancelar_Click(object sender, EventArgs e)
        {
           if(mode  == 'E')
            {
                Response.Redirect("pedido.aspx");
                return;
            }
           string msg = funcoes.RetornoProcedureSimples(
                "sp_DeletarPedidoDefault",
                new MySqlParameter("pIdPed", idPedido)
            );
            //Mensagem + redirect
            string script =
                $"alert('{msg}'); window.location='pedido.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
        }
    }
}