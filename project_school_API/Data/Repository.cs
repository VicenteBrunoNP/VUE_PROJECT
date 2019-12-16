using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using project_school_API.Models;

namespace project_school_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }
        public Repository(DataContext context)
        {
            _context = context;

        }
        
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
 
        public void Update<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        //ALUNO

        public async Task<Aluno[]> GetAllAlunoAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query
                        .Include(a=>a.Professor);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeProfessor)
            {
                query = query
                        .Include(a=>a.Professor);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Where(a => a.Id == AlunoId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Aluno[]> GetAlunosAsyncByProfessorId(int ProfessorId, bool includeAluno)
        {
            IQueryable<Aluno> query = _context.Alunos;

            if(includeAluno)
            {
                query = query
                        .Include(a=>a.Professor);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Where(a => a.ProfessorId == ProfessorId);

            return await query.ToArrayAsync();
        }

        //PROFESSOR

        public async Task<Professor[]> GetAllProfessorAsync(bool includeAluno)
        {           
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query.Include(a=>a.Alunos);
            }

            query = query.AsNoTracking().OrderBy(a => a.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetProfessorAsyncById(int ProfessorId, bool includeAluno)
        {
            IQueryable<Professor> query = _context.Professores;

            if(includeAluno)
            {
                query = query
                        .Include(a=>a.Alunos);
            }

            query = query
                    .AsNoTracking()
                    .OrderBy(a => a.Id)
                    .Where(a => a.Id == ProfessorId);

            return await query.FirstOrDefaultAsync();
        }
    }
}