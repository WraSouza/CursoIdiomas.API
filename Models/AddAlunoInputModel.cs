using CursoIdiomas.API.Entities;

namespace CursoIdiomas.API.Models
{
    
    public record AddAlunoInputModel(string name,string cpf,string email, int turmaId)
    {
        
    }    
}