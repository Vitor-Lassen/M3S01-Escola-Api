using Escola.API.Services;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Escola.API.Tests.Services
{
    public  class CalculoMediaServiceTests
    {
        private readonly CalculoMediaService _calculoMediaServices;
        public CalculoMediaServiceTests()
        {
           _calculoMediaServices = new CalculoMediaService();
        }
        [Test]
        public void CalcularMedia_3NumerosPositivos_RetornoMediValida()
        {
            var resultado = _calculoMediaServices.CalcularMedia(3, 5, 7);

            Assert.AreEqual(5, resultado);
        }
        [Test]
        public void CalcularMedia_2NumerosPositivos_RetornoMediValida()
        {
            var resultado = _calculoMediaServices.CalcularMedia(2,8);

            Assert.AreEqual(5, resultado);
        }
        [Test]
        public void CalcularMedia_4NumerosPositivos_RetornoMediValida()
        {
            var resultado = _calculoMediaServices.CalcularMedia(2, 8,2,2);

            Assert.AreEqual(3.5, resultado);

        }


        [Test]
        public void CalcularMedia_1NumeroValidoE1Invalido_RetornoErro()
        {

            try
            {
                var resultado = _calculoMediaServices.CalcularMedia(2, 15);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert.IsTrue(ex is ArgumentOutOfRangeException);
                Assert.AreEqual("A nota 15 deve ser maior ou igual a zero", ex.ParamName);
                Assert.IsTrue(ex.Message.Contains("deve ser maior ou igual a zero"));
            }

        }

        [Test]
        public void CalcularMedia_1NumeroValidoE1Invalido_RetornoErroRecomendado()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var resultado = _calculoMediaServices.CalcularMedia(2, -5);

            });
            
            Assert.AreEqual("A nota -5 deve ser maior ou igual a zero", ex.ParamName);
            Assert.IsTrue("A nota -5 deve ser maior ou igual a zero" == ex.ParamName);
            Assert.IsTrue(ex.Message.Contains("deve ser maior ou igual a zero"));


        }
    }
}
