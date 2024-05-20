
﻿using Metalcoin.Core.Abstracts;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;

﻿using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Domain
{

    public class Cupom : Entidade
    {

     

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
