using Escola.API.Exceptions;
using Escola.API.Interfaces.Repositories;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using System.Collections.Generic;

namespace Escola.API.Services
{
    public class BoletimService : IBoletimServices
    {
        private readonly IBoletimRepository _boletimRepository;
        private readonly IAlunoService _alunoService;

        public BoletimService(IBoletimRepository boletimRepository, IAlunoService alunoService)
        {
            _boletimRepository = boletimRepository;
            _alunoService = alunoService;
        }
        public Boletim Atualizar(Boletim boletim)
        {
            throw new System.NotImplementedException();
        }

        public Boletim Cadastrar(Boletim boletim)
        {
            if (_alunoService.ObterPorId(boletim.AlunoId) == null)
            {
                throw new NotFoundException("Aluno não cadastrado");
            }

            _boletimRepository.Inserir(boletim);
            return boletim;
        }

        public void Excluir(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<Boletim> ObterPorAluno(int alunoId)
        {
            throw new System.NotImplementedException();
        }

        public Boletim ObterPorId(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
