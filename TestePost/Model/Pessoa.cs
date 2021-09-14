using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TestePost.Model
{
    public class Pessoa
    {
        [JsonProperty("nome")]
        public string nome { get; set; }
        [JsonProperty("codigo")]
        public string codigo { get; set; }
        [JsonProperty("tipo_pessoa")]
        public char tipo_pessoa { get; set; }



        public void CadastrarPessoa()
        {
            ConnectionPsql connectionPsql = new ConnectionPsql();

            // connectionPsql.ExecutarInsert("insert into pessoa" +
            //  $"(codigo,nome,tipo_pessoa ) values ({codigo},{nome},{tipo_pessoa});");

            connectionPsql.ExecutarInsert("insert into pessoa(codigo,nome,tipo_pessoa ) values ('" + nome + "','" + codigo + "','" + tipo_pessoa + "');");




        }

        public string BuscarPessoa(int id)
        {

            ConnectionPsql connectionPsql = new ConnectionPsql();
             DataTable dados = connectionPsql.ExecutarBuscaPessoa("select nome from pessoa where idpes = " + id + ";");

            return dados.Rows[0]["nome"].ToString();


        }

        public List<Pessoa> listaPessoas()
        {
            string sql = "select * from pessoa order by nome asc;";
            ConnectionPsql connectionPsql = new ConnectionPsql();
            DataTable dados = new DataTable();
            dados = connectionPsql.BuscarTodasPessoas(sql);
    
            List<Pessoa> lista = new List<Pessoa>();
            Pessoa item;


            for (int i = 0; i < dados.Rows.Count; i++)
            {
                item = new Pessoa
                {
                    codigo = dados.Rows[i]["idpes"].ToString(),
                    nome = dados.Rows[i]["nome"].ToString(),
                    tipo_pessoa = Convert.ToChar(dados.Rows[i]["tipo_pessoa"])
                };

                lista.Add(item);
            }

            return lista;

        }
    }
}

   

