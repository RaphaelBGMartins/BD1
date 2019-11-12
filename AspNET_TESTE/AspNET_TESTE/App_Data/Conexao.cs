using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AspNET_TESTE {
    public class Conexao {

        SqlConnection con = new SqlConnection();
        
        
        //Construtor
        public Conexao()
        {
            con.ConnectionString = "Data Source=DESKTOP-RITL7V2;Initial Catalog=Locadora;Integrated Security=True";
        }
        
        //Conectar
        public SqlConnection Conectar() 
        {
            if(con.State == System.Data.ConnectionState.Closed) {
                con.Open();
            }
            return con;
        }

        //Desconectar
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open) {
                con.Close();
            }
        }
               
    }
}