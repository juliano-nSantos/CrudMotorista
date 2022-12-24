using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Filters;
using API.Models;
using Application.DTO.DTO;
using Application.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace API.V1.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = false)]
    [ApiVersion("1.0")]
    [Route("api/v{version:ApiVersion}/[controller]")]
    public class MotoristaController : ControllerBase
    {
        private readonly IApplicationServiceMotorista _applicationServiceMotorista;

        public MotoristaController(IApplicationServiceMotorista applicationServiceMotorista)
        {
            _applicationServiceMotorista = applicationServiceMotorista;
        }

        [HttpPost]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao registrar motorista")]
        [SwaggerResponse(statusCode: 400, description: "Campos obrigatórios", type: typeof(ValidateInputViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Erro Interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("add")]
        public ActionResult Post(MotoristaDTO motorista)
        {
            try
            {
                _applicationServiceMotorista.Add(motorista);

                return Ok("Motorista Cadastrado com sucesso!");
            }
            catch (ArgumentException ax)
            {
                return BadRequest(ax.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao consultar todos motoristas")]
        [SwaggerResponse(statusCode: 400, description: "Erro ao consultar todos motoristas")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("GetAll")]
        public ActionResult Get()
        {
            try
            {
                var lstMotoristas = _applicationServiceMotorista.GetAll();

                return Ok(lstMotoristas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao consultar motorista por código")]
        [SwaggerResponse(statusCode: 404, description: "Dados não encontrado")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("GetById")]
        public ActionResult Get([FromHeader] int id)
        {
            try
            {
                var motorista = _applicationServiceMotorista.GetById(id);

                if (motorista == null)
                    return NotFound("Dados não encontrado!");

                return Ok(motorista);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao atualizar os dados do motorista")]
        [SwaggerResponse(statusCode: 400, description: "Dados inválidos", type: typeof(ValidateInputViewModel))]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("update")]
        public ActionResult Put(MotoristaDTO motorista)
        {
            try
            {
                _applicationServiceMotorista.Update(motorista);

                return Ok("Dados Atualizados com sucesso!");
            }
            catch (ArgumentException ax)
            {
                return BadRequest(ax.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao excluir dados motorista")]
        [SwaggerResponse(statusCode: 404, description: "Dados não encontrado")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("delete")]
        public ActionResult Delete([FromHeader] int id)
        {
            try
            {
                var motorista = _applicationServiceMotorista.GetById(id);

                if (motorista == null)
                    return NotFound("Dados não encontrado!");
                else
                    _applicationServiceMotorista.Remove(motorista);

                return Ok("Dados excluido com sucesso");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerResponse(statusCode: 200, description: "Sucesso ao consultar dados dos motoristas")]
        [SwaggerResponse(statusCode: 404, description: "Dados não encontrados!")]
        [SwaggerResponse(statusCode: 400, description: "Dados inválidos!")]
        [SwaggerResponse(statusCode: 500, description: "Erro interno", type: typeof(GenericErrorViewModel))]
        [CustomModelStateValidation]
        [Route("filterMotoristas")]
        public ActionResult Get([FromQuery] FiltroBuscaMotorista filtro)
        {
            try
            {
                var resposeMotorista = new ResponseMotorista();

                resposeMotorista.lstMotoristas = _applicationServiceMotorista.GetByFilter(filtro);

                return Ok(resposeMotorista);
            }
            catch (ArgumentException ax)
            {
                return BadRequest(ax.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}