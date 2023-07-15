using Escola.API.DTO;
using Escola.API.Exceptions;
using Escola.API.Interfaces.Services;
using Escola.API.Model;
using Escola.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Escola.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BoletimController : Controller
    {
        private readonly IBoletimService _boletimService;

        public BoletimController(IBoletimService boletimService)
        {
            _boletimService = boletimService;
        }

        [HttpPost("/alunos/{idAluno}/boletins")]
        public ActionResult Post(BoletimDTO boletim, int idAluno)
        {

            boletim.AlunoId = idAluno;

            boletim.Id = _boletimService.Cadastrar(new Boletim(boletim)).Id;

            //var boletimModel = _boletimService.Cadastrar(new Boletim(boletim));
            //boletim.Id = boletimModel.Id;

            return Ok(boletim);

        }

        [HttpPut("/alunos/{idAluno}/boletins/{id}")]
        public ActionResult Put(BoletimDTO boletim, int idAluno, int id)
        {

            boletim.AlunoId = idAluno;

            boletim.Id = id;

            return Ok(new BoletimDTO(_boletimService.Atualizar(new Boletim(boletim))));

        }



        [HttpGet("/alunos/{idAluno}/boletins")]
        public ActionResult GetPorAluno(int idAluno)
        {


            var boletins = _boletimService.ObterPorAluno(idAluno);
            return Ok(boletins.Select(x => new BoletimDTO(x)));

        }

        [HttpGet("/alunos/{idAluno}/boletins/{id}")]
        public ActionResult GetPorIdValidaAluno(int idAluno, int id)
        {

            var boletim = _boletimService.ObterPorId(id);

            if (boletim.AlunoId != idAluno)
                return NotFound("Boletim Id invalido para aluno");

            return Ok(new BoletimDTO(boletim));

        }

        [HttpGet("{id}")]
        public ActionResult GetPorId(int id)
        {


            var boletim = _boletimService.ObterPorId(id);

            return Ok(new BoletimDTO(boletim));

        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {

            _boletimService.Excluir(id);

            return StatusCode(204);

        }
    }
}
