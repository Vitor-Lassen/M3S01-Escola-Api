using Escola.API.Controllers;
using Escola.API.DTO;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.API.Tests.Controller
{
    public class AlunoControllerTest
    {

        [Test]
        [TestCase("93719268055") ]
        [TestCase("17697539071") ]
        public void Cadadastrar_SendValidCPF_Suceso(string cpf )
        {
            //ARRANGE

            var alunoDTO = new AlunoDTO() { Nome = "João",
                                            Sobrenome = "Santos",
                                            CPF = cpf,
                                            DataNascimento = "01/01/90"
            };
            var alunoServiceMock = new Mock<IAlunoService>();
            var memorycacheMock = new Mock<IMemoryCache>();
            alunoServiceMock.Setup(x => x.Criar(It.IsAny<Aluno>()))
                                            .Returns<Aluno>(a =>
                                            {
                                                a.Id = 10;
                                                return a;
                                            });
            var alunoController = new AlunosController(alunoServiceMock.Object,
                                                       memorycacheMock.Object);

            var expectedResult = new AlunoDTO()
            {
                Nome = "João",
                Sobrenome = "Santos",
                CPF = cpf, 
                Id =10,
                DataNascimento = "01/01/90"
            };

            //ACT
            var result = alunoController.Post(alunoDTO);

            //ASSERT
            Assert.IsTrue(result is OkObjectResult);
            var resultOk = (OkObjectResult)result;
            Assert.AreEqual(JsonConvert.SerializeObject(resultOk.Value), JsonConvert.SerializeObject(expectedResult));
        }


        [Test]
        [TestCase("93719556055")]
        [TestCase("11111111111")]
        public void Cadadastrar_SendInvalidCPF_Fail(string cpf)
        {
            //ARRANGE

            var alunoDTO = new AlunoDTO()
            {
                Nome = "João",
                Sobrenome = "Santos",
                CPF = cpf,
                DataNascimento = "01/01/90"
            };
            var alunoServiceMock = new Mock<IAlunoService>();
            var memorycacheMock = new Mock<IMemoryCache>();

            var alunoController = new AlunosController(alunoServiceMock.Object,
                                                       memorycacheMock.Object);

            //ACT
            var result = alunoController.Post(alunoDTO);

            
            //ASSERT
            Assert.IsTrue(result is BadRequestResult);
        
        }
    }
}
