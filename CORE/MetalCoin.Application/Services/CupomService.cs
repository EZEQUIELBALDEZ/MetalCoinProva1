using Metalcoin.Core.Domain;
using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Dtos.Response;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MetalCoin.Application.Services
{
    public class CupomService : ICupomService
    {
        private readonly ICupomRepository _cupomRepository;
        public CupomService(ICupomRepository repository)
        {
            _cupomRepository = repository;
        }

        public async Task<CupomResponse> AtualizarCupom(CupomAtualizarRequest cupom)
        {
            var cupomDb = await _cupomRepository.ObterPorId(cupom.Id);

            cupomDb.CodigoDoCupom = cupom. CodigoDoCupom.ToUpper();
            cupomDb.DescricaoDoCupom = cupom.DescricaoDoCupom;
            cupomDb.ValorDoDesconto = cupom.ValorDoDesconto;

            cupomDb.TipoDescontoCupom = cupom.TipoDescontoCupom;
            cupomDb.TipoStatusCupom = cupom.TipoStatusCupom;

            cupomDb.DataDeValidade = cupom.DataDeValidade;
            cupomDb.CuponsLiberados = cupom.CuponsLiberados;


            await _cupomRepository.Atualizar(cupomDb);


            var response = new CupomResponse
            {
   

                Id = cupomDb.Id,
                CodigoDoCupom = cupomDb.CodigoDoCupom,
                DescricaoDoCupom = cupomDb.DescricaoDoCupom,
                ValorDoDesconto = cupomDb.ValorDoDesconto,

                TipoDescontoCupom = cupomDb.TipoDescontoCupom,
                TipoStatusCupom = cupomDb.TipoStatusCupom,

                DataDeValidade = cupomDb.DataDeValidade,
                CuponsLiberados = cupomDb.CuponsLiberados,
                CuponsUsados = cupomDb.CuponsUsados


            };

            return response;
        }

        public Task<CupomResponse> CadastrarCupom(CupomCadastrarRequest cupom)
        {


            throw new NotImplementedException();
        }

        public async Task<CupomResponse> CupomCadastrar(CupomCadastrarRequest cupom)
        {

            if (cupom.DataDeValidade < DateTime.Today)
            {

                throw new ArgumentException
                    ("A data da validade só pode ser posterior a data atual! ");
            }

            var cupomEntidade = new Cupom
            {

                CodigoDoCupom = cupom.CodigoDoCupom,
                DescricaoDoCupom = cupom.DescricaoDoCupom,
                ValorDoDesconto = cupom.ValorDoDesconto,

                TipoDescontoCupom = cupom.TipoDescontoCupom,
                TipoStatusCupom = cupom.TipoStatusCupom,

                DataDeValidade = cupom.DataDeValidade,

            };


            await _cupomRepository.Adicionar(cupomEntidade);

            var response = new CupomResponse
            {

                Id = cupomEntidade.Id,
                CodigoDoCupom = cupomEntidade.CodigoDoCupom,
                DescricaoDoCupom = cupomEntidade.DescricaoDoCupom,
                ValorDoDesconto = cupomEntidade.ValorDoDesconto,

                TipoDescontoCupom = cupomEntidade.TipoDescontoCupom,
                TipoStatusCupom = cupomEntidade.TipoStatusCupom,

                DataDeValidade = cupomEntidade.DataDeValidade,
                CuponsLiberados = cupomEntidade.CuponsLiberados,
                CuponsUsados = cupomEntidade.CuponsUsados



            };


            return response;

        }

        public async Task<bool> DeletarCupom(Guid id)
        {

            var cupom = await _cupomRepository.ObterPorId(id);
            if (cupom == null) return false;

            await _cupomRepository.RemoverCupom(id);
            return true;

        }
    }


}
