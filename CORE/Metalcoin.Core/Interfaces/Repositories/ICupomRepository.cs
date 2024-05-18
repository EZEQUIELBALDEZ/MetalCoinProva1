using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metalcoin.Core.Interfaces.Repositories
{


    public interface ICupomRepository : IRepository<Cupom>
    {
        Task<Cupom> BuscarPorAtivados(TipoStatusCupom tipoStatusCupom);

        Task<Cupom> BuscarPorDesativados(TipoStatusCupom tipoStatusCupom);




        Task<Cupom> AtivarCupom(Guid id);
        Task<Cupom> DesativarCupom(Guid id);


    }




}
