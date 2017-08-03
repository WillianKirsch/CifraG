using Dominio.Entidades;
using Dominio.Mensagens;
using Microsoft.EntityFrameworkCore;
using Persistencia.Mapeamentos;
using System;
using System.Collections.Generic;

namespace Persistencia.Contextos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ListaMap(modelBuilder.Entity<Lista>());
        }

        public DbSet<Lista> Listas { get; set; }


        public TEntidade Incluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Set<TEntidade>().Add(entidade);
            return entidade;
        }

        public IEnumerable<TEntidade> IncluirVarios<TEntidade>(IEnumerable<TEntidade> entidades) where TEntidade : Entidade
        {
            this.Set<TEntidade>().AddRange(entidades);
            return entidades;
        }

        public TEntidade Alterar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Entry<TEntidade>(entidade).State = EntityState.Modified;
            return entidade;
        }

        public TEntidade Excluir<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Set<TEntidade>().Remove(entidade);
            return entidade;
        }

        public TEntidade Desanexar<TEntidade>(TEntidade entidade) where TEntidade : Entidade
        {
            this.Entry<TEntidade>(entidade).State = EntityState.Detached;
            return entidade;
        }

        public T ObterEntidadePorId<T>(int id) where T : Entidade
        {
            T entidade = Set<T>().Find(id);

            if (entidade == null)
                throw new Exception(Mensagem.EntidadeNaoEncontrada);

            return entidade;
        }
    }
}
