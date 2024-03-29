using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;
using UMFG.Venda.Aprensetacao.ViewModels;

namespace UMFG.Venda.Aprensetacao.UserControls
{
    /// <summary>
    /// Interação lógica para ucReceber.xam
    /// </summary>
    public partial class ucReceber : UserControl
    {
        private IObserver observer;

        private ucReceber(IObserver observer, PedidoModel pedido)
        {
            InitializeComponent();
            this.observer = observer;
            DataContext = new ReceberViewModel(this,observer,pedido);
        }

        internal static PedidoModel Exibir (IObserver observer,
            PedidoModel pedido)
        {
            var tela = new ucReceber(observer, pedido);
            var vm = tela.DataContext as ReceberViewModel;

            vm.Notify();
            return vm.Pedido;
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox != null && textBox.Text.Length >= 3)
            {
                e.Handled = true;
            }
        }

        private void VerificarDados(object sender, RoutedEventArgs e)
        {
            string data = this.data.Text;
            string numeroCartao = this.numeroCartao.Text;
            string cvv = this.cvv.Text;
            DateTimeStyles estiloData = DateTimeStyles.None;
            DateTime dataHoje = DateTime.Today;
            bool dataValida = false;
            bool cartaoValido = false;
            bool cvvValido = false;

            try
            {
                if (DateTime.TryParseExact(data, "MM-yyyy", CultureInfo.InvariantCulture, estiloData, out DateTime dataConvertida))
                {
                    int comparacao = dataConvertida.CompareTo(dataHoje);

                    if (dataConvertida < DateTime.Today)
                    {
                        dataValida = false;
                        MessageBox.Show("A data já venceu.");
                    }
                    else if (dataConvertida > DateTime.Today)
                    {
                        dataValida = true;
                    }
                    else
                    {
                        dataValida = false;
                        MessageBox.Show("A data é hoje.");
                    }
                }

                if (int.TryParse(cvv, out int cvvI))
                {
                    cvvValido = true;
                } else
                {
                    cvvValido = false;
                    MessageBox.Show("CVV deve conter apenas numeros");
                }

                if (long.TryParse(numeroCartao, out long numeroCartaoL))
                {
                    if (numeroCartao.Length == 16)
                    {
                        cartaoValido = true;  
                    }
                    else
                    {
                        cartaoValido = false;
                    }
                }
                else
                {
                    cartaoValido = false;
                }

                if (cartaoValido && dataValida && cvvValido)
                {
                    MessageBox.Show("Pagamento realizado", "Sucesso");

                    ucListarProdutos.Exibir(observer);
                } 
                else
                {
                    MessageBox.Show("Verifique seus dados novamente", "Erro");
                }
            } catch (Exception ex)
            {
                MessageBox.Show("Verifique seus dados novamente", "Erro");
            }
        }


    }
}
