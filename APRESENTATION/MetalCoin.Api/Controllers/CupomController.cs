using Metalcoin.Core.Dtos.Categorias;
using Metalcoin.Core.Dtos.Request;
using Metalcoin.Core.Enums;
using Metalcoin.Core.Interfaces.Repositories;
using Metalcoin.Core.Interfaces.Services;
using MetalCoin.Application.Services;
using MetalCoin.Infra.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace MetalCoin.Api.Controllers
{


    [ApiController]
    public class CupomController : ControllerBase
    {
        private readonly ICupomRepository _cupomRepository;
        private readonly ICupomService _cupomService;


        public CupomController(ICupomRepository cupomRepository, ICupomService cupomService)
        {
            _cupomRepository = cupomRepository;
            _cupomService = cupomService;
        }


        [HttpGet]
        [Route("TodosCupons")]
        public async Task<ActionResult> ObterTodosCupons()
        {
            var listaCupons = await _cupomRepository.
                ObterTodosCupons();

            if (listaCupons.Count == 0) return NoContent();

            return Ok(listaCupons);
        }



        [HttpGet]
        [Route("CuponsAtivadosDisponiveis")]
        public async Task<ActionResult> ObterCuponsAtivos()
        {
            var cupom = await _cupomRepository.
                BuscarPorAtivados(TipoStatusCupom.Ativo);
            if (cupom == null) BadRequest("Os cupons ativos não foram encontrados ");
            return Ok(cupom);
        }

        [HttpGet]
        [Route("CuponsIndisponiveis")]
        public async Task<ActionResult> ObterCuponsInativos()
        {
            var cupom = await _cupomRepository.BuscarPorDesativados(TipoStatusCupom.Desativado);
            if (cupom == null) BadRequest("Os cupons ativos não foram encontrados");
            return Ok(cupom);
        }




        [HttpPost]
        [Route("CadastrarCupom")]
        public async Task<ActionResult> CadastrarCategoria([FromBody] CupomCadastrarRequest cupom)
        {
            if (cupom == null) return BadRequest("É necessario Informar o nome do cupom");
            var response = await _cupomService.
                CadastrarCupom(cupom);

            if (response == null) return BadRequest("O Cupom já é existente");

            return Created("Cupom cadastrado", response);
        }

        [HttpPut]
        [Route("AtualizarCupom")]
        public async Task<ActionResult> AtualizarCupom([FromBody] CupomAtualizarRequest cupom)
        {
            if (cupom == null) return BadRequest("A API não recebeu nenhum valor");
            var response = await _cupomService.
                AtualizarCupom(cupom);

            return Ok(response);
        }


        [HttpDelete]
        [Route("AtivarCpom/{id:guid}")]
        public async Task<ActionResult> AtivarCupom(Guid id)
        {

            var cupom = await _cupomRepository.
                AtivarCupom(id);

            if (cupom == null) return BadRequest("O cupom não foi encontrado");
            cupom.TipoStatusCupom = TipoStatusCupom.Ativo;
            await _cupomRepository.
                AtualizarCupons(cupom);

            return Ok("O cupom foi ativado ");
        }


        [HttpDelete]
        [Route("DesativarCupom/{id:guid}")]
        public async Task<ActionResult> DesativarCupom(Guid id)
        {

            var cupom = await _cupomRepository.
                DesativarCupom(id);

            if (cupom == null) return BadRequest("O cupom não foi encontrado");
            cupom.TipoStatusCupom = TipoStatusCupom.Desativado;
            await _cupomRepository.
                AtualizarCupons(cupom);


            return Ok("O cupom foi Desativado");
        }



        [HttpDelete]
        [Route("ExcluirCupom/{id:guid}")]
        public async Task<ActionResult> RemoverCupom(Guid id)
        {
            if (id == Guid.Empty) return BadRequest("O Id não foi informado");
            var resultado = await _cupomService.
                DeletarCupom(id);

            if (!resultado) return BadRequest("O cupom selecionado não existe");

            return Ok("O cupom foi deletado");
        }
    }

}
