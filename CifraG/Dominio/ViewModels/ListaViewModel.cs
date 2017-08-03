using Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.ViewModels
{
    public class ListaViewModel : ViewModel
    {
        public string Descricao { get; set; }
    }

    public static class ListaExtension
    {
        public static Lista TransformarEmModel(this ListaViewModel viewModel, Lista entidade)
        {
            entidade.Id = viewModel.Id;
            entidade.Descricao = viewModel.Descricao;

            return entidade;
        }

        public static Lista TransformarViewEmModel(ListaViewModel viewModel, Lista entidade)
        {
            return viewModel.TransformarEmModel(entidade);
        }

        public static ListaViewModel TransformarEmViewModel(this Lista entidade)
        {
            return new ListaViewModel
            {
                Id = entidade.Id,
                Descricao = entidade.Descricao
            };
        }
    }
}
