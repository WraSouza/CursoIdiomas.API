namespace Curso.API.Controllers
{
    using CursoIdiomas.API.Entities;
    using CursoIdiomas.API.Models;
    using CursoIdiomas.API.Persistance.Repositories;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/turmas")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepositories _repository;

        public TurmaController(ITurmaRepositories repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var turmas = _repository.GetAll();
            return Ok(turmas);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var turma = _repository.FindById(id);

            if(turma == null)
            return NotFound();

            return Ok(turma);
        }

        [HttpPost]
        public IActionResult Post(AddTurmaInputModel model)
        {
            var turma = new Turma(
                model.NumeroTurma,
                model.AnoLetivo
            );
            
            _repository.Add(turma);

            return CreatedAtAction("GetById",new { id = turma.Id}, turma);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, UpdateTurmaInputModel model)
        {
            var turma = _repository.FindById(id);            

            if(turma == null)
            return NotFound();           

            turma.Update(model.numeroTurma,model.anoLetivo);

            _repository.Update(turma);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var turma = _repository.FindById(id);

            if(turma == null)
            return NotFound("Turma Não Encontrada"); 

            bool existeAluno = _repository.VerificaExisteAlunoTurma(id); 

            if(existeAluno)
            return BadRequest("A Turma Possui Alunos, Não é Possível Deletar.");          

            _repository.Delete(turma);

            return NoContent();
        }

    }
}