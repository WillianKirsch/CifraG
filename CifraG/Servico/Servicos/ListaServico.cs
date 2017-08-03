using Dominio.Entidades;
using Dominio.Interfaces;
using Dominio.Regras;
using Dominio.ViewModels;
using Persistencia.Contextos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Servico.Servicos
{
    public class ListaServico : Servico<Lista, ListaViewModel>, IListaServico
    {
        public ListaServico(Contexto contexto) : base(contexto)
        {
        }

        public Lista Salvar(ListaViewModel viewModel)
        {
            Func<IEnumerable<string>> metodoParaValidarViewModel = (() => ListaRegras.ValidarParaSalvar(viewModel, this.ObterTodos()));
            return base.Salvar(viewModel, metodoParaValidarViewModel, ListaExtension.TransformarViewEmModel);
        }

        public Lista Excluir(int id)
        {
            return base.Excluir(id, ListaRegras.ValidarParaExcluir);
        }
    }
}
