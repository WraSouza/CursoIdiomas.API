using CursoIdiomas.API.Entities;

namespace CursoIdiomas.API.Persistance.Repositories
{
    public interface ITurmaRepositories
    {
         List<Turma> GetAll();          
         Turma FindById(int id);
         List<Aluno> GetAlunos();
         void Add(Turma turma);
         void Update(Turma turma);
         void AddAluno(Aluno aluno);
         void Delete(Turma turma);
         bool VerificaExisteAlunoTurma(int id);
         
    }
}