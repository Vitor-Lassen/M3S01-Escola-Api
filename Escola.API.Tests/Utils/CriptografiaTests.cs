using NUnit.Framework;
using Escola.API.Utils;
using Escola.API.Model;
using Newtonsoft.Json;

namespace Escola.API.Tests
{
    public class CriptografiaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CriptografarSenha_Senha_HashCriptografiaValido()
        {
            //ARRANGE
            var hashExpected = "uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=";

            //ACT
            //A senha deve ser criptohtafada em SHA256
            var hash = Criptografia.CriptografarSenha("hello world");

            //ASSERT
            Assert.AreEqual(hashExpected, hash);
        }

        [Test]
        //Teste de encheção de linguiça,, visto que é pouco assertivo
        public void CriptografarSenha_Senha_HashCriptografiaInvalido()
        {
            //ARRANGE
            var hashNotExpected = "MJ7MSJwS1utMxA9QyQLytNDtd+5RGnx6m808qG1M2G+YndNbxf9JlnDaNCVbRbDP2DDoH2Bdz33FVC6TrpzXbw==";

            //ACT
            //A senha deve ser criptohtafada em SHA256
            var hash = Criptografia.CriptografarSenha("hello world");

            //ASSERT
            Assert.AreNotEqual(hashNotExpected, hash);
        }

        [Test]
        public void CriptografarSenha_Usuario_UsuarioComSenhaEmHashEquals()
        {
            //Arrange 
            var usuario = new Usuario()
            {
                Nome = "Vitor",
                Senha = "hello world",
                TipoAcesso = "Professor"
            };
            var usuarioEsperado = new Usuario()
            {
                Nome = "Vitor",
                Senha = "uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=",
                TipoAcesso = "Professor"
            };

            //ACT
            //A senha deve ser criptohtafada em SHA256
            var usuarioRetorno = Criptografia.CriptografarSenha(usuario);


            //Asserts
            Assert.AreEqual(usuarioEsperado, usuarioRetorno);
        }

        [Test]
        public void CriptografarSenha_Usuario_UsuarioComSenhaEmHash()
        {
            //Arrage 
            var usuario = new Usuario()
            {
                Nome = "Vitor",
                Senha = "hello world",
                TipoAcesso = "Professor"
            };
            var usuarioEsperado = new Usuario()
            {
                Nome = "Vitor",
                Senha = "uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=",
                TipoAcesso = "Professor"
            };

            //Act
            //A senha deve ser criptohtafada em SHA256
            var usuarioRetorno = Criptografia.CriptografarSenha(usuario);


            //ASSERT
            Assert.AreEqual(JsonConvert.SerializeObject( usuarioEsperado), JsonConvert.SerializeObject(usuarioRetorno));
        }

    }
}