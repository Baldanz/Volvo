namespace Volvo.WebApi.Models.Sistema
{
    public abstract class MensagemSistema
    {
        #region métodos

        /// <summary>
        /// método utilizado para tratar a mensagem retornada pelo sistema
        /// </summary>
        /// <param name="metodo">método executado para a mensagem de command ou query</param>
        /// <returns>retorna a mensagem do sistema</returns>
        protected string RetornarMensagem(string metodo)
        {
            // case para retornar a mensagem tratada pelo sistema
            switch (metodo)
            {
                case "Post":
                    return "Registro cadastrado com sucesso";

                case "Put":
                    return "Registro atualizado com sucesso";

                case "Delete":
                    return "Registro excluído com sucesso";

                case "GetById":
                    return "Foi encontrado o seguinte registro";

                case "GetAll":
                    return "Foram encontrados os seguintes registros";
            }
            return null;
        }

        #endregion
    }
}
