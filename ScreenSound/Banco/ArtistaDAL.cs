using Microsoft.Data.SqlClient;
using ScreenSound.Modelos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class ArtistaDAL
{
    private readonly ScreenSoundContext Context;

    public ArtistaDAL(ScreenSoundContext context)
    {
        Context = context;
    }
    public IEnumerable<Artista> Listar()
    {
        return Context.Artistas.ToList();
    }

    public void Adicionar(Artista artista)
    {
        Context.Artistas.Add(artista);
        Context.SaveChanges();
    }

    public void Atualizar(Artista artista) 
    {
        Context.Artistas.Update(artista);
        Context.SaveChanges();
    }

    public void Excluir(Artista artista)
    {
        Context.Artistas.Remove(artista);
        Context.SaveChanges();
    }

    public Artista? RecuperarPeloNome(string nome)
    {
        return Context.Artistas.FirstOrDefault(a => a.Nome.Equals(nome));
    }

}
