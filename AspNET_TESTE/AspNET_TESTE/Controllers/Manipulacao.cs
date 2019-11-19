using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AspNET_TESTE {
    public class Manipulacao {
        public int          cont_Rows                { get; private set; }
        public String[]     dados_CodFilme           { get; private set; }
        public String[]     dados_NomeFilme          { get; private set; }
        public String[]     dados_InfoFilme_Filme    { get; private set; }
        public String       dados_InfoFime_Ator      { get; private set; }
        public String       dados_InfoFime_Diretor   { get; private set; }
        public String       dados_InfoFime_Genero    { get; private set; }
        public String       dados_InfoFime_Franquia  { get; private set; }
        public Boolean      dados_InfoFilme_Alugado  { get; private set; }
        public String[]     dados_InfoCliente        { get; private set; }
        public String[,]   dados_HistCliente         { get; private set; }
        public String[,]   dados_InfoFilme_Completa  { get; private set; }
        public String[]    dados_Generos             { get; private set; }
        public String[,]    dados_Atores             { get; private set; }
        public String[,]    dados_Diretores          { get; private set; }
        public String[,]    dados_Estudios           { get; private set; }

        public int Conferencia_User(String cpf, String email) {
            Consulta cs = new Consulta();
            int ret = cs.ConfUser(cpf, email).Rows.Count;
            return ret;
        }

        public void Busca_Home() {
            Consulta cs = new Consulta();
            DataTable busca_Home = cs.BuscaFilmes();
            cont_Rows = busca_Home.Rows.Count;
            dados_CodFilme = new String[cont_Rows];
            dados_NomeFilme = new String[cont_Rows];
            for(int i = 0; i< cont_Rows; i++) {
                dados_CodFilme[i] = busca_Home.Rows[i].ItemArray[0].ToString();
                dados_NomeFilme[i] = busca_Home.Rows[i].ItemArray[1].ToString();
            }            
        }

        public void Busca_InfoFilme(String id, String cpf) {
            Consulta cs = new Consulta();
            DataTable busca_InfoFilme_Filme = cs.BuscaInfoFilme_Filme(id);
            dados_InfoFilme_Filme = new String[4];
            for(int i=0; i< 4; i++) {
                dados_InfoFilme_Filme[i] = busca_InfoFilme_Filme.Rows[0].ItemArray[i].ToString();
            }

            cs = new Consulta();
            DataTable busca_InfoFilme_Ator = cs.BuscaInfoFilme_Ator(id);
            cont_Rows = busca_InfoFilme_Ator.Rows.Count;
            dados_InfoFime_Ator = "";
            for(int i=0; i< cont_Rows; i++) {
                if (i == 0) {
                    dados_InfoFime_Ator = busca_InfoFilme_Ator.Rows[i].ItemArray[0].ToString();
                } else {
                    dados_InfoFime_Ator = dados_InfoFime_Ator +", "+ busca_InfoFilme_Ator.Rows[i].ItemArray[0].ToString();
                }
            }

            cs = new Consulta();
            DataTable busca_InfoFilme_Diretor   = cs.BuscaInfoFilme_Diretor(id);
            cont_Rows = busca_InfoFilme_Diretor.Rows.Count;
            dados_InfoFime_Diretor = "";
            for (int i = 0; i < cont_Rows; i++) {
                if (i == 0) {
                    dados_InfoFime_Diretor = busca_InfoFilme_Diretor.Rows[i].ItemArray[0].ToString();
                } else {
                    dados_InfoFime_Diretor = dados_InfoFime_Diretor + ", " + busca_InfoFilme_Diretor.Rows[i].ItemArray[0].ToString();
                }
            }

            cs = new Consulta();
            DataTable busca_InfoFilme_Genero    = cs.BuscaInfoFilme_Genero(id);
            cont_Rows = busca_InfoFilme_Genero.Rows.Count;
            dados_InfoFime_Genero = "";
            for (int i = 0; i < cont_Rows; i++) {
                if (i == 0) {
                    dados_InfoFime_Genero = busca_InfoFilme_Genero.Rows[i].ItemArray[0].ToString();
                } else {
                    dados_InfoFime_Genero = dados_InfoFime_Genero + ", " + busca_InfoFilme_Genero.Rows[i].ItemArray[0].ToString();
                }
            }

            cs = new Consulta();
            DataTable busca_InfoFilme_Alugado   = cs.BuscaInfoAlugado(id, cpf);
            if (busca_InfoFilme_Alugado.Rows.Count > 0) {
                dados_InfoFilme_Alugado = true; //tem filme alugado
            } else {
                dados_InfoFilme_Alugado = false; //nao tem filme alugado
            }
               
        }

        public void Busca_Franquia(String id) {
            Consulta cs = new Consulta();
            DataTable franquia = cs.BuscaInfoFilme_Franquia(id);
            cont_Rows = franquia.Rows.Count;
            dados_InfoFime_Franquia = "";
            for (int i = 0; i < cont_Rows; i++) {
                if (i == 0) {
                    dados_InfoFime_Franquia = franquia.Rows[i].ItemArray[0].ToString();
                } else {
                    dados_InfoFime_Franquia = dados_InfoFime_Franquia + ", " + franquia.Rows[i].ItemArray[0].ToString();
                }
            }
        }

        public String AlterandoAluga(String id, String cpf, int bit) {
            Consulta cs = new Consulta();
            cs.AtualizaAluga(id, cpf, bit);
            return cs.mensagem;
        }

        public String NovoCliente(String nome, String email, String cpf, String ano, String telefone) {
            Consulta cs = new Consulta();
            cs.CadastroCliente(nome, email, cpf, ano, telefone);
            return cs.mensagem;
        }

        public void InfoCliente(String cpf) {
            Consulta cs = new Consulta();
            DataTable infoCliente = cs.BuscaInfoCliente(cpf);
            dados_InfoCliente = new string[5];
            for(int i=0; i<5; i++) {
                dados_InfoCliente[i] = infoCliente.Rows[0].ItemArray[i].ToString();
            }
        }

        public void HistCliente(String cpf) {
            Consulta cs = new Consulta();
            DataTable histCliente = cs.BuscaHistCliente(cpf);
            cont_Rows = histCliente.Rows.Count;
            dados_HistCliente = new String[cont_Rows,4];
            String ano, mes, dia, hora, data;
            for (int i = 0; i < cont_Rows; i++) {
                for(int j = 0; j< 4; j++) {
                    dados_HistCliente[i,j] = histCliente.Rows[i].ItemArray[j].ToString();
                }
            }
        }

        public void InfoCompletaFilmes() {
            Consulta cs = new Consulta();
            DataTable infoFilme = cs.BuscaInfoCompletaFilmes();
            cont_Rows = infoFilme.Rows.Count;
            dados_InfoFilme_Completa = new string[cont_Rows, 4];
            for(int i = 0; i < cont_Rows; i++) {
                for(int j = 0; j < 4; j++) {
                    dados_InfoFilme_Completa[i, j] = infoFilme.Rows[i].ItemArray[j].ToString();
                }
            }
        }

        public String DeletandoFilmes(String cpf) {
            Consulta cs = new Consulta();
            cs.DeletandoFilme(cpf);
            return cs.mensagem;
        }

        public void TodosGeneros() {
            Consulta cs = new Consulta();
            DataTable generos = cs.BuscandoGeneros();
            cont_Rows = generos.Rows.Count;
            dados_Generos = new string[cont_Rows];
            for (int i=0; i<cont_Rows; i++) {
                dados_Generos[i] = generos.Rows[i].ItemArray[0].ToString();
            }
        }

        public void TodosAtores() {
            Consulta cs = new Consulta();
            DataTable atores = cs.BuscandoAtores();
            cont_Rows = atores.Rows.Count;
            dados_Atores = new string[cont_Rows,2];
            for (int i = 0; i < cont_Rows; i++) {
                dados_Atores[i,0] = atores.Rows[i].ItemArray[0].ToString();
                dados_Atores[i,1] = atores.Rows[i].ItemArray[1].ToString();
            }
        }

        public void TodosDiretores() {
            Consulta cs = new Consulta();
            DataTable diretores = cs.BuscandoDiretores();
            cont_Rows = diretores.Rows.Count;
            dados_Diretores = new string[cont_Rows, 2];
            for (int i = 0; i < cont_Rows; i++) {
                dados_Diretores[i, 0] = diretores.Rows[i].ItemArray[0].ToString();
                dados_Diretores[i, 1] = diretores.Rows[i].ItemArray[1].ToString();
            }
        }

        public void TodosEstudios() {
            Consulta cs = new Consulta();
            DataTable estudios = cs.BuscandoEstudios();
            cont_Rows = estudios.Rows.Count;
            dados_Estudios = new string[cont_Rows, 2];
            for (int i = 0; i < cont_Rows; i++) {
                dados_Estudios[i, 0] = estudios.Rows[i].ItemArray[0].ToString();
                dados_Estudios[i, 1] = estudios.Rows[i].ItemArray[1].ToString();
            }
        }

        public String InserindoNovoFilme(String nome, String cod, String dura, String ano, String estd, String[] gen, String[] ator, String[] dir, String[] franq) {
            Boolean sucess = true;
            Consulta cs = new Consulta();
            cs.NovoFilme(cod, nome, dura, ano, estd);
            if (cs.mensagem.Equals("Sucesso")) {
                for(int i = 0; i<gen.Length; i++) {
                    cs = new Consulta();
                    cs.NovaClassificacao(gen[i], cod);
                    if (!cs.mensagem.Equals("Sucesso")) {
                        sucess = false;
                        break;
                    }
                }
                if (sucess) {
                    for (int i = 0; i < ator.Length; i++) {
                        cs = new Consulta();
                        cs.NovaAtuacao(ator[i], cod);
                        if (!cs.mensagem.Equals("Sucesso")) {
                            sucess = false;
                            break;
                        }
                    }
                    if (sucess) {
                        for (int i = 0; i < dir.Length; i++) {
                            cs = new Consulta();
                            cs.NovaDircao(dir[i], cod);
                            if (!cs.mensagem.Equals("Sucesso")) {
                                sucess = false;
                                break;
                            }
                        }
                        if (sucess) {
                            if (franq[0].Length > 0) {
                                for (int i = 0; i < franq.Length; i++) {
                                    cs = new Consulta();
                                    cs.NovaFranquia(franq[i], cod);
                                    if (!cs.mensagem.Equals("Sucesso")) {
                                        sucess = false;
                                        break;
                                    }
                                    cs = new Consulta();
                                    cs.NovaFranquia(cod, franq[i]);
                                    if (!cs.mensagem.Equals("Sucesso")) {
                                        sucess = false;
                                        break;
                                    }
                                }
                            }
                            return cs.mensagem;
                        } else {
                            return cs.mensagem;
                        }
                    } else {
                        return cs.mensagem;
                    }
                } else {
                    return cs.mensagem;
                }
            } else {
                return cs.mensagem;
            }
        }
    }
}