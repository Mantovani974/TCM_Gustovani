using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;

namespace PrjTcm
{
    public class Funcoes
    {
        MySqlConnection conexao = new MySqlConnection();
        private MySqlConnection Conectar()
        {
            try
            {
                string strConn = ConfigurationManager.ConnectionStrings["ConexaoRemota"].ConnectionString;
                conexao = new MySqlConnection(strConn);
                conexao.Open(); 
                return conexao;
            }
            catch (Exception)
            {
                desconectar();
                return null;
            }
        }

        public void desconectar()
        {
            try
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                    conexao.Dispose();
                    conexao = null;
                }
            }
            catch (Exception) { }
        }

        public DataTable retornarTabela(string table)
        {
            var result = new DataTable();

            if (string.IsNullOrWhiteSpace(table))
                return result;

            // Allow only basic identifier characters to avoid SQL injection via table name
            if (!Regex.IsMatch(table, @"^[A-Za-z0-9_]+$"))
                return result;

            string sql = "SELECT * FROM `" + table + "`;";

            MySqlConnection conn = null;
            try
            {
                conn = Conectar();
                if (conn == null)
                    return result;
                using (var  cmd = new MySqlCommand(sql, conn))
                    using( var adapter = new MySqlDataAdapter(cmd)) {
                    adapter.Fill(result);
                    }
                return result;
            }catch (Exception)
            {
                return result;
            }
            finally
            {
                desconectar();
            }

        }

        public DataTable exSQLParameters(MySqlCommand cmd)
        {
            DataTable  dt = new DataTable ();
            try
            {
                cmd.Connection = Conectar();
                MySqlDataReader dr = cmd.ExecuteReader();
                dt.Load(dr);
            }catch(Exception) { }
            desconectar();
            return dt;
        }

        public string[] ExecutarProcedureRetornarArray(string nomeProcedure, params MySqlParameter[] parametros)
        {
            List<string> dados = new List<string>();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(nomeProcedure))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var p in parametros)
                        cmd.Parameters.Add(p);

                    DataTable dt = exSQLParameters(cmd);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (var item in dt.Rows[0].ItemArray)
                            dados.Add(item.ToString());
                    }
                }
            }
            catch { }

            return dados.ToArray();
        }

        public string RetornoProcedureSimples(string nomeProcedure, params MySqlParameter[] parametros)
        {
            string retorno = string.Empty;
            try
            {
                using (MySqlCommand cmd = new MySqlCommand(nomeProcedure))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    foreach (var p in parametros)
                        cmd.Parameters.Add(p);
                    DataTable dt = exSQLParameters(cmd);
                    if (dt.Rows.Count > 0)
                    {
                        retorno = dt.Rows[0][0].ToString();
                    }
                }
            }
            catch { }
            return retorno;
        }

        public string[] RetornoStringDados(string nomeProcedure)
        {
            List<string> dados = new List<string>();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(nomeProcedure))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    DataTable dt = exSQLParameters(cmd);

                    foreach (DataRow row in dt.Rows)
                    {
                        foreach (var item in row.ItemArray)
                            dados.Add(item.ToString());
                    }
                }
            }
            catch { }

            return dados.ToArray();
        }

        public string[][] RetornoMatrizDados(string nomeProcedure, params MySqlParameter[] parametros)
        {
            List<string[]> linhas = new List<string[]>();

            try
            {
                using (MySqlCommand cmd = new MySqlCommand(nomeProcedure))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach (var p in parametros)
                        cmd.Parameters.Add(p);

                    DataTable dt = exSQLParameters(cmd);

                    foreach (DataRow row in dt.Rows)
                    {
                        string[] linha = new string[row.ItemArray.Length];

                        for (int i = 0; i < row.ItemArray.Length; i++)
                            linha[i] = row.ItemArray[i].ToString();

                        linhas.Add(linha);
                    }
                }
            }
            catch { }

            return linhas.ToArray();
        }

    }
}
