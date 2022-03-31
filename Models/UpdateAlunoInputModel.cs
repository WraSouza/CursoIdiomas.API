namespace CursoIdiomas.API.Models
{
    public record UpdateAlunoInputModel(string name, string cpf,string email, int turmaId)
    {
        
    }
}