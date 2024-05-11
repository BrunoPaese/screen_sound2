using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;
internal class MusicaDAL
{
    private readonly ScreenSoundContext Context;

    public MusicaDAL(ScreenSoundContext context)
    {
        Context = context;
    }

    public IEnumerable<Musica> Listar()
    {
        return Context.Musicas.ToList();
    }

    public void Adicionar(Musica musica)
    {
        Context.Musicas.Add(musica);
        Context.SaveChanges();
    }

    public void Atualizar(Musica musica)
    {
        Context.Musicas.Update(musica);
        Context.SaveChanges();
    }

    public void Excluir(Musica musica)
    {
        Context.Musicas.Remove(musica);
        Context.SaveChanges();
    }

    public Musica? RecuperarPeloNome(string nome)
    {
        Context.Musicas.FirstOrDefault(a => a.Nome.Equals(nome));
    }

}

