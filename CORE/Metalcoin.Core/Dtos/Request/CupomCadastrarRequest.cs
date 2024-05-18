using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Request
{
    public record CupomCadastrarRequest
    {


        [Required(ErrorMessage = "O codigo do Cupom não foi informado ")]
        public string CodigoDoCupom { get; set; }




        [MaxLength(100, ErrorMessage = "A descrição tem o limite de 100 caracteres")]
        public string DescricaoDoCupom { get; set; }


        [Required(ErrorMessage = "o valor do desconto não foi informado ")]
        public decimal ValorDoDesconto { get; set; }




        [Required(ErrorMessage = "O tipo de Desconto não foi informado ")]
        public TipoDescontoCupom TipoDescontoCupom { get; set; }

        [Required(ErrorMessage = "O status do Cupom não foi informado ")]
        public TipoStatusCupom TipoStatusCupom { get; set; }




        [Required(ErrorMessage = "A data de Validade não foi informada ")]
        public DateTime DataDeValidade { get; set; }



        [Required(ErrorMessage = "A quantidade de cupons liberados não foi informado ")]
        public int CuponsLiberados { get; set; }




    }
}
