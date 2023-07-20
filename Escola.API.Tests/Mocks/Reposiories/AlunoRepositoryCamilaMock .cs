using Escola.API.Interfaces.Repositories;
using Escola.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escola.API.Tests.Mock.Reposiories
{
    public class AlunoRepositoryCamilaMock : IAlunoRepository
    {
        public Aluno Atualizar(Aluno model)
        {
            throw new NotImplementedException();
        }

        public bool EmailJaCadastrado(string email)
        {
            return true;
        }

        public void Excluir(Aluno model)
        {
            throw new NotImplementedException();
        }

        public Aluno Inserir(Aluno model)
        {
            model.Id = 10;
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
