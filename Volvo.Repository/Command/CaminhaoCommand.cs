using Microsoft.Extensions.Configuration;
using Volto.Repository;
using Volvo.Domain;
using Volvo.Repository.Interface;

namespace Volvo.Repository
{
    public class CaminhaoCommand : Connection, ICommand<CaminhaoModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe CaminhaoCommand
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public CaminhaoCommand(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.command)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        /// <summary>
        /// exclui
        /// </summary>
        /// <param name="id">id do registro de caminhão</param>
        public void Delete(int id)
        {
            _db.Remove(CaminhaoModel.CaminhaoModelFactory.ObterModel(id));
            _db.SaveChanges();
        }

        /// <summary>
        /// inclui um novo registro
        /// </summary>
        /// <param name="entity">entidade caminhão</param>
        public void Post(CaminhaoModel entity)
        {
            _db.Add(CaminhaoModel.CaminhaoModelFactory.ObterModel(entity.Modelo, entity.AnoFabricao, entity.AnoModelo));
            _db.SaveChanges();
        }

        /// <summary>
        /// atualiza um registro
        /// </summary>
        /// <param name="entity">entidade login</param>
        public void Put(CaminhaoModel entity)
        {
            _db.Update(CaminhaoModel.CaminhaoModelFactory.ObterModel(entity.Modelo, entity.AnoFabricao, entity.AnoModelo, entity.Id));
            _db.SaveChanges();
        }

        #endregion
    }
}
