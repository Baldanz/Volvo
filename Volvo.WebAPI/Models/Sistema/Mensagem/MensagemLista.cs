using Volvo.WebApi.Utils.Enums;
using System.Collections.Generic;

namespace Volvo.WebApi.Models.Sistema.Mensagem
{
    public class MensagemLista<TEntity> : MensagemSistema
    {
        #region construtores

        /// <summary>
        /// construtor da classe MensagemLista
        /// </summary>
        /// <param name="codigo">código da mensagem</param>
        /// <param name="metodo">método para o retorno da mensagem</param>
        public MensagemLista(EMensagem codigo, string metodo)
        {
            // bloco de construção de objetos
            Codigo = codigo;
            Mensagem = RetornarMensagem(metodo);
        }

        #endregion

        #region propriedades

        public EMensagem Codigo { get; private set; }
        public string Mensagem { get; private set; }
        public IEnumerable<TEntity> Lista { get; set; } = new List<TEntity>();

        #endregion

    }
}