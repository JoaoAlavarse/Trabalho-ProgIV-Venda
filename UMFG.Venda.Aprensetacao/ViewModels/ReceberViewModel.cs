﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UMFG.Venda.Aprensetacao.Classes;
using UMFG.Venda.Aprensetacao.Comandos;
using UMFG.Venda.Aprensetacao.Interfaces;
using UMFG.Venda.Aprensetacao.Models;

namespace UMFG.Venda.Aprensetacao.ViewModels
{
    internal sealed class ReceberViewModel : AbstractViewModel
    {
        private PedidoModel _pedido = new PedidoModel();

        private string _dataText;
        public string DataText
        {
            get => _dataText;
            set => SetField(ref _dataText, value);
        }

        private string _numeroCartao;
        public string NumeroCartao
        {
            get => _numeroCartao;
            set => SetField(ref _numeroCartao, value);
        }

        public PedidoModel Pedido
        {
            get => _pedido;
            set => SetField(ref _pedido, value);
        }


        public ReceberViewModel(UserControl userControl,
            IObserver observer, 
            PedidoModel pedido
            ) : base("Receber")
        {
            UserControl= userControl ?? throw new ArgumentNullException(nameof(userControl));
            MainUserControl = observer ?? throw new ArgumentNullException(nameof(observer)); 
            Pedido= pedido ?? throw new ArgumentNullException(nameof(pedido));

            Add(observer);

        }
    }
}
