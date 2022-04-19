using System;
using Volvo.Domain;
using Volvo.Repository.Interface;

namespace Volvo.Services
{
    public class CaminhaoService : ICommandHandler<CaminhaoModel>
    {
        #region atributos

        readonly ICommand<CaminhaoModel> _caminhao;

        #endregion

        #region construtores

        /// <summary>
        /// construtor da classe CaminhaoService
        /// </summary>
        /// <param name="Caminhao">objeto command do Caminhao</param>
        public CaminhaoService(ICommand<CaminhaoModel> Caminhao)
        {
            // bloco de construção de objetos
            _caminhao = Caminhao;
        }
        #endregion

        #region métodos

        /// <summary>
        /// exclui os dados do registro
        /// </summary>
        /// <param name="id">id do registro</param>
        public void Delete(int Id)
            => _caminhao.Delete(Id);

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade Caminhao</param>
        public void Post(CaminhaoModel entity)
            => _caminhao.Post(entity);

        /// <summary>
        /// atualizar o registro
        /// </summary>
        /// <param name="entity">entidade Caminhao</param>
        public void Put(CaminhaoModel entity)
            => _caminhao.Put(entity);

        #endregion
    }
}
