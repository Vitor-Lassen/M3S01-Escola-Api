using Escola.API.Exceptions;
using Escola.API.Model;
using Escola.API.Services;
using Escola.API.Tests.Mock.Reposiories;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static NUnit.Framework.Constraints.Tolerance;

namespace Escola.API.Tests.Services
{
    public class AlunoServicesTests
    {

        [Test]
        public void Criar_AlunoNaoCadastrado_Successo()
        {
            //ARRANGE
            var aluno = new Aluno() { Nome = "Vitor", Email = "vitor@email.com", Sobrenome = "Lassen" };
            var expectedAluno = new Aluno() {Id = 10, Nome = "Vitor", Email = "vitor@email.com", Sobrenome = "Lassen" };

            var alunoService = new AlunoService(new AlunoRepositoryMock());

            //ACT
            var result = alunoService.Criar(aluno);

            //Assert

            Assert.AreEqual(JsonConvert.SerializeObject(expectedAluno), JsonConvert.SerializeObject(result));

        }
        [Test]
        public void Criar_AlunoJaCadastrado_ErroDuplicidade()
        {

            // ARRANGE
            var aluno = new Aluno() { Nome = "Camila", Email = "camila@email.com", Sobrenome = "Santos" };
            var expectedMessage = "email já cadastrado";

            var alunoService = new AlunoService(new AlunoRepositoryCamilaMock());

            //ACT
            //Assert
            var ex = Assert.Throws<RegistroDuplicadoException>(() => alunoService.Criar(aluno));
            Assert.AreEqual(expectedMessage, ex.Message);


         
        }

        [Test]
        public void Criar_AlunoJaCadastrado_ErroDuplicidade2()
        {

            // ARRANGE
            var aluno = new Aluno() { Nome = "Camila", Email = "camila@email.com", Sobrenome = "Santos" };
            var expectedMessage = "email já cadastrado";

            var alunoService = new AlunoService(new AlunoRepositoryMock());

            //ACT
            //Assert
            var ex = Assert.Throws<RegistroDuplicadoException>(() => alunoService.Criar(aluno));
            Assert.AreEqual(expectedMessage, ex.Message);



        }
    }
}
