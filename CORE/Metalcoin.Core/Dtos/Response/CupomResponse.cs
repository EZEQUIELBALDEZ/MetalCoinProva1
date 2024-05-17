using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Dtos.Response
{
    public class CupomResponse
    {


        public Guid Id { get; set; }
        public string CodigoDoCupom { get; set; }
        public string DescricaoDoCupom { get; set; }
        public decimal ValorDoDesconto { get; set; }
        public TipoDescontoCupom TipoDescontoCupom { get; set; }
        public DateTime DataDeValidade { get; set; }
        public int CuponsLiberados { get; set; }
        public int CuponsUsados { get; set; }
        public TipoStatusCupom TipoStatusCupom { get; set; }
    }
}
