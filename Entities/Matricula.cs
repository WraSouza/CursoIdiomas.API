namespace CursoIdiomas.API.Entities
{
    public class Matricula
    {
        /*
        public Matricula(int numeroMatricula,Aluno aluno, int turmaId)
        {
            NumeroMatricula = numeroMatricula;
            Aluno = aluno;
            Turmas.Add(turma);

        }
        */

        public int Id { get; private set; }
        public int NumeroMatricula { get; private set; }
        public Aluno Aluno { get; private set;}
        public List<Turma> Turmas { get; private set; }
    }
}