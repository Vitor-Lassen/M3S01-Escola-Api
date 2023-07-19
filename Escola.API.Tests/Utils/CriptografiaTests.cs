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

            //A senha deve ser criptohtafada em SHA256
            var hash = Criptografia.CriptografarSenha("hello world");

            Assert.AreEqual("uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=", hash);
        }

        [Test]
        //Teste de encheção de linguiça,, visto que é pouco assertivo
        public void CriptografarSenha_Senha_HashCriptografiaInvalido()
        {

            //A senha deve ser criptohtafada em SHA256
            var hash = Criptografia.CriptografarSenha("hello world");

            Assert.AreNotEqual("MJ7MSJwS1utMxA9QyQLytNDtd+5RGnx6m808qG1M2G+YndNbxf9JlnDaNCVbRbDP2DDoH2Bdz33FVC6TrpzXbw==", hash);
        }

        [Test]
        public void CriptografarSenha_Usuario_UsuarioComSenhaEmHashEquals()
        {

            var usuario = new Usuario()
            {
                Nome = "Vitor",
                Senha = "hello world",
                TipoAcesso = "Professor"
            };

            //A senha deve ser criptohtafada em SHA256
            var usuarioRetorno = Criptografia.CriptografarSenha(usuario);


            var usuarioEsperado = new Usuario()
            {
                Nome = "Vitor",
                Senha = "uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=",
                TipoAcesso = "Professor"
            };

            Assert.AreEqual(usuarioEsperado, usuarioRetorno);
        }

        [Test]
        public void CriptografarSenha_Usuario_UsuarioComSenhaEmHash()
        {

            var usuario = new Usuario()
            {
                Nome = "Vitor",
                Senha = "hello world",
                TipoAcesso = "Professor"
            };

            //A senha deve ser criptohtafada em SHA256
            var usuarioRetorno = Criptografia.CriptografarSenha(usuario);


            var usuarioEsperado = new Usuario()
            {
                Nome = "Vitor",
                Senha = "uU0nuZNNPgilLlLX2n2r+sSE7+N6U4DukIj3rOLvzek=",
                TipoAcesso = "Professor"
            };

            Assert.AreEqual(JsonConvert.SerializeObject( usuarioEsperado), JsonConvert.SerializeObject(usuarioRetorno));
        }

    }
}