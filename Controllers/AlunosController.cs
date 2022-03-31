namespace CursoIdiomas.API.Controllers
{
    using CursoIdiomas.API.Entities;
    using CursoIdiomas.API.Models;
    using CursoIdiomas.API.Persistance.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/alunos")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repository;

    public AlunoController(IAlunoRepository repository)
    {
        _repository = repository;
    }

        [HttpGet]
        public IActionResult GetAll()
        {
            var alunos = _repository.GetAll();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var aluno = _repository.FindById(id);

            if(aluno == null)
            return NotFound();

            return Ok(aluno);
        }

        [HttpPost]
        public IActionResult Post(AddAlunoInputModel model)
        {
            //Puxar todos alunos para verificar se já existe CPF cadastrado
             var alunos = _repository.GetAll();

             foreach(var item in alunos)
             {
                 if (item.CPF == model.cpf)
                 return BadRequest("CPF já cadastrado");
             }                                 
            
            
            if(model.turmaId == 0)
            {
                return BadRequest("É Necessário Informar o Número da Turma");
            }            

            var aluno = new Aluno(
              model.name,
              model.cpf,
              model.email,
              model.turmaId
              );

           var turmas = _repository.GetTurmaById(model.turmaId);             

           if(turmas == null)
           return NotFound("Turma Não Foi Encontrada");

           int qtdeAlunos = _repository.VerificarQtdeAluno(model.turmaId);
           
           if(qtdeAlunos >= 5)
           return BadRequest("Turma Cheia");

            /*
           if(turmas.Alunos.Count >= 5)
           {
               return BadRequest("Turma Cheia");
           }
           */

            turmas.UpdateTurma(turmas.NumeroTurma, turmas.AnoLetivo,aluno); 

             _repository.Add(aluno);            

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateAlunoInputModel model)
        {
            var aluno = _repository.FindById(id);

            if(aluno == null)
            return NotFound();

            aluno.Update(model.name,model.cpf, model.email, model.turmaId);

            _repository.UpdateAluno(aluno);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var aluno = _repository.FindById(id);

            if(aluno == null)
            return NotFound();
            
            _repository.DeleteAluno(aluno);

            return NoContent();
        }

        
    }
}