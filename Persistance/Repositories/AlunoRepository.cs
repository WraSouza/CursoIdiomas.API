using CursoIdiomas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomas.API.Persistance.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly CursoIdiomasContext _context;

        public AlunoRepository(CursoIdiomasContext context)
        {
            _context = context;
        }

        public void Add(Aluno aluno)
        {
            int numeroMatricula = GerarMatricula();

            //Matricula novaMatricula = new Matricula(numeroMatricula,aluno,aluno.TurmaId);            

            _context.Alunos.Add(aluno);

            _context.SaveChanges();           
            
        }       

        public void AddMatricula(Matricula matricula)
        {     
            Aluno dadosAluno;
                   
            int numeroMatricula = GerarMatricula();                       
        }

        public int GerarMatricula()
        {
            Random numeroMatricula = new Random();
            return numeroMatricula.Next();
        }

        public void DeleteAluno(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        public List<Turma> GetTurmas()
        {
           return _context.Turmas.ToList();
        }

        public List<Aluno> GetAll()
        {
             return _context.Alunos.ToList();
        }

        public Turma GetTurmaById(int id)
        {   
            
            return _context.Turmas
            .Include( t => t.Alunos)
            .SingleOrDefault(t => t.Id == id);
            
        }

        public Aluno FindById(int id)
        {
            return _context.Alunos            
            .SingleOrDefault(a => a.Id == id);
        }

        public void Update(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        public void Update(Turma turma)
        {
            //throw new NotImplementedException();
            _context.Turmas.Update(turma);
        }

        public void UpdateAluno(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
            _context.SaveChanges();
        }

        public int VerificarQtdeAluno(int id)
        {
            Turma alunosTurma = GetTurmaById(id);
            int qtdeAlunos = alunosTurma.Alunos.Count();

            return qtdeAlunos;
        }
    }
}