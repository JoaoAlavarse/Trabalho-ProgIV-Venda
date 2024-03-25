using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMFG.Venda.Aprensetacao.Classes;

namespace UMFG.Venda.Aprensetacao.Models
{
    internal class CartaoModel : AbstractModel
    {
        private string _numeroCartao;
        private string _data;

        [CreditCard(ErrorMessage = "Numero de cartao invalido")]
        public string NumeroCartao
        {
            get => _numeroCartao;
            set => SetField(ref _numeroCartao, value);
        }

        public string Data
        {
            get => _data;
            set => SetField(ref _data, value);
        }

        public CartaoModel(string numeroCartao, string data)
        {
            NumeroCartao = numeroCartao;
            Data = data;
        }
    }
}
