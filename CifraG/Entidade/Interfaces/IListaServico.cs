using Dominio.Entidades;
using Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Interfaces
{
    public interface IListaServico : IServico<Lista, ListaViewModel>
    {
        Lista Salvar(ListaViewModel viewModel);
        Lista Excluir(int id);
    }
}
