using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using Escola.API.Services;
using Escola.API.Tests.Mocks.Reposiories;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;

namespace Escola.API.Tests.Services
{
    public  class AlunoServicesTestsMoq
    {
        [Test]
        public void Criar_AlunoNaoCadastrado_Successo()
        {
            //ARRANGE
            var aluno = new Aluno() { Nome = "Vitor", Email = "vitor@email.com", Sobrenome = "Lassen" };
            var expectedAluno = new Aluno() { Id = 10, Nome = "Vitor", Email = "vitor@email.com", Sobrenome = "Lassen" };

            var alunoRepository = new AlunoRepositoryMock();

            var alunoRepositoryMoq = new Mock<IAlunoRepository>();
            alunoRepositoryMoq.Setup(x => x.EmailJaCadastrado("vitor@email.com")).Returns(false);
            alunoRepositoryMoq.Setup(x => x.Inserir(aluno)).Returns(() => 
                                                            {
                                                                aluno.Id = 10;
                                                                return aluno;
                                                               });

            var alunoService = new AlunoService(alunoRepositoryMoq.Object);

            //ACT
            var result = alunoService.Criar(aluno);

            //Assert
            Assert.AreEqual(JsonConvert.SerializeObject(expectedAluno), JsonConvert.SerializeObject(result));

        }
        [Test]
        public void Criar_AlunoNaoCadastrado_Successo_ItsAny()
        {
            //ARRANGE
            var aluno = new Aluno() { Nome = "Vitor", Email = "vitor@email.com", Sobrenome = "Lassen" };
            var expectedAluno = new Aluno() { Id = 10, Nome = "Vitor", Email = "vitor@email.com", Sobrenome = "Lassen" };

            var alunoRepository = new AlunoRepositoryMock();

            var alunoRepositoryMoq = new Mock<IAlunoRepository>();
            alunoRepositoryMoq.Setup(x => x.EmailJaCadastrado(It.IsAny<string>())).Returns(false);
            alunoRepositoryMoq.Setup(x => x.Inserir(It.IsAny<Aluno>())).Returns(() =>
            {
                aluno.Id = 10;
                return aluno;
            });

            var alunoService = new AlunoService(alunoRepositoryMoq.Object);

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

            var alunoRepositoryMoq = new Mock<IAlunoRepository>();
            alunoRepositoryMoq.Setup(x => x.EmailJaCadastrado("camila@email.com")).Returns(true);

            var alunoService = new AlunoService(alunoRepositoryMoq.Object);

            //ACT
            //Assert
            var ex = Assert.Throws<RegistroDuplicadoException>(() => alunoService.Criar(aluno));
            Assert.AreEqual(expectedMessage, ex.Message);

        }
        [Test]
        public void Criar_AlunoJaCadastrado_ErroDuplicidade_ItsAny()
        {
            // ARRANGE
            var aluno = new Aluno() { Nome = "Camila", Email = "camila@email.com", Sobrenome = "Santos" };
            var expectedMessage = "email já cadastrado";

            var alunoRepositoryMoq = new Mock<IAlunoRepository>();
            alunoRepositoryMoq.Setup(x => x.EmailJaCadastrado(It.IsAny<string>())).Returns(true);

            var alunoService = new AlunoService(alunoRepositoryMoq.Object);

            //ACT
            //Assert
            var ex = Assert.Throws<RegistroDuplicadoException>(() => alunoService.Criar(aluno));
            Assert.AreEqual(expectedMessage, ex.Message);
        }
    }
}
