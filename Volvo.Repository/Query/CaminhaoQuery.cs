using Dapper;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Volto.Repository;
using Volvo.Domain;
using Volvo.Repository.Interface;

namespace Volvo.Repository.Query
{
    public class CaminhaoQuery : Connection, IQuery<CaminhaoModel>
    {
        #region construtores

        /// <summary>
        /// construtor da classe CaminhaoQuery
        /// </summary>
        /// <param name="configuration">configuração para acesso ao banco de dados</param>
        /// <param name="chaveAcesso">chave de acesso para a conexão com o banco de dados</param>
        public CaminhaoQuery(IConfiguration configuration, Enums.EChaveAcesso chaveAcesso = Enums.EChaveAcesso.query)
        {
            // abre a conexão com o banco de dados
            AbrirConexao(configuration, chaveAcesso);
        }

        #endregion

        #region métodos

        public IEnumerable<CaminhaoModel> GetAll() =>
            _conn.Query<CaminhaoModel>($"{Query}");

        public IEnumerable<CaminhaoModel> GetAll(string where = "") =>
            _conn.Query<CaminhaoModel>($"{Query} WHERE { where }");

        public CaminhaoModel GetById(int id) =>
            _conn.Query<CaminhaoModel>($"{Query} WHERE ID = { id }", new { Id = id }).FirstOrDefault();

        #endregion

        #region propriedades

        private StringBuilder Query => new StringBuilder()
            .Append("SELECT ID as Id")
            .Append(", MODELO as Modelo")
            .Append(", ANO_FABRICACAO as AnoFabricacao")
            .Append(", ANO_MODELO as AnoModelo")
            .Append(" FROM TB_VOLVO_CAMINHAO");

        #endregion

        #region destruturores

        /// <summary>
        /// construtor da classe CaminhaoQuery
        /// </summary>
        ~CaminhaoQuery()
        {
            // encerra a conexão com o banco de dados
            EncerrarConexao();
        }

        #endregion
    }
}
