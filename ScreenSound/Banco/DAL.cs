﻿using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco;

internal class DAL<T> where T : class
{ 
    protected readonly ScreenSoundContext Context;

    public DAL(ScreenSoundContext context)
    {
        Context = context;
    }
    public IEnumerable<T> Listar()
    {
        return Context.Set<T>().ToList();
    }
    public void Adicionar(T objeto)
    {
        Context.Set<T>().Add(objeto);
        Context.SaveChanges();
    }
    public void Atualizar(T objeto)
    {
        Context.Set<T>().Update(objeto);
        Context.SaveChanges();
    }
    public void Excluir(T objeto)
    {
        Context.Set<T>().Remove(objeto);
        Context.SaveChanges();
    }

    public T? RecuperarPor(Func<T, bool> condicao)
    {
        return Context.Set<T>().FirstOrDefault(condicao);
    }

    public IEnumerable<T> ListarPor(Func<T, bool> condicao)
    {
        return Context.Set<T>().Where(condicao);
    }
}
