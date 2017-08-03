using Dominio.Entidades;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistencia.Mapeamentos
{
    public class ListaMap
    {
        public ListaMap(EntityTypeBuilder<Lista> entityBuilder)
        {
            entityBuilder.Property(entidade => entidade.Descricao).HasMaxLength(200).IsRequired();
        }
    }
}
