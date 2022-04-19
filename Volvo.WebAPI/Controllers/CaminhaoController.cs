using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using Volvo.Domain;
using Volvo.Repository.Interface;
using Volvo.Services;
using Volvo.WebApi.Models.Sistema;
using Volvo.WebApi.Models.Sistema.Mensagem;
using Volvo.WebApi.Utils.Enums;
using Volvo.WebAPI.Models;

namespace Volvo.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CaminhaoController : ControllerBase
    {
        #region atributos

        readonly IQuery<CaminhaoModel> _query;
        readonly ICommandHandler<CaminhaoModel> _command;
        readonly IMapper _mapper;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CaminhaoController
        /// </summary>
        /// <param name="query">objeto query para as operações query</param>
        /// <param name="command">objeto command para as operações nonquery</param>
        /// <param name="mapper">objeto automapper</param>
        public CaminhaoController(IQuery<CaminhaoModel> query, ICommandHandler<CaminhaoModel> command, IMapper mapper)
        {
            // bloco de construção de objetos
            _query = query;
            _command = command;
            _mapper = mapper;
        }

        #endregion

        #region métodos

        [Route("incluir")]
        [HttpPost]
        public MensagemSistema Post([FromBody] CaminhaoViewModel p)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de inclusão do registro de Caminhao
                _command.Post(_mapper.Map<CaminhaoModel>(p));
                return new MensagemRetorno(EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("atualizar")]
        [HttpPut]
        public MensagemSistema Put([FromBody] CaminhaoViewModel p)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de atualização do registro de Caminhao
                _command.Put(_mapper.Map<CaminhaoModel>(p));
                return new MensagemRetorno(EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sysEx.Message);
            }

        }

        [Route("excluir")]
        [HttpDelete]
        public MensagemSistema Delete(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                // executa o processo de exclusão do registro de Caminhao
                _command.Delete(Id);
                return new MensagemRetorno(EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name);
            }
            catch (SqlException sqlEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("listar")]
        [HttpGet]
        public MensagemSistema GetAll()
        {
            // bloco de tratamento de exceção
            try
            {
                return new MensagemLista<CaminhaoViewModel>(EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Lista = _mapper.Map<IEnumerable<CaminhaoViewModel>>(_query.GetAll("MODELO IN ('FM', 'FH') "))
                };
            }
            catch (SqlException sqlEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sysEx.Message);
            }
        }

        [Route("consultar/{Id}")]
        [HttpGet]
        public MensagemSistema GetById(int Id)
        {
            // bloco de tratamento de exceção
            try
            {
                return new MensagemRegistro<CaminhaoViewModel>(EMensagem.Sucesso, new System.Diagnostics.StackFrame(0).GetMethod().Name)
                {
                    Registro = _mapper.Map<CaminhaoViewModel>(_query.GetById(Id))
                };
            }
            catch (SqlException sqlEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sqlEx.Message);
            }
            catch (Exception sysEx)
            {
                return new MensagemRetorno(EMensagem.Erro, sysEx.Message);
            }
        }

        #endregion
    }
}
