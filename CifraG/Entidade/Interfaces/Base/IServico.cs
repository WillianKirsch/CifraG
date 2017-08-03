﻿using Dominio.Entidades;
using Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IServico<TEntidade, TViewModel>
        where TEntidade : Entidade
        where TViewModel : ViewModel
    {
        TEntidade ObterPorId(int id);
        IQueryable<TEntidade> ObterTodos();
        TEntidade Excluir(
            int id,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao);
        TEntidade Excluir(
            TEntidade entidade,
            Func<TEntidade, IEnumerable<string>> metodoParaValidarExclusao);
        TEntidade Salvar(
            TViewModel viewModel,
            Func<IEnumerable<string>> metodoParaValidarViewModel,
            Func<TViewModel, TEntidade, TEntidade> metodoParaTransformarViewModelEmModel);
    }
}
