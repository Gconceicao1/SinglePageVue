using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using webapi.Models;

namespace webapi.Data
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
            _context.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()>0);
        }
        //Aluno
        public async Task<Aluno[]> GetAllAlunosAsync(bool includeProfessor = false)
        {
            IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor == true){
                query = query.Include(a => a.Professor);
                
            }
            query = query.AsNoTracking().OrderBy(a => a.Id);
            return await query.ToArrayAsync();
        }

        public async Task<Aluno[]> GetAlunoByProfessorId(int ProfessorId, bool includeProfessor = false)
        {
             IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor == true){
                query = query.Include(a => a.Professor);
                
            }
            query = query.AsNoTracking().OrderBy(a => a.Nome).Where(aluno => aluno.ProfessorId == ProfessorId);
            return await query.ToArrayAsync();
        }

        public async Task<Aluno> GetAlunoAsyncById(int AlunoId, bool includeProfessor = false)
        {
              IQueryable<Aluno> query = _context.Alunos;
            if(includeProfessor == true){
                query = query.Include(a => a.Professor);
                
            }
            query = query.AsNoTracking().OrderBy(a => a.Nome).Where(aluno => aluno.Id == AlunoId);
            return await query.FirstOrDefaultAsync();
        }
        //Professor
        public async Task<Professor[]> GetAllProfessorAsync(bool includeAluno = false)
        {
             IQueryable<Professor> query = _context.Professores;
            if(includeAluno == true){
                query = query.Include(p => p.Alunos);
                
            }
            query = query.AsNoTracking().OrderBy(p => p.Nome);
            return await query.ToArrayAsync();
        }

        public async Task<Professor> GetAProfessorAsyncById(int ProfessorId, bool includeAluno =false)
        {
            IQueryable<Professor> query = _context.Professores;
            if(includeAluno == true){
                query = query.Include(p => p.Alunos);
                
            }
            query = query.AsNoTracking().OrderBy(p => p.Nome).Where(Professor => Professor.Id == ProfessorId);
            return await query.FirstOrDefaultAsync();
        }
    }
}