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

        //Busca se o Usuário existe
        public DataTable ConfUser(String cpf, String email)
        {
            cmd.CommandText = "select 1 from Cliente c where c.CPF = @cpf and c.Email = @email";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@email", email);
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

        //Buscando Nome e Codigo do Filme
        public DataTable BuscaFilmes()
        {
            cmd.CommandText = "SELECT Cod_Filme, Nome FROM Filme";
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

        //Buscando Informações de um Filme (Nome, Estudio, Duracao, Ano_Lançamento
        public DataTable BuscaInfoFilme_Filme(String id) {
            cmd.CommandText = "select f.Nome, e.Nome as Studio, f.Duracao, f.Ano_Lancamento from Filme f join Estudio e on f.Cod_Estudio= e.Cod_Estudio where f.Cod_Filme = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        
        //Buscando Informações de um Filme (Atores)
        public DataTable BuscaInfoFilme_Ator(String id) {
            cmd.CommandText = "select a.Nome from Ator a join Atua atu on atu.DRT = a.DRT and atu.Cod_Filme = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        
        //Buscando Informações de um Filme (Diretores)
        public DataTable BuscaInfoFilme_Diretor(String id) {
            cmd.CommandText = "select d.Nome from Diretor d join Dirige dir on dir.Cod_Diretor = d.Cod_Diretor and	dir.Cod_Filme = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        
        //Buscando Informações de um Filme (Generos)
        public DataTable BuscaInfoFilme_Genero(String id) {
            cmd.CommandText = "select g.Nome from Genero g join Classifica c on c.Nome = g.Nome and c.Cod_Filme = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        
        //Buscando se o filme está alugado pelo cliente
        public DataTable BuscaInfoAlugado(String id, String cpf) {
            cmd.CommandText = "select 1 from Aluga a where a.Cod_Filme = @id and a.Alugado = 1 and a.CPF = @cpf";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@cpf", cpf);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        
        //Atualizando a tabela de Alugado
        public void AtualizaAluga(String id, String cpf, int bit) {
            if(bit == 0) {
                cmd.CommandText = "update Aluga set Alugado = @bit where Cod_Filme = @id and CPF = @cpf";
            } else {
                cmd.CommandText = "insert into Aluga (Data_Alguel, Cod_Filme, CPF, Alugado) values (getdate(), @id, @cpf, @bit)";
            }
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@bit", bit);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";     
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }
        
        //Cadastrando um novo Cliente
        public void CadastroCliente(String nome, String email, String cpf, String ano, String telefone) {
            if (telefone.Length == 0) {
                cmd.CommandText = "insert into Cliente (CPF, Nome, Email, AnoNasc_Cliente) values (@cpf, @nome, @email ,@ano)";
            } else {
                cmd.CommandText = "insert into Cliente (CPF, Nome, Email, AnoNasc_Cliente, telefone) values (@cpf, @nome, @email ,@ano, @telefone)";
                cmd.Parameters.AddWithValue("@telefone", telefone);
            }
            cmd.Parameters.AddWithValue("@cpf", cpf);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@ano", ano);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }
        
        //Buscando info. do cliente
        public DataTable BuscaInfoCliente(String cpf) {
            cmd.CommandText = "select c.Nome, c.CPF, c.Email, c.AnoNasc_Cliente, c.Telefone  from Cliente c where c.CPF = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }

        //Buscando Historico do cliente
        public DataTable BuscaHistCliente(String cpf) {
            cmd.CommandText = "select a.Cod_Filme, f.Nome, a.Data_Alguel, a.Alugado from Aluga a join Filme f on a.Cod_Filme = f.Cod_Filme where a.CPF = @cpf order by a.Data_Alguel desc";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }

        //Atualizando Daddos do Cliente
        public void AtualizaInfoCliente(String cpf, String nome, String ano, String tel) {
            String comando = "";
            int cont = 0;
            if(nome.Length > 0) {
                comando = comando + "Nome = @nome";
                cmd.Parameters.AddWithValue("@nome", nome);
                cont++;
            }
            if(ano.Length > 0) {
                if(cont > 0) {
                    comando = comando + ", AnoNasc_Cliente = @ano";
                } else {
                    comando = comando + "AnoNasc_Cliente = @ano";
                }
                cmd.Parameters.AddWithValue("@ano", ano);
                cont++;
            }
            if(tel.Length > 0) {
                if(cont > 0) {
                    comando = comando + ", Telefone = @tel";
                } else {
                    comando = comando + "Telefone = @tel";
                }
                cmd.Parameters.AddWithValue("@tel", tel);
            }
            cmd.CommandText = "update Cliente set "+comando+ " where CPF = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }

        //Buscando info completa de Filmes
        public DataTable BuscaInfoCompletaFilmes() {
            cmd.CommandText = "select f.Cod_Filme, f.Nome, f.Duracao, f.Ano_Lancamento from Filme f";
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }

        }

        //Deletando Filme
        public void DeletandoFilme(String cpf) {
            cmd.CommandText = "delete Aluga where Cod_Filme = @cpf delete Dirige where Cod_Filme = @cpf delete Atua where Cod_Filme = @cpf delete FRANQUIA where Cod_Filme = @cpf or Cod_Filme_Franquia = @cpf delete Classifica where Cod_Filme = @cpf delete Filme where Cod_Filme = @cpf";
            cmd.Parameters.AddWithValue("@cpf", cpf);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }

        //Buscando Generos Cadastrados
        public DataTable BuscandoGeneros() {
            cmd.CommandText = "select Nome from Genero";
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }

        //Buscando Atores Cadastrados
        public DataTable BuscandoAtores() {
            cmd.CommandText = "select DRT, Nome from Ator";
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        //Buscando Diretores Cadastrados
        public DataTable BuscandoDiretores() {
            cmd.CommandText = "select Cod_Diretor, Nome from Diretor";
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        //Buscando Estudios Cadastrados
        public DataTable BuscandoEstudios() {
            cmd.CommandText = "select Cod_Estudio, Nome from Estudio";
            SqlDataAdapter resultSET = new SqlDataAdapter();
            DataTable dt_retorno = new DataTable();
            try {
                cmd.Connection = con.Conectar();
                resultSET.SelectCommand = cmd;
                resultSET.Fill(dt_retorno);
                con.Desconectar();
                this.mensagem = "Sucesso";
                return dt_retorno;
            } catch (SqlException e) {
                this.mensagem = e.Message;
                return null;
            }
        }
        //Inserindo Novo Filme
        public void NovoFilme(String cod, String nome, String duracao, String ano, String estudio) {
            cmd.CommandText = "insert into Filme (Cod_Filme, Nome, Duracao, Ano_Lancamento, Cod_Estudio) values (@cod, @nome, @duracao, @ano, @estd)";
            cmd.Parameters.AddWithValue("@cod", cod);
            cmd.Parameters.AddWithValue("@nome", nome);
            cmd.Parameters.AddWithValue("@duracao", duracao);
            cmd.Parameters.AddWithValue("@ano", ano);
            cmd.Parameters.AddWithValue("@estd", estudio);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }
        //Inserindo Atuaçao do Filme
        public void NovaAtuacao(String drt, String cod) {
            cmd.CommandText = "insert into Atua (DRT, Cod_Filme) values (@drt, @cod)";
            cmd.Parameters.AddWithValue("@drt", drt);
            cmd.Parameters.AddWithValue("@cod", cod);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }
        //Inserindo Classificacao do Filme
        public void NovaClassificacao(String gen, String cod) {
            cmd.CommandText = "insert into Classifica (Nome, Cod_Filme) values (@gen, @cod)";
            cmd.Parameters.AddWithValue("@gen", gen);
            cmd.Parameters.AddWithValue("@cod", cod);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }
        //Inserindo Direcao do Filme
        public void NovaDircao(String dir, String cod) {
            cmd.CommandText = "insert into Dirige (Cod_Diretor, Cod_Filme) values (@dir, @cod)";
            cmd.Parameters.AddWithValue("@dir", dir);
            cmd.Parameters.AddWithValue("@cod", cod);
            try {
                cmd.Connection = con.Conectar();
                cmd.ExecuteNonQuery();
                con.Desconectar();
                this.mensagem = "Sucesso";
            } catch (SqlException e) {
                this.mensagem = e.Message;
            }
        }
    }
}