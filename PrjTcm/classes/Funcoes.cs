using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace PrjTcm
{
    public static class Funcoes
    {
        private static string connStr = "Server=mysql-tcmmantogusta.alwaysdata.net;Database=tcmmantogusta_tcm;Uid=439374_gustavo_1;Pwd=Gugu0304@;";

        // 🔹 Método genérico pra SELECT (retorna tabela)
        public static DataTable Consultar(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlDataAdapter da = new MySqlDataAdapter(sql, conn))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }
            }
        }

        // 🔹 Método pra INSERT, UPDATE, DELETE (não retorna nada)
        public static void Executar(string sql)
        {
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
