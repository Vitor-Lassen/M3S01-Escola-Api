using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Escola.API.Controllers; 
using System.Threading.Tasks;
using Moq;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.DTO;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework.Constraints;
using Newtonsoft.Json;

namespace Escola.API.Tests.Controller
{
    public class BoletimControllerTest
    {

        [Test]
        public void CriarBoletim_AdicionarBoletim_Sucesso()
        {
            //Arrange 

            var boletimServiceMock = new Mock<IBoletimService>();
            boletimServiceMock.Setup(x => x.Cadastrar(It.IsAny<Boletim>())).Returns(new Boletim() { Id = 10 });

            var boletimController = new BoletimController(boletimServiceMock.Object);

            var boletim = new BoletimDTO() { Data = new DateTime(2023, 07, 18), AlunoId = 5 };
            var expectedBoletim = new BoletimDTO() { Data = new DateTime(2023, 07, 18), AlunoId = 5, Id = 10 };
            var expectedStatus = 200;

            //Act
            var result = boletimController.Post(boletim, 5);

            //ASSERTs
            Assert.IsTrue(result is OkObjectResult);
            var resultOk = (OkObjectResult)result;

            Assert.AreEqual(expectedStatus, resultOk.StatusCode);

            Assert.AreEqual(JsonConvert.SerializeObject(expectedBoletim), JsonConvert.SerializeObject(resultOk.Value));

        }
    }
}
