using System;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

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
                MySqlConnection conn = new MySqlConnection(strConn);
                conn.Open(); 
                return conn;
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
    }
}
