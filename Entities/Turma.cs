namespace CursoIdiomas.API.Entities
{
    public class Turma
    {
        public Turma(string numeroTurma, string anoLetivo)
        {
            NumeroTurma = numeroTurma;
            AnoLetivo = anoLetivo;
            Alunos = new List<Aluno>();
        }        

        public int Id { get; private set; }
        public string NumeroTurma { get; private set; }
        public string AnoLetivo { get; private set; }
        public List<Aluno> Alunos { get; private set; }

        public void Update(string numeroTurma, string anoLetivo)
        {
            NumeroTurma = numeroTurma;
            AnoLetivo = anoLetivo;            
        }

        public void UpdateTurma(string numeroTurma, string anoLetivo, Aluno aluno)
        {
            NumeroTurma = numeroTurma;
            AnoLetivo = anoLetivo; 
            Alunos.Add(aluno);
        }
        
        public void Delete(int id)
        {
            Id = id;
        }
        
    }
}