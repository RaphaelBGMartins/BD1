using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspNET_TESTE {
    public class Consulta {

        private Conexao con = new Conexao();
        private SqlCommand cmd = new SqlCommand();
        public String mensagem = "";

        //Construtor
        public Consulta() { }

        //Buscando Nome e Codigo do Filme
        public DataTable BuscaFilmes()
        {
            cmd.CommandText = "SELECT Nome, Cod_Filme FROM Filme";
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try 
            {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            }
            catch(SqlException e) 
            {
                this.mensagem = e.Message;
                return null;
            }
            
        }
    }
}