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



        public Task<Cupom> AtivarCupom(Guid id)
        {
            throw new NotImplementedException();
        }




        public async Task<Cupom> BuscarPorAtivados (TipoStatusCupom tipoStatusCupom)
        {

            var resultado = await DbSet.Where(c => c.TipoStatusCupom == tipoStatusCupom).FirstOrDefaultAsync();
            return resultado;
        }


        public async Task<Cupom> BuscarPorDesativados (TipoStatusCupom tipoStatusCupom)
        {
            var resultado = await DbSet.Where(c => c.TipoStatusCupom == tipoStatusCupom).FirstOrDefaultAsync();
            return resultado;
        }

        public Task<Cupom> DesativarCupom(Guid id)
        {
            throw new NotImplementedException();
        }
    }



}

