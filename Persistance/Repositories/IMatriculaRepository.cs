using CursoIdiomas.API.Entities;

namespace CursoIdiomas.API.Persistance.Repositories
{
    public interface IMatriculaRepository
    {
        List<Matricula> GetAll();
         Matricula FindById(int id);
         void Delete(Matricula matricula);
         void Add(Matricula matricula);
    }
}