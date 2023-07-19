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
            //ARRANGE
            var expectedResult = 5;

            //ACT
            var resultado = _calculoMediaServices.CalcularMedia(3, 5, 7);

            //ASSERT
            Assert.AreEqual(expectedResult, resultado);
        }
        [Test]
        public void CalcularMedia_2NumerosPositivos_RetornoMediValida()
        {
            //ARRANGE
            var expectedResult = 5;

            //ACT
            var resultado = _calculoMediaServices.CalcularMedia(2,8);
            //ASSERT
            Assert.AreEqual(expectedResult, resultado);
        }
        [Test]
        public void CalcularMedia_4NumerosPositivos_RetornoMediValida()
        {
            //ARRANGE
            var expectedResult = 3.5;

            //ACT
            var resultado = _calculoMediaServices.CalcularMedia(2, 8,2,2);

            //ASSERT
            Assert.AreEqual(expectedResult, resultado);

        }


        [Test]
        public void CalcularMedia_1NumeroValidoE1Invalido_RetornoErro()
        {
            //ARRANGE
            var expectedMessage = "A nota 15 deve ser maior ou igual a zero";
            var expectedPartialMessage = "deve ser maior ou igual a zero";

            //ACT
            try
            {
                var resultado = _calculoMediaServices.CalcularMedia(2, 15);

            }
            catch (ArgumentOutOfRangeException ex)
            {
                //Assert.IsTrue(ex is ArgumentOutOfRangeException);
                Assert.AreEqual(expectedMessage, ex.ParamName);
                Assert.IsTrue(ex.Message.Contains(expectedPartialMessage));
            }

        }

        [Test]
        public void CalcularMedia_1NumeroValidoE1Invalido_RetornoErroRecomendado()
        {
            //ARRANGE
            var expectedMessage = "A nota -5 deve ser maior ou igual a zero";
            var expectedPartialMessage = "deve ser maior ou igual a zero";

            //ACT
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var resultado = _calculoMediaServices.CalcularMedia(2, -5);

            });
            //ASSERT
            
            Assert.AreEqual(expectedMessage, ex.ParamName);
            Assert.IsTrue(expectedMessage == ex.ParamName);
            Assert.IsTrue(ex.Message.Contains(expectedPartialMessage));


        }
    }
}
