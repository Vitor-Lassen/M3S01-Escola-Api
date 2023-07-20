using Escola.API.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.API.Tests.Utils
{
    public class CpfValidacoTests
    {

        [Test]
        [TestCase("84176748028")]
        [TestCase("05227458065")]
        public void Validar_CpfValido_Sucesso(string cpf)
        {

            //ACT
            bool result = CpfValidacao.Validate(cpf);  //Chamada método  

            //ASSERT

            Assert.IsTrue(result);
        }

        [Test]
        [TestCase("84176454028")]
        [TestCase("052265")]
        [TestCase("11111111111")]
        [TestCase("22222222222")]
        [TestCase("33333333333")]
        [TestCase("12345678911")]
        public void Validar_CpfInvalido_Falha(string cpf)
        {

            //ACT
            bool result = CpfValidacao.Validate(cpf);  //Chamada método  

            //ASSERT

            Assert.IsFalse(result);
        }
    }
}
