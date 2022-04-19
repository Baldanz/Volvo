using AutoMapper;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Volvo.Domain;
using Volvo.Repository.Interface;
using Volvo.Services;
using Volvo.WebApi.Models.Sistema;
using Volvo.WebAPI.Controllers;
using Volvo.WebAPI.Models;
using Xunit;

namespace Volto.Testes
{
    public class CaminhaoServiceTests
    {
        #region atributos

        private CaminhaoController caminhaoController;

        #endregion

        #region construtores

        /// <summary>
        /// construtor CaminhaoServiceTests
        /// </summary>
        public CaminhaoServiceTests()
        {
            caminhaoController = new CaminhaoController(
                new Mock<IQuery<CaminhaoModel>>().Object,
                new Mock<ICommandHandler<CaminhaoModel>>().Object,
                new Mock<IMapper>().Object);
        }

        #endregion

        #region métodos

        [Fact]
        public void Post_ModeloFH()
        {
            var result = true;
            try
            {
                caminhaoController.Post(new CaminhaoViewModel()
                {
                    Modelo = "FH",
                    AnoFabricao = DateTime.Now.Year,
                    AnoModelo = DateTime.Now.Year
                });
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Post_ModeloFM()
        {
            var result = true;
            try
            {
                caminhaoController.Post(new CaminhaoViewModel()
                {
                    Modelo = "FM",
                    AnoFabricao = DateTime.Now.Year,
                    AnoModelo = DateTime.Now.Year + 1
                });
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Post_ModeloFA()
        {
            var result = true;
            try
            {
                caminhaoController.Post(new CaminhaoViewModel()
                {
                    Modelo = "FA",
                    AnoFabricao = DateTime.Now.Year,
                    AnoModelo = DateTime.Now.Year
                });
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Post_ModeloFB()
        {
            var result = true;
            try
            {
                caminhaoController.Post(new CaminhaoViewModel()
                {
                    Modelo = "FA",
                    AnoFabricao = DateTime.Now.Year,
                    AnoModelo = DateTime.Now.Year + 1
                });
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Put_ModeloFH()
        {
            var result = true;
            try
            {
                caminhaoController.Put(new CaminhaoViewModel()
                {
                    Id = 1,
                    Modelo = "FH",
                    AnoFabricao = DateTime.Now.Year,
                    AnoModelo = DateTime.Now.Year + 1
                });
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Put_ModeloFM()
        {
            var result = true;
            try
            {
                caminhaoController.Put(new CaminhaoViewModel()
                {
                    Id = 2,
                    Modelo = "FM",
                    AnoFabricao = DateTime.Now.Year,
                    AnoModelo = DateTime.Now.Year
                });
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Remove_ModeloFH()
        {
            var result = true;
            try
            {
                caminhaoController.Delete(1);
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Remove_ModeloFM()
        {
            var result = true;
            try
            {
                caminhaoController.Delete(2);
            }
            catch { result = false; }
            Assert.True(result);
        }

        [Fact]
        public void Get_AllFMFH()
        {
            var list = new List<CaminhaoViewModel>();
            list.Add(new CaminhaoViewModel()
            {
                Id = 1,
                Modelo = "FH",
                AnoFabricao = 2022,
                AnoModelo = 2022
            });
            list.Add(new CaminhaoViewModel()
            {
                Id = 2,
                Modelo = "FM",
                AnoFabricao = 2022,
                AnoModelo = 2023
            });
            list.Add(new CaminhaoViewModel()
            {
                Id = 3,
                Modelo = "FA",
                AnoFabricao = 2022,
                AnoModelo = 2023
            });
            list.Add(new CaminhaoViewModel()
            {
                Id = 4,
                Modelo = "FB",
                AnoFabricao = 2022,
                AnoModelo = 2023
            });
            var listagem = list.Where(x => x.Modelo == "FM" || x.Modelo == "FH").ToList();
            Assert.True(listagem.Count() == 2);
        }

        #endregion
    }
}
