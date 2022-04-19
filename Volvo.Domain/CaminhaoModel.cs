using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Volvo.Domain
{
    public class CaminhaoModel
    {
        #region construtores

        /// <summary>
        /// construtor da classe CaminhaoModel
        /// </summary>
        public CaminhaoModel() { }

        /// <summary>
        /// construtor da classe CaminhaoModel
        /// </summary>
        /// <param name="modelo">descrição do modelo</param>
        /// <param name="anoFabricao">ano de fabricação</param>
        /// <param name="anoModelo">ai=no modelo</param>
        /// <param name="id">id do modelo do caminhão</param>
        public CaminhaoModel(string modelo, int anoFabricao, int anoModelo, int? id = null) 
        {
            Id = id;
            Modelo = modelo;
            AnoFabricao = anoFabricao;
            AnoModelo = anoModelo;
        }

        #endregion

        #region propriedades

        [Required]
        [Column("ID", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int? Id { get; private set; }

        [Required]
        [Column("MODELO", TypeName = "char")]
        [StringLength(2)]
        public string Modelo { get; private set; }

        [Required]
        [Column("ANO_FABRICACAO", TypeName = "int")]
        public int AnoFabricao { get; private set; }

        [Required]
        [Column("ANO_MODELO", TypeName = "int")]
        public int AnoModelo { get; private set; }

        #endregion

        #region factory

        public static class CaminhaoModelFactory 
        {
            /// <summary>
            /// obtém o modelo do caminhão selecionado
            /// </summary>
            /// <param name="modelo">descrição do modelo</param>
            /// <param name="anoFabricao">ano de fabricação</param>
            /// <param name="anoModelo">ai=no modelo</param>
            /// <param name="id">id do modelo do caminhão</param>
            /// <returns>retorna o modelo de dados</returns>
            public static CaminhaoModel ObterModel(string modelo, int anoFabricao, int anoModelo, int? id = null)
            => new CaminhaoModel
            {
                Modelo = modelo,
                AnoFabricao = anoFabricao,
                AnoModelo = anoModelo,
                Id = id
            };

            /// <summary>
            /// obtém o modelo do caminhão selecionado
            /// </summary>
            /// <param name="id">id do modelo do caminhão</param>
            /// <returns>retorna o modelo de dados</returns>
            public static CaminhaoModel ObterModel(int? id = null)
            => new CaminhaoModel
            {
                Id = id
            };
        }

        #endregion
    }
}
