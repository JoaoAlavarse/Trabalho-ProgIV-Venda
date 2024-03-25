using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.Comandos
{
    internal class RemoverProdutoPedidoComand : AbstractCommand
    {
        public override void Execute(object? parameter)
        {
            var vm = parameter as ListarProdutosViewModel;

            if (vm == null || vm.ProdutoSelecionado.Descricao == null)
            {
                MessageBox.Show("Selecione um produto para remover.");
                return;
            }

            if (!vm.Pedido.Produtos.Contains(vm.ProdutoSelecionado))
            {
                MessageBox.Show("O produto selecionado nao existe na lista");
                return;
            }

            vm.Pedido.Produtos.Remove(vm.ProdutoSelecionado);
            vm.Pedido.Total = vm.Pedido.Produtos.Sum(x => x.Preco);
        }
    }
}
