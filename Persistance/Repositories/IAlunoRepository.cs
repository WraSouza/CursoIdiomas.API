using CursoIdiomas.API.Entities;

namespace CursoIdiomas.API.Persistance.Repositories
{
    public interface IAlunoRepository
    {         
        List<Turma> GetTurmas();
        Turma GetTurmaById(int id);
         List<Aluno> GetAll();   
         Aluno FindById(int id);      
         void Add(Aluno aluno);
         void Update(Turma turma);  
         void UpdateAluno(Aluno aluno);          
         void DeleteAluno(Aluno aluno);
         int VerificarQtdeAluno(int id);
         void AddMatricula(Matricula matricula);
    }
}