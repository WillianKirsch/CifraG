using Dominio.Entidades;
using Dominio.Mensagens;
using Dominio.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using Infraestrutura.Extensions;

namespace Dominio.Regras
{
    public class ListaRegras
    {
        public static IEnumerable<string> ValidarParaSalvar(ListaViewModel viewModel, IQueryable<Lista> listas)
        {
            if (string.IsNullOrWhiteSpace(viewModel.Descricao))
                yield return Mensagem.ParametroObrigatorio.Formatar(Termo.Descricao);

            if (PossuiListaPorDescricao(listas, viewModel.Id, viewModel.Descricao))
                yield return Mensagem.EntidadeDuplicada.Formatar(Termo.Descricao);
        }

        public static IEnumerable<string> ValidarParaExcluir(Lista entidade)
        {
            if (entidade == null)
                yield return Mensagem.EntidadeNaoEncontrada.Formatar(Termo.Lista);
        }

        private static bool PossuiListaPorDescricao(IQueryable<Lista> listas, int id, string descricao)
        {
            return listas.Any(lista =>
                    (id == 0 || lista.Id != id) &&
                    lista.Descricao.ToLower().Equals(descricao.ToLower()));
        }
    }
}
