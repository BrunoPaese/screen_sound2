using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class ArtistaDAL
    {

        public IEnumerable<Artista> Listar()
        {
            var lista = new List<Artista>();
            string sql = "select * from Artistas";

            using var connection = new Connection().ObterConexao();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {
                string nomeArtista = Convert.ToString(dataReader["Nome"]);
                string bioArtista = Convert.ToString(dataReader["Bio"]);
                int idArtista = Convert.ToInt32(dataReader["Id"]);

                Artista artista = new Artista(nomeArtista, bioArtista) { Id = idArtista };

                lista.Add(artista);
            }

            return lista;
        }

        public void Adicionar(Artista artista)
        {
            string sql = "insert into Artistas (Nome, FotoPerfil, Bio) values (@nome, @fotoPerfil, @bio)";

            using var connection = new Connection().ObterConexao();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@fotoPerfil", artista.FotoPerfil);
            command.Parameters.AddWithValue("@bio", artista.Bio);

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"{retorno} linhas afetadas.");
        }

        public void Atualizar(Artista artista) 
        {
            string sql = "update Artistas set Nome = @nome, Bio = @bio where Id = @id";

            using var connection = new Connection().ObterConexao();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("@nome", artista.Nome);
            command.Parameters.AddWithValue("@bio", artista.Bio);
            command.Parameters.AddWithValue("@id", artista.Id);

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"{retorno} linhas afetadas.");
        }

        public void Excluir(Artista artista)
        {
            string sql = "delete from Artistas where Id = @id";

            using var connection = new Connection().ObterConexao();
            connection.Open();
            SqlCommand command = new SqlCommand(sql, connection);
            command.Parameters.AddWithValue("id", artista.Id);

            int retorno = command.ExecuteNonQuery();
            Console.WriteLine($"{retorno} linhas afetadas.");
        }
    }
}
