using Volvo.WebApi.Utils.Enums;

namespace Volvo.WebApi.Models.Sistema.Mensagem
{
    public class MensagemRetorno : MensagemSistema
    {
        #region construtores

        /// <summary>
        /// construtor da classe MensagemRetorno
        /// </summary>
        /// <param name="codigo">código da mensagem</param>
        /// <param name="metodo">método para o retorno da mensagem</param>
        public MensagemRetorno(EMensagem codigo, string metodo)
        {
            // bloco de construção de objetos
            Codigo = codigo;
            Mensagem = RetornarMensagem(metodo);
        }

        #endregion

        #region propriedades

        public EMensagem Codigo { get; private set; }
        public string Mensagem { get; private set; }

        #endregion
    }
}