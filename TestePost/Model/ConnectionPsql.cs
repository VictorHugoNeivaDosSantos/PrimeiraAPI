using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace TestePost.Model
{
    public class ConnectionPsql
    {
        static string nomeserver = "localhost";
        static string database = "testeuser";
        static string user = "postgres";
        static string senha = "12345";
        static string porta = "5432";
        string connectString = $"Server ={nomeserver}; Username={user}; Database={database}; Port={porta}; Password={senha};SSLMode=Prefer ";       

        private NpgsqlConnection Connection;







        public ConnectionPsql()
        {
         
            Connection = new NpgsqlConnection(connectString);
            Console.WriteLine("Conexão aberta");
            Connection.Open();
            Console.WriteLine("Fechada");

        }

        public void ExecutarInsert(string sql)
        {
            NpgsqlCommand command = new NpgsqlCommand(sql, Connection);
            command.ExecuteNonQuery();

        }

        public DataTable ExecutarBuscaPessoa (string sql)
        {
            NpgsqlCommand command = new NpgsqlCommand(sql, Connection);

            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);

            DataTable dados = new DataTable();

            dataAdapter.Fill(dados);

            return dados;

        }

        public DataTable BuscarTodasPessoas(string sql)
        {

            NpgsqlCommand command = new NpgsqlCommand(sql, Connection);
            DataTable dados = new DataTable();
            NpgsqlDataAdapter dataAdapter = new NpgsqlDataAdapter(command);
            dataAdapter.Fill(dados);

            return dados;

        }









    }
}
