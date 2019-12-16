using System.Threading.Tasks;
using project_school_API.Models;

namespace project_school_API.Data
{
    public interface IRepository
    {
         //Geral
         void Add<T>(T entity) where T:class;
         void Update<T>(T entity) where T:class;
         void Delete<T>(T entity)where T:class;
         Task<bool> SaveChangesAsync();

         //ALUNO
         Task<Aluno[]> GetAllAlunoAsync(bool includeProfessor);         
         Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor);
         Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeAluno);

         //PROFESSOR
         Task<Professor[]> GetAllProfessorAsync(bool includeAluno);
         Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno);
    }
}