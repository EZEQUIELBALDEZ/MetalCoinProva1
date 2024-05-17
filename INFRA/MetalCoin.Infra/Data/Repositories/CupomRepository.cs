using Metalcoin.Core.Abstracts;
using Metalcoin.Core.Domain;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MetalCoin.Infra.Data.Repositories.CupomRepository;

namespace MetalCoin.Infra.Data.Repositories
{
    public class CupomRepository : Repository<Cupom>, ICupomRepository
    {


        public CupomRepository(AppDbContext appDbContext) : base(appDbContext) { }


        Task<Cupom> ICupomRepository.BuscarPorAtivados(TipoStatusCupom TipoStatusCupom)
        {
            
            throw new NotImplementedException();
        }


        Task<Cupom> ICupomRepository.BuscarPorDesativados(TipoStatusCupom TipoStatusCupom)
        {
            throw new NotImplementedException();


        }
    }



}

