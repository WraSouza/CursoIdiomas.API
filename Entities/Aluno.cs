namespace CursoIdiomas.API.Entities
{
    public class Aluno
    {
        public Aluno(string name, string cPF, string email, int turmaId)
        {
            Name = name;
            CPF = cPF;
            Email = email;
            TurmaId = turmaId;
            //ListaTurmas = new List<Turma>();
        }

        public int Id { get; private set; }
        public string Name { get; private set; }        
        public string CPF { get; private set; }
        public string Email { get; private set; } 
        public int TurmaId{ get; private set;}   
        //public List<Turma> ListaTurmas { get; private set; }

        public void Update(string name, string cpf, string email, int turmaId)
        {
            Name = name;
            CPF = cpf;
            Email = email;
            TurmaId = turmaId;
            //ListaTurmas = new List<Turma>();
        }          
        
    }
}