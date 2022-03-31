using CursoIdiomas.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace CursoIdiomas.API.Persistance.Repositories
{
    public class TurmaRepository : ITurmaRepositories
    {
        private readonly CursoIdiomasContext _context;

        public TurmaRepository(CursoIdiomasContext context)
        {
            _context = context;
        }

        public void Add(Turma turma)
        {
            _context.Turmas.Add(turma);

            _context.SaveChanges();
        }

        public void AddAluno(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
        }

        public void Delete(Turma turma)
        {
            _context.Turmas.Remove(turma);
            _context.SaveChanges();
        }

        public List<Turma> GetAll()
        {
            return _context.Turmas.ToList();
        }

        public List<Aluno> GetAlunos()
        {
            //throw new NotImplementedException();
            return _context.Alunos.ToList();
        }

        public Turma FindById(int id)
        {
            return _context.Turmas
            .Include( t => t.Alunos)
            .SingleOrDefault(t => t.Id == id);
        }

        public void Update(Turma turma)
        {
            _context.Turmas.Update(turma);
            _context.SaveChanges();
        }

        public Turma VerificaTurma(int id)
        {
            Turma TurmaExiste = FindById(id);

            return TurmaExiste;
        }

        public bool VerificaExisteAlunoTurma(int id)
        {
            Turma alunosPorTurma = FindById(id);
            if(alunosPorTurma.Alunos.Count > 0)
            {
                return true;
            }
            return false;
        }
    }
}