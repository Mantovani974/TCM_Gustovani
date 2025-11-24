using Google.Protobuf.Collections;
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
    public partial class detalheProduto : System.Web.UI.Page
    {
        char mode;
        string idProduto;
        Funcoes f = new Funcoes();
        protected void Page_Load(object sender, EventArgs e)
        {
            idProduto = Request.QueryString["id"];
            PreecherListBox();
            if (idProduto != "0" && !string.IsNullOrEmpty(idProduto))
            {
                mode = 'E';
                if (!IsPostBack)
                {
                    CarregarProduto();
                }

            }
            else if(idProduto == "0")
            {
                mode = 'A';
            }
            else
            {
                Response.Redirect("produto.aspx");
            }
        }
        protected void PreecherListBox()
        {
            if(lbCategorias.Items.Count > 0)
            {
                return;
            }
            string[] dadosCat = f.RetornoStringDados("sp_ListBoxCategorias");
            for (int i = 0; i < dadosCat.Length; i += 2)
            {
                ListItem item = new ListItem(dadosCat[i + 1], dadosCat[i]);
                lbCategorias.Items.Add(item);
            }
        }
        protected  void CarregarProduto()
        {
            MySqlParameter[] parametros = new MySqlParameter[] {
                new MySqlParameter("pId",idProduto)
            };
            string[] dados = f.ExecutarProcedureRetornarArray(
                "sp_RetornarProdutoPeloId",
                parametros
            );
            txtDescricaoProduto.Text = dados[0];
            txtPrecoProduto.Text = dados[1];
            lbCategorias.SelectedValue = dados[2];
            txtCodigoBProduto.Text = dados[3];
            txtQtdeProduto.Text = dados[4];
            txtImagemProduto.Text = dados[5];
        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("produto.aspx");
        }

        protected void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Pega valores dos campos
            string descricao = txtDescricaoProduto.Text?.Trim();
            string preco = txtPrecoProduto.Text?.Trim();
            string categoria = lbCategorias.SelectedValue;
            string codigoBarras = txtCodigoBProduto.Text?.Trim();
            string qtdeEstoque = txtQtdeProduto.Text?.Trim();
            string imagem = txtImagemProduto.Text?.Trim();

            // Msg resultado
            string msg = "erro";
            string script;

            if (string.IsNullOrEmpty(descricao) || string.IsNullOrEmpty(preco) || string.IsNullOrEmpty(categoria)
                || string.IsNullOrEmpty(codigoBarras) || string.IsNullOrEmpty(qtdeEstoque))
            {
                script = "alert('Por favor, preencha todos os campos obrigatórios.');";
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
                return;
            }
            if (mode == 'A')
            {
                MySqlParameter[] parametros = new MySqlParameter[] {
                    new MySqlParameter("pDescricao",descricao),
                    new MySqlParameter("pPreco",float.Parse(preco)),
                    new MySqlParameter("pCategoria",int.Parse(categoria)),
                    new MySqlParameter("pCodBarras",codigoBarras),
                    new MySqlParameter("pQtde",int.Parse(qtdeEstoque)),
                    new MySqlParameter("pImg",imagem)
                };
                msg = f.RetornoProcedureSimples("sp_InserirProduto", parametros);
            }
            else if (mode == 'E')
            {
                MySqlParameter[] parametros = new MySqlParameter[] {
                    new MySqlParameter("pId",idProduto),
                    new MySqlParameter("pDescricao",descricao),
                    new MySqlParameter("pPreco",preco),
                    new MySqlParameter("pCategoria",categoria),
                    new MySqlParameter("pCodBarras",codigoBarras),
                    new MySqlParameter("pQtde",qtdeEstoque),
                    new MySqlParameter("pImg",imagem)
                };
                msg = f.RetornoProcedureSimples("sp_EditarProduto",parametros);
            }
            else
            {
                Response.Redirect("produto.aspx");
            }
            script = $"alert('{msg}'); window.location='produto.aspx';";
            ScriptManager.RegisterStartupScript(this, GetType(), "msg", script, true);
        }
    }
}