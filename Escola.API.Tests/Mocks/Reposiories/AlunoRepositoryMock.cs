using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System;
using System.Collections.Generic;

namespace Escola.API.Tests.Mock.Reposiories
{
    public class AlunoRepositoryMock : IAlunoRepository
    {
        public Aluno Atualizar(Aluno model)
        {
            throw new NotImplementedException();
        }

        public bool EmailJaCadastrado(string email)
        {
            var emails = new List<string> { "camila@email.com" };
            return emails.Contains(email);
        }

        public void Excluir(Aluno model)
        {
            throw new NotImplementedException();
        }

        public Aluno Inserir(Aluno model)
        {
            if (model.Nome == "Vitor")
            {
                model.Id = 10;
            }
            return model;
        }

        public Aluno ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public List<Aluno> ObterTodos()
        {
            throw new NotImplementedException();
        }
    }
}
